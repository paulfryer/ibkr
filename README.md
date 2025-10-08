# IBKR REST API SDKs for .NET

[![Build and Release](https://github.com/paulfryer/ibkr/actions/workflows/release.yml/badge.svg)](https://github.com/paulfryer/ibkr/actions/workflows/release.yml)
![License](https://img.shields.io/badge/license-MIT-green)
![.NET](https://img.shields.io/badge/.NET-8.0-purple)

> Production-ready C# SDKs for the Interactive Brokers Client Portal Web API

## 🚀 Quick Start

### ⭐ Clean API (Recommended)
Production-ready abstraction with comprehensive error handling and strongly-typed models:

```bash
dotnet add package IBKR.Api.Contract
dotnet add package IBKR.Api.Client
dotnet add package IBKR.Api.Authentication
```

```csharp
// Strongly-typed, clean API - no magic strings!
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
├── ⭐ Clean API/        # Production-ready abstraction (Recommended)
│   ├── IBKR.Api.Contract       # Clean interfaces & strongly-typed models
│   ├── IBKR.Api.Client         # Implementation with built-in workarounds
│   ├── IBKR.Api.Authentication # Thread-safe session management
│   └── IBKR.Api.Tests          # Comprehensive test suite
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
| Enterprise .NET apps with DI | **NSwag** | Native service interfaces, familiar patterns |
| Modern microservices | **Kiota** | Smaller footprint, fluent API |
| Testing with mocks | **Both** | Full mock infrastructure included |
| Maximum IntelliSense | **Kiota** | Fluent API provides better discoverability |

**→ [Detailed SDK Comparison](docs/SDK-COMPARISON.md)**

## 📚 Documentation

- **[Getting Started](docs/GETTING-STARTED.md)** - Installation, first API call, authentication
- **[SDK Comparison](docs/SDK-COMPARISON.md)** - Side-by-side code examples and decision guide
- **[NSwag SDK Guide](docs/NSWAG-SDK.md)** - Service-oriented architecture details
- **[Kiota SDK Guide](docs/KIOTA-SDK.md)** - Fluent API architecture details
- **[Testing Guide](docs/TESTING.md)** - Mock vs real implementations, DI patterns
- **[Architecture](docs/ARCHITECTURE.md)** - Repository structure and generation workflow
- **[Contributing](docs/CONTRIBUTING.md)** - How to regenerate SDKs and contribute
- **[Release Workflow](docs/RELEASE-WORKFLOW.md)** - CI/CD and package publishing

## 🏗️ Architecture Highlights

- ✅ **Dual SDK Generation** - NSwag + Kiota from single OpenAPI spec
- ✅ **Automated Reorganization** - Splits generated code into Contract/Client projects
- ✅ **Test Infrastructure** - MockClient + xUnit tests with DI support
- ✅ **CI/CD Ready** - GitHub Actions workflow for automated releases
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
dotnet build IBKR.Api.sln

# Run tests (uses mocks by default)
dotnet test IBKR.Api.sln
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
