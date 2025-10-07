using System.Text;
using System.Text.RegularExpressions;

namespace IBKR.Api.Generator.KiotaReorganization;

/// <summary>
/// Reorganizes the Kiota-generated monolithic client into a 3-project architecture:
/// - Contract: Models (POCOs)
/// - Client: RequestBuilders and IBKRClient
/// - MockClient: IRequestAdapter mocking helpers
/// </summary>
public class KiotaReorganizer
{
    private readonly string _sourceProjectDir;
    private readonly string _solutionDir;

    public KiotaReorganizer(string sourceProjectDir, string solutionDir)
    {
        _sourceProjectDir = sourceProjectDir;
        _solutionDir = solutionDir;
    }

    public void Reorganize()
    {
        Console.WriteLine("Starting Kiota reorganization...");

        var baseDir = Path.GetDirectoryName(_sourceProjectDir)!;
        var contractDir = Path.Combine(baseDir, "IBKR.Api.Kiota.Contract");
        var clientDir = Path.Combine(baseDir, "IBKR.Api.Kiota.Client");
        var mockClientDir = Path.Combine(baseDir, "IBKR.Api.Kiota.MockClient");

        // Check if MockClient already exists (contains user code we should preserve)
        var mockClientExists = Directory.Exists(mockClientDir) &&
                               File.Exists(Path.Combine(mockClientDir, "IBKR.Api.Kiota.MockClient.csproj"));

        // Step 1: Create project directories
        Directory.CreateDirectory(contractDir);
        Directory.CreateDirectory(clientDir);
        if (!mockClientExists)
        {
            Directory.CreateDirectory(mockClientDir);
        }

        // Step 2: Create Contract project (Models only)
        CreateContractProject(contractDir);

        // Step 3: Move Models to Contract
        MoveModels(contractDir);

        // Step 4: Create Client project (RequestBuilders)
        CreateClientProject(clientDir, contractDir);

        // Step 5: Move RequestBuilders and IBKRClient to Client
        MoveRequestBuilders(clientDir);

        // Step 6: Create MockClient project (only if it doesn't exist)
        if (!mockClientExists)
        {
            CreateMockClientProject(mockClientDir, contractDir);
        }
        else
        {
            Console.WriteLine("MockClient project already exists - preserving user code");
        }

        // Step 7: Update namespaces in Client project
        UpdateClientNamespaces(clientDir);

        // Step 8: Add all projects to solution
        AddProjectsToSolution(contractDir, clientDir, mockClientDir);

        // Step 9: Delete original generated project
        DeleteSourceProject();

        Console.WriteLine("Kiota reorganization complete!");
    }

    private void CreateContractProject(string contractDir)
    {
        Console.WriteLine("Creating Contract project...");

        var csprojContent = @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.Kiota.Abstractions"" Version=""1.19.0"" />
    <PackageReference Include=""Microsoft.Kiota.Serialization.Json"" Version=""1.19.0"" />
    <PackageReference Include=""Microsoft.Kiota.Serialization.Text"" Version=""1.19.0"" />
  </ItemGroup>

</Project>
";
        File.WriteAllText(Path.Combine(contractDir, "IBKR.Api.Kiota.Contract.csproj"), csprojContent);
    }

    private void CreateClientProject(string clientDir, string contractDir)
    {
        Console.WriteLine("Creating Client project...");

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

  <ItemGroup>
    <ProjectReference Include=""..\IBKR.Api.Kiota.Contract\IBKR.Api.Kiota.Contract.csproj"" />
  </ItemGroup>

</Project>
";
        File.WriteAllText(Path.Combine(clientDir, "IBKR.Api.Kiota.Client.csproj"), csprojContent);
    }

    private void CreateMockClientProject(string mockClientDir, string contractDir)
    {
        Console.WriteLine("Creating MockClient project...");

        var csprojContent = @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.Kiota.Abstractions"" Version=""1.19.0"" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include=""..\IBKR.Api.Kiota.Contract\IBKR.Api.Kiota.Contract.csproj"" />
  </ItemGroup>

</Project>
";
        File.WriteAllText(Path.Combine(mockClientDir, "IBKR.Api.Kiota.MockClient.csproj"), csprojContent);

        // Create a placeholder helper class
        var helperContent = @"using Microsoft.Kiota.Abstractions;

namespace IBKR.Api.Kiota.MockClient;

/// <summary>
/// Helper utilities for mocking IRequestAdapter in tests.
/// Use this with your preferred mocking framework (NSubstitute, Moq, etc.)
/// </summary>
public static class MockRequestAdapterHelper
{
    // TODO: Add helper methods for common IRequestAdapter mocking scenarios
    // Example:
    // public static IRequestAdapter CreateMockAdapter()
    // {
    //     var mock = Substitute.For<IRequestAdapter>();
    //     // Configure common behaviors
    //     return mock;
    // }
}
";
        File.WriteAllText(Path.Combine(mockClientDir, "MockRequestAdapterHelper.cs"), helperContent);
    }

    private void MoveModels(string contractDir)
    {
        Console.WriteLine("Moving Models to Contract project...");

        var modelsSourceDir = Path.Combine(_sourceProjectDir, "Models");
        var modelsTargetDir = Path.Combine(contractDir, "Models");

        if (Directory.Exists(modelsSourceDir))
        {
            CopyDirectory(modelsSourceDir, modelsTargetDir);

            // Update namespaces in all model files
            UpdateModelNamespaces(modelsTargetDir);
        }
    }

    private void MoveRequestBuilders(string clientDir)
    {
        Console.WriteLine("Moving RequestBuilders to Client project...");

        // Get all directories except Models, bin, obj
        var directories = Directory.GetDirectories(_sourceProjectDir)
            .Where(d => !d.EndsWith("Models") && !d.EndsWith("bin") && !d.EndsWith("obj"))
            .ToList();

        foreach (var dir in directories)
        {
            var dirName = Path.GetFileName(dir);
            var targetDir = Path.Combine(clientDir, dirName);
            CopyDirectory(dir, targetDir);
        }

        // Copy IBKRClient.cs
        var ibkrClientFile = Path.Combine(_sourceProjectDir, "IBKRClient.cs");
        if (File.Exists(ibkrClientFile))
        {
            File.Copy(ibkrClientFile, Path.Combine(clientDir, "IBKRClient.cs"), true);
        }

        // Copy kiota-lock.json if exists
        var kiotaLockFile = Path.Combine(_sourceProjectDir, "kiota-lock.json");
        if (File.Exists(kiotaLockFile))
        {
            File.Copy(kiotaLockFile, Path.Combine(clientDir, "kiota-lock.json"), true);
        }
    }

    private void UpdateModelNamespaces(string modelsDir)
    {
        Console.WriteLine("Updating Model namespaces...");

        var files = Directory.GetFiles(modelsDir, "*.cs", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            var content = File.ReadAllText(file);

            // Replace namespace declaration
            content = Regex.Replace(
                content,
                @"namespace IBKR\.Api\.Kiota\.Models",
                "namespace IBKR.Api.Kiota.Contract.Models"
            );

            // Update using statements that reference Models
            content = Regex.Replace(
                content,
                @"using IBKR\.Api\.Kiota\.Models;",
                "using IBKR.Api.Kiota.Contract.Models;"
            );

            // Update global:: qualified references (used in XML comments and CreateFromDiscriminatorValue)
            content = Regex.Replace(
                content,
                @"global::IBKR\.Api\.Kiota\.Models\.",
                "global::IBKR.Api.Kiota.Contract.Models."
            );

            File.WriteAllText(file, content);
        }
    }

    private void UpdateClientNamespaces(string clientDir)
    {
        Console.WriteLine("Updating Client namespaces and model references...");

        var files = Directory.GetFiles(clientDir, "*.cs", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            var content = File.ReadAllText(file);
            var originalContent = content;

            // Update model references to point to Contract project
            content = Regex.Replace(
                content,
                @"IBKR\.Api\.Kiota\.Models\.",
                "IBKR.Api.Kiota.Contract.Models."
            );

            // Update using statements
            content = Regex.Replace(
                content,
                @"using IBKR\.Api\.Kiota\.Models;",
                "using IBKR.Api.Kiota.Contract.Models;"
            );

            // Update namespace declarations (except Models namespace)
            content = Regex.Replace(
                content,
                @"^namespace IBKR\.Api\.Kiota\.(?!Models)(\w+)",
                "namespace IBKR.Api.Kiota.Client.$1",
                RegexOptions.Multiline
            );

            // Update root namespace (IBKRClient.cs)
            content = Regex.Replace(
                content,
                @"^namespace IBKR\.Api\.Kiota\s*$",
                "namespace IBKR.Api.Kiota.Client",
                RegexOptions.Multiline
            );

            // Update using statements for request builders (but not Models or Contract)
            content = Regex.Replace(
                content,
                @"using IBKR\.Api\.Kiota\.(?!Models|Contract)(\w+)",
                "using IBKR.Api.Kiota.Client.$1"
            );

            // Update fully qualified type references in code
            content = Regex.Replace(
                content,
                @"global::IBKR\.Api\.Kiota\.(?!Contract\.Models)(\w+)",
                "global::IBKR.Api.Kiota.Client.$1"
            );

            if (content != originalContent)
            {
                File.WriteAllText(file, content);
            }
        }
    }

    private void CopyDirectory(string sourceDir, string targetDir)
    {
        Directory.CreateDirectory(targetDir);

        foreach (var file in Directory.GetFiles(sourceDir))
        {
            var fileName = Path.GetFileName(file);
            var destFile = Path.Combine(targetDir, fileName);
            File.Copy(file, destFile, true);
        }

        foreach (var subDir in Directory.GetDirectories(sourceDir))
        {
            var dirName = Path.GetFileName(subDir);
            var destDir = Path.Combine(targetDir, dirName);
            CopyDirectory(subDir, destDir);
        }
    }

    private void AddProjectsToSolution(string contractDir, string clientDir, string mockClientDir)
    {
        Console.WriteLine("Adding projects to solution...");

        var solutionFile = Path.Combine(_solutionDir, "src", "IBKR.Api.sln");

        if (!File.Exists(solutionFile))
        {
            Console.WriteLine($"Warning: Solution file not found at {solutionFile}");
            return;
        }

        // Remove old monolithic project if it exists in solution
        var oldProjectPath = "Kiota\\IBKR.Api.Kiota\\IBKR.Api.Kiota.csproj";
        RunDotnetCommand($"sln \"{solutionFile}\" remove \"{oldProjectPath}\"");

        // Use dotnet sln add to add the new projects
        var contractProj = Path.Combine(contractDir, "IBKR.Api.Kiota.Contract.csproj");
        var clientProj = Path.Combine(clientDir, "IBKR.Api.Kiota.Client.csproj");
        var mockClientProj = Path.Combine(mockClientDir, "IBKR.Api.Kiota.MockClient.csproj");

        RunDotnetCommand($"sln \"{solutionFile}\" add \"{contractProj}\" --solution-folder Kiota");
        RunDotnetCommand($"sln \"{solutionFile}\" add \"{clientProj}\" --solution-folder Kiota");
        RunDotnetCommand($"sln \"{solutionFile}\" add \"{mockClientProj}\" --solution-folder Kiota");
    }

    private void DeleteSourceProject()
    {
        Console.WriteLine("Deleting original generated project...");

        try
        {
            if (Directory.Exists(_sourceProjectDir))
            {
                Directory.Delete(_sourceProjectDir, true);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Warning: Could not delete source project: {ex.Message}");
        }
    }

    private void RunDotnetCommand(string arguments)
    {
        var processInfo = new System.Diagnostics.ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = System.Diagnostics.Process.Start(processInfo);
        if (process != null)
        {
            process.WaitForExit();
            if (process.ExitCode != 0)
            {
                var error = process.StandardError.ReadToEnd();
                Console.WriteLine($"Warning: dotnet command failed: {error}");
            }
        }
    }
}
