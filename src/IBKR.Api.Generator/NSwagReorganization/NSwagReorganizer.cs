using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.TypeSystem;
using System.Text.RegularExpressions;

namespace IBKR.Api.Generator.NSwagReorganization;

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
        Console.WriteLine($"Output Base Directory: {Path.GetDirectoryName(_outputProjectDir)}\n");

        // Validate input
        if (!File.Exists(_tempNSwagAssemblyPath))
        {
            throw new FileNotFoundException($"Assembly not found: {_tempNSwagAssemblyPath}");
        }

        // Step 1: Define the 3 project directories
        var baseDir = Path.GetDirectoryName(_outputProjectDir)!;
        var contractDir = Path.Combine(baseDir, "IBKR.Api.NSwag.Contract");
        var httpClientDir = Path.Combine(baseDir, "IBKR.Api.NSwag.Client");
        var mockClientDir = Path.Combine(baseDir, "IBKR.Api.NSwag.MockClient");

        // Check if MockClient already exists (contains user code we should preserve)
        var mockClientExists = Directory.Exists(mockClientDir) &&
                               File.Exists(Path.Combine(mockClientDir, "IBKR.Api.NSwag.MockClient.csproj"));

        // Clean output directories (idempotent) - but preserve MockClient if it exists
        foreach (var dir in new[] { contractDir, httpClientDir })
        {
            if (Directory.Exists(dir))
            {
                Console.WriteLine($"Cleaning existing directory: {Path.GetFileName(dir)}...");
                Directory.Delete(dir, recursive: true);
            }
        }

        // Step 2: Create directory structure for Contract project
        Console.WriteLine("\n=== Creating Contract Project Structure ===");
        Directory.CreateDirectory(contractDir);
        var modelsDir = Directory.CreateDirectory(Path.Combine(contractDir, "Models")).FullName;
        var clientsDir = Directory.CreateDirectory(Path.Combine(contractDir, "Clients")).FullName;
        var helpersDir = Directory.CreateDirectory(Path.Combine(contractDir, "Helpers")).FullName;
        var interfacesDir = Directory.CreateDirectory(Path.Combine(contractDir, "Interfaces")).FullName;

        Console.WriteLine($"Contract project: {contractDir}");
        Console.WriteLine($"  • Models/");
        Console.WriteLine($"  • Clients/");
        Console.WriteLine($"  • Helpers/");
        Console.WriteLine($"  • Interfaces/");

        // Step 3: Create directory structure for Client project
        Console.WriteLine("\n=== Creating Client Project Structure ===");
        Directory.CreateDirectory(httpClientDir);
        var servicesDir = Directory.CreateDirectory(Path.Combine(httpClientDir, "Services")).FullName;
        Console.WriteLine($"Client project: {httpClientDir}");
        Console.WriteLine($"  • Services/");

        // Step 4: Create directory structure for MockClient project (only if it doesn't exist)
        string mockServicesDir;
        if (!mockClientExists)
        {
            Console.WriteLine("\n=== Creating MockClient Project Structure ===");
            Directory.CreateDirectory(mockClientDir);
            mockServicesDir = Directory.CreateDirectory(Path.Combine(mockClientDir, "Services")).FullName;
            Console.WriteLine($"MockClient project: {mockClientDir}");
            Console.WriteLine($"  • Services/\n");
        }
        else
        {
            Console.WriteLine("\n=== MockClient Project Already Exists ===");
            Console.WriteLine($"Preserving existing MockClient project with user code");
            Console.WriteLine($"MockClient project: {mockClientDir}\n");
            mockServicesDir = Path.Combine(mockClientDir, "Services");
        }

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

        // Step 7: Split interfaces into service-based interfaces (into Contract project)
        Console.WriteLine("\n=== Splitting monolithic interface into service interfaces ===");
        var sourceInterface = Path.Combine(clientsDir, "IIBKRClient.cs");
        var splitter = new InterfaceSplitter(sourceInterface, interfacesDir);
        await splitter.SplitInterfaces();

        // Step 8: Generate service implementation classes (into Client project)
        Console.WriteLine("\n=== Generating service implementation classes ===");
        var sourceClient = Path.Combine(clientsDir, "IBKRClient.cs");
        var serviceGenerator = new ServiceImplementationGenerator(sourceClient, interfacesDir, servicesDir);
        await serviceGenerator.GenerateServiceImplementations();

        // Step 9: Delete old monolithic client files from Clients/ folder (they're now in Client/Services/)
        Console.WriteLine("\nRemoving old monolithic client files from Contract/Clients/...");
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

        // Step 10: Create project files for all 3 projects
        Console.WriteLine("\n=== Creating project files ===");
        await CreateContractProjectFile(contractDir);
        await CreateClientProjectFile(httpClientDir);
        if (!mockClientExists)
        {
            await CreateMockClientProjectFile(mockClientDir);
        }

        // Step 11: Update namespaces to match folder structure
        Console.WriteLine("\n=== Updating namespaces ===");
        await UpdateNamespacesForProject(contractDir, "IBKR.Api.NSwag.Contract");
        await UpdateNamespacesForProject(httpClientDir, "IBKR.Api.NSwag.Client");
        if (!mockClientExists)
        {
            await UpdateNamespacesForProject(mockClientDir, "IBKR.Api.NSwag.MockClient");
        }

        Console.WriteLine($"\n✅ Success! Created 3 projects:");
        Console.WriteLine($"   Contract: {contractDir}");
        Console.WriteLine($"   Client: {httpClientDir}");
        Console.WriteLine($"   MockClient: {mockClientDir}");
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

    private static async Task CreateContractProjectFile(string projectDir)
    {
        var projectFile = Path.Combine(projectDir, "IBKR.Api.NSwag.Contract.csproj");

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

    private static async Task CreateClientProjectFile(string projectDir)
    {
        var projectFile = Path.Combine(projectDir, "IBKR.Api.NSwag.Client.csproj");
        var contractDir = Path.Combine(Path.GetDirectoryName(projectDir)!, "IBKR.Api.NSwag.Contract", "IBKR.Api.NSwag.Contract.csproj");

        var content = @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Newtonsoft.Json"" Version=""13.0.4"" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include=""..\IBKR.Api.NSwag.Contract\IBKR.Api.NSwag.Contract.csproj"" />
  </ItemGroup>

</Project>
";

        await File.WriteAllTextAsync(projectFile, content);
        Console.WriteLine($"  ✓ Created {Path.GetFileName(projectFile)}");
    }

    private static async Task CreateMockClientProjectFile(string projectDir)
    {
        var projectFile = Path.Combine(projectDir, "IBKR.Api.NSwag.MockClient.csproj");

        var content = @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include=""..\IBKR.Api.NSwag.Contract\IBKR.Api.NSwag.Contract.csproj"" />
  </ItemGroup>

</Project>
";

        await File.WriteAllTextAsync(projectFile, content);
        Console.WriteLine($"  ✓ Created {Path.GetFileName(projectFile)}");
    }

    private static async Task UpdateNamespacesForProject(string projectDir, string baseNamespace)
    {
        var folders = new[]
        {
            "Models",
            "Services",
            "Interfaces",
            "Clients",
            "Helpers"
        };

        int filesUpdated = 0;

        foreach (var folder in folders)
        {
            var folderPath = Path.Combine(projectDir, folder);
            if (!Directory.Exists(folderPath))
                continue;

            var files = Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var content = await File.ReadAllTextAsync(file);
                var originalContent = content;

                // Determine target namespace based on folder
                var targetNamespace = folder switch
                {
                    "Models" => $"{baseNamespace}.Models",
                    "Services" => $"{baseNamespace}.Services",
                    "Interfaces" => $"{baseNamespace}.Interfaces",
                    "Clients" => $"{baseNamespace}.Clients",
                    "Helpers" => $"{baseNamespace}.Helpers",
                    _ => baseNamespace
                };

                // Update namespace declaration
                content = Regex.Replace(
                    content,
                    @"namespace\s+IBKR\.Api(?:\.V2\.Generated)?\.NSwag(?:\.Temp)?(?:\.[\w\.]+)?\s*[;{]",
                    $"namespace {targetNamespace};",
                    RegexOptions.Multiline
                );

                // Add using directives for cross-namespace references
                content = AddUsingDirectivesForProject(content, folder, baseNamespace);

                if (content != originalContent)
                {
                    await File.WriteAllTextAsync(file, content);
                    filesUpdated++;
                }
            }
        }

        Console.WriteLine($"  ✓ Updated {filesUpdated} files in {Path.GetFileName(projectDir)}");
    }

    private static string AddUsingDirectivesForProject(string content, string folder, string baseNamespace)
    {
        var usingsToAdd = new List<string>();

        // Services and Interfaces need Models and Interfaces (from Contract project)
        if (folder == "Services")
        {
            usingsToAdd.Add("using IBKR.Api.NSwag.Contract.Models;");
            usingsToAdd.Add("using IBKR.Api.NSwag.Contract.Interfaces;");
        }

        if (folder == "Interfaces")
        {
            usingsToAdd.Add("using IBKR.Api.NSwag.Contract.Models;");
        }

        // Helpers need Models
        if (folder == "Helpers")
        {
            usingsToAdd.Add($"using {baseNamespace}.Models;");
        }

        // Clients need Models (for nested types)
        if (folder == "Clients")
        {
            usingsToAdd.Add($"using {baseNamespace}.Models;");
        }

        // Models need Helpers for JsonInheritanceConverter and DateFormatConverter
        if (folder == "Models")
        {
            if (content.Contains("JsonInheritanceConverter") || content.Contains("DateFormatConverter"))
            {
                usingsToAdd.Add($"using {baseNamespace}.Helpers;");
            }
        }

        if (usingsToAdd.Count == 0)
            return content;

        // Find where to insert usings
        var namespaceMatch = Regex.Match(content, @"^namespace\s+", RegexOptions.Multiline);
        if (!namespaceMatch.Success)
            return content;

        var lastUsingMatch = Regex.Matches(content.Substring(0, namespaceMatch.Index), @"^using\s+.*?;", RegexOptions.Multiline)
            .Cast<Match>()
            .LastOrDefault();

        int insertPosition;
        string insertText;

        if (lastUsingMatch != null)
        {
            insertPosition = lastUsingMatch.Index + lastUsingMatch.Length;
            insertText = "\n" + string.Join("\n", usingsToAdd);
        }
        else
        {
            insertPosition = namespaceMatch.Index;
            insertText = string.Join("\n", usingsToAdd) + "\n\n";
        }

        // Check if usings already exist
        foreach (var usingDirective in usingsToAdd.ToList())
        {
            if (content.Contains(usingDirective))
            {
                usingsToAdd.Remove(usingDirective);
            }
        }

        if (usingsToAdd.Count == 0)
            return content;

        // Rebuild insert text
        if (lastUsingMatch != null)
        {
            insertText = "\n" + string.Join("\n", usingsToAdd);
        }
        else
        {
            insertText = string.Join("\n", usingsToAdd) + "\n\n";
        }

        return content.Insert(insertPosition, insertText);
    }
}
