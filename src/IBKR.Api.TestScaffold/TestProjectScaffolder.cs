namespace IBKR.Api.TestScaffold;

/// <summary>
/// Scaffolds Test projects with xUnit, DI support, and example tests.
/// Only creates the project if it doesn't already exist (preserves user code).
/// </summary>
public class TestProjectScaffolder
{
    private readonly string _solutionDir;
    private readonly string _sdkFolder; // "NSwag" or "Kiota"
    private readonly string _baseNamespace; // "IBKR.Api.NSwag" or "IBKR.Api.Kiota"
    private readonly TestProjectType _type;

    public TestProjectScaffolder(string solutionDir, string sdkFolder, string baseNamespace, TestProjectType type)
    {
        _solutionDir = solutionDir;
        _sdkFolder = sdkFolder;
        _baseNamespace = baseNamespace;
        _type = type;
    }

    /// <summary>
    /// Scaffolds the Test project.
    /// Returns true if created, false if already exists (preserved).
    /// </summary>
    public async Task<bool> ScaffoldAsync()
    {
        var projectDir = Path.Combine(_solutionDir, "src", _sdkFolder, $"{_baseNamespace}.Tests");
        var projectFile = Path.Combine(projectDir, $"{_baseNamespace}.Tests.csproj");

        // Check if project already exists
        if (File.Exists(projectFile))
        {
            Console.WriteLine($"✓ {_baseNamespace}.Tests already exists - preserving user code");
            return false;
        }

        Console.WriteLine($"Creating {_baseNamespace}.Tests project...");

        // Create directory
        Directory.CreateDirectory(projectDir);

        // Create .csproj file
        await CreateProjectFile(projectFile);

        // Create scaffold files based on type
        if (_type == TestProjectType.NSwagTests)
        {
            await CreateNSwagTestScaffold(projectDir);
        }
        else
        {
            await CreateKiotaTestScaffold(projectDir);
        }

        Console.WriteLine($"✓ Created {_baseNamespace}.Tests\n");
        return true;
    }

    private async Task CreateProjectFile(string projectFile)
    {
        var contractReference = $"..\\{_baseNamespace}.Contract\\{_baseNamespace}.Contract.csproj";
        var clientReference = $"..\\{_baseNamespace}.Client\\{_baseNamespace}.Client.csproj";
        var mockReference = $"..\\{_baseNamespace}.MockClient\\{_baseNamespace}.MockClient.csproj";

        var content = $@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.Extensions.Configuration"" Version=""8.0.0"" />
    <PackageReference Include=""Microsoft.Extensions.Configuration.Binder"" Version=""8.0.2"" />
    <PackageReference Include=""Microsoft.Extensions.Configuration.EnvironmentVariables"" Version=""8.0.0"" />
    <PackageReference Include=""Microsoft.Extensions.Configuration.Json"" Version=""8.0.0"" />
    <PackageReference Include=""Microsoft.Extensions.DependencyInjection"" Version=""8.0.1"" />
    <PackageReference Include=""Microsoft.Extensions.Http"" Version=""8.0.1"" />
    <PackageReference Include=""Microsoft.NET.Test.Sdk"" Version=""17.11.1"" />
    <PackageReference Include=""xunit"" Version=""2.9.2"" />
    <PackageReference Include=""xunit.runner.visualstudio"" Version=""2.8.2"">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include=""{contractReference}"" />
    <ProjectReference Include=""{clientReference}"" />
    <ProjectReference Include=""{mockReference}"" />
  </ItemGroup>

  <ItemGroup>
    <None Update=""appsettings.json"">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
    <None Update=""appsettings.test.json"">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
    <None Update=""appsettings.development.json"">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
  </ItemGroup>

</Project>
";
        await File.WriteAllTextAsync(projectFile, content);
    }

    private async Task CreateNSwagTestScaffold(string projectDir)
    {
        // Create test infrastructure
        await CreateTestFixture(projectDir, isNSwag: true);
        await CreateAppSettings(projectDir);

        // Create example test
        var exampleTestContent = $@"using {_baseNamespace}.Contract.Interfaces;
using Xunit;

namespace {_baseNamespace}.Tests;

/// <summary>
/// Example tests for IFyiService.
/// Implementation (Mock or Real) is injected via DI based on appsettings.json configuration.
/// </summary>
public class FyiServiceTests : IClassFixture<TestFixture>
{{
    private readonly IFyiService _fyiService;

    public FyiServiceTests(TestFixture fixture)
    {{
        _fyiService = fixture.GetService<IFyiService>();
    }}

    [Fact]
    public async Task GetNotifications_ShouldReturnData()
    {{
        // Act
        var result = await _fyiService.GetNotificationsAsync();

        // Assert
        Assert.NotNull(result);
        // TODO: Add more assertions based on your service interface
    }}

    [Fact(Skip = ""Example test - implement when service interface is complete"")]
    public async Task ExampleTest_VerifyBehavior()
    {{
        // Arrange
        // Act
        // Assert
        Assert.True(true);
    }}
}}
";
        await File.WriteAllTextAsync(Path.Combine(projectDir, "FyiServiceTests.cs"), exampleTestContent);

        // Create README
        await CreateReadme(projectDir, isNSwag: true);
    }

    private async Task CreateKiotaTestScaffold(string projectDir)
    {
        // Create test infrastructure
        await CreateTestFixture(projectDir, isNSwag: false);
        await CreateAppSettings(projectDir);

        // Create example test
        var exampleTestContent = $@"using {_baseNamespace}.Client;
using Microsoft.Kiota.Abstractions;
using Xunit;

namespace {_baseNamespace}.Tests;

/// <summary>
/// Example tests for Kiota-based client.
/// IRequestAdapter implementation (Mock or Real) is injected via DI based on appsettings.json configuration.
/// </summary>
public class FyiClientTests : IClassFixture<TestFixture>
{{
    private readonly IBKRClient _client;

    public FyiClientTests(TestFixture fixture)
    {{
        var requestAdapter = fixture.GetService<IRequestAdapter>();
        _client = new IBKRClient(requestAdapter);
    }}

    [Fact]
    public async Task GetNotifications_ShouldReturnData()
    {{
        // Act
        var result = await _client.Fyi.Notifications.GetAsync();

        // Assert
        Assert.NotNull(result);
        // TODO: Add more assertions based on API response
    }}

    [Fact(Skip = ""Example test - implement when client is complete"")]
    public async Task ExampleTest_VerifyBehavior()
    {{
        // Arrange
        // Act
        // Assert
        Assert.True(true);
    }}
}}
";
        await File.WriteAllTextAsync(Path.Combine(projectDir, "FyiClientTests.cs"), exampleTestContent);

        // Create README
        await CreateReadme(projectDir, isNSwag: false);
    }

    private async Task CreateTestFixture(string projectDir, bool isNSwag)
    {
        string fixtureContent;

        if (isNSwag)
        {
            fixtureContent = $@"using {_baseNamespace}.Contract.Interfaces;
using {_baseNamespace}.Client.Services;
using {_baseNamespace}.MockClient.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace {_baseNamespace}.Tests;

/// <summary>
/// Test fixture for dependency injection setup.
/// Configures services based on appsettings.json to use either Mock or Real implementations.
/// </summary>
public class TestFixture : IDisposable
{{
    public IServiceProvider ServiceProvider {{ get; }}
    public IConfiguration Configuration {{ get; }}

    public TestFixture()
    {{
        // Load configuration
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(""appsettings.json"", optional: false)
            .AddJsonFile(""appsettings.test.json"", optional: true)
            .AddJsonFile(""appsettings.development.json"", optional: true)
            .AddEnvironmentVariables()
            .Build();

        // Setup DI container
        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }}

    private void ConfigureServices(IServiceCollection services)
    {{
        // Add configuration
        services.AddSingleton(Configuration);

        // Determine which implementation to use
        var useMockClient = Configuration.GetValue<bool>(""Testing:UseMockClient"", defaultValue: true);

        if (useMockClient)
        {{
            Console.WriteLine(""[Test Setup] Using MOCK client implementations"");

            // Register mock service implementations
            services.AddTransient<IFyiService, MockFyiService>();
            // TODO: Add more mock services as needed:
            // services.AddTransient<IGwService, MockGwService>();
            // services.AddTransient<IPortfolioService, MockPortfolioService>();
        }}
        else
        {{
            Console.WriteLine(""[Test Setup] Using REAL client implementations"");

            // Register real service implementations
            // Configure HttpClient for real services
            services.AddHttpClient();

            services.AddTransient<IFyiService, FyiService>();
            // TODO: Add more real services as needed:
            // services.AddTransient<IGwService, GwService>();
            // services.AddTransient<IPortfolioService, PortfolioService>();
        }}
    }}

    public T GetService<T>() where T : notnull
    {{
        return ServiceProvider.GetRequiredService<T>();
    }}

    public void Dispose()
    {{
        if (ServiceProvider is IDisposable disposable)
        {{
            disposable.Dispose();
        }}
    }}
}}
";
        }
        else
        {
            fixtureContent = $@"using {_baseNamespace}.Client;
using {_baseNamespace}.MockClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace {_baseNamespace}.Tests;

/// <summary>
/// Test fixture for dependency injection setup.
/// Configures IRequestAdapter based on appsettings.json to use either Mock or Real implementation.
/// </summary>
public class TestFixture : IDisposable
{{
    public IServiceProvider ServiceProvider {{ get; }}
    public IConfiguration Configuration {{ get; }}

    public TestFixture()
    {{
        // Load configuration
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(""appsettings.json"", optional: false)
            .AddJsonFile(""appsettings.test.json"", optional: true)
            .AddJsonFile(""appsettings.development.json"", optional: true)
            .AddEnvironmentVariables()
            .Build();

        // Setup DI container
        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }}

    private void ConfigureServices(IServiceCollection services)
    {{
        // Add configuration
        services.AddSingleton(Configuration);

        // Determine which implementation to use
        var useMockClient = Configuration.GetValue<bool>(""Testing:UseMockClient"", defaultValue: true);

        if (useMockClient)
        {{
            Console.WriteLine(""[Test Setup] Using MOCK request adapter"");

            // Register mock request adapter
            services.AddSingleton<IRequestAdapter>(sp => new MockRequestAdapter());
        }}
        else
        {{
            Console.WriteLine(""[Test Setup] Using REAL request adapter"");

            // Register real request adapter with HTTP client
            services.AddHttpClient();

            services.AddSingleton<IRequestAdapter>(sp =>
            {{
                var authProvider = new AnonymousAuthenticationProvider();
                var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient();
                return new HttpClientRequestAdapter(authProvider, httpClient: httpClient);
            }});
        }}

        // Register IBKRClient
        services.AddTransient<IBKRClient>(sp =>
        {{
            var adapter = sp.GetRequiredService<IRequestAdapter>();
            return new IBKRClient(adapter);
        }});
    }}

    public T GetService<T>() where T : notnull
    {{
        return ServiceProvider.GetRequiredService<T>();
    }}

    public void Dispose()
    {{
        if (ServiceProvider is IDisposable disposable)
        {{
            disposable.Dispose();
        }}
    }}
}}
";
        }

        await File.WriteAllTextAsync(Path.Combine(projectDir, "TestFixture.cs"), fixtureContent);
    }

    private async Task CreateAppSettings(string projectDir)
    {
        // appsettings.json (base configuration)
        var appSettingsContent = @"{
  ""Testing"": {
    ""UseMockClient"": true,
    ""Comments"": ""Set UseMockClient to false to test against real IBKR API""
  }
}
";
        await File.WriteAllTextAsync(Path.Combine(projectDir, "appsettings.json"), appSettingsContent);

        // appsettings.test.json (CI/CD environment)
        var testSettingsContent = @"{
  ""Testing"": {
    ""UseMockClient"": true,
    ""Comments"": ""CI/CD build server always uses mocks (fast, deterministic, no credentials needed)""
  }
}
";
        await File.WriteAllTextAsync(Path.Combine(projectDir, "appsettings.test.json"), testSettingsContent);

        // appsettings.development.json (local development)
        var devSettingsContent = @"{
  ""Testing"": {
    ""UseMockClient"": false,
    ""Comments"": ""Local development can test against real API (requires valid credentials)""
  },
  ""IBKR"": {
    ""BaseUrl"": ""https://api.ibkr.com"",
    ""ApiKey"": ""your-api-key-here"",
    ""Comments"": ""Add your IBKR API credentials here for local integration testing""
  }
}
";
        await File.WriteAllTextAsync(Path.Combine(projectDir, "appsettings.development.json"), devSettingsContent);
    }

    private async Task CreateReadme(string projectDir, bool isNSwag)
    {
        var architecture = isNSwag ? "NSwag (Service-Oriented)" : "Kiota (Fluent API)";
        var diExample = isNSwag
            ? @"```csharp
services.AddTransient<IFyiService, MockFyiService>();  // Mock for CI/CD
// OR
services.AddTransient<IFyiService, FyiService>();      // Real for local testing
```"
            : @"```csharp
services.AddSingleton<IRequestAdapter>(new MockRequestAdapter());  // Mock for CI/CD
// OR
services.AddSingleton<IRequestAdapter>(new HttpClientRequestAdapter(...)); // Real for local testing
```";

        var readmeContent = $@"# {_baseNamespace}.Tests

xUnit tests with Dependency Injection support for {architecture} SDK.

## Architecture

**Tests depend on INTERFACES, not implementations.**

This allows the same tests to run against:
- **Mock implementations** (CI/CD build server - fast, deterministic)
- **Real implementations** (Local development - integration testing)

Simply change the `appsettings.json` configuration to switch between mock and real clients.

## Configuration

### appsettings.test.json (CI/CD)
```json
{{
  ""Testing"": {{
    ""UseMockClient"": true
  }}
}}
```

### appsettings.development.json (Local)
```json
{{
  ""Testing"": {{
    ""UseMockClient"": false
  }},
  ""IBKR"": {{
    ""BaseUrl"": ""https://api.ibkr.com"",
    ""ApiKey"": ""your-api-key-here""
  }}
}}
```

## Dependency Injection

Tests use `TestFixture` to configure DI based on configuration:

{diExample}

## Running Tests

```bash
# Run all tests (uses appsettings.json configuration)
dotnet test

# Run with specific configuration
ASPNETCORE_ENVIRONMENT=test dotnet test          # Use mock client
ASPNETCORE_ENVIRONMENT=development dotnet test   # Use real client
```

## Writing Tests

```csharp
public class MyServiceTests : IClassFixture<TestFixture>
{{
    private readonly IMyService _service;

    public MyServiceTests(TestFixture fixture)
    {{
        _service = fixture.GetService<IMyService>();
        // Test doesn't know if this is mock or real!
    }}

    [Fact]
    public async Task MyTest()
    {{
        var result = await _service.DoSomethingAsync();
        Assert.NotNull(result);
    }}
}}
```

## Notes

- This project is **user-editable** and will be preserved during SDK regeneration
- Tests verify interface contracts, not implementation details
- Same test code works for both mock and real clients
- Build server uses mocks (fast, no credentials needed)
- Local developers can test against real API (integration testing)
";
        await File.WriteAllTextAsync(Path.Combine(projectDir, "README.md"), readmeContent);
    }
}

public enum TestProjectType
{
    NSwagTests,
    KiotaTests
}
