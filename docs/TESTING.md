# Testing Guide

This guide covers testing patterns for both SDKs, including mock implementations, dependency injection, and configuration-based switching between mock and real clients.

## Test Architecture

Both SDKs include comprehensive test infrastructure:

```
SDK Projects:
├── Contract     # Models (shared by all)
├── Client       # Real implementations
├── MockClient   # Test mocks (user-editable)
└── Tests        # xUnit tests with DI
```

## MockClient Projects

### Purpose

MockClient projects provide **canned responses** for fast, deterministic unit testing without network calls:

- ✅ **Fast**: No HTTP overhead
- ✅ **Deterministic**: Same input = same output
- ✅ **Offline**: No API credentials needed
- ✅ **User-Editable**: Preserved during SDK regeneration

### NSwag MockClient

Implements service interfaces with stub methods:

```csharp
// IBKR.Api.NSwag.MockClient/Services/MockFyiService.cs
public class MockFyiService : IFyiService
{
    public Task<Response> UnreadnumberAsync(CancellationToken cancellationToken = default)
    {
        // Return canned response
        return Task.FromResult(new Response
        {
            UnreadCount = 3
        });
    }

    // Implement other methods as needed...
}
```

### Kiota MockClient

Implements IRequestAdapter with path-based responses:

```csharp
// IBKR.Api.Kiota.MockClient/MockRequestAdapter.cs
public class MockRequestAdapter : IRequestAdapter
{
    private readonly Dictionary<string, object> _cannedResponses = new();

    public void SetCannedResponse<T>(string path, T response)
    {
        _cannedResponses[path] = response!;
    }

    public async Task<ModelType?> SendAsync<ModelType>(...)
    {
        var path = requestInfo.URI.PathAndQuery;
        if (_cannedResponses.TryGetValue(path, out var response))
        {
            return await Task.FromResult((ModelType?)response);
        }
        throw new InvalidOperationException($"No canned response for: {path}");
    }
}
```

## Configuration-Based Testing

The test projects use `appsettings.json` to switch between mock and real implementations.

### Configuration Files

```json
// appsettings.json (default - uses mocks)
{
  "Testing": {
    "UseMockClient": true
  },
  "IBKR": {
    "ClientId": "",
    "Credential": "",
    "ClientKeyId": "",
    "ClientPemPath": "",
    "BaseUrl": "https://api.ibkr.com"
  }
}
```

**Environment variables override config files:**
- `Testing__UseMockClient=false` - Use real API instead of mocks
- `IBKR__ClientId` - Your IBKR OAuth2 Client ID
- `IBKR__Credential` - Your IBKR username
- `IBKR__ClientKeyId` - OAuth2 Key ID
- `IBKR__ClientPemPath` - Path to RSA private key PEM file

### Test Fixture with DI

Both test projects use xUnit's `IClassFixture<TestFixture>` pattern:

#### NSwag TestFixture

```csharp
public class TestFixture : IDisposable
{
    public IServiceProvider ServiceProvider { get; }
    public IConfiguration Configuration { get; }

    public TestFixture()
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.test.json", optional: true)
            .AddJsonFile("appsettings.development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        var useMockClient = Configuration.GetValue<bool>("Testing:UseMockClient", defaultValue: true);

        if (useMockClient)
        {
            Console.WriteLine("[Test Setup] Using MOCK client - no credentials required");

            // Register mock authentication provider
            services.AddSingleton<IIBKRAuthenticationProvider>(new MockAuthenticationProvider());

            // Register mock service implementations
            services.AddTransient<IIserverService, MockIserverService>();
            services.AddTransient<IMdService, MockMdService>();
        }
        else
        {
            Console.WriteLine("[Test Setup] Using REAL IBKR API - credentials required");

            // Load authentication options from configuration or environment variables
            var authOptions = new IBKRAuthenticationOptions
            {
                ClientId = Configuration["IBKR:ClientId"] ?? throw new InvalidOperationException("IBKR:ClientId not configured"),
                Credential = Configuration["IBKR:Credential"] ?? throw new InvalidOperationException("IBKR:Credential not configured"),
                ClientKeyId = Configuration["IBKR:ClientKeyId"] ?? throw new InvalidOperationException("IBKR:ClientKeyId not configured"),
                ClientPemPath = Configuration["IBKR:ClientPemPath"] ?? throw new InvalidOperationException("IBKR:ClientPemPath not configured"),
                BaseUrl = Configuration["IBKR:BaseUrl"] ?? "https://api.ibkr.com"
            };

            // Validate credentials are complete
            authOptions.Validate();

            // Register authenticated services
            services.AddIBKRAuthenticatedClient<IIserverService, IserverService>(authOptions);
            services.AddIBKRAuthenticatedClient<IMdService, MdService>(authOptions);
        }
    }

    public T GetService<T>() where T : notnull
    {
        return ServiceProvider.GetRequiredService<T>();
    }

    public void Dispose()
    {
        if (ServiceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
```

#### Kiota TestFixture

```csharp
public class TestFixture : IDisposable
{
    public IServiceProvider ServiceProvider { get; }
    public IConfiguration Configuration { get; }

    public TestFixture()
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.test.json", optional: true)
            .AddJsonFile("appsettings.development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        var useMockClient = Configuration.GetValue<bool>("Testing:UseMockClient", defaultValue: true);

        if (useMockClient)
        {
            Console.WriteLine("[Test Setup] Using MOCK client - no credentials required");

            // Register mock request adapter
            services.AddSingleton<IRequestAdapter>(sp => new MockRequestAdapter());

            // Register IBKRClient with mock adapter
            services.AddTransient<IBKRClient>(sp =>
            {
                var adapter = sp.GetRequiredService<IRequestAdapter>();
                return new IBKRClient(adapter);
            });
        }
        else
        {
            Console.WriteLine("[Test Setup] Using REAL IBKR API - credentials required");

            // Load authentication options from configuration or environment variables
            var authOptions = new IBKRAuthenticationOptions
            {
                ClientId = Configuration["IBKR:ClientId"] ?? throw new InvalidOperationException("IBKR:ClientId not configured"),
                Credential = Configuration["IBKR:Credential"] ?? throw new InvalidOperationException("IBKR:Credential not configured"),
                ClientKeyId = Configuration["IBKR:ClientKeyId"] ?? throw new InvalidOperationException("IBKR:ClientKeyId not configured"),
                ClientPemPath = Configuration["IBKR:ClientPemPath"] ?? throw new InvalidOperationException("IBKR:ClientPemPath not configured"),
                BaseUrl = Configuration["IBKR:BaseUrl"] ?? "https://api.ibkr.com"
            };

            // Validate credentials are complete
            authOptions.Validate();

            // Use extension method to register authenticated Kiota client
            services.AddIBKRAuthenticatedKiotaClient(authOptions);
        }
    }

    public T GetService<T>() where T : notnull
    {
        return ServiceProvider.GetRequiredService<T>();
    }

    public void Dispose()
    {
        if (ServiceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
```

## Writing Tests

### NSwag Test Example

```csharp
public class FyiServiceTests : IClassFixture<TestFixture>
{
    private readonly IFyiService _fyiService;

    public FyiServiceTests(TestFixture fixture)
    {
        _fyiService = fixture.GetService<IFyiService>();
    }

    [Fact]
    public async Task UnreadNumber_ShouldReturnData()
    {
        // Act
        var result = await _fyiService.UnreadnumberAsync();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.UnreadCount >= 0);
    }
}
```

### Kiota Test Example

```csharp
public class FyiClientTests : IClassFixture<TestFixture>
{
    private readonly IBKRClient _client;

    public FyiClientTests(TestFixture fixture)
    {
        var requestAdapter = fixture.GetService<IRequestAdapter>();
        _client = new IBKRClient(requestAdapter);
    }

    [Fact]
    public async Task GetNotifications_ShouldReturnData()
    {
        // Act
        var result = await _client.Fyi.Unreadnumber.GetAsync();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.UnreadCount >= 0);
    }
}
```

## Implementing Mock Responses

### NSwag: Implement Interface Methods

Edit `MockFyiService.cs` to add actual canned responses:

```csharp
public class MockFyiService : IFyiService
{
    public Task<Response> UnreadnumberAsync(CancellationToken cancellationToken = default)
    {
        // Return realistic test data
        return Task.FromResult(new Response
        {
            UnreadCount = 5,
            Timestamp = DateTimeOffset.UtcNow
        });
    }

    public Task<ICollection<Anonymous>> NotificationsAllAsync(
        string max,
        object? include = null,
        object? exclude = null,
        object? id = null,
        CancellationToken cancellationToken = default)
    {
        // Return collection of test notifications
        var notifications = new List<Anonymous>
        {
            new() { Id = "1", Message = "Test notification 1", Date = DateTime.UtcNow },
            new() { Id = "2", Message = "Test notification 2", Date = DateTime.UtcNow }
        };
        return Task.FromResult<ICollection<Anonymous>>(notifications);
    }
}
```

### Kiota: Configure Canned Responses

Edit `MockRequestAdapter.cs` or configure in tests:

```csharp
// In test setup
var mockAdapter = new MockRequestAdapter();
mockAdapter.SetCannedResponse("/fyi/unreadnumber", new Response
{
    UnreadCount = 5
});

mockAdapter.SetCannedResponse("/fyi/notifications", new List<NotificationMessage>
{
    new() { Id = "1", Message = "Test 1" },
    new() { Id = "2", Message = "Test 2" }
});

var client = new IBKRClient(mockAdapter);
```

## Running Tests

### Run All Tests

```bash
dotnet test
```

### Run with Mocks (Fast - Default)

```bash
# Uses appsettings.json (UseMockClient: true)
dotnet test
```

### Run with Real API (Integration Tests)

**Using Environment Variables (Recommended):**

```bash
# Windows PowerShell
$env:Testing__UseMockClient="false"
$env:IBKR__ClientId="YOUR_CLIENT_ID"
$env:IBKR__Credential="YOUR_USERNAME"
$env:IBKR__ClientKeyId="YOUR_KEY_ID"
$env:IBKR__ClientPemPath="C:\path\to\your\key.pem"
dotnet test

# Linux/macOS
export Testing__UseMockClient=false
export IBKR__ClientId=YOUR_CLIENT_ID
export IBKR__Credential=YOUR_USERNAME
export IBKR__ClientKeyId=YOUR_KEY_ID
export IBKR__ClientPemPath=/path/to/your/key.pem
dotnet test
```

**Or update appsettings.json (not recommended for security):**
```json
{
  "Testing": { "UseMockClient": false },
  "IBKR": {
    "ClientId": "YOUR_CLIENT_ID",
    "Credential": "YOUR_USERNAME",
    "ClientKeyId": "YOUR_KEY_ID",
    "ClientPemPath": "C:\\path\\to\\your\\key.pem"
  }
}
```

### Run Specific Tests

```bash
# Run only FyiService tests
dotnet test --filter "FullyQualifiedName~FyiServiceTests"

# Run only one test
dotnet test --filter "FullyQualifiedName~UnreadNumber_ShouldReturnData"
```

## CI/CD Testing Strategy

### GitHub Actions Configuration

The CI/CD workflow uses mocks by default (no environment variables set):

```yaml
- name: 🧪 Run NSwag tests (with mocks)
  working-directory: src/NSwag
  run: |
    dotnet test IBKR.Api.NSwag.Tests/IBKR.Api.NSwag.Tests.csproj \
      --configuration Release \
      --logger "trx;LogFileName=test-results.trx" \
      --logger "console;verbosity=detailed"
```

Tests automatically use mocks because:
1. `appsettings.json` has `UseMockClient: true` by default
2. No environment variables are set in CI to override this
3. Empty credentials in config trigger mock mode

### Local Integration Testing

For local development with real API, use environment variables:

1. Set `Testing__UseMockClient=false`
2. Set all IBKR credentials as environment variables
3. Ensure Client Portal Gateway is running (if needed)
4. Run tests

## Best Practices

✅ **Do:**
- Use mocks in CI/CD for speed and reliability
- Implement only the mock methods you actually test
- Use realistic test data in mocks
- Use environment variables for credentials (not config files)
- Keep integration tests separate (use test categories)
- Add `[Fact(Skip = "...")]` for tests needing mock implementation

❌ **Don't:**
- Commit real API credentials to source control
- Run integration tests in CI/CD by default
- Store credentials in appsettings.json (use environment variables)
- Implement all mock methods at once (do it incrementally)
- Forget to handle null cases in tests

## Test Organization

```
Tests/
├── appsettings.json                    # Default config (mocks)
├── appsettings.test.json               # CI/CD config (mocks)
├── appsettings.development.json        # Local config (optional real API)
├── TestFixture.cs                      # DI container setup
├── FyiServiceTests.cs                  # Unit tests
└── IntegrationTests/
    └── FyiServiceIntegrationTests.cs   # Real API tests (skip in CI)
```

## Troubleshooting

### "No canned response configured for: /path"

**Cause:** Mock not implemented for that endpoint

**Solution:** Implement the mock method or add canned response

### Tests passing locally but failing in CI

**Cause:** Local tests using real API, CI using mocks

**Solution:** Ensure mocks are properly implemented

### "UseMockClient not found"

**Cause:** Missing appsettings.json

**Solution:** Ensure appsettings.json exists and is copied to output

## Next Steps

- **[NSwag SDK Guide](NSWAG-SDK.md)** - Service-oriented testing patterns
- **[Kiota SDK Guide](KIOTA-SDK.md)** - Fluent API testing patterns
- **[Architecture](ARCHITECTURE.md)** - Understand test infrastructure generation

---

**Questions?** Open an issue at https://github.com/paulfryer/ibkr/issues
