using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.TypeSystem;
using System.Text.RegularExpressions;

namespace IBKR.Api.V2.Generator.NSwagReorganization;

/// <summary>
/// Reorganizes the monolithic NSwag-generated client into a clean service-oriented architecture
/// </summary>
public class NSwagReorganizer
{
    private readonly string _tempNSwagAssemblyPath;
    private readonly string _outputProjectDir;

    public NSwagReorganizer(string tempNSwagAssemblyPath, string outputProjectDir)
    {
        _tempNSwagAssemblyPath = tempNSwagAssemblyPath;
        _outputProjectDir = outputProjectDir;
    }

    public async Task ReorganizeAsync()
    {
        Console.WriteLine("\n=== IBKR NSwag Reorganizer ===\n");
        Console.WriteLine($"Input Assembly: {Path.GetFileName(_tempNSwagAssemblyPath)}");
        Console.WriteLine($"Output Directory: {_outputProjectDir}\n");

        // Validate input
        if (!File.Exists(_tempNSwagAssemblyPath))
        {
            throw new FileNotFoundException($"Assembly not found: {_tempNSwagAssemblyPath}");
        }

        // Step 1: Clean output directory (idempotent)
        if (Directory.Exists(_outputProjectDir))
        {
            Console.WriteLine("Cleaning existing output directory...");
            Directory.Delete(_outputProjectDir, recursive: true);
        }

        // Step 2: Create directory structure
        Directory.CreateDirectory(_outputProjectDir);
        var modelsDir = Directory.CreateDirectory(Path.Combine(_outputProjectDir, "Models")).FullName;
        var clientsDir = Directory.CreateDirectory(Path.Combine(_outputProjectDir, "Clients")).FullName;
        var helpersDir = Directory.CreateDirectory(Path.Combine(_outputProjectDir, "Helpers")).FullName;

        Console.WriteLine("Created directory structure:");
        Console.WriteLine($"  • {Path.GetFileName(modelsDir)}/");
        Console.WriteLine($"  • {Path.GetFileName(clientsDir)}/");
        Console.WriteLine($"  • {Path.GetFileName(helpersDir)}/\n");

        // Step 3: Initialize decompiler
        Console.WriteLine("Initializing decompiler...");
        var decompiler = new CSharpDecompiler(_tempNSwagAssemblyPath, new DecompilerSettings
        {
            ThrowOnAssemblyResolveErrors = false
        });

        Console.WriteLine($"✓ Loaded assembly: {decompiler.TypeSystem.MainModule.AssemblyName}\n");

        // Step 4: Collect all lowercase type names first
        Console.WriteLine("Analyzing type names...");
        var lowercaseTypes = new Dictionary<string, string>(); // lowercase -> ProperCase
        foreach (var typeDefinition in decompiler.TypeSystem.MainModule.TypeDefinitions)
        {
            if (typeDefinition.Name.Contains("<") || typeDefinition.Name.Contains("__"))
                continue;

            if (char.IsLower(typeDefinition.Name[0]))
            {
                var properName = char.ToUpper(typeDefinition.Name[0]) + typeDefinition.Name.Substring(1);
                lowercaseTypes[typeDefinition.Name] = properName;
            }
        }
        Console.WriteLine($"Found {lowercaseTypes.Count} types with lowercase names to fix\n");

        // Step 5: Decompile each type (process properly-cased types first to avoid overwriting)
        Console.WriteLine("Decompiling types...");
        int modelsCount = 0;
        int clientsCount = 0;
        int helpersCount = 0;
        int skipped = 0;

        var allTypes = decompiler.TypeSystem.MainModule.TypeDefinitions
            .Where(t => !t.Name.Contains("<") && !t.Name.Contains("__"))
            .OrderBy(t => char.IsLower(t.Name[0]) ? 1 : 0) // Properly-cased types first
            .ThenBy(t => t.Name); // Then alphabetical

        foreach (var typeDefinition in allTypes)
        {
            try
            {
                // Decompile the type
                var fullTypeName = new FullTypeName(typeDefinition.FullName);
                var code = decompiler.DecompileTypeAsString(fullTypeName);

                // Fix all lowercase type references
                code = FixAllLowercaseTypes(code, lowercaseTypes);

                // Fix specific known case issues
                code = code.Replace("public Accounttype ", "public AccountType? ");

                // Determine output folder
                string folder;
                if (IsClientType(typeDefinition))
                {
                    folder = clientsDir;
                    clientsCount++;
                }
                else if (IsHelperType(typeDefinition))
                {
                    folder = helpersDir;
                    helpersCount++;
                }
                else
                {
                    folder = modelsDir;
                    modelsCount++;
                }

                // Write to file - use exact type name, overwrite if exists
                var fileName = $"{SanitizeFileName(typeDefinition.Name)}.cs";
                var filePath = Path.Combine(folder, fileName);
                await File.WriteAllTextAsync(filePath, code);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  ⚠ Failed to decompile {typeDefinition.Name}: {ex.Message}");
                skipped++;
            }
        }

        Console.WriteLine($"\n✓ Decompilation complete!");
        Console.WriteLine($"  • Models: {modelsCount} files");
        Console.WriteLine($"  • Clients: {clientsCount} files");
        Console.WriteLine($"  • Helpers: {helpersCount} files");
        Console.WriteLine($"  • Skipped: {skipped} types\n");

        // Step 6: Fix ApiException to add generic version
        Console.WriteLine("Fixing ApiException...");
        await FixApiException(modelsDir);

        // Step 7: Create project file
        Console.WriteLine("Creating project file...");
        await CreateProjectFile(_outputProjectDir);

        // Step 8: Split interfaces into service-based interfaces
        Console.WriteLine("\nSplitting monolithic interface into service interfaces...");
        var interfacesDir = Path.Combine(_outputProjectDir, "Interfaces");
        var sourceInterface = Path.Combine(_outputProjectDir, "Clients", "IIBKRClient.cs");

        var splitter = new InterfaceSplitter(sourceInterface, interfacesDir);
        await splitter.SplitInterfaces();

        // Step 9: Generate service implementation classes (BEFORE deleting the source files)
        Console.WriteLine("\nGenerating service implementation classes...");
        var servicesDir = Path.Combine(_outputProjectDir, "Services");
        var sourceClient = Path.Combine(_outputProjectDir, "Clients", "IBKRClient.cs");

        var serviceGenerator = new ServiceImplementationGenerator(sourceClient, interfacesDir, servicesDir);
        await serviceGenerator.GenerateServiceImplementations();

        // Step 10: Delete old monolithic client files from Clients/ folder (they're now in Services/)
        Console.WriteLine("\nRemoving old monolithic client files from Clients/...");
        var oldClientFile = Path.Combine(clientsDir, "IBKRClient.cs");
        var oldInterfaceFile = Path.Combine(clientsDir, "IIBKRClient.cs");
        if (File.Exists(oldClientFile))
        {
            File.Delete(oldClientFile);
            Console.WriteLine($"  ✓ Deleted {Path.GetFileName(oldClientFile)}");
        }
        if (File.Exists(oldInterfaceFile))
        {
            File.Delete(oldInterfaceFile);
            Console.WriteLine($"  ✓ Deleted {Path.GetFileName(oldInterfaceFile)}");
        }

        // Step 11: Update namespaces to match folder structure
        Console.WriteLine("\nUpdating namespaces to match folder structure...");
        var namespaceUpdater = new NamespaceUpdater(_outputProjectDir);
        await namespaceUpdater.UpdateNamespaces();

        Console.WriteLine($"\n✅ Success! Organized project created at:");
        Console.WriteLine($"   {_outputProjectDir}");
        Console.WriteLine($"   Interfaces: {interfacesDir}");
        Console.WriteLine($"   Services: {servicesDir}");
    }

    private static bool IsClientType(ITypeDefinition type)
    {
        return type.Name.Contains("Client") && type.Accessibility == Accessibility.Public;
    }

    private static bool IsHelperType(ITypeDefinition type)
    {
        // Helper types are typically internal or private, or have specific patterns
        return type.Name.Contains("Converter") ||
               type.Name.Contains("ObjectResponseResult") ||
               type.Accessibility != Accessibility.Public;
    }

    private static string FixAllLowercaseTypes(string code, Dictionary<string, string> lowercaseTypes)
    {
        // Fix all lowercase type names throughout the code
        foreach (var kvp in lowercaseTypes)
        {
            var lowercaseName = kvp.Key;
            var properName = kvp.Value;

            // Replace all occurrences of the lowercase type name with proper case
            // Use word boundaries to avoid partial matches
            code = Regex.Replace(
                code,
                $@"\b{Regex.Escape(lowercaseName)}\b",
                properName);
        }

        return code;
    }

    private static string SanitizeFileName(string fileName)
    {
        // Remove invalid file name characters
        foreach (var c in Path.GetInvalidFileNameChars())
        {
            fileName = fileName.Replace(c, '_');
        }
        return fileName;
    }

    private static async Task FixApiException(string modelsDir)
    {
        var apiExceptionPath = Path.Combine(modelsDir, "ApiException.cs");
        if (!File.Exists(apiExceptionPath))
        {
            Console.WriteLine("  ⚠ ApiException.cs not found, skipping");
            return;
        }

        var content = await File.ReadAllTextAsync(apiExceptionPath);

        // Check if generic version already exists
        if (content.Contains("ApiException<TResult>"))
        {
            Console.WriteLine("  ✓ ApiException already has generic version");
            return;
        }

        // Add generic version after the non-generic class (after its closing brace)
        var genericVersion = @"
[GeneratedCode(""NSwag"", ""14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))"")]
public partial class ApiException<TResult> : ApiException
{
	public TResult Result { get; private set; }

	public ApiException(string message, int statusCode, string? response, IReadOnlyDictionary<string, IEnumerable<string>> headers, TResult result, Exception? innerException)
		: base(message, statusCode, response, headers, innerException)
	{
		Result = result;
	}
}
";

        // Find the end of the non-generic ApiException class (look for "public class ApiException" then find its closing brace)
        var classStart = content.IndexOf("public class ApiException : Exception");
        if (classStart > 0)
        {
            // Count braces to find the matching closing brace
            int braceDepth = 0;
            int classBodyStart = content.IndexOf('{', classStart);
            if (classBodyStart > 0)
            {
                for (int i = classBodyStart; i < content.Length; i++)
                {
                    if (content[i] == '{') braceDepth++;
                    else if (content[i] == '}')
                    {
                        braceDepth--;
                        if (braceDepth == 0)
                        {
                            // Found the closing brace of the class, insert after it
                            content = content.Insert(i + 1, genericVersion);
                            await File.WriteAllTextAsync(apiExceptionPath, content);
                            Console.WriteLine("  ✓ Added generic ApiException<TResult>");
                            return;
                        }
                    }
                }
            }
        }
        Console.WriteLine("  ⚠ Could not find proper location to insert generic ApiException");
    }

    private static async Task CreateProjectFile(string projectDir)
    {
        var projectFile = Path.Combine(projectDir, "IBKR.Api.V2.Generated.NSwag.csproj");

        var content = @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Newtonsoft.Json"" Version=""13.0.4"" />
  </ItemGroup>

</Project>
";

        await File.WriteAllTextAsync(projectFile, content);
        Console.WriteLine($"  ✓ Created {Path.GetFileName(projectFile)}");
    }
}
