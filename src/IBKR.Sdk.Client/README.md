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
- **Comprehensive option chain support** - Simplified option trading workflows

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

**2. Configure in Program.cs:**
```csharp
using IBKR.Sdk.Client;
using IBKR.Sdk.Contract.Interfaces;

// Standard .NET web application setup
var builder = WebApplication.CreateBuilder(args);

// Add IBKR SDK - automatically reads environment variables
builder.Services.AddIBKRSdk();

var app = builder.Build();
app.Run();
```

> **Note**: `builder` is from .NET's standard `WebApplication.CreateBuilder()`. For console apps, use `HostApplicationBuilder` or a `ServiceCollection` directly.

**3. Inject and use in your services:**
```csharp
public class MyService
{
    private readonly IOptionService _options;

    public MyService(IOptionService options)
    {
        _options = options;
    }

    public async Task GetOptions()
    {
        var chain = await _options.GetOptionChainAsync(
            symbol: "AAPL",
            expirationStart: DateTime.Today,
            expirationEnd: DateTime.Today.AddDays(30)
        );

        foreach (var contract in chain.Contracts)
        {
            Console.WriteLine($"{contract.Strike} {contract.Right} - IV: {contract.ImpliedVolatility:P2}");
        }
    }
}
```

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
   - Contact IBKR API team (api-solutions@interactivebrokers.com) to request OAuth2 access
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
    public string UnderlyingSymbol { get; set; }
    public int UnderlyingConid { get; set; }
    public List<OptionContract> Contracts { get; set; }
}

public class OptionContract
{
    public int Conid { get; set; }
    public string Symbol { get; set; }        // "AAPL  250117C00150000"
    public DateTime Expiration { get; set; }
    public decimal Strike { get; set; }
    public string Right { get; set; }         // "C" or "P"

    // Greeks
    public decimal? Delta { get; set; }
    public decimal? Gamma { get; set; }
    public decimal? Theta { get; set; }
    public decimal? Vega { get; set; }

    // Pricing
    public decimal? ImpliedVolatility { get; set; }
    public decimal? Bid { get; set; }
    public decimal? Ask { get; set; }
    public decimal? Last { get; set; }

    // Volume
    public int? Volume { get; set; }
    public int? OpenInterest { get; set; }
}
```

### Example: Find Highest IV Options

```csharp
var chain = await _options.GetOptionChainAsync("TSLA", DateTime.Today, DateTime.Today.AddDays(7));

var highestIV = chain.Contracts
    .Where(c => c.ImpliedVolatility.HasValue)
    .OrderByDescending(c => c.ImpliedVolatility)
    .Take(10);

foreach (var contract in highestIV)
{
    Console.WriteLine($"{contract.Symbol} - IV: {contract.ImpliedVolatility:P2}");
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

## Roadmap

- [ ] Market data streaming
- [ ] Order placement and management
- [ ] Portfolio and account information
- [ ] Watchlist management
- [ ] Scanner support

## Contributing

Contributions welcome! This SDK is actively developed. See [CONTRIBUTING.md](../../CONTRIBUTING.md).

## License

MIT License - see [LICENSE](../../LICENSE)

## Support

- **Issues**: [GitHub Issues](https://github.com/USERNAME/REPO/issues)
- **Discussions**: [GitHub Discussions](https://github.com/USERNAME/REPO/discussions)
- **IBKR API Docs**: https://www.interactivebrokers.com/api/doc.html
