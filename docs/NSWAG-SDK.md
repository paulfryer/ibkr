# NSwag SDK Guide

The NSwag SDK provides a **service-oriented architecture** for accessing the Interactive Brokers Client Portal API. If you're familiar with traditional .NET Web API clients and dependency injection patterns, this SDK will feel natural.

## Architecture Overview

```
┌─────────────────────────────────┐
│  Your Application (DI Container)│
└────────────┬────────────────────┘
             │
             │ Constructor Injection
             │
    ┌────────▼─────────┐
    │  Service         │
    │  Interfaces      │
    ├──────────────────┤
    │ IFyiService      │◄─── Testable
    │ IGwService       │     (mockable)
    │ IAccountService  │
    │ ...              │
    └────────┬─────────┘
             │
             │ Implemented by
             │
    ┌────────▼─────────┐
    │  HTTP Client     │
    │  Implementations │
    ├──────────────────┤
    │ FyiService       │
    │ GwService        │
    │ AccountService   │
    │ ...              │
    └──────────────────┘
```

## Project Structure

The NSwag SDK consists of two main packages:

### IBKR.Api.NSwag.Contract
Contains:
- **Model Classes**: POCOs representing API request/response models
- **Service Interfaces**: Contracts for each API service area
- **Enums**: Type-safe enumerations

```csharp
// Example interface
public interface IFyiService
{
    Task<Response> UnreadnumberAsync(CancellationToken cancellationToken = default);
    Task<ICollection<Anonymous>> NotificationsAllAsync(string max, ...);
    Task<ICollection<Anonymous2>> SettingsAllAsync(CancellationToken cancellationToken = default);
    // ... more methods
}
```

### IBKR.Api.NSwag.Client
Contains:
- **Service Implementations**: Concrete classes that make HTTP calls
- **HTTP Client Logic**: Request/response handling

```csharp
// Example implementation
public class FyiService : IFyiService
{
    private readonly HttpClient _httpClient;

    public FyiService(string baseUrl, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(baseUrl);
    }

    public async Task<Response> UnreadnumberAsync(CancellationToken cancellationToken = default)
    {
        // HTTP call implementation
    }
}
```

## Installation

```bash
dotnet add package IBKR.Api.NSwag.Contract
dotnet add package IBKR.Api.NSwag.Client
```

## Basic Usage

### Without Dependency Injection

```csharp
using IBKR.Api.NSwag.Client;
using IBKR.Api.NSwag.Contract.Interfaces;

// Setup HttpClient
var httpClient = new HttpClient();
var baseUrl = "https://localhost:5000";

// Create service instances
var fyiService = new FyiService(baseUrl, httpClient);
var gwService = new GwService(baseUrl, httpClient);

// Make API calls
var unreadCount = await fyiService.UnreadnumberAsync();
var sessions = await gwService.SessionsAsync();
```

### With Dependency Injection (Recommended)

```csharp
// Startup.cs or Program.cs
public void ConfigureServices(IServiceCollection services)
{
    var baseUrl = "https://localhost:5000";

    // Register services with HttpClientFactory
    services.AddHttpClient<IFyiService, FyiService>(client =>
    {
        client.BaseAddress = new Uri(baseUrl);
        client.Timeout = TimeSpan.FromSeconds(30);
    });

    services.AddHttpClient<IGwService, GwService>(client =>
    {
        client.BaseAddress = new Uri(baseUrl);
    });

    services.AddHttpClient<IAccountService, AccountService>(client =>
    {
        client.BaseAddress = new Uri(baseUrl);
    });
}
```

Then inject into your classes:

```csharp
public class TradingService
{
    private readonly IFyiService _fyiService;
    private readonly IAccountService _accountService;

    public TradingService(IFyiService fyiService, IAccountService accountService)
    {
        _fyiService = fyiService;
        _accountService = accountService;
    }

    public async Task<decimal> GetAccountBalanceAsync()
    {
        var accounts = await _accountService.AccountsAsync();
        // ... process accounts
    }
}
```

## Service Organization

Services are organized by API domain:

| Service Interface | Purpose | Key Methods |
|-------------------|---------|-------------|
| `IFyiService` | Notifications & FYI | `UnreadnumberAsync()`, `NotificationsAllAsync()` |
| `IGwService` | Gateway management | `SessionsAsync()`, `AuthStatusAsync()` |
| `IAccountService` | Account information | `AccountsAsync()`, `SummaryAsync()` |
| `IPortfolioService` | Portfolio data | `PositionsAsync()`, `AllocationAsync()` |
| `ITradesService` | Order management | `OrdersAsync()`, `PlaceOrderAsync()` |

**Full list**: See `IBKR.Api.NSwag.Contract.Interfaces` namespace

## Advanced Patterns

### Configuration from appsettings.json

```json
{
  "IBKR": {
    "BaseUrl": "https://localhost:5000",
    "Timeout": 30,
    "RetryCount": 3
  }
}
```

```csharp
public void ConfigureServices(IServiceCollection services)
{
    var ibkrConfig = Configuration.GetSection("IBKR");
    var baseUrl = ibkrConfig["BaseUrl"];
    var timeout = ibkrConfig.GetValue<int>("Timeout");

    services.AddHttpClient<IFyiService, FyiService>(client =>
    {
        client.BaseAddress = new Uri(baseUrl);
        client.Timeout = TimeSpan.FromSeconds(timeout);
    });
}
```

### Retry Policies with Polly

```bash
dotnet add package Microsoft.Extensions.Http.Polly
```

```csharp
services.AddHttpClient<IFyiService, FyiService>(client =>
{
    client.BaseAddress = new Uri(baseUrl);
})
.AddTransientHttpErrorPolicy(policyBuilder =>
    policyBuilder.WaitAndRetryAsync(
        retryCount: 3,
        sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
        onRetry: (outcome, timespan, retryAttempt, context) =>
        {
            Console.WriteLine($"Retry {retryAttempt} after {timespan.TotalSeconds}s");
        }
    )
);
```

### Circuit Breaker Pattern

```csharp
services.AddHttpClient<IFyiService, FyiService>(client =>
{
    client.BaseAddress = new Uri(baseUrl);
})
.AddTransientHttpErrorPolicy(policyBuilder =>
    policyBuilder.CircuitBreakerAsync(
        handledEventsAllowedBeforeBreaking: 5,
        durationOfBreak: TimeSpan.FromMinutes(1),
        onBreak: (outcome, timespan) =>
        {
            Console.WriteLine($"Circuit breaker opened for {timespan.TotalSeconds}s");
        },
        onReset: () =>
        {
            Console.WriteLine("Circuit breaker reset");
        }
    )
);
```

### Custom HttpMessageHandler

```csharp
public class AuthenticationHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // Add authentication headers
        request.Headers.Add("X-Custom-Auth", "your-token");

        return await base.SendAsync(request, cancellationToken);
    }
}

// Register
services.AddTransient<AuthenticationHandler>();

services.AddHttpClient<IFyiService, FyiService>()
    .AddHttpMessageHandler<AuthenticationHandler>();
```

### Logging HTTP Requests

```csharp
public class LoggingHandler : DelegatingHandler
{
    private readonly ILogger<LoggingHandler> _logger;

    public LoggingHandler(ILogger<LoggingHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request: {Method} {Url}", request.Method, request.RequestUri);

        var response = await base.SendAsync(request, cancellationToken);

        _logger.LogInformation("Response: {StatusCode}", response.StatusCode);

        return response;
    }
}

// Register
services.AddTransient<LoggingHandler>();
services.AddHttpClient<IFyiService, FyiService>()
    .AddHttpMessageHandler<LoggingHandler>();
```

## Testing with Mocks

The SDK includes `IBKR.Api.NSwag.MockClient` for testing:

```csharp
using IBKR.Api.NSwag.MockClient.Services;

public class NotificationServiceTests
{
    [Fact]
    public async Task GetUnreadCount_ReturnsExpectedValue()
    {
        // Arrange
        var mockFyiService = new MockFyiService();
        mockFyiService.SetCannedResponse("UnreadnumberAsync", new Response
        {
            UnreadCount = 5
        });

        var service = new NotificationService(mockFyiService);

        // Act
        var count = await service.GetUnreadCountAsync();

        // Assert
        Assert.Equal(5, count);
    }
}
```

See [Testing Guide](TESTING.md) for comprehensive testing patterns.

## Error Handling

```csharp
public class SafeFyiService
{
    private readonly IFyiService _fyiService;
    private readonly ILogger<SafeFyiService> _logger;

    public SafeFyiService(IFyiService fyiService, ILogger<SafeFyiService> logger)
    {
        _fyiService = fyiService;
        _logger = logger;
    }

    public async Task<int> GetUnreadCountAsync()
    {
        try
        {
            var response = await _fyiService.UnreadnumberAsync();
            return response.UnreadCount;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP error while fetching unread count");
            return 0; // Fallback value
        }
        catch (TaskCanceledException ex)
        {
            _logger.LogError(ex, "Request timeout while fetching unread count");
            return 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error while fetching unread count");
            throw; // Re-throw unknown exceptions
        }
    }
}
```

## Performance Optimization

### Use HttpClientFactory

✅ **Do this:**
```csharp
services.AddHttpClient<IFyiService, FyiService>();
```

❌ **Don't do this:**
```csharp
var service = new FyiService(baseUrl, new HttpClient()); // Creates new HttpClient every time
```

### Connection Pooling

```csharp
services.AddHttpClient<IFyiService, FyiService>()
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        MaxConnectionsPerServer = 10, // Adjust based on your needs
        PooledConnectionLifetime = TimeSpan.FromMinutes(5)
    });
```

### Async Best Practices

✅ **Do this:**
```csharp
public async Task<int> GetUnreadCountAsync()
{
    var response = await _fyiService.UnreadnumberAsync();
    return response.UnreadCount;
}
```

❌ **Don't do this:**
```csharp
public int GetUnreadCount()
{
    var response = _fyiService.UnreadnumberAsync().Result; // Blocks thread
    return response.UnreadCount;
}
```

## Migration from Other SDKs

### From Kiota SDK

**Before (Kiota):**
```csharp
var client = new IBKRClient(requestAdapter);
var response = await client.Fyi.Unreadnumber.GetAsync();
```

**After (NSwag):**
```csharp
var fyiService = serviceProvider.GetRequiredService<IFyiService>();
var response = await fyiService.UnreadnumberAsync();
```

**Key Changes:**
1. Replace `IBKRClient` with specific service interfaces
2. Update DI registrations from `IRequestAdapter` to individual services
3. Method names may differ slightly (check IntelliSense)

## Common Pitfalls

### 1. Not Disposing HttpClient Properly

❌ **Wrong:**
```csharp
using var httpClient = new HttpClient(); // Don't create HttpClient with 'using'
```

✅ **Correct:**
```csharp
services.AddHttpClient<IFyiService, FyiService>(); // Let DI manage lifecycle
```

### 2. Forgetting CancellationToken

❌ **Suboptimal:**
```csharp
var response = await _fyiService.UnreadnumberAsync();
```

✅ **Better:**
```csharp
var response = await _fyiService.UnreadnumberAsync(cancellationToken);
```

### 3. Not Handling Exceptions

❌ **Risky:**
```csharp
var response = await _fyiService.UnreadnumberAsync(); // Unhandled exceptions
```

✅ **Safe:**
```csharp
try
{
    var response = await _fyiService.UnreadnumberAsync();
}
catch (HttpRequestException ex)
{
    // Handle HTTP errors
}
```

## Best Practices Summary

✅ **Do:**
- Use HttpClientFactory for all HttpClient instances
- Inject service interfaces, not implementations
- Use async/await throughout
- Handle exceptions appropriately
- Pass CancellationToken where possible
- Configure retry policies for resilience

❌ **Don't:**
- Create HttpClient with `new HttpClient()`
- Use `.Result` or `.Wait()` on async calls
- Ignore exceptions
- Hardcode URLs (use configuration)

## Next Steps

- **[Testing Guide](TESTING.md)** - Learn testing patterns with mocks
- **[SDK Comparison](SDK-COMPARISON.md)** - Compare with Kiota SDK
- **[Architecture](ARCHITECTURE.md)** - Understand how the SDK is generated

---

**Questions?** Open an issue at https://github.com/paulfryer/ibkr/issues
