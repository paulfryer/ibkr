# Kiota SDK Guide

The Kiota SDK provides a **fluent API architecture** for accessing the Interactive Brokers Client Portal API. Built on Microsoft's Kiota code generator, it offers a modern, discoverable API surface with excellent IntelliSense support.

## Architecture Overview

```
┌─────────────────────────────────┐
│  Your Application (DI Container)│
└────────────┬────────────────────┘
             │
             │ Inject IRequestAdapter
             │
    ┌────────▼─────────┐
    │  IBKRClient      │
    │                  │
    │  ┌────────────┐  │
    │  │ .Fyi       │  │◄─── Fluent
    │  │ .Gw        │  │     (discoverable)
    │  │ .Account   │  │
    │  │ .Portfolio │  │
    │  │ .Trades    │  │
    │  └────────────┘  │
    └──────────────────┘
```

## Project Structure

### IBKR.Api.Kiota.Contract
- **Model Classes**: POCOs for API data
- **Enums**: Type-safe enumerations
- No interfaces (models only)

### IBKR.Api.Kiota.Client
- **IBKRClient**: Main entry point
- **Request Builders**: Fluent API surface
- **IRequestAdapter**: Abstraction for HTTP calls

## Installation

```bash
dotnet add package IBKR.Api.Kiota.Contract
dotnet add package IBKR.Api.Kiota.Client
```

## Basic Usage

```csharp
using IBKR.Api.Kiota.Client;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

// Create authentication provider
var authProvider = new AnonymousAuthenticationProvider();

// Create request adapter
var requestAdapter = new HttpClientRequestAdapter(authProvider)
{
    BaseUrl = "https://localhost:5000"
};

// Create client
var client = new IBKRClient(requestAdapter);

// Make API calls - fluent and discoverable!
var unreadCount = await client.Fyi.Unreadnumber.GetAsync();
var sessions = await client.Gw.Sessions.GetAsync();
var accounts = await client.Account.Accounts.GetAsync();
```

## Fluent API Discovery

The power of Kiota is in its IntelliSense-driven API discovery:

```csharp
// Type "client." and IntelliSense shows all API areas:
client.
  ├─ Fyi          // Notifications
  ├─ Gw           // Gateway
  ├─ Account      // Account info
  ├─ Portfolio    // Portfolio data
  └─ Trades       // Order management

// Type "client.Fyi." and see all FYI endpoints:
client.Fyi.
  ├─ Unreadnumber
  ├─ Notifications
  ├─ Settings
  └─ Deliveryoptions

// Type "client.Fyi.Unreadnumber." to see HTTP methods:
client.Fyi.Unreadnumber.
  ├─ GetAsync()
  ├─ PostAsync()
  └─ DeleteAsync()
```

## Dependency Injection

### Recommended Setup

```csharp
// Program.cs or Startup.cs
public void ConfigureServices(IServiceCollection services)
{
    // Register authentication provider
    services.AddSingleton<IAuthenticationProvider>(
        new AnonymousAuthenticationProvider()
    );

    // Configure HttpClient
    services.AddHttpClient("IBKRClient", client =>
    {
        client.BaseAddress = new Uri("https://localhost:5000");
        client.Timeout = TimeSpan.FromSeconds(30);
    });

    // Register IRequestAdapter
    services.AddSingleton<IRequestAdapter>(sp =>
    {
        var authProvider = sp.GetRequiredService<IAuthenticationProvider>();
        var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
        var httpClient = httpClientFactory.CreateClient("IBKRClient");

        return new HttpClientRequestAdapter(authProvider, httpClient: httpClient)
        {
            BaseUrl = "https://localhost:5000"
        };
    });

    // Register IBKRClient
    services.AddTransient<IBKRClient>(sp =>
    {
        var adapter = sp.GetRequiredService<IRequestAdapter>();
        return new IBKRClient(adapter);
    });
}
```

### Usage in Controllers/Services

```csharp
public class TradingService
{
    private readonly IBKRClient _client;

    public TradingService(IBKRClient client)
    {
        _client = client;
    }

    public async Task<int> GetUnreadNotificationsAsync()
    {
        var response = await _client.Fyi.Unreadnumber.GetAsync();
        return response?.UnreadCount ?? 0;
    }
}
```

## Advanced Patterns

### Request Options & Headers

```csharp
// Add custom headers
var requestConfig = new RequestConfiguration<DefaultQueryParameters>
{
    Headers = new RequestHeaders
    {
        { "X-Custom-Header", "value" }
    }
};

var response = await client.Fyi.Unreadnumber.GetAsync(requestConfig);
```

### Query Parameters

```csharp
// Endpoints with query parameters
var notifications = await client.Fyi.Notifications.GetAsync(config =>
{
    config.QueryParameters.Max = "50";
    config.QueryParameters.Include = "unread";
});
```

### Custom IRequestAdapter

Create a custom adapter for advanced scenarios:

```csharp
public class CustomRequestAdapter : HttpClientRequestAdapter
{
    public CustomRequestAdapter(
        IAuthenticationProvider authProvider,
        HttpClient? httpClient = null)
        : base(authProvider, httpClient: httpClient)
    {
    }

    public override async Task<ModelType?> SendAsync<ModelType>(
        RequestInformation requestInfo,
        ParsableFactory<ModelType> factory,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default)
    {
        // Custom logic before request
        Console.WriteLine($"Sending request to: {requestInfo.URI}");

        var response = await base.SendAsync(requestInfo, factory, errorMapping, cancellationToken);

        // Custom logic after request
        Console.WriteLine("Request completed");

        return response;
    }
}
```

### Retry Policies

Since Kiota uses HttpClient under the hood, use Polly for retries:

```csharp
services.AddHttpClient("IBKRClient")
    .AddTransientHttpErrorPolicy(policyBuilder =>
        policyBuilder.WaitAndRetryAsync(
            retryCount: 3,
            sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt))
        )
    );
```

## Testing with MockRequestAdapter

```csharp
using IBKR.Api.Kiota.MockClient;

public class NotificationServiceTests
{
    [Fact]
    public async Task GetUnreadCount_ReturnsExpectedValue()
    {
        // Arrange
        var mockAdapter = new MockRequestAdapter();
        mockAdapter.SetCannedResponse(
            "/fyi/unreadnumber",
            new Response { UnreadCount = 5 }
        );

        var client = new IBKRClient(mockAdapter);

        // Act
        var response = await client.Fyi.Unreadnumber.GetAsync();

        // Assert
        Assert.Equal(5, response?.UnreadCount);
    }
}
```

See [Testing Guide](TESTING.md) for comprehensive testing patterns.

## Error Handling

```csharp
public async Task<int> GetUnreadCountSafelyAsync()
{
    try
    {
        var response = await _client.Fyi.Unreadnumber.GetAsync();
        return response?.UnreadCount ?? 0;
    }
    catch (ApiException ex)
    {
        // Kiota-specific exceptions
        _logger.LogError(ex, "API error: {StatusCode}", ex.ResponseStatusCode);
        return 0;
    }
    catch (HttpRequestException ex)
    {
        _logger.LogError(ex, "HTTP error");
        return 0;
    }
}
```

## Best Practices

✅ **Do:**
- Use IRequestAdapter abstraction for testability
- Leverage IntelliSense to discover API endpoints
- Use async/await throughout
- Register adapter as singleton, client as transient
- Pass CancellationToken where possible

❌ **Don't:**
- Create new HttpClientRequestAdapter for each request
- Use `.Result` or `.Wait()` on async calls
- Ignore null responses (Kiota returns nullable types)
- Hardcode URLs (use configuration)

## Common Patterns

### Configuration from appsettings.json

```json
{
  "IBKR": {
    "BaseUrl": "https://localhost:5000",
    "Timeout": 30
  }
}
```

```csharp
var config = Configuration.GetSection("IBKR");
var baseUrl = config["BaseUrl"];

services.AddHttpClient("IBKRClient", client =>
{
    client.BaseAddress = new Uri(baseUrl);
});
```

### Null Handling

Kiota returns nullable types - always check for null:

```csharp
var response = await client.Fyi.Unreadnumber.GetAsync();
if (response != null)
{
    Console.WriteLine($"Unread: {response.UnreadCount}");
}
```

## Migration from NSwag SDK

**Before (NSwag):**
```csharp
var fyiService = serviceProvider.GetRequiredService<IFyiService>();
var response = await fyiService.UnreadnumberAsync();
```

**After (Kiota):**
```csharp
var client = serviceProvider.GetRequiredService<IBKRClient>();
var response = await client.Fyi.Unreadnumber.GetAsync();
```

**Key Changes:**
1. Replace service interfaces with IBKRClient
2. Update DI from individual services to IRequestAdapter
3. Use fluent API instead of direct method calls

## API Structure

| Client Path | Purpose |
|-------------|---------|
| `client.Fyi.*` | Notifications & FYI |
| `client.Gw.*` | Gateway management |
| `client.Account.*` | Account information |
| `client.Portfolio.*` | Portfolio data |
| `client.Trades.*` | Order management |

## Next Steps

- **[Testing Guide](TESTING.md)** - Learn testing patterns with mocks
- **[SDK Comparison](SDK-COMPARISON.md)** - Compare with NSwag SDK
- **[Architecture](ARCHITECTURE.md)** - Understand how the SDK is generated

---

**Questions?** Open an issue at https://github.com/paulfryer/ibkr/issues
