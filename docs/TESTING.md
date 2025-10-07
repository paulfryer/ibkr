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
  }
}

// appsettings.test.json (CI/CD - forces mocks)
{
  "Testing": {
    "UseMockClient": true
  }
}

// appsettings.development.json (Local - optionally use real API)
{
  "Testing": {
    "UseMockClient": false
  },
  "IBKR": {
    "BaseUrl": "https://localhost:5000"
  }
}
```

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
            Console.WriteLine("[Test Setup] Using MOCK client implementations");
            services.AddTransient<IFyiService, MockFyiService>();
        }
        else
        {
            Console.WriteLine("[Test Setup] Using REAL client implementations");
            var baseUrl = Configuration["IBKR:BaseUrl"] ?? "https://localhost:5000";
            services.AddHttpClient<IFyiService, FyiService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });
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
            Console.WriteLine("[Test Setup] Using MOCK request adapter");
            services.AddSingleton<IRequestAdapter, MockRequestAdapter>();
        }
        else
        {
            Console.WriteLine("[Test Setup] Using REAL request adapter");
            var baseUrl = Configuration["IBKR:BaseUrl"] ?? "https://localhost:5000";

            services.AddSingleton<IAuthenticationProvider>(new AnonymousAuthenticationProvider());
            services.AddHttpClient("IBKRClient");
            services.AddSingleton<IRequestAdapter>(sp =>
            {
                var authProvider = sp.GetRequiredService<IAuthenticationProvider>();
                var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient("IBKRClient");

                return new HttpClientRequestAdapter(authProvider, httpClient: httpClient)
                {
                    BaseUrl = baseUrl
                };
            });
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

```bash
# Create appsettings.development.json locally
cat > appsettings.development.json <<EOF
{
  "Testing": {
    "UseMockClient": false
  },
  "IBKR": {
    "BaseUrl": "https://localhost:5000"
  }
}
EOF

# Run tests
dotnet test
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

The workflow uses `appsettings.test.json` to force mock usage:

```yaml
- name: 🧪 Run tests (with mocks)
  run: |
    dotnet test --configuration Release \
      --logger "trx;LogFileName=test-results.trx" \
      --no-build
```

Tests automatically use mocks because `appsettings.test.json` takes precedence.

### Local Integration Testing

For local development with real API:

1. Create `appsettings.development.json` (gitignored)
2. Set `UseMockClient: false`
3. Start Client Portal Gateway
4. Run tests

## Best Practices

✅ **Do:**
- Use mocks in CI/CD for speed and reliability
- Implement only the mock methods you actually test
- Use realistic test data in mocks
- Keep integration tests separate (use test categories)
- Add `[Fact(Skip = "...")]` for tests needing mock implementation

❌ **Don't:**
- Commit real API credentials
- Run integration tests in CI/CD by default
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
