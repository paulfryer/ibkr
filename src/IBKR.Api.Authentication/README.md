# IBKR.Api.Authentication

Core OAuth2 + JWT authentication library for Interactive Brokers Client Portal API.

[![NuGet](https://img.shields.io/nuget/v/IBKR.Api.Authentication.svg)](https://www.nuget.org/packages/IBKR.Api.Authentication/)

## Overview

This package provides the core authentication logic for IBKR Client Portal API, including:
- OAuth2 token flow with JWT client assertions
- Bearer token management and caching
- Brokerage session initialization
- RSA signing for JWT

## Usage

This is a low-level library. **Most users should use [IBKR.Sdk.Client](https://www.nuget.org/packages/IBKR.Sdk.Client/)** instead, which provides a complete, easy-to-use SDK.

### Direct Usage (Advanced)

```csharp
var options = new IBKRAuthenticationOptions
{
    ClientId = "TESTCONS",
    Credential = "your_username",
    ClientKeyId = "kid-from-portal",
    ClientPemPath = "/path/to/private-key.pem",
    BaseUrl = "https://api.ibkr.com"
};

var authProvider = new IBKRAuthenticationProvider(options);
await authProvider.InitializeSessionAsync();
var bearerToken = await authProvider.GetBearerTokenAsync();
```

## Related Packages

- **[IBKR.Sdk.Client](https://www.nuget.org/packages/IBKR.Sdk.Client/)** - High-level SDK (recommended)
- **[IBKR.Api.NSwag.Authentication](https://www.nuget.org/packages/IBKR.Api.NSwag.Authentication/)** - NSwag authentication adapter
- **[IBKR.Api.Kiota.Authentication](https://www.nuget.org/packages/IBKR.Api.Kiota.Authentication/)** - Kiota authentication adapter

## License

MIT License
