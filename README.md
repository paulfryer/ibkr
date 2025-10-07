# IBKR REST API SDKs for .NET

[![Build and Release](https://github.com/paulfryer/ibkr/actions/workflows/release.yml/badge.svg)](https://github.com/paulfryer/ibkr/actions/workflows/release.yml)
![License](https://img.shields.io/badge/license-MIT-green)
![.NET](https://img.shields.io/badge/.NET-8.0-purple)

> Auto-generated C# SDKs for the Interactive Brokers Client Portal Web API

## 🚀 Quick Start

Choose your preferred SDK architecture:

### NSwag SDK (Service-Oriented)
```bash
dotnet add package IBKR.Api.NSwag.Contract
dotnet add package IBKR.Api.NSwag.Client
```

```csharp
// Dependency injection with service interfaces
services.AddTransient<IFyiService, FyiService>();
var notifications = await fyiService.UnreadnumberAsync();
```

### Kiota SDK (Fluent API)
```bash
dotnet add package IBKR.Api.Kiota.Contract
dotnet add package IBKR.Api.Kiota.Client
```

```csharp
// Fluent, discoverable API surface
var client = new IBKRClient(requestAdapter);
var notifications = await client.Fyi.Unreadnumber.GetAsync();
```

## 📦 What's Inside

Both SDKs are generated from the same OpenAPI specification but offer different architectural approaches:

```
📁 src/
├── 🔷 NSwag/          # Service-oriented architecture
│   ├── Contract       # Models + Service Interfaces
│   ├── Client         # HTTP Client Implementations
│   ├── MockClient     # Test Mocks
│   └── Tests          # xUnit Tests
│
└── 🔶 Kiota/          # Fluent API architecture
    ├── Contract       # Model Classes (POCOs)
    ├── Client         # Fluent Request Builders
    ├── MockClient     # Test Mocks
    └── Tests          # xUnit Tests
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

# Run tests
dotnet test IBKR.Api.sln
```

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
