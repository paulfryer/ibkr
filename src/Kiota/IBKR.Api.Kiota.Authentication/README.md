# IBKR.Api.Kiota.Authentication

Authentication adapter for Kiota-generated IBKR Client Portal API client.

[![NuGet](https://img.shields.io/nuget/v/IBKR.Api.Kiota.Authentication.svg)](https://www.nuget.org/packages/IBKR.Api.Kiota.Authentication/)

## Overview

This package provides authentication integration for the Kiota-generated IBKR client using `IAuthenticationProvider` pattern.

**Most users should use [IBKR.Sdk.Client](https://www.nuget.org/packages/IBKR.Sdk.Client/)** instead, which handles everything automatically.

## Usage (Advanced)

```csharp
var options = new IBKRAuthenticationOptions { /* ... */ };

services.AddIBKRAuthenticatedKiotaClient(options);
```

## Related Packages

- **[IBKR.Sdk.Client](https://www.nuget.org/packages/IBKR.Sdk.Client/)** - High-level SDK (recommended)
- **[IBKR.Api.Authentication](https://www.nuget.org/packages/IBKR.Api.Authentication/)** - Core authentication
- **[IBKR.Api.Kiota.Client](https://www.nuget.org/packages/IBKR.Api.Kiota.Client/)** - Kiota-generated client

## License

MIT License
