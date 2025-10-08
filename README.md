# IBKR REST API SDKs for .NET

[![Build and Release](https://github.com/paulfryer/ibkr/actions/workflows/release.yml/badge.svg)](https://github.com/paulfryer/ibkr/actions/workflows/release.yml)
![License](https://img.shields.io/badge/license-MIT-green)
![.NET](https://img.shields.io/badge/.NET-8.0-purple)

> Production-ready C# SDKs for the Interactive Brokers Client Portal Web API

## 🚀 Quick Start

### ⭐ IBKR SDK (Recommended)
Production-ready abstraction with comprehensive error handling and strongly-typed models:

```bash
dotnet add package IBKR.Sdk.Contract
dotnet add package IBKR.Sdk.Client
dotnet add package IBKR.Sdk.Authentication
```

```csharp
// ⭐ One-line setup - just like AWS SDK!
services.AddIBKRSdk(configuration.GetSection("IBKR"));

// Use the SDK
var optionService = serviceProvider.GetRequiredService<IOptionService>();
var chain = await optionService.GetOptionChainAsync(
    "AAPL",
    DateTime.UtcNow,
    DateTime.UtcNow.AddDays(30));

// All contracts are strongly typed with DateTime, enums, decimals
foreach (var contract in chain.Contracts)
{
    Console.WriteLine($"{contract.Symbol} {contract.Right} " +
                     $"Strike: {contract.Strike:C} Exp: {contract.Expiration:yyyy-MM-dd}");
}
```

**Configuration (appsettings.json):**
```json
{
  "IBKR": {
    "ClientId": "YOUR_CLIENT_ID",
    "Credential": "YOUR_USERNAME",
    "ClientKeyId": "YOUR_KEY_ID",
    "ClientPemPath": "/path/to/private-key.pem",
    "BaseUrl": "https://api.ibkr.com"
  }
}
```

Or use environment variables: `IBKR_CLIENT_ID`, `IBKR_CREDENTIAL`, `IBKR_CLIENT_KEY_ID`, `IBKR_CLIENT_PEM_PATH`

### Alternative: Lower-Level SDKs

<details>
<summary><b>NSwag SDK</b> (Service-Oriented)</summary>

```bash
dotnet add package IBKR.Api.NSwag.Contract
dotnet add package IBKR.Api.NSwag.Client
```

```csharp
// Direct API access with service interfaces
services.AddTransient<IIserverService, IserverService>();
var searchResults = await iserverService.SearchAllGETAsync(symbol: "AAPL");
```
</details>

<details>
<summary><b>Kiota SDK</b> (Fluent API)</summary>

```bash
dotnet add package IBKR.Api.Kiota.Contract
dotnet add package IBKR.Api.Kiota.Client
```

```csharp
// Fluent, discoverable API surface
var client = new IBKRClient(requestAdapter);
var results = await client.Iserver.Secdef.Search.GetAsync();
```
</details>

## 📦 What's Inside

Three SDK layers offering different levels of abstraction:

```
📁 src/
├── ⭐ IBKR SDK/        # Production-ready abstraction (Recommended)
│   ├── IBKR.Sdk.Contract       # Clean interfaces & strongly-typed models
│   ├── IBKR.Sdk.Client         # Implementation with built-in workarounds
│   ├── IBKR.Sdk.Authentication # Thread-safe session management
│   └── IBKR.Sdk.Tests          # Comprehensive test suite
│
├── 🔷 NSwag/            # Lower-level generated SDK
│   ├── Contract         # Generated models + service interfaces
│   ├── Client           # HTTP client implementations
│   ├── MockClient       # Test mocks
│   └── Tests            # Discovery & quirk testing
│
└── 🔶 Kiota/            # Lower-level generated SDK
    ├── Contract         # Generated model classes (POCOs)
    ├── Client           # Fluent request builders
    ├── MockClient       # Test mocks
    └── Tests            # Discovery & quirk testing
```

## 🎯 Which SDK Should I Use?

| Scenario | Recommended SDK | Why? |
|----------|----------------|------|
| **Production applications** | **IBKR SDK** ⭐ | Strongly-typed, built-in error handling, API quirks handled |
| **Quick prototypes** | **IBKR SDK** ⭐ | Minimal setup, comprehensive documentation |
| **Enterprise .NET apps** | **IBKR SDK** ⭐ | DI-friendly, production-ready abstractions |
| **Need lower-level control** | **NSwag** | Direct API access, service interfaces |
| **Fluent API preference** | **Kiota** | Discoverable API surface, smaller footprint |
| **SDK development/testing** | **NSwag/Kiota** | Full mock infrastructure, quirk discovery |

**→ [Detailed SDK Comparison](docs/SDK-COMPARISON.md)**

## 📚 Documentation

### Getting Started
- **[Getting Started](docs/GETTING-STARTED.md)** - Installation, first API call, authentication
- **[IBKR SDK Guide](docs/IBKR-SDK.md)** - Production-ready abstraction layer (recommended)
- **[SDK Comparison](docs/SDK-COMPARISON.md)** - Side-by-side code examples and decision guide

### SDK-Specific Guides
- **[NSwag SDK Guide](docs/NSWAG-SDK.md)** - Service-oriented architecture details
- **[Kiota SDK Guide](docs/KIOTA-SDK.md)** - Fluent API architecture details

### Development & Testing
- **[Testing Guide](docs/TESTING.md)** - Mock vs real implementations, DI patterns
- **[Architecture](docs/ARCHITECTURE.md)** - Repository structure and generation workflow
- **[Contributing](docs/CONTRIBUTING.md)** - How to regenerate SDKs and contribute
- **[Release Workflow](docs/RELEASE-WORKFLOW.md)** - CI/CD and package publishing

## 🏗️ Architecture Highlights

- ✅ **Three-Layer Architecture** - IBKR SDK → NSwag/Kiota → OpenAPI spec
- ✅ **Production-Ready Abstractions** - Built-in error handling and API quirk workarounds
- ✅ **Dual SDK Generation** - NSwag + Kiota from single OpenAPI spec
- ✅ **Automated Reorganization** - Splits generated code into Contract/Client projects
- ✅ **Comprehensive Test Suite** - High-quality logging, mocks + real API support
- ✅ **CI/CD Ready** - GitHub Actions workflow with parallel job execution
- ✅ **NuGet Packaging** - Production-ready packages with symbols

## 🔧 Development

```bash
# Generate both SDKs locally
cd src/IBKR.Api.Generator
dotnet run

# Scaffold test infrastructure
cd ../IBKR.Api.TestScaffold
dotnet run

# Build everything
cd ..
dotnet build IBKR.Sdk.sln

# Run tests (uses mocks by default)
dotnet test IBKR.Sdk.sln
```

See [Testing Guide](docs/TESTING.md) for using real IBKR API credentials.

## 📝 License

MIT License - Copyright © 2025 Paul Fryer

See [LICENSE](LICENSE) for full details.

## 🤝 Contributing

Contributions welcome! Please see [CONTRIBUTING.md](docs/CONTRIBUTING.md) for guidelines.

## 🔗 Links

- **GitHub Repository**: https://github.com/paulfryer/ibkr
- **Interactive Brokers API Docs**: https://ibkrcampus.com/ibkr-api-page/cpapi-v1/
- **Issues & Support**: https://github.com/paulfryer/ibkr/issues

---

**Note**: These SDKs are auto-generated from the Interactive Brokers OpenAPI specification. They are not officially maintained by Interactive Brokers.
