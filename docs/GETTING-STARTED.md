# Getting Started with IBKR SDKs

This guide walks you through installing and making your first API call with the IBKR SDKs.

## Prerequisites

- **.NET 8.0 SDK** or later ([Download](https://dotnet.microsoft.com/download))
- **Interactive Brokers Account** with Client Portal API access
- **Basic C# knowledge**
- **IDE**: Visual Studio 2022, VS Code, or Rider

## Installation

### ⭐ Recommended: IBKR SDK

Production-ready abstraction with comprehensive error handling and strongly-typed models:

```bash
dotnet add package IBKR.Sdk.Contract
dotnet add package IBKR.Sdk.Client
dotnet add package IBKR.Sdk.Authentication
```

### Alternative: Lower-Level SDKs

<details>
<summary><b>NSwag SDK</b> (Service-Oriented)</summary>

```bash
dotnet add package IBKR.Api.NSwag.Contract
dotnet add package IBKR.Api.NSwag.Client
```
</details>

<details>
<summary><b>Kiota SDK</b> (Fluent API)</summary>

```bash
dotnet add package IBKR.Api.Kiota.Contract
dotnet add package IBKR.Api.Kiota.Client
```
</details>

**Not sure which to choose?** Read the [SDK Comparison](SDK-COMPARISON.md) or start with the **IBKR SDK** for the best experience.

## Authentication Setup

Interactive Brokers uses **session-based authentication** via the Client Portal Gateway.

### 1. Start the Client Portal Gateway

Download and run the Client Portal Gateway from Interactive Brokers:

1. Download from: https://www.interactivebrokers.com/en/trading/ibportal.php
2. Extract and run: `bin/run.sh` (Unix) or `bin\run.bat` (Windows)
3. Gateway runs on `https://localhost:5000` by default
4. Log in via browser at `https://localhost:5000`

### 2. Configure Base URL

```csharp
// Base URL for Client Portal Gateway
const string baseUrl = "https://localhost:5000";
```

⚠️ **Important:** The Gateway uses a self-signed certificate. You'll need to:
- Accept the certificate in your browser first
- Or configure your HttpClient to allow self-signed certificates (see below)

## Your First API Call

### IBKR SDK Example ⭐ (Recommended)

```csharp
using IBKR.Sdk.Authentication;
using IBKR.Sdk.Client.Services;
using IBKR.Sdk.Contract.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

// Configure services
var services = new ServiceCollection();

// Configure IBKR settings
services.Configure<IBKRSettings>(options =>
{
    options.ClientId = "your-client-id";
    options.ClientSecret = "your-client-secret";
    options.BaseUrl = "https://localhost:5000/v1/api";
});

// Register authentication
services.AddSingleton<IIBKRAuthenticationProvider, IBKRAuthenticationProvider>();

// Register option service
services.AddTransient<IOptionService, OptionService>();

var serviceProvider = services.BuildServiceProvider();

try
{
    // Get option service
    var optionService = serviceProvider.GetRequiredService<IOptionService>();

    // Get option chain for AAPL expiring in next 30 days
    var chain = await optionService.GetOptionChainAsync(
        "AAPL",
        DateTime.UtcNow,
        DateTime.UtcNow.AddDays(30));

    Console.WriteLine($"Symbol: {chain.Symbol}");
    Console.WriteLine($"Total Contracts: {chain.Contracts.Count}");

    foreach (var contract in chain.Contracts.Take(5))
    {
        Console.WriteLine($"{contract.Symbol} {contract.Right} " +
                         $"Strike: {contract.Strike:C} " +
                         $"Exp: {contract.Expiration:yyyy-MM-dd}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

**Output:**
```
Symbol: AAPL
Total Contracts: 156
AAPL Call Strike: $90.00 Exp: 2025-10-17
AAPL Call Strike: $95.00 Exp: 2025-10-17
AAPL Put Strike: $90.00 Exp: 2025-10-17
AAPL Put Strike: $95.00 Exp: 2025-10-17
...
```

**Why use IBKR SDK?**
- ✅ Strongly-typed models (DateTime, decimal, enums)
- ✅ Comprehensive error handling
- ✅ API quirks handled automatically
- ✅ Thread-safe authentication
- ✅ Production-ready from day one

---

### NSwag SDK Example 🔷 (Lower-Level)

```csharp
using IBKR.Api.NSwag.Client;
using IBKR.Api.NSwag.Contract.Interfaces;

// Setup HttpClient
var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://localhost:5000")
};

// For development: Accept self-signed certificate
var handler = new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
};
httpClient = new HttpClient(handler)
{
    BaseAddress = new Uri("https://localhost:5000")
};

// Create service instance
var fyiService = new FyiService("https://localhost:5000", httpClient);

try
{
    // Get unread notification count
    var response = await fyiService.UnreadnumberAsync();
    Console.WriteLine($"Unread notifications: {response.UnreadCount}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

### Kiota SDK Example 🔶 (Lower-Level)

```csharp
using IBKR.Api.Kiota.Client;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

// Setup authentication (no API key needed - session-based)
var authProvider = new AnonymousAuthenticationProvider();

// Configure HttpClient for self-signed certificate
var handler = new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
};
var httpClient = new HttpClient(handler);

// Create request adapter
var requestAdapter = new HttpClientRequestAdapter(authProvider, httpClient: httpClient)
{
    BaseUrl = "https://localhost:5000"
};

// Create client
var client = new IBKRClient(requestAdapter);

try
{
    // Get unread notification count
    var response = await client.Fyi.Unreadnumber.GetAsync();
    Console.WriteLine($"Unread notifications: {response?.UnreadCount}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

## Common Setup: Dependency Injection

For production applications, use dependency injection:

### NSwag with DI 🔷

```csharp
// Program.cs or Startup.cs
public void ConfigureServices(IServiceCollection services)
{
    // Configure HttpClient
    services.AddHttpClient<IFyiService, FyiService>(client =>
    {
        client.BaseAddress = new Uri("https://localhost:5000");
    })
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
    });

    // Register all services you need
    services.AddTransient<IFyiService, FyiService>();
    services.AddTransient<IGwService, GwService>();
    services.AddTransient<IAccountService, AccountService>();
}

// Usage in controllers/services
public class NotificationController : ControllerBase
{
    private readonly IFyiService _fyiService;

    public NotificationController(IFyiService fyiService)
    {
        _fyiService = fyiService;
    }

    [HttpGet("unread-count")]
    public async Task<ActionResult<int>> GetUnreadCount()
    {
        var response = await _fyiService.UnreadnumberAsync();
        return Ok(response.UnreadCount);
    }
}
```

### Kiota with DI 🔶

```csharp
// Program.cs or Startup.cs
public void ConfigureServices(IServiceCollection services)
{
    // Register authentication provider
    services.AddSingleton<IAuthenticationProvider>(
        new AnonymousAuthenticationProvider()
    );

    // Configure HttpClient
    services.AddHttpClient("IBKRClient")
        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        });

    // Register request adapter
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

    // Register client
    services.AddTransient<IBKRClient>(sp =>
    {
        var adapter = sp.GetRequiredService<IRequestAdapter>();
        return new IBKRClient(adapter);
    });
}

// Usage in controllers/services
public class NotificationController : ControllerBase
{
    private readonly IBKRClient _client;

    public NotificationController(IBKRClient client)
    {
        _client = client;
    }

    [HttpGet("unread-count")]
    public async Task<ActionResult<int>> GetUnreadCount()
    {
        var response = await _client.Fyi.Unreadnumber.GetAsync();
        return Ok(response?.UnreadCount);
    }
}
```

## Configuration with appsettings.json

Store configuration in `appsettings.json`:

```json
{
  "IBKR": {
    "BaseUrl": "https://localhost:5000",
    "AllowSelfSignedCertificate": true,
    "Timeout": 30
  }
}
```

Load in your app:

```csharp
// Read configuration
var config = builder.Configuration.GetSection("IBKR");
var baseUrl = config["BaseUrl"];
var allowSelfSigned = config.GetValue<bool>("AllowSelfSignedCertificate");
var timeout = config.GetValue<int>("Timeout");

// Apply to HttpClient
services.AddHttpClient<IFyiService, FyiService>(client =>
{
    client.BaseAddress = new Uri(baseUrl);
    client.Timeout = TimeSpan.FromSeconds(timeout);
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = allowSelfSigned
        ? (message, cert, chain, errors) => true
        : null
});
```

## Common Errors & Solutions

### ❌ "HttpRequestException: The SSL connection could not be established"

**Cause:** Self-signed certificate from Client Portal Gateway

**Solution:**
```csharp
var handler = new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
};
```

⚠️ **Production Warning:** Only bypass certificate validation in development. Use proper certificates in production.

### ❌ "401 Unauthorized"

**Cause:** Not authenticated with Client Portal Gateway

**Solution:**
1. Open browser: `https://localhost:5000`
2. Log in with your IBKR credentials
3. Leave browser open (maintains session)
4. Run your application

### ❌ "Connection refused" or "No connection could be made"

**Cause:** Client Portal Gateway not running

**Solution:**
1. Start the Gateway: `bin/run.sh` or `bin\run.bat`
2. Wait for "Gateway ready" message
3. Verify it's accessible: `https://localhost:5000`

### ❌ "Task was canceled" or Timeout

**Cause:** Request took too long

**Solution:**
```csharp
httpClient.Timeout = TimeSpan.FromSeconds(60); // Increase timeout
```

## Testing Your Setup

Create a simple console app to test:

```bash
dotnet new console -n IBKRTest
cd IBKRTest
dotnet add package IBKR.Api.NSwag.Contract  # or Kiota
dotnet add package IBKR.Api.NSwag.Client    # or Kiota
```

Replace `Program.cs` with one of the examples above and run:

```bash
dotnet run
```

Expected output:
```
Unread notifications: 3
```

## Next Steps

Now that you have the SDK working:

1. **Explore the API**
   - [NSwag SDK Guide](NSWAG-SDK.md) - Service-oriented patterns
   - [Kiota SDK Guide](KIOTA-SDK.md) - Fluent API patterns

2. **Add Testing**
   - [Testing Guide](TESTING.md) - Mock vs real implementations

3. **Understand the Architecture**
   - [Architecture Overview](ARCHITECTURE.md) - How the SDKs are generated

4. **Production Deployment**
   - Replace `localhost:5000` with your production Gateway URL
   - Use proper SSL certificates
   - Implement proper authentication handling
   - Add retry policies and circuit breakers

## Additional Resources

- **[IBKR Client Portal API Docs](https://ibkrcampus.com/ibkr-api-page/cpapi-v1/)** - Official API documentation
- **[IBKR Client Portal Gateway](https://www.interactivebrokers.com/en/trading/ibportal.php)** - Download the gateway
- **[SDK Comparison](SDK-COMPARISON.md)** - Choose between NSwag and Kiota
- **[GitHub Issues](https://github.com/paulfryer/ibkr/issues)** - Report problems or ask questions

---

**Questions?** Open an issue at https://github.com/paulfryer/ibkr/issues
