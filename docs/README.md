# IBKR SDK Documentation

Welcome to the comprehensive documentation for the IBKR REST API SDKs for .NET.

## 📖 Table of Contents

### Getting Started
- **[Getting Started Guide](GETTING-STARTED.md)** - Installation, prerequisites, and your first API call
- **[SDK Comparison](SDK-COMPARISON.md)** - NSwag vs Kiota: Which should you choose?
- **[Authentication Guide](AUTHENTICATION.md)** - OAuth2 setup, JWT signing, and token management

### SDK Guides
- **[NSwag SDK Guide](NSWAG-SDK.md)** - Service-oriented architecture with dependency injection
- **[Kiota SDK Guide](KIOTA-SDK.md)** - Fluent API architecture with request builders

### Development
- **[Testing Guide](TESTING.md)** - Mock vs real implementations, test patterns with DI
- **[Architecture Overview](ARCHITECTURE.md)** - Repository structure, generation workflow, and design decisions
- **[Contributing Guide](CONTRIBUTING.md)** - How to regenerate SDKs and contribute to the project

### Operations
- **[Release Workflow](RELEASE-WORKFLOW.md)** - CI/CD pipeline, versioning, and package publishing

## 🚀 Quick Navigation

### I want to...

**Install and use the SDK**
→ Start with [Getting Started](GETTING-STARTED.md)

**Set up OAuth2 authentication**
→ Read the [Authentication Guide](AUTHENTICATION.md)

**Choose between NSwag and Kiota**
→ Read the [SDK Comparison](SDK-COMPARISON.md)

**Write tests with mocks**
→ Check out the [Testing Guide](TESTING.md)

**Understand the project structure**
→ See [Architecture Overview](ARCHITECTURE.md)

**Regenerate the SDKs from OpenAPI spec**
→ Follow the [Contributing Guide](CONTRIBUTING.md)

**Create a new release**
→ Read the [Release Workflow](RELEASE-WORKFLOW.md)

## 🎯 SDK Architecture at a Glance

```
┌─────────────────────────────────────────────────────┐
│          OpenAPI Specification                       │
│     (Interactive Brokers REST API)                   │
└──────────────┬──────────────────────────────────────┘
               │
               ├─────────────────┬────────────────────┐
               │                 │                    │
         ┌─────▼──────┐   ┌──────▼──────┐           │
         │   NSwag    │   │   Kiota     │           │
         │ Generator  │   │  Generator  │           │
         └─────┬──────┘   └──────┬──────┘           │
               │                 │                    │
    ┌──────────▼─────┐  ┌────────▼─────────┐         │
    │  Service-      │  │  Fluent API      │         │
    │  Oriented SDK  │  │  SDK             │         │
    ├────────────────┤  ├──────────────────┤         │
    │ • Contract     │  │ • Contract       │         │
    │ • Client       │  │ • Client         │         │
    │ • MockClient   │  │ • MockClient     │         │
    │ • Tests        │  │ • Tests          │         │
    └────────────────┘  └──────────────────┘         │
               │                 │                    │
               └─────────┬───────┘                    │
                         │                            │
                    ┌────▼─────┐                      │
                    │  NuGet   │                      │
                    │ Packages │                      │
                    └──────────┘                      │
                         │                            │
                    ┌────▼──────────┐                 │
                    │  Your .NET    │                 │
                    │  Application  │◄────────────────┘
                    └───────────────┘
```

## 🔑 Key Concepts

### Two SDKs, One API
Both SDKs are generated from the same OpenAPI specification but provide different developer experiences:

- **NSwag SDK**: Interface-based, service-oriented architecture (think traditional .NET Web API clients)
- **Kiota SDK**: Fluent, discoverable API surface (think LINQ-style method chaining)

### Consistent Testing Story
Both SDKs include:
- MockClient projects for fast unit testing
- Test projects with xUnit and DI support
- Configuration-based switching between mock and real implementations

### Automated Generation
The entire SDK generation, reorganization, and packaging process is automated via:
- Local generators (`IBKR.Api.Generator`)
- Test scaffolding (`IBKR.Api.TestScaffold`)
- GitHub Actions CI/CD pipeline

## 📚 Additional Resources

- **[Interactive Brokers API Documentation](https://ibkrcampus.com/ibkr-api-page/cpapi-v1/)** - Official IBKR API docs
- **[NSwag GitHub](https://github.com/RicoSuter/NSwag)** - NSwag code generator
- **[Kiota GitHub](https://github.com/microsoft/kiota)** - Microsoft Kiota API client generator

## 💬 Support

- **Issues**: https://github.com/paulfryer/ibkr/issues
- **Discussions**: https://github.com/paulfryer/ibkr/discussions

---

**Ready to get started?** → [Getting Started Guide](GETTING-STARTED.md)
