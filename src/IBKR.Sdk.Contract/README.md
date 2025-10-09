# IBKR.Sdk.Contract

Clean, hand-crafted data models and interfaces for IBKR SDK.

[![NuGet](https://img.shields.io/nuget/v/IBKR.Sdk.Contract.svg)](https://www.nuget.org/packages/IBKR.Sdk.Contract/)

## Overview

This package contains the clean, intuitive interfaces and models used by IBKR.Sdk.Client. Unlike the auto-generated packages, these models are:

- Hand-crafted for clarity
- Properly named (no `Anonymous`, `Anonymous2`, etc.)
- Comprehensive documentation
- Stable across API regeneration

**Most users should use [IBKR.Sdk.Client](https://www.nuget.org/packages/IBKR.Sdk.Client/)** which includes this package.

## Example Models

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

public class OptionContract
{
    public int Conid { get; set; }
    public DateTime Expiration { get; set; }
    public decimal Strike { get; set; }
    public decimal? Delta { get; set; }
    public decimal? ImpliedVolatility { get; set; }
    // ... and more
}
```

## Related Packages

- **[IBKR.Sdk.Client](https://www.nuget.org/packages/IBKR.Sdk.Client/)** - High-level SDK (recommended)

## License

MIT License
