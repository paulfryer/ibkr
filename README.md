# IBKR SDK for .NET

A comprehensive, production-ready .NET SDK for Interactive Brokers Client Portal API.

[![NuGet](https://img.shields.io/nuget/v/IBKR.Sdk.Client.svg)](https://www.nuget.org/packages/IBKR.Sdk.Client/)
[![Build](https://github.com/USERNAME/REPO/workflows/Build%20and%20Release/badge.svg)](https://github.com/USERNAME/REPO/actions)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

## Quick Start

**1. Install package:**
```bash
dotnet add package IBKR.Sdk.Client
```

**2. Set environment variables:**
```bash
export IBKR_CLIENT_ID="TESTCONS"
export IBKR_CREDENTIAL="your_username"
export IBKR_CLIENT_KEY_ID="your-kid-from-ibkr"
export IBKR_CLIENT_PEM_PATH="/path/to/private-key.pem"
```

**3. Configure in Program.cs:**
```csharp
using IBKR.Sdk.Client;
using IBKR.Sdk.Contract.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add IBKR SDK - automatically uses environment variables
builder.Services.AddIBKRSdk();

var app = builder.Build();
app.Run();
```

**4. Inject and use:**
```csharp
public class MyService
{
    private readonly IOptionService _options;

    public MyService(IOptionService options) => _options = options;

    public async Task GetOptions()
    {
        var chain = await _options.GetOptionChainAsync("AAPL", DateTime.Today, DateTime.Today.AddDays(30));

        foreach (var contract in chain.Contracts)
        {
            Console.WriteLine($"{contract.Symbol} - IV: {contract.ImpliedVolatility:P2}");
        }
    }
}
```

## Packages

This repository contains 9 NuGet packages organized by layer:

### 🎯 High-Level SDK (Recommended)

| Package | Description | NuGet |
|---------|-------------|-------|
| **[IBKR.Sdk.Client](src/IBKR.Sdk.Client)** | Clean, intuitive SDK with AWS-like DX | [![NuGet](https://img.shields.io/nuget/v/IBKR.Sdk.Client.svg)](https://www.nuget.org/packages/IBKR.Sdk.Client/) |
| [IBKR.Sdk.Contract](src/IBKR.Sdk.Contract) | Hand-crafted models and interfaces | [![NuGet](https://img.shields.io/nuget/v/IBKR.Sdk.Contract.svg)](https://www.nuget.org/packages/IBKR.Sdk.Contract/) |

### 🔐 Authentication

| Package | Description | NuGet |
|---------|-------------|-------|
| [IBKR.Api.Authentication](src/IBKR.Api.Authentication) | Core OAuth2 + JWT authentication | [![NuGet](https://img.shields.io/nuget/v/IBKR.Api.Authentication.svg)](https://www.nuget.org/packages/IBKR.Api.Authentication/) |
| [IBKR.Api.NSwag.Authentication](src/NSwag/IBKR.Api.NSwag.Authentication) | NSwag authentication adapter | [![NuGet](https://img.shields.io/nuget/v/IBKR.Api.NSwag.Authentication.svg)](https://www.nuget.org/packages/IBKR.Api.NSwag.Authentication/) |
| [IBKR.Api.Kiota.Authentication](src/Kiota/IBKR.Api.Kiota.Authentication) | Kiota authentication adapter | [![NuGet](https://img.shields.io/nuget/v/IBKR.Api.Kiota.Authentication.svg)](https://www.nuget.org/packages/IBKR.Api.Kiota.Authentication/) |

### ⚙️ Generated Clients (Auto-Updated)

| Package | Description | NuGet |
|---------|-------------|-------|
| [IBKR.Api.NSwag.Client](src/NSwag/IBKR.Api.NSwag.Client) | NSwag-generated HTTP client | [![NuGet](https://img.shields.io/nuget/v/IBKR.Api.NSwag.Client.svg)](https://www.nuget.org/packages/IBKR.Api.NSwag.Client/) |
| [IBKR.Api.NSwag.Contract](src/NSwag/IBKR.Api.NSwag.Contract) | NSwag-generated models | [![NuGet](https://img.shields.io/nuget/v/IBKR.Api.NSwag.Contract.svg)](https://www.nuget.org/packages/IBKR.Api.NSwag.Contract/) |
| [IBKR.Api.Kiota.Client](src/Kiota/IBKR.Api.Kiota.Client) | Kiota-generated HTTP client | [![NuGet](https://img.shields.io/nuget/v/IBKR.Api.Kiota.Client.svg)](https://www.nuget.org/packages/IBKR.Api.Kiota.Client/) |
| [IBKR.Api.Kiota.Contract](src/Kiota/IBKR.Api.Kiota.Contract) | Kiota-generated models | [![NuGet](https://img.shields.io/nuget/v/IBKR.Api.Kiota.Contract.svg)](https://www.nuget.org/packages/IBKR.Api.Kiota.Contract/) |

## Features

- ✅ **Clean API** - No confusing generated types in your code
- ✅ **AWS SDK-like DX** - Simple `AddIBKRSdk()` setup
- ✅ **Production-ready** - Handles auth, token refresh, session management automatically
- ✅ **Dependency Injection** - Built for modern .NET
- ✅ **Comprehensive Options** - Full option chain support with Greeks, IV, volume
- ✅ **Auto-generated** - Stays up-to-date with IBKR API changes
- ✅ **Dual generators** - Both NSwag and Kiota support

## Architecture

```
┌─────────────────────────────────────┐
│     Your Application Code           │
└──────────────┬──────────────────────┘
               │ IOptionService, etc.
┌──────────────▼──────────────────────┐
│   IBKR.Sdk.Client (High-level)      │
│   - Clean interfaces                │
│   - Intuitive models                │
│   - Production-ready wrappers       │
└──────────────┬──────────────────────┘
               │
┌──────────────▼──────────────────────┐
│   Authentication Layer              │
│   - OAuth2 + JWT                    │
│   - Token caching                   │
│   - Session management              │
└──────────────┬──────────────────────┘
               │
┌──────────────▼──────────────────────┐
│   Generated Clients                 │
│   - NSwag (default)                 │
│   - Kiota (alternative)             │
└──────────────┬──────────────────────┘
               │
┌──────────────▼──────────────────────┐
│   IBKR Client Portal API            │
└─────────────────────────────────────┘
```

## Documentation

- **[IBKR.Sdk.Client README](src/IBKR.Sdk.Client/README.md)** - Comprehensive usage guide
- **[IBKR API Docs](https://www.interactivebrokers.com/api/doc.html)** - Official API documentation

## Requirements

- .NET 8.0 or later
- IBKR account with OAuth2 credentials
- RSA key pair generated from IBKR portal

## Authentication Setup

You'll need OAuth2 credentials with RSA key pair from IBKR:

1. **Contact IBKR API Team**: Email api-solutions@interactivebrokers.com to request OAuth2 access
2. **Generate RSA Key Pair**: Create a 3072-bit RSA key pair for signing JWTs
3. **Register with IBKR**: Provide your public key and receive your `kid` (Key ID)
4. **Get Client ID**: Use "TESTCONS" for paper trading, or your assigned consumer ID for live
5. **Configure SDK**: Use your credentials (ClientId, Credential/username, ClientKeyId/kid, PEM file path)

See [IBKR OAuth Documentation](https://www.interactivebrokers.com/campus/ibkr-api-page/oauth-1-0a-extended/) for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

MIT License - see [LICENSE](LICENSE) for details

## Disclaimer

This is an unofficial SDK. Not affiliated with or endorsed by Interactive Brokers LLC. Use at your own risk.

## Support

- **Issues**: [GitHub Issues](https://github.com/USERNAME/REPO/issues)
- **Discussions**: [GitHub Discussions](https://github.com/USERNAME/REPO/discussions)
