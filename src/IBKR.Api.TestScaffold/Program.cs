namespace IBKR.Api.TestScaffold;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== IBKR Test Infrastructure Scaffold ===\n");
        Console.WriteLine("This tool creates MockClient and Test projects for both SDK architectures.");
        Console.WriteLine("Existing projects with user code will be PRESERVED.\n");

        var solutionDir = GetSolutionDirectory();
        Console.WriteLine($"Solution directory: {solutionDir}\n");

        // Track what was created vs. preserved
        var created = new List<string>();
        var preserved = new List<string>();

        // Step 1: Scaffold NSwag test infrastructure
        Console.WriteLine("=== NSwag Test Infrastructure ===\n");

        var nswagMockScaffolder = new MockClientScaffolder(
            solutionDir,
            "NSwag",
            "IBKR.Api.NSwag",
            MockClientType.NSwagServices
        );
        if (await nswagMockScaffolder.ScaffoldAsync())
            created.Add("NSwag MockClient");
        else
            preserved.Add("NSwag MockClient");

        var nswagTestScaffolder = new TestProjectScaffolder(
            solutionDir,
            "NSwag",
            "IBKR.Api.NSwag",
            TestProjectType.NSwagTests
        );
        if (await nswagTestScaffolder.ScaffoldAsync())
            created.Add("NSwag Tests");
        else
            preserved.Add("NSwag Tests");

        // Step 2: Scaffold Kiota test infrastructure
        Console.WriteLine("\n=== Kiota Test Infrastructure ===\n");

        var kiotaMockScaffolder = new MockClientScaffolder(
            solutionDir,
            "Kiota",
            "IBKR.Api.Kiota",
            MockClientType.KiotaRequestAdapter
        );
        if (await kiotaMockScaffolder.ScaffoldAsync())
            created.Add("Kiota MockClient");
        else
            preserved.Add("Kiota MockClient");

        var kiotaTestScaffolder = new TestProjectScaffolder(
            solutionDir,
            "Kiota",
            "IBKR.Api.Kiota",
            TestProjectType.KiotaTests
        );
        if (await kiotaTestScaffolder.ScaffoldAsync())
            created.Add("Kiota Tests");
        else
            preserved.Add("Kiota Tests");

        // Step 3: Add projects to solution
        Console.WriteLine("\n=== Adding Projects to Solution ===\n");
        await AddProjectsToSolution(solutionDir, created);

        // Summary
        Console.WriteLine("\n=== Summary ===\n");
        if (created.Count > 0)
        {
            Console.WriteLine("✅ Created:");
            foreach (var item in created)
                Console.WriteLine($"   • {item}");
        }
        if (preserved.Count > 0)
        {
            Console.WriteLine($"\n🔒 Preserved (already exists with user code):");
            foreach (var item in preserved)
                Console.WriteLine($"   • {item}");
        }

        Console.WriteLine("\n✅ Test infrastructure is ready!");
        Console.WriteLine("\nNext steps:");
        Console.WriteLine("  1. Implement mock logic in MockClient projects");
        Console.WriteLine("  2. Write tests in Test projects");
        Console.WriteLine("  3. Run: dotnet test");
    }

    static string GetSolutionDirectory()
    {
        // Navigate from bin/Debug/net8.0 to solution root
        return Path.GetFullPath(Path.Combine(
            AppContext.BaseDirectory,
            "..", "..", "..", "..", ".."
        ));
    }

    static async Task AddProjectsToSolution(string solutionDir, List<string> created)
    {
        var solutionFile = Path.Combine(solutionDir, "src", "IBKR.Api.sln");

        if (!File.Exists(solutionFile))
        {
            Console.WriteLine($"⚠ Warning: Solution file not found at {solutionFile}");
            return;
        }

        // Define all possible test projects
        var projects = new[]
        {
            (Path: Path.Combine(solutionDir, "src", "NSwag", "IBKR.Api.NSwag.MockClient", "IBKR.Api.NSwag.MockClient.csproj"), Folder: "NSwag"),
            (Path: Path.Combine(solutionDir, "src", "NSwag", "IBKR.Api.NSwag.Tests", "IBKR.Api.NSwag.Tests.csproj"), Folder: "NSwag"),
            (Path: Path.Combine(solutionDir, "src", "Kiota", "IBKR.Api.Kiota.MockClient", "IBKR.Api.Kiota.MockClient.csproj"), Folder: "Kiota"),
            (Path: Path.Combine(solutionDir, "src", "Kiota", "IBKR.Api.Kiota.Tests", "IBKR.Api.Kiota.Tests.csproj"), Folder: "Kiota")
        };

        // Read solution file to check what's already added
        var slnContent = await File.ReadAllTextAsync(solutionFile);

        foreach (var project in projects)
        {
            if (!File.Exists(project.Path))
                continue;

            var projectName = Path.GetFileNameWithoutExtension(project.Path);

            if (slnContent.Contains(projectName))
            {
                Console.WriteLine($"   • {projectName} already in solution");
            }
            else
            {
                Console.WriteLine($"   • Adding {projectName}...");
                await RunDotnetCommand($"sln \"{solutionFile}\" add \"{project.Path}\" --solution-folder {project.Folder}", solutionDir);
            }
        }
    }

    static async Task RunDotnetCommand(string arguments, string workingDirectory)
    {
        var processInfo = new System.Diagnostics.ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = arguments,
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = System.Diagnostics.Process.Start(processInfo);
        if (process != null)
        {
            await process.WaitForExitAsync();
            if (process.ExitCode != 0)
            {
                var error = await process.StandardError.ReadToEndAsync();
                Console.WriteLine($"   ⚠ Warning: {error}");
            }
        }
    }
}
