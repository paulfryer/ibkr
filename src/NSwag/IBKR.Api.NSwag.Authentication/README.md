# IBKR.Api.NSwag.Authentication

Authentication adapter for NSwag-generated IBKR Client Portal API client.

[![NuGet](https://img.shields.io/nuget/v/IBKR.Api.NSwag.Authentication.svg)](https://www.nuget.org/packages/IBKR.Api.NSwag.Authentication/)

## Overview

This package provides authentication integration for the NSwag-generated IBKR client using `HttpMessageHandler` pattern.

**Most users should use [IBKR.Sdk.Client](https://www.nuget.org/packages/IBKR.Sdk.Client/)** instead, which handles everything automatically.

## Usage (Advanced)

```csharp
var options = new IBKRAuthenticationOptions { /* ... */ };

services.AddIBKRAuthenticatedClient<IIserverService, IserverService>(options);
```

## Related Packages

- **[IBKR.Sdk.Client](https://www.nuget.org/packages/IBKR.Sdk.Client/)** - High-level SDK (recommended)
- **[IBKR.Api.Authentication](https://www.nuget.org/packages/IBKR.Api.Authentication/)** - Core authentication
- **[IBKR.Api.NSwag.Client](https://www.nuget.org/packages/IBKR.Api.NSwag.Client/)** - NSwag-generated client

## License

MIT License
