# IBKR.Sdk.Client

A clean, intuitive .NET SDK for Interactive Brokers Client Portal API with AWS SDK-like developer experience.

[![NuGet](https://img.shields.io/nuget/v/IBKR.Sdk.Client.svg)](https://www.nuget.org/packages/IBKR.Sdk.Client/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

## Why This SDK?

The IBKR Client Portal API is powerful but has a complex, inconsistent surface. This SDK provides:

- **Clean, typed interfaces** - No raw JSON, no confusing generated code in your application
- **AWS SDK-like DX** - Simple setup with `services.AddIBKRSdk()`
- **Production-ready** - Handles authentication, token refresh, session management automatically
- **Dependency injection native** - Built for modern .NET with full DI support
- **Option chain discovery** - Find available strikes and expirations for any symbol

## Quick Start

### Installation

```bash
dotnet add package IBKR.Sdk.Client
```

### Basic Setup (Environment Variables - Recommended)

**1. Set environment variables:**
```bash
export IBKR_CLIENT_ID="TESTCONS"
export IBKR_CREDENTIAL="your_username"
export IBKR_CLIENT_KEY_ID="your-kid-from-ibkr"
export IBKR_CLIENT_PEM_PATH="/path/to/private-key.pem"
```

**2. Create a console app in Program.cs:**
```csharp
using IBKR.Sdk.Client;
using IBKR.Sdk.Contract.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Add IBKR SDK - automatically reads environment variables
builder.Services.AddIBKRSdk();

var host = builder.Build();

// Get service and fetch option chain
var optionService = host.Services.GetRequiredService<IOptionService>();

var chain = await optionService.GetOptionChainAsync(
    symbol: "AAPL",
    expirationStart: DateTime.Today,
    expirationEnd: DateTime.Today.AddDays(30)
);

foreach (var contract in chain.Contracts)
{
    Console.WriteLine($"{contract.Symbol} {contract.Expiration:yyyy-MM-dd} {contract.Strike:F2} {contract.Right}");
}
```

> **Note**: For ASP.NET Core web applications, use `WebApplication.CreateBuilder(args)` instead of `Host.CreateApplicationBuilder(args)`. For simple scripts without the host, you can use `ServiceCollection` directly.

## Configuration Options

### 1. Environment Variables (Recommended)

The SDK automatically reads environment variables:
- `IBKR_CLIENT_ID` - Your client/consumer ID (e.g., "TESTCONS")
- `IBKR_CREDENTIAL` - Your IBKR username
- `IBKR_CLIENT_KEY_ID` - Your key ID (kid)
- `IBKR_CLIENT_PEM_PATH` - Path to your RSA private key PEM file
- `IBKR_BASE_URL` - Optional, defaults to `https://api.ibkr.com`

```bash
export IBKR_CLIENT_ID="TESTCONS"
export IBKR_CREDENTIAL="your_username"
export IBKR_CLIENT_KEY_ID="your-kid"
export IBKR_CLIENT_PEM_PATH="/path/to/key.pem"
```

```csharp
builder.Services.AddIBKRSdk();  // Automatically uses env vars
```

### 2. Configuration File

**appsettings.json:**
```json
{
  "IBKR": {
    "ClientId": "TESTCONS",
    "Credential": "your_username",
    "ClientKeyId": "your-kid",
    "ClientPemPath": "/path/to/private-key.pem",
    "BaseUrl": "https://api.ibkr.com"
  }
}
```

**Program.cs:**
```csharp
builder.Services.AddIBKRSdk(builder.Configuration.GetSection("IBKR"));
```

### 3. Configuration Action

```csharp
builder.Services.AddIBKRSdk(options =>
{
    options.ClientId = "TESTCONS";
    options.Credential = "your_username";
    options.ClientKeyId = "your-kid";
    options.ClientPemPath = "/path/to/private-key.pem";
    options.BaseUrl = "https://api.ibkr.com";
});
```

## Authentication Setup

The SDK uses OAuth2 with JWT signing. You'll need:

1. **OAuth2 Credentials from IBKR**:
   - Contact IBKR API team through their API support channels to request OAuth2 access
   - Generate a 3072-bit RSA key pair for signing JWTs
   - Register your public key with IBKR and receive your `kid` (Key ID)
   - Download/save your private key PEM file

2. **Client ID**: Usually "TESTCONS" for paper trading, your assigned consumer ID for live

3. **Credential**: Your IBKR account username

See [IBKR OAuth Documentation](https://www.interactivebrokers.com/campus/ibkr-api-page/oauth-1-0a-extended/) for details.

## Available Services

### IOptionService

Get option chains with comprehensive market data:

```csharp
public interface IOptionService
{
    Task<OptionChain> GetOptionChainAsync(
        string symbol,
        DateTime expirationStart,
        DateTime expirationEnd,
        CancellationToken cancellationToken = default
    );
}
```

**OptionChain Model:**
```csharp
public class OptionChain
{
    public string Symbol { get; set; }
    public int UnderlyingContractId { get; set; }
    public List<OptionContract> Contracts { get; set; }
    public DateTime RequestedExpirationStart { get; set; }
    public DateTime RequestedExpirationEnd { get; set; }
    public DateTime RetrievedAt { get; set; }
}

public class OptionContract
{
    public int ContractId { get; set; }
    public int UnderlyingContractId { get; set; }
    public string Symbol { get; set; }
    public OptionRight Right { get; set; }         // Call or Put enum
    public decimal Strike { get; set; }
    public DateTime Expiration { get; set; }
    public string TradingClass { get; set; }
    public string Exchange { get; set; }
    public string Currency { get; set; }
    public decimal Multiplier { get; set; }
    public string[] ValidExchanges { get; set; }
    public int? DaysUntilExpiration { get; set; }
}
```

> **Note**: Current version returns contract metadata only. Market data support (Greeks, IV, Bid/Ask, Volume) coming in future release.

### Example: Filter Options by Strike Range

```csharp
var chain = await _options.GetOptionChainAsync("TSLA", DateTime.Today, DateTime.Today.AddDays(7));

var nearMoneyOptions = chain.Contracts
    .Where(c => c.Strike >= 200 && c.Strike <= 250)
    .OrderBy(c => c.Expiration)
    .ThenBy(c => c.Strike);

foreach (var contract in nearMoneyOptions)
{
    Console.WriteLine($"{contract.Expiration:yyyy-MM-dd} {contract.Strike:F2} {contract.Right}");
}
```

## Architecture

This SDK follows a layered architecture:

```
Your Application
    ↓
IBKR.Sdk.Client (this package) - Clean, intuitive API
    ↓
IBKR.Api.NSwag.Authentication - OAuth2 + JWT authentication
    ↓
IBKR.Api.NSwag.Client - Generated client (auto-updated)
    ↓
IBKR Client Portal API
```

**Key Design Principles:**
- **Abstractions over implementations** - Code against `IOptionService`, not implementation details
- **Clean models** - No `Anonymous`, `Anonymous2`, or confusing generated types
- **Automatic workarounds** - Handles IBKR API quirks (array serialization, etc.) transparently
- **Production-ready** - Thread-safe, handles token caching, automatic session init

## Error Handling

```csharp
try
{
    var chain = await _options.GetOptionChainAsync("INVALID", DateTime.Today, DateTime.Today.AddDays(7));
}
catch (InvalidOperationException ex) when (ex.Message.Contains("not found"))
{
    // Symbol not found
}
catch (HttpRequestException ex)
{
    // Network/API error
}
```

## Advanced: Direct API Access

If you need functionality not yet wrapped by the SDK, you can access the underlying NSwag client:

```csharp
using IBKR.Api.NSwag.Contract.Interfaces;

public class MyService
{
    private readonly IIserverService _nswagClient;

    public MyService(IIserverService nswagClient)
    {
        _nswagClient = nswagClient;
    }

    public async Task<object> CallDirectAPI()
    {
        return await _nswagClient.SomeMethodNotYetWrappedAsync();
    }
}
```

The SDK automatically registers the NSwag client with authentication configured.

## Related Packages

This is the high-level SDK. For lower-level access or different code generators:

- **[IBKR.Api.Authentication](https://www.nuget.org/packages/IBKR.Api.Authentication)** - Core OAuth2 + JWT authentication
- **[IBKR.Api.NSwag.Client](https://www.nuget.org/packages/IBKR.Api.NSwag.Client)** - NSwag-generated client
- **[IBKR.Api.NSwag.Authentication](https://www.nuget.org/packages/IBKR.Api.NSwag.Authentication)** - NSwag authentication adapter
- **[IBKR.Api.Kiota.Client](https://www.nuget.org/packages/IBKR.Api.Kiota.Client)** - Kiota-generated client (alternative)
- **[IBKR.Api.Kiota.Authentication](https://www.nuget.org/packages/IBKR.Api.Kiota.Authentication)** - Kiota authentication adapter

## Support

- **Issues**: [GitHub Issues](https://github.com/paulfryer/ibkr/issues)
- **Repository**: [github.com/paulfryer/ibkr](https://github.com/paulfryer/ibkr)
