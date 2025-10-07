using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.TypeSystem;

namespace IBKR.Api.V2.NSwag.Reorganizer;

class Program
{
    static async Task<int> Main(string[] args)
    {
        try
        {
            Console.WriteLine("=== IBKR NSwag Assembly Reorganizer ===\n");

            // Paths
            var solutionDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", ".."));
            var nswagProjectDir = Path.Combine(solutionDir, "src", "IBKR.Api.V2.Generated.NSwag");
            var assemblyPath = Path.Combine(nswagProjectDir, "bin", "Debug", "net8.0", "IBKR.Api.V2.Generated.NSwag.dll");
            var outputProjectDir = Path.Combine(solutionDir, "src", "IBKR.Api.V2.Generated.NSwag.Organized");

            // Validate input
            if (!File.Exists(assemblyPath))
            {
                Console.WriteLine($"❌ Assembly not found: {assemblyPath}");
                Console.WriteLine("   Build IBKR.Api.V2.Generated.NSwag project first!");
                return 1;
            }

            Console.WriteLine($"Input Assembly: {Path.GetFileName(assemblyPath)}");
            Console.WriteLine($"Output Directory: {outputProjectDir}\n");

            // Step 1: Clean output directory (idempotent)
            if (Directory.Exists(outputProjectDir))
            {
                Console.WriteLine("Cleaning existing output directory...");
                Directory.Delete(outputProjectDir, recursive: true);
            }

            // Step 2: Create directory structure
            Directory.CreateDirectory(outputProjectDir);
            var modelsDir = Directory.CreateDirectory(Path.Combine(outputProjectDir, "Models")).FullName;
            var clientsDir = Directory.CreateDirectory(Path.Combine(outputProjectDir, "Clients")).FullName;
            var helpersDir = Directory.CreateDirectory(Path.Combine(outputProjectDir, "Helpers")).FullName;

            Console.WriteLine("Created directory structure:");
            Console.WriteLine($"  • {Path.GetFileName(modelsDir)}/");
            Console.WriteLine($"  • {Path.GetFileName(clientsDir)}/");
            Console.WriteLine($"  • {Path.GetFileName(helpersDir)}/\n");

            // Step 3: Initialize decompiler
            Console.WriteLine("Initializing decompiler...");
            var decompiler = new CSharpDecompiler(assemblyPath, new DecompilerSettings
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
            Console.WriteLine($"Found {lowercaseTypes.Count} types with lowercase names to fix\\n");

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

            // Step 5: Create project file
            Console.WriteLine("Creating project file...");
            await CreateProjectFile(outputProjectDir);

            Console.WriteLine($"\n✅ Success! Organized project created at:");
            Console.WriteLine($"   {outputProjectDir}");

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Error: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
            return 1;
        }
    }

    static bool IsClientType(ITypeDefinition type)
    {
        return type.Name.Contains("Client") && type.Accessibility == Accessibility.Public;
    }

    static bool IsHelperType(ITypeDefinition type)
    {
        // Helper types are typically internal or private, or have specific patterns
        return type.Name.Contains("Converter") ||
               type.Name.Contains("ObjectResponseResult") ||
               type.Accessibility != Accessibility.Public;
    }

    static string FixAllLowercaseTypes(string code, Dictionary<string, string> lowercaseTypes)
    {
        // Fix all lowercase type names throughout the code
        foreach (var kvp in lowercaseTypes)
        {
            var lowercaseName = kvp.Key;
            var properName = kvp.Value;

            // Replace all occurrences of the lowercase type name with proper case
            // Use word boundaries to avoid partial matches
            code = System.Text.RegularExpressions.Regex.Replace(
                code,
                $@"\b{System.Text.RegularExpressions.Regex.Escape(lowercaseName)}\b",
                properName);
        }

        return code;
    }

    static string SanitizeFileName(string fileName)
    {
        // Remove invalid file name characters
        foreach (var c in Path.GetInvalidFileNameChars())
        {
            fileName = fileName.Replace(c, '_');
        }
        return fileName;
    }

    static async Task CreateProjectFile(string projectDir)
    {
        var projectFile = Path.Combine(projectDir, "IBKR.Api.V2.Generated.NSwag.Organized.csproj");

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
