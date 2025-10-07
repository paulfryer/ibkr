namespace IBKR.Api.TestScaffold;

/// <summary>
/// Scaffolds MockClient projects that implement service interfaces.
/// Only creates the project if it doesn't already exist (preserves user code).
/// </summary>
public class MockClientScaffolder
{
    private readonly string _solutionDir;
    private readonly string _sdkFolder; // "NSwag" or "Kiota"
    private readonly string _baseNamespace; // "IBKR.Api.NSwag" or "IBKR.Api.Kiota"
    private readonly MockClientType _type;

    public MockClientScaffolder(string solutionDir, string sdkFolder, string baseNamespace, MockClientType type)
    {
        _solutionDir = solutionDir;
        _sdkFolder = sdkFolder;
        _baseNamespace = baseNamespace;
        _type = type;
    }

    /// <summary>
    /// Scaffolds the MockClient project.
    /// Returns true if created, false if already exists (preserved).
    /// </summary>
    public async Task<bool> ScaffoldAsync()
    {
        var projectDir = Path.Combine(_solutionDir, "src", _sdkFolder, $"{_baseNamespace}.MockClient");
        var projectFile = Path.Combine(projectDir, $"{_baseNamespace}.MockClient.csproj");

        // Check if project already exists
        if (File.Exists(projectFile))
        {
            Console.WriteLine($"✓ {_baseNamespace}.MockClient already exists - preserving user code");
            return false;
        }

        Console.WriteLine($"Creating {_baseNamespace}.MockClient project...");

        // Create directory
        Directory.CreateDirectory(projectDir);

        // Create .csproj file
        await CreateProjectFile(projectFile);

        // Create scaffold files based on type
        if (_type == MockClientType.NSwagServices)
        {
            await CreateNSwagMockScaffold(projectDir);
        }
        else
        {
            await CreateKiotaMockScaffold(projectDir);
        }

        Console.WriteLine($"✓ Created {_baseNamespace}.MockClient\n");
        return true;
    }

    private async Task CreateProjectFile(string projectFile)
    {
        var contractReference = $"..\\{_baseNamespace}.Contract\\{_baseNamespace}.Contract.csproj";

        var content = $@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include=""{contractReference}"" />
  </ItemGroup>

</Project>
";
        await File.WriteAllTextAsync(projectFile, content);
    }

    private async Task CreateNSwagMockScaffold(string projectDir)
    {
        var servicesDir = Path.Combine(projectDir, "Services");
        Directory.CreateDirectory(servicesDir);

        // Create example mock service
        var mockFyiServiceContent = $@"using {_baseNamespace}.Contract.Interfaces;
using {_baseNamespace}.Contract.Models;

namespace {_baseNamespace}.MockClient.Services;

/// <summary>
/// Mock implementation of IFyiService for testing.
/// Returns canned responses to simulate API behavior without network calls.
/// </summary>
public class MockFyiService : IFyiService
{{
    // TODO: Implement interface methods with canned responses
    // Example:
    // public async Task<ICollection<NotificationMessage>> GetNotificationsAsync(CancellationToken cancellationToken = default)
    // {{
    //     return new List<NotificationMessage>
    //     {{
    //         new NotificationMessage {{ Id = ""1"", Message = ""Test notification"" }}
    //     }};
    // }}
}}
";
        await File.WriteAllTextAsync(Path.Combine(servicesDir, "MockFyiService.cs"), mockFyiServiceContent);

        // Create README
        var readmeContent = $@"# {_baseNamespace}.MockClient

Mock implementations of service interfaces for testing.

## Purpose

This project provides mock implementations of the service interfaces defined in `{_baseNamespace}.Contract`.
These mocks return canned responses for fast, deterministic testing without network calls.

## Usage

Mocks are registered via Dependency Injection in tests:

```csharp
services.AddTransient<IFyiService, MockFyiService>();
services.AddTransient<IGwService, MockGwService>();
// ... etc
```

## Implementation Guide

For each service interface in `{_baseNamespace}.Contract.Interfaces`:

1. Create a mock class: `Mock{{ServiceName}}.cs`
2. Implement the interface
3. Return canned data (hardcoded responses)
4. Consider using helper methods for common test scenarios

## Example

```csharp
public class MockFyiService : IFyiService
{{
    public async Task<ICollection<NotificationMessage>> GetNotificationsAsync(CancellationToken cancellationToken = default)
    {{
        // Return canned test data
        return await Task.FromResult(new List<NotificationMessage>
        {{
            new NotificationMessage {{ Id = ""test-1"", Message = ""Sample notification"" }}
        }});
    }}
}}
```

## Notes

- This project is **user-editable** and will be preserved during SDK regeneration
- Implement only the methods you need for your tests
- Use async/await for consistency with real services
";
        await File.WriteAllTextAsync(Path.Combine(projectDir, "README.md"), readmeContent);
    }

    private async Task CreateKiotaMockScaffold(string projectDir)
    {
        var mockAdapterContent = $@"using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;

namespace {_baseNamespace}.MockClient;

/// <summary>
/// Mock implementation of IRequestAdapter for testing Kiota-based clients.
/// Returns canned responses without making actual HTTP requests.
/// </summary>
public class MockRequestAdapter : IRequestAdapter
{{
    private readonly Dictionary<string, object> _cannedResponses = new();

    public ISerializationWriterFactory SerializationWriterFactory {{ get; set; }} = null!;
    public IParseNodeFactory ParseNodeFactory {{ get; set; }} = null!;
    public string? BaseUrl {{ get; set; }} = ""https://mock.api.ibkr.com"";

    /// <summary>
    /// Register a canned response for a specific request path.
    /// </summary>
    public void SetCannedResponse<T>(string path, T response)
    {{
        _cannedResponses[path] = response!;
    }}

    public Task<T?> ConvertToNativeRequestAsync<T>(RequestInformation requestInfo, CancellationToken cancellationToken = default)
    {{
        throw new NotImplementedException(""ConvertToNativeRequestAsync is not supported in mock mode"");
    }}

    public async Task<ModelType?> SendAsync<ModelType>(
        RequestInformation requestInfo,
        ParsableFactory<ModelType> factory,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default) where ModelType : IParsable
    {{
        var path = requestInfo.URI.PathAndQuery;

        if (_cannedResponses.TryGetValue(path, out var response))
        {{
            return await Task.FromResult((ModelType?)response);
        }}

        throw new InvalidOperationException($""No canned response configured for: {{path}}"");
    }}

    public async Task<IEnumerable<ModelType>?> SendCollectionAsync<ModelType>(
        RequestInformation requestInfo,
        ParsableFactory<ModelType> factory,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default) where ModelType : IParsable
    {{
        var path = requestInfo.URI.PathAndQuery;

        if (_cannedResponses.TryGetValue(path, out var response))
        {{
            return await Task.FromResult((IEnumerable<ModelType>?)response);
        }}

        throw new InvalidOperationException($""No canned response configured for: {{path}}"");
    }}

    public async Task<ModelType?> SendPrimitiveAsync<ModelType>(
        RequestInformation requestInfo,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default)
    {{
        var path = requestInfo.URI.PathAndQuery;

        if (_cannedResponses.TryGetValue(path, out var response))
        {{
            return await Task.FromResult((ModelType?)response);
        }}

        throw new InvalidOperationException($""No canned response configured for: {{path}}"");
    }}

    public async Task<IEnumerable<ModelType>?> SendPrimitiveCollectionAsync<ModelType>(
        RequestInformation requestInfo,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default)
    {{
        var path = requestInfo.URI.PathAndQuery;

        if (_cannedResponses.TryGetValue(path, out var response))
        {{
            return await Task.FromResult((IEnumerable<ModelType>?)response);
        }}

        throw new InvalidOperationException($""No canned response configured for: {{path}}"");
    }}

    public Task SendNoContentAsync(
        RequestInformation requestInfo,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default)
    {{
        return Task.CompletedTask;
    }}

    public void EnableBackingStore(IBackingStoreFactory backingStoreFactory)
    {{
        // No-op for mock
    }}

    public IAuthenticationProvider AuthenticationProvider {{ get; set; }} = null!;
}}
";
        await File.WriteAllTextAsync(Path.Combine(projectDir, "MockRequestAdapter.cs"), mockAdapterContent);

        // Create README
        var readmeContent = $@"# {_baseNamespace}.MockClient

Mock implementation of IRequestAdapter for testing Kiota-based clients.

## Purpose

This project provides a mock `IRequestAdapter` that returns canned responses for fast,
deterministic testing without network calls.

## Usage

Register the mock adapter via Dependency Injection in tests:

```csharp
var mockAdapter = new MockRequestAdapter();
mockAdapter.SetCannedResponse(""/v1/api/fyi/notifications"", new List<Notification> {{ ... }});

services.AddSingleton<IRequestAdapter>(mockAdapter);
```

## Implementation Guide

The `MockRequestAdapter` class:

1. Implements `IRequestAdapter` interface
2. Stores canned responses in a dictionary (keyed by request path)
3. Returns canned data when requests are made
4. Throws if no canned response is configured (helps catch test setup issues)

## Example

```csharp
// In test setup
var mockAdapter = new MockRequestAdapter();
mockAdapter.SetCannedResponse(""/v1/api/fyi/notifications"", new List<NotificationMessage>
{{
    new() {{ Id = ""test-1"", Message = ""Sample notification"" }}
}});

var client = new IBKRClient(mockAdapter);

// In test
var notifications = await client.Fyi.Notifications.GetAsync();
// Returns the canned response
```

## Notes

- This project is **user-editable** and will be preserved during SDK regeneration
- Extend `MockRequestAdapter` as needed for your testing scenarios
- Consider creating helper methods for common test setups
";
        await File.WriteAllTextAsync(Path.Combine(projectDir, "README.md"), readmeContent);
    }
}

public enum MockClientType
{
    NSwagServices,
    KiotaRequestAdapter
}
