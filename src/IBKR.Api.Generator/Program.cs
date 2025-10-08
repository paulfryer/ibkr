using NSwag;
using NSwag.CodeGeneration.CSharp;
using Microsoft.OpenApi.Readers;
using System.Diagnostics;

namespace IBKR.Api.Generator;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== IBKR OpenAPI Code Generator Test Harness ===\n");

        // Path to the original unformatted OpenAPI spec from IBKR website
        var specPath = Path.Combine(AppContext.BaseDirectory, "source-spec", "api-docs.json");

        if (!File.Exists(specPath))
        {
            Console.WriteLine($"ERROR: OpenAPI spec not found at: {specPath}");
            Console.WriteLine($"Current directory: {Directory.GetCurrentDirectory()}");
            return;
        }

        var fileInfo = new FileInfo(specPath);
        Console.WriteLine($"✓ Found OpenAPI spec: {specPath}");
        Console.WriteLine($"  File size: {fileInfo.Length / 1024.0:F1} KB");
        Console.WriteLine($"  Last modified: {fileInfo.LastWriteTime}\n");

        Console.WriteLine("Select generator to test:");
        Console.WriteLine("0. All (Generate both Kiota and NSwag)");
        Console.WriteLine("1. Kiota (Microsoft's modern generator)");
        Console.WriteLine("2. NSwag (CSharp client)");
        Console.WriteLine("3. Microsoft OpenApi Reader (Parse & Analyze)");
        Console.Write("\nChoice (0-3): ");

        var choice = Console.ReadLine();

        try
        {
            switch (choice)
            {
                case "0":
                    Console.WriteLine("\n=== Generating Both SDKs ===\n");
                    await GenerateWithKiota(specPath);
                    Console.WriteLine("\n" + new string('=', 80) + "\n");
                    await GenerateWithNSwag(specPath);
                    break;
                case "1":
                    await GenerateWithKiota(specPath);
                    break;
                case "2":
                    await GenerateWithNSwag(specPath);
                    break;
                case "3":
                    await TestOpenApiReader(specPath);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("\n=== Generation Complete ===");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ ERROR: {ex.Message}");
            Console.WriteLine($"Stack trace:\n{ex.StackTrace}");
        }
    }

    static async Task GenerateWithKiota(string specPath)
    {
        Console.WriteLine("\n--- Generating with Kiota ---");
        var generatorName = "Kiota";
        var projectName = $"IBKR.Api.{generatorName}";

        var solutionDir = GetSolutionDirectory();
        // Output to src/Kiota/ subfolder to match NSwag structure
        var projectDir = Path.Combine(solutionDir, "src", generatorName, projectName);
        var projectFile = Path.Combine(projectDir, $"{projectName}.csproj");
        var solutionFile = Path.Combine(solutionDir, "src", "IBKR.Api.sln");

        // Step 1: Remove from solution if exists
        if (File.Exists(projectFile))
        {
            Console.WriteLine($"Removing existing project from solution: {projectName}");
            var removeResult = await RunCommand("dotnet", $"sln \"{solutionFile}\" remove \"{projectFile}\"", solutionDir);
            Console.WriteLine(removeResult);
        }

        // Step 2: Delete project directory if exists
        if (Directory.Exists(projectDir))
        {
            Console.WriteLine($"Deleting existing project directory: {projectDir}");
            Directory.Delete(projectDir, recursive: true);
            await Task.Delay(500); // Give filesystem time to settle
        }

        // Step 3: Load and fix OpenAPI spec
        Console.WriteLine($"Loading OpenAPI spec from: {specPath}");
        var reader = new OpenApiStreamReader();
        Microsoft.OpenApi.Models.OpenApiDocument msDocument;
        OpenApiDiagnostic diagnostic;

        using (var stream = File.OpenRead(specPath))
        {
            msDocument = reader.Read(stream, out diagnostic);
        }

        Console.WriteLine($"  Loaded: {msDocument.Info.Title} v{msDocument.Info.Version}");
        Console.WriteLine($"  Paths: {msDocument.Paths.Count}, Schemas: {msDocument.Components?.Schemas?.Count ?? 0}");

        if (diagnostic.Errors.Any())
        {
            Console.WriteLine($"  ⚠ OpenAPI has {diagnostic.Errors.Count} validation errors (will be fixed)");
        }

        // Apply Kiota-specific fixes
        var fixer = new KiotaSpecFixer(msDocument);
        fixer.ApplyAllFixes();

        // Save fixed spec to temp file
        var fixedSpecPath = Path.Combine(Path.GetDirectoryName(specPath)!, "api-docs.fixed.json");
        Console.WriteLine($"Saving fixed spec to: {fixedSpecPath}");

        using (var stream = File.Create(fixedSpecPath))
        {
            var writer = new Microsoft.OpenApi.Writers.OpenApiJsonWriter(new StreamWriter(stream));
            msDocument.SerializeAsV3(writer);
            writer.Flush();
        }

        Console.WriteLine("  ✓ Fixed spec saved\n");

        // Step 4: Create new project
        Console.WriteLine($"Creating new project: {projectName}");
        var createResult = await RunCommand("dotnet", $"new classlib -n {projectName} -o \"{projectDir}\" -f net8.0", solutionDir);
        Console.WriteLine(createResult);

        // Note: We don't add the temp project to the solution - the reorganizer will add Contract/Client instead

        // Step 5: Delete default Class1.cs
        var class1Path = Path.Combine(projectDir, "Class1.cs");
        if (File.Exists(class1Path))
        {
            File.Delete(class1Path);
        }

        // Step 6: Run Kiota generation with FIXED spec and VALIDATION ENABLED
        Console.WriteLine($"Running Kiota code generation with fixed spec (validation enabled)...");
        var kiotaResult = await RunCommand("kiota",
            $"generate --language CSharp --openapi \"{fixedSpecPath}\" --output . --class-name IBKRClient --namespace-name {projectName} --clean-output",
            projectDir);
        Console.WriteLine(kiotaResult);

        // Step 7: Create .csproj with dependencies
        Console.WriteLine($"Adding Kiota dependencies to project...");
        var csprojContent = @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.Kiota.Authentication.Azure"" Version=""1.19.0"" />
    <PackageReference Include=""Microsoft.Kiota.Bundle"" Version=""1.19.0"" />
  </ItemGroup>

</Project>
";
        await File.WriteAllTextAsync(projectFile, csprojContent);

        // Step 8: Build the project
        Console.WriteLine($"Building project...");
        var buildResult = await RunCommand("dotnet", $"build \"{projectFile}\"", solutionDir);
        Console.WriteLine(buildResult);

        // Step 9: Reorganize into 2-project structure (Contract, Client)
        Console.WriteLine($"\nReorganizing Kiota project into 2-project structure...");
        var reorganizer = new KiotaReorganization.KiotaReorganizer(projectDir, solutionDir);
        reorganizer.Reorganize();

        Console.WriteLine($"\n✓ {generatorName} generation complete!");
        Console.WriteLine($"  Contract: {Path.Combine(solutionDir, "src", generatorName, "IBKR.Api.Kiota.Contract")}");
        Console.WriteLine($"  Client: {Path.Combine(solutionDir, "src", generatorName, "IBKR.Api.Kiota.Client")}");
        Console.WriteLine($"  MockClient: {Path.Combine(solutionDir, "src", generatorName, "IBKR.Api.Kiota.MockClient")}");
    }

    static async Task GenerateWithNSwag(string specPath)
    {
        Console.WriteLine("\n--- Generating with NSwag ---");
        var generatorName = "NSwag";
        var projectName = $"IBKR.Api.{generatorName}";

        var solutionDir = GetSolutionDirectory();
        // Output to src/{GeneratorName}/ subfolder (e.g., src/NSwag/, src/Kiota/)
        var finalProjectDir = Path.Combine(solutionDir, "src", generatorName, projectName);
        var solutionFile = Path.Combine(solutionDir, "src", "IBKR.Api.sln");

        // Step 1: Generate raw NSwag code to temp directory (in bin/temp/ to avoid source control)
        var tempProjectName = $"{projectName}.Temp";
        var tempBaseDir = Path.Combine(solutionDir, "bin", "temp");
        var tempProjectDir = Path.Combine(tempBaseDir, tempProjectName);
        var tempProjectFile = Path.Combine(tempProjectDir, $"{tempProjectName}.csproj");

        // Clean entire bin/temp directory if exists
        if (Directory.Exists(tempBaseDir))
        {
            Console.WriteLine($"Cleaning temp directory: {tempBaseDir}");
            try
            {
                Directory.Delete(tempBaseDir, recursive: true);
                await Task.Delay(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  ⚠ Warning: Could not fully clean temp directory: {ex.Message}");
            }
        }

        // Create temp project
        Console.WriteLine($"Creating temp project: {tempProjectDir}");
        Directory.CreateDirectory(tempProjectDir);

        // Step 2: Generate raw NSwag code to temp directory
        Console.WriteLine($"Generating raw NSwag code to temp directory...");
        await TestNSwagGenerator(specPath, tempProjectDir);

        // Step 3: Create temp project file
        Console.WriteLine($"Creating temp project file...");
        var tempCsprojContent = @"<Project Sdk=""Microsoft.NET.Sdk"">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include=""Newtonsoft.Json"" Version=""13.0.4"" />
  </ItemGroup>
</Project>";
        await File.WriteAllTextAsync(tempProjectFile, tempCsprojContent);

        // Step 4: Apply NSwag-specific post-generation fixes to temp
        Console.WriteLine($"Applying NSwag fixes...");
        var projectFixer = new NSwagProjectFixer(tempProjectDir, tempProjectFile);
        await projectFixer.ApplyAllFixes();

        // Step 5: Build the temp project
        Console.WriteLine($"\nBuilding temp project...");
        var buildResult = await RunCommand("dotnet", $"build \"{tempProjectFile}\"", solutionDir);
        Console.WriteLine(buildResult);

        // Verify build succeeded
        var tempAssemblyPath = Path.Combine(tempProjectDir, "bin", "Debug", "net8.0", $"{tempProjectName}.dll");
        if (!File.Exists(tempAssemblyPath))
        {
            throw new FileNotFoundException($"Temp assembly not found after build: {tempAssemblyPath}");
        }

        Console.WriteLine($"✓ Temp assembly built: {tempAssemblyPath}");

        // Step 5: Run reorganizer on temp assembly -> final project directory
        Console.WriteLine($"\nReorganizing temp assembly into final project...");
        var reorganizer = new IBKR.Api.Generator.NSwagReorganization.NSwagReorganizer(tempAssemblyPath, finalProjectDir);
        await reorganizer.ReorganizeAsync();

        // Step 6: Clean up temp directory
        Console.WriteLine($"\nCleaning up temp directory...");
        try
        {
            Directory.Delete(tempBaseDir, recursive: true);
            Console.WriteLine($"  ✓ Deleted {tempBaseDir}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  ⚠ Warning: Could not delete temp directory: {ex.Message}");
            Console.WriteLine($"  You can manually delete: {tempBaseDir}");
        }

        // Step 7: Add Contract and Client projects to solution if not already there
        var contractProjectFile = Path.Combine(Path.GetDirectoryName(finalProjectDir)!, "IBKR.Api.NSwag.Contract", "IBKR.Api.NSwag.Contract.csproj");
        var httpClientProjectFile = Path.Combine(Path.GetDirectoryName(finalProjectDir)!, "IBKR.Api.NSwag.Client", "IBKR.Api.NSwag.Client.csproj");

        var projectFiles = new[]
        {
            (contractProjectFile, "IBKR.Api.NSwag.Contract"),
            (httpClientProjectFile, "IBKR.Api.NSwag.Client")
        };

        Console.WriteLine($"\nAdding projects to solution...");
        var slnContent = await File.ReadAllTextAsync(solutionFile);

        foreach (var (projFile, projName) in projectFiles)
        {
            if (!File.Exists(projFile))
            {
                throw new FileNotFoundException($"Project file not created: {projFile}");
            }

            if (!slnContent.Contains(projName))
            {
                Console.WriteLine($"  Adding {projName}...");
                var addProjResult = await RunCommand("dotnet", $"sln \"{solutionFile}\" add \"{projFile}\"", solutionDir);
                Console.WriteLine(addProjResult);
            }
            else
            {
                Console.WriteLine($"  {projName} already in solution");
            }
        }

        // Step 8: Build all projects
        Console.WriteLine($"\nBuilding projects...");
        foreach (var (projFile, projName) in projectFiles)
        {
            Console.WriteLine($"  Building {projName}...");
            var projBuildResult = await RunCommand("dotnet", $"build \"{projFile}\"", solutionDir);
            Console.WriteLine(projBuildResult);
        }

        Console.WriteLine($"\n✓ {generatorName} generation complete!");
        Console.WriteLine($"  Contract: {Path.GetDirectoryName(contractProjectFile)}");
        Console.WriteLine($"  Client: {Path.GetDirectoryName(httpClientProjectFile)}");
        Console.WriteLine($"\nNote: Run IBKR.Api.TestScaffold to create MockClient and Test projects");
    }

    static string GetSolutionDirectory()
    {
        // Navigate from bin/Debug/net8.0 to solution root
        return Path.GetFullPath(Path.Combine(
            AppContext.BaseDirectory,
            "..", "..", "..", "..", ".."
        ));
    }

    static async Task<string> RunCommand(string command, string arguments, string workingDirectory)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                WorkingDirectory = workingDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        var output = new System.Text.StringBuilder();
        var error = new System.Text.StringBuilder();

        process.OutputDataReceived += (sender, e) => { if (e.Data != null) output.AppendLine(e.Data); };
        process.ErrorDataReceived += (sender, e) => { if (e.Data != null) error.AppendLine(e.Data); };

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        await process.WaitForExitAsync();

        var result = output.ToString();
        if (error.Length > 0)
            result += "\nErrors:\n" + error.ToString();

        return result;
    }

    static async Task TestNSwagGenerator(string specPath, string outputDir)
    {
        Console.WriteLine("\n--- Testing NSwag Generator ---");
        var sw = Stopwatch.StartNew();

        try
        {
            // Step 1: Load the OpenAPI spec using Microsoft OpenAPI reader (for fixing)
            Console.WriteLine("Loading OpenAPI spec for fixing...");
            var reader = new OpenApiStreamReader();
            Microsoft.OpenApi.Models.OpenApiDocument msDocument;
            OpenApiDiagnostic diagnostic;

            using (var stream = File.OpenRead(specPath))
            {
                msDocument = reader.Read(stream, out diagnostic);
            }

            Console.WriteLine($"  Loaded: {msDocument.Info.Title} v{msDocument.Info.Version}");
            Console.WriteLine($"  Paths: {msDocument.Paths.Count}, Schemas: {msDocument.Components?.Schemas?.Count ?? 0}");

            // Step 2: Apply NSwag-specific fixes
            var fixer = new NSwagSpecFixer(msDocument);
            fixer.ApplyAllFixes();

            // Step 3: Save fixed spec to temp file
            var fixedSpecPath = Path.Combine(Path.GetDirectoryName(specPath)!, "api-docs.nswag-fixed.json");
            Console.WriteLine($"Saving NSwag-fixed spec to: {fixedSpecPath}");

            using (var stream = File.Create(fixedSpecPath))
            {
                var writer = new Microsoft.OpenApi.Writers.OpenApiJsonWriter(new StreamWriter(stream));
                msDocument.SerializeAsV3(writer);
                writer.Flush();
            }

            Console.WriteLine("  ✓ Fixed spec saved\n");

            // Step 4: Load the FIXED OpenAPI document for NSwag generation
            Console.WriteLine("Loading fixed OpenAPI document for NSwag...");
            var document = await OpenApiDocument.FromFileAsync(fixedSpecPath);

            Console.WriteLine($"✓ Loaded successfully");
            Console.WriteLine($"  Title: {document.Info.Title}");
            Console.WriteLine($"  Version: {document.Info.Version}");
            Console.WriteLine($"  Paths: {document.Paths.Count}");
            Console.WriteLine($"  Schemas: {document.Components.Schemas.Count}");

            // Configure C# client generator
            // Using SingleClientFromOperationId to create one unified client with all methods
            // This should avoid duplicate helper method issues that occur with partial classes
            var settings = new CSharpClientGeneratorSettings
            {
                ClassName = "IBKRClient",
                CSharpGeneratorSettings =
                {
                    Namespace = "IBKR.Api.NSwag",
                    GenerateNullableReferenceTypes = true,
                    GenerateDataAnnotations = true,
                    RequiredPropertiesMustBeDefined = true,
                    ClassStyle = NJsonSchema.CodeGeneration.CSharp.CSharpClassStyle.Poco,
                    GenerateDefaultValues = true
                },
                GenerateClientInterfaces = true,
                GenerateOptionalParameters = true,
                UseBaseUrl = true,
                GenerateDtoTypes = true,
                InjectHttpClient = true,
                DisposeHttpClient = false,
                GenerateClientClasses = true,
                OperationNameGenerator = new NSwag.CodeGeneration.OperationNameGenerators.SingleClientFromOperationIdOperationNameGenerator()
            };

            Console.WriteLine("\nGenerating C# client code...");
            var generator = new CSharpClientGenerator(document, settings);
            var code = generator.GenerateFile();

            var outputFile = Path.Combine(outputDir, "IBKRClient.cs");
            await File.WriteAllTextAsync(outputFile, code);

            sw.Stop();

            var generatedFileInfo = new FileInfo(outputFile);
            Console.WriteLine($"\n✓ NSwag generation complete!");
            Console.WriteLine($"  Time: {sw.ElapsedMilliseconds:N0} ms");
            Console.WriteLine($"  Output file: {outputFile}");
            Console.WriteLine($"  Generated code size: {generatedFileInfo.Length / 1024.0:F1} KB");
            Console.WriteLine($"  Lines of code: ~{File.ReadAllLines(outputFile).Length:N0}");

            // Analyze generated code
            AnalyzeGeneratedCode(outputFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ NSwag generation failed: {ex.Message}");
            if (ex.InnerException != null)
                Console.WriteLine($"   Inner exception: {ex.InnerException.Message}");
        }
    }

    static async Task TestOpenApiReader(string specPath)
    {
        Console.WriteLine("\n--- Testing Microsoft OpenAPI Reader ---");
        var sw = Stopwatch.StartNew();

        try
        {
            using var stream = File.OpenRead(specPath);
            var reader = new OpenApiStreamReader();

            Console.WriteLine("Parsing OpenAPI document...");
            var result = await reader.ReadAsync(stream);

            sw.Stop();

            if (result.OpenApiDiagnostic.Errors.Any())
            {
                Console.WriteLine($"⚠ Parsing completed with {result.OpenApiDiagnostic.Errors.Count} errors:");
                foreach (var error in result.OpenApiDiagnostic.Errors.Take(10))
                {
                    Console.WriteLine($"  - {error.Message}");
                }
                if (result.OpenApiDiagnostic.Errors.Count > 10)
                    Console.WriteLine($"  ... and {result.OpenApiDiagnostic.Errors.Count - 10} more");
            }
            else
            {
                Console.WriteLine("✓ Parsing successful with no errors");
            }

            var doc = result.OpenApiDocument;
            Console.WriteLine($"\n✓ OpenAPI analysis complete!");
            Console.WriteLine($"  Time: {sw.ElapsedMilliseconds:N0} ms");
            Console.WriteLine($"  Title: {doc.Info.Title}");
            Console.WriteLine($"  Version: {doc.Info.Version}");
            Console.WriteLine($"  Servers: {doc.Servers.Count}");
            Console.WriteLine($"  Paths: {doc.Paths.Count}");
            Console.WriteLine($"  Total operations: {doc.Paths.Values.SelectMany(p => p.Operations).Count()}");
            Console.WriteLine($"  Schemas: {doc.Components?.Schemas.Count ?? 0}");
            Console.WriteLine($"  Security schemes: {doc.Components?.SecuritySchemes.Count ?? 0}");

            // Group operations by tag
            var operationsByTag = doc.Paths.Values
                .SelectMany(p => p.Operations.Values)
                .SelectMany(op => op.Tags.Select(tag => new { Tag = tag.Name, Operation = op }))
                .GroupBy(x => x.Tag)
                .OrderByDescending(g => g.Count())
                .ToList();

            Console.WriteLine($"\nOperations by tag:");
            foreach (var group in operationsByTag.Take(15))
            {
                Console.WriteLine($"  {group.Key}: {group.Count()} operations");
            }

            if (operationsByTag.Count > 15)
                Console.WriteLine($"  ... and {operationsByTag.Count - 15} more tags");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ OpenAPI reading failed: {ex.Message}");
            if (ex.InnerException != null)
                Console.WriteLine($"   Inner exception: {ex.InnerException.Message}");
        }
    }

    static void AnalyzeGeneratedCode(string filePath)
    {
        try
        {
            var code = File.ReadAllText(filePath);
            var lines = File.ReadAllLines(filePath);

            Console.WriteLine("\nGenerated code analysis:");

            // Count classes
            var classCount = lines.Count(l => l.TrimStart().StartsWith("public class ") ||
                                              l.TrimStart().StartsWith("public partial class "));
            Console.WriteLine($"  Classes: ~{classCount}");

            // Count interfaces
            var interfaceCount = lines.Count(l => l.TrimStart().StartsWith("public interface "));
            Console.WriteLine($"  Interfaces: ~{interfaceCount}");

            // Count methods
            var methodCount = lines.Count(l => l.Contains("Async(") && l.Contains("Task"));
            Console.WriteLine($"  Async methods: ~{methodCount}");

            // Check for our desired patterns
            var hasStrongTyping = code.Contains("class") && !code.Contains("Dictionary<string, object>");
            var hasCancellationToken = code.Contains("CancellationToken");
            var hasNullableRef = code.Contains("?");

            Console.WriteLine($"\nCode quality checks:");
            Console.WriteLine($"  Strong typing: {(hasStrongTyping ? "✓" : "❌")}");
            Console.WriteLine($"  CancellationToken support: {(hasCancellationToken ? "✓" : "❌")}");
            Console.WriteLine($"  Nullable reference types: {(hasNullableRef ? "✓" : "❌")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Could not analyze: {ex.Message}");
        }
    }
}
