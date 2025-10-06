# IBKR.Api.Client.Mock

Mock implementation of the IBKR API Client for testing and development.

## Overview

This library provides a **real, in-memory implementation** of `IInstrumentApiService` (not Moq-based). It allows you to test code that depends on the IBKR API without requiring:

- HTTP connections
- API credentials
- Rate limit concerns
- Network availability

## Key Features

✅ **Implementation-Agnostic Testing** - Tests depend only on interfaces
✅ **Fast Execution** - No HTTP overhead, all data in-memory
✅ **Pre-Loaded Test Data** - Realistic MSFT stock and option data included
✅ **Fluent Builder API** - Easy configuration and setup
✅ **Reusable** - Can be used in any project, not just tests

## Usage

### Quick Start (Default MSFT Data)

```csharp
using IBKR.Api.Client.Mock.Services;
using IBKR.Api.Client.Services;

// Create service with pre-loaded MSFT test data
IInstrumentApiService service = MockInstrumentApiServiceBuilder
    .CreateDefault()
    .Build();

// Use it like any other IInstrumentApiService
var results = await service.SearchStocksAsync("MSFT");
var optionChain = await service.GetOptionChainAsync(272093);
```

### Custom Configuration

```csharp
using IBKR.Api.Client.Mock.Data;
using IBKR.Api.Client.Mock.Services;

var service = new MockInstrumentApiServiceBuilder()
    .WithStockSearch("AAPL", GetAppleData())
    .WithOptionChain(12345, GetCustomOptionChain())
    .Build();
```

### Manual Setup (No Builder)

```csharp
var mockService = new MockInstrumentApiService();

// Add test data
mockService.AddStockData("MSFT", MsftTestData.GetStockSearchResult());
mockService.AddOptionChain(272093, MsftTestData.GetOptionChain());

// Use as IInstrumentApiService
IInstrumentApiService service = mockService;
```

## Test Data Included

### MSFT (Microsoft) Test Data

Located in `IBKR.Api.Client.Mock.Data.MsftTestData`:

- **Contract ID**: 272093 (realistic value)
- **Symbol**: MSFT
- **Exchange**: NASDAQ (plus SMART, ISLAND)
- **Option Chains**: 4 expirations within 30 days, 1 beyond
- **Strike Prices**: $380-$470 in $5 increments
- **Option Types**: Both calls and puts
- **Multiplier**: Standard 100 shares

### Available Methods

```csharp
// Stock search results
MsftTestData.GetStockSearchResult()

// Security information
MsftTestData.GetSecurityInfo()

// Option chain with expirations
MsftTestData.GetOptionChain()

// Strike data (calls and puts)
MsftTestData.GetStrikeData()

// Specific option contracts
MsftTestData.GetOptionContracts(expiration, strike, right)
```

## Architecture

### Class Diagram

```
IInstrumentApiService (interface in IBKR.Api.Client)
        ↑
        |
MockInstrumentApiService (in-memory implementation)
        ↑
        |
MockInstrumentApiServiceBuilder (fluent configuration)
```

### Implementation Details

**MockInstrumentApiService**:
- Implements `IInstrumentApiService` fully
- Stores data in `Dictionary<>` collections
- Returns `Task.FromResult()` for async operations
- Thread-safe for reading (writes during setup only)

**MockInstrumentApiServiceBuilder**:
- Fluent API for easy configuration
- Method chaining: `.WithX().WithY().Build()`
- `CreateDefault()` provides MSFT data out-of-the-box

## Integration with Tests

Tests should use dependency injection and **never know** if they're using mock or real HTTP implementation.

### xUnit Example (using IClassFixture)

```csharp
public class InstrumentServiceFixture : IDisposable
{
    public IInstrumentApiService Service { get; }

    public InstrumentServiceFixture()
    {
        // Configuration determines which implementation to use
        if (useRealApi)
            Service = new RealHttpService();
        else
            Service = MockInstrumentApiServiceBuilder.CreateDefault().Build();
    }
}

public class MyTests : IClassFixture<InstrumentServiceFixture>
{
    private readonly IInstrumentApiService _service;

    public MyTests(InstrumentServiceFixture fixture)
    {
        _service = fixture.Service;  // No knowledge of implementation!
    }

    [Fact]
    public async Task CanSearchForStocks()
    {
        var results = await _service.SearchStocksAsync("MSFT");
        // Test assertions...
    }
}
```

## When to Use

✅ **Unit Tests** - Test business logic without HTTP
✅ **Integration Tests** - Test workflows without API keys
✅ **Development** - Build features before API access is ready
✅ **CI/CD Pipelines** - Run tests on build servers without credentials
✅ **Demo/Prototype** - Demonstrate functionality offline

## When NOT to Use

❌ **Production Code** - Use real HTTP implementation
❌ **API Contract Validation** - Use real API for integration tests
❌ **Performance Testing** - Mock doesn't reflect network latency

## Extending with Custom Data

To add support for other symbols (e.g., AAPL, TSLA):

1. Create a new test data class (e.g., `AppleTestData.cs`)
2. Follow the pattern from `MsftTestData.cs`
3. Use the builder to configure:

```csharp
var service = new MockInstrumentApiServiceBuilder()
    .WithStockSearch("AAPL", AppleTestData.GetStockSearchResult())
    .WithOptionChain(AppleTestData.AppleConid, AppleTestData.GetOptionChain())
    .Build();
```

## Related Projects

- **IBKR.Api.Client** - Main library with interfaces and models
- **IBKR.Api.Client.Tests** - Test project using this mock
- **IBKR.Api.Client.Http** (future) - Real HTTP implementation

---

**License**: Same as parent project
**Version**: 1.0.0
**Target**: .NET 8.0
