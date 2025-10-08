# IBKR SDK Guide

> Production-ready abstraction layer for Interactive Brokers Client Portal Web API

## Overview

The IBKR SDK is a **production-ready abstraction layer** built on top of the generated NSwag and Kiota SDKs. It provides:

- ✅ **Strongly-typed models** - DateTime, enums, decimals instead of strings
- ✅ **Comprehensive error handling** - Detailed error messages with context
- ✅ **Built-in workarounds** - All API quirks handled automatically
- ✅ **Thread-safe authentication** - Automatic session management
- ✅ **DI-friendly design** - Full dependency injection support
- ✅ **Extensive logging** - High-quality diagnostics for troubleshooting

## Architecture

```
┌─────────────────────────────────────────────┐
│  Your Application                           │
│  ↓ Uses strongly-typed interfaces           │
├─────────────────────────────────────────────┤
│  IBKR.Sdk.Contract                          │
│  • IOptionService                           │
│  • OptionContract, OptionChain              │
│  • OptionRight, OptionType (enums)          │
├─────────────────────────────────────────────┤
│  IBKR.Sdk.Client                            │
│  • OptionService (implementation)           │
│  • OptionMapper (handles quirks)            │
├─────────────────────────────────────────────┤
│  IBKR.Sdk.Authentication                    │
│  • IBKRAuthenticationProvider               │
│  • Thread-safe session management           │
├─────────────────────────────────────────────┤
│  IBKR.Api.NSwag.Client                      │
│  • Generated HTTP clients                   │
│  • Service interfaces                       │
└─────────────────────────────────────────────┘
```

### Package Structure

| Package | Purpose | Dependencies |
|---------|---------|--------------|
| **IBKR.Sdk.Contract** | Interfaces and models | None (pure contracts) |
| **IBKR.Sdk.Authentication** | Session management | NSwag.Contract |
| **IBKR.Sdk.Client** | Service implementations | Contract, Authentication, NSwag.Client |

## Installation

```bash
dotnet add package IBKR.Sdk.Contract
dotnet add package IBKR.Sdk.Client
dotnet add package IBKR.Sdk.Authentication
```

## Quick Start

### 1. Configure Authentication

Create `appsettings.json`:

```json
{
  "IBKR": {
    "ClientId": "YOUR_CLIENT_ID",
    "Credential": "YOUR_USERNAME",
    "ClientKeyId": "YOUR_KEY_ID_FROM_PORTAL",
    "ClientPemPath": "/path/to/your/private-key.pem",
    "BaseUrl": "https://api.ibkr.com"
  }
}
```

### 2. Setup Dependency Injection

```csharp
using IBKR.Sdk.Client;
using IBKR.Sdk.Contract.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// Build configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var services = new ServiceCollection();

// ⭐ One-line setup - just like AWS SDK!
services.AddIBKRSdk(configuration.GetSection("IBKR"));

var serviceProvider = services.BuildServiceProvider();
```

### 3. Use the Option Service

```csharp
var optionService = serviceProvider.GetRequiredService<IOptionService>();

// Get option chain for AAPL expiring in next 30 days
var optionChain = await optionService.GetOptionChainAsync(
    symbol: "AAPL",
    expirationStart: DateTime.UtcNow,
    expirationEnd: DateTime.UtcNow.AddDays(30));

Console.WriteLine($"Symbol: {optionChain.Symbol}");
Console.WriteLine($"Underlying ConId: {optionChain.UnderlyingContractId}");
Console.WriteLine($"Total Contracts: {optionChain.Contracts.Count}");

foreach (var contract in optionChain.Contracts)
{
    Console.WriteLine($"{contract.Symbol} " +
                     $"{contract.Right} " +
                     $"Strike: {contract.Strike:C} " +
                     $"Exp: {contract.Expiration:yyyy-MM-dd} " +
                     $"({contract.DaysUntilExpiration} days)");
}
```

### Output Example

```
Symbol: AAPL
Underlying ConId: 265598
Total Contracts: 156

AAPL Call Strike: $90.00 Exp: 2025-10-17 (9 days)
AAPL Call Strike: $95.00 Exp: 2025-10-17 (9 days)
AAPL Put Strike: $90.00 Exp: 2025-10-17 (9 days)
AAPL Put Strike: $95.00 Exp: 2025-10-17 (9 days)
...
```

## Strongly-Typed Models

### OptionContract

```csharp
public class OptionContract
{
    public int ContractId { get; set; }
    public int UnderlyingContractId { get; set; }
    public string Symbol { get; set; }
    public decimal Strike { get; set; }
    public DateTime Expiration { get; set; }          // Strongly-typed DateTime
    public OptionRight Right { get; set; }            // Enum: Call/Put
    public string TradingClass { get; set; }
    public string Exchange { get; set; }
    public string Currency { get; set; }
    public int Multiplier { get; set; }
    public string[] ValidExchanges { get; set; }
    public int? DaysUntilExpiration { get; set; }     // Calculated field
}
```

### OptionChain

```csharp
public class OptionChain
{
    public string Symbol { get; set; }
    public int UnderlyingContractId { get; set; }
    public List<OptionContract> Contracts { get; set; }
    public DateTime RetrievedAt { get; set; }
}
```

### OptionRight Enum

```csharp
public enum OptionRight
{
    Call,
    Put
}
```

## API Quirks Handled Automatically

The IBKR SDK handles several quirks in the Interactive Brokers API:

### 1. Symbol Field Mismatch

**Problem:** API returns `"symbol"` but OpenAPI spec defines `"ticker"`, causing the value to appear in `AdditionalProperties`.

**Solution:** OptionMapper extracts from AdditionalProperties with fallback:

```csharp
var symbol = GetAdditionalProperty<string>(generated, "symbol")
            ?? generated.Ticker
            ?? string.Empty;
```

### 2. Date Format Parsing

**Problem:** API returns dates as `"20251017"` (yyyyMMdd string).

**Solution:** Automatic parsing to DateTime:

```csharp
private DateTime ParseMaturityDate(string? date)
{
    if (string.IsNullOrEmpty(date) || date.Length != 8)
        return DateTime.MinValue;

    return DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
}
```

### 3. Enum Conversion

**Problem:** API uses `"C"` and `"P"` for Call/Put.

**Solution:** Clean enum mapping:

```csharp
private OptionRight ParseRight(SecDefInfoResponseRight right)
{
    return right == SecDefInfoResponseRight.C
        ? OptionRight.Call
        : OptionRight.Put;
}
```

### 4. Exchange List Parsing

**Problem:** API returns comma-separated string of exchanges.

**Solution:** Automatic splitting into array:

```csharp
private string[] ParseValidExchanges(string? exchanges)
{
    if (string.IsNullOrEmpty(exchanges))
        return Array.Empty<string>();

    return exchanges.Split(',',
        StringSplitOptions.RemoveEmptyEntries |
        StringSplitOptions.TrimEntries);
}
```

## Error Handling

The IBKR SDK provides comprehensive error handling with detailed context:

```csharp
try
{
    var chain = await optionService.GetOptionChainAsync("AAPL", start, end);
}
catch (IBKRApiException ex)
{
    Console.WriteLine($"API Error: {ex.Message}");
    Console.WriteLine($"Status Code: {ex.StatusCode}");
    Console.WriteLine($"Request: {ex.RequestDetails}");
}
catch (IBKRAuthenticationException ex)
{
    Console.WriteLine($"Authentication failed: {ex.Message}");
    // Re-authenticate or refresh session
}
```

## Authentication

The IBKR SDK uses thread-safe authentication with automatic session management:

### Thread Safety

```csharp
public class IBKRAuthenticationProvider : IIBKRAuthenticationProvider
{
    private readonly SemaphoreSlim _authenticationLock = new(1, 1);

    public async Task<string> GetAccessTokenAsync()
    {
        if (!string.IsNullOrEmpty(_cachedToken) && !IsTokenExpired())
            return _cachedToken;

        await _authenticationLock.WaitAsync();
        try
        {
            // Double-check pattern
            if (!string.IsNullOrEmpty(_cachedToken) && !IsTokenExpired())
                return _cachedToken;

            // Authenticate and cache token
            _cachedToken = await AuthenticateAsync();
            return _cachedToken;
        }
        finally
        {
            _authenticationLock.Release();
        }
    }
}
```

### Benefits

- ✅ Thread-safe concurrent access
- ✅ Automatic token caching
- ✅ Token expiration detection
- ✅ Double-check locking pattern

## Testing

The IBKR SDK is designed for testability with comprehensive mock support.

### Local Development (Real API)

```bash
# Set environment variables
export IBKR__ClientId="your-client-id"
export IBKR__ClientSecret="your-client-secret"
export IBKR__BaseUrl="https://localhost:5000/v1/api"

# Run tests with real API
dotnet test src/IBKR.Sdk.Tests
```

### CI/CD (Mock Mode)

```bash
# Force mock mode (no credentials needed)
dotnet test src/IBKR.Sdk.Tests -e Testing:UseMockClient=true
```

### Test Configuration

```csharp
public class CleanApiTestFixture : IDisposable
{
    public CleanApiTestFixture()
    {
        var hasCredentials = !string.IsNullOrEmpty(Configuration["IBKR:ClientId"]) &&
                            !string.IsNullOrEmpty(Configuration["IBKR:ClientSecret"]);

        var forceMock = Configuration.GetValue<bool>("Testing:UseMockClient", false);
        var useMock = forceMock || !hasCredentials;

        if (useMock)
            Console.WriteLine("[IBKR SDK Tests] Using MOCK implementation");
        else
            Console.WriteLine("[IBKR SDK Tests] Using REAL IBKR API");
    }
}
```

## Best Practices

### 1. Use Dependency Injection

Always register services through DI for proper lifecycle management:

```csharp
services.AddTransient<IOptionService, OptionService>();
```

### 2. Handle Exceptions Gracefully

Catch specific exceptions and provide meaningful feedback:

```csharp
try
{
    var chain = await optionService.GetOptionChainAsync(symbol, start, end);
}
catch (IBKRApiException ex) when (ex.StatusCode == 404)
{
    Console.WriteLine($"Symbol '{symbol}' not found");
}
catch (IBKRApiException ex)
{
    Console.WriteLine($"API error: {ex.Message}");
}
```

### 3. Validate Input Parameters

```csharp
if (string.IsNullOrWhiteSpace(symbol))
    throw new ArgumentException("Symbol cannot be empty", nameof(symbol));

if (expirationEnd < expirationStart)
    throw new ArgumentException("End date must be after start date");
```

### 4. Log for Diagnostics

Use structured logging to track API calls:

```csharp
_logger.LogInformation(
    "Fetching option chain for {Symbol} from {Start:yyyy-MM-dd} to {End:yyyy-MM-dd}",
    symbol, expirationStart, expirationEnd);
```

## Comparison with Lower-Level SDKs

### IBKR SDK (Recommended)

```csharp
// Strongly-typed, clean
var optionService = serviceProvider.GetRequiredService<IOptionService>();
var chain = await optionService.GetOptionChainAsync("AAPL", start, end);

foreach (var contract in chain.Contracts)
{
    Console.WriteLine($"{contract.Symbol} {contract.Right} " +
                     $"Strike: {contract.Strike:C}");
}
```

### NSwag SDK (Lower-level)

```csharp
// Manual parsing, workarounds needed
var service = new IserverService(httpClient);
var searchResults = await service.SearchAllGETAsync(symbol: "AAPL");
var conid = searchResults.First().Conid;

var info = await service.InfoAsync(conid);
// Manual extraction from AdditionalProperties
// Manual date parsing
// Manual error handling
```

## Extending the IBKR SDK

To add new methods to the IBKR SDK:

### 1. Add to Contract

```csharp
// IBKR.Sdk.Contract/Services/IOptionService.cs
public interface IOptionService
{
    Task<OptionChain> GetOptionChainAsync(
        string symbol,
        DateTime expirationStart,
        DateTime expirationEnd);

    // Add new method
    Task<OptionQuote> GetOptionQuoteAsync(int contractId);
}
```

### 2. Implement in Client

```csharp
// IBKR.Sdk.Client/Services/OptionService.cs
public async Task<OptionQuote> GetOptionQuoteAsync(int contractId)
{
    // Implementation with error handling and mapping
}
```

### 3. Add Tests

```csharp
// IBKR.Sdk.Tests/OptionServiceTests.cs
[Fact]
public async Task GetOptionQuoteAsync_ReturnsValidQuote()
{
    var quote = await _optionService.GetOptionQuoteAsync(774988992);
    Assert.NotNull(quote);
    // Comprehensive assertions with logging
}
```

## Troubleshooting

### Issue: Authentication Fails

**Solution:** Verify credentials and base URL:

```csharp
services.Configure<IBKRSettings>(options =>
{
    options.ClientId = Environment.GetEnvironmentVariable("IBKR__ClientId");
    options.ClientSecret = Environment.GetEnvironmentVariable("IBKR__ClientSecret");
    options.BaseUrl = "https://localhost:5000/v1/api"; // Verify port
});
```

### Issue: Empty Symbol in Contracts

**Problem:** API returns symbol in AdditionalProperties, not in typed field.

**Solution:** Already handled in OptionMapper - ensure you're using latest version.

### Issue: Date Parsing Errors

**Problem:** Unexpected date format from API.

**Solution:** Check MaturityDate format - should be "yyyyMMdd" (8 characters).

## Further Reading

- **[Testing Guide](TESTING.md)** - Comprehensive testing patterns with mocks
- **[SDK Comparison](SDK-COMPARISON.md)** - Compare IBKR SDK with NSwag/Kiota
- **[Architecture](ARCHITECTURE.md)** - Deep dive into SDK architecture
- **[Contributing](CONTRIBUTING.md)** - How to extend the IBKR SDK

## Summary

The IBKR SDK provides:

✅ **Production-ready** - Built-in error handling, thread safety, comprehensive logging
✅ **Strongly-typed** - DateTime, enums, decimals instead of strings
✅ **Developer-friendly** - Intuitive interfaces, excellent IntelliSense
✅ **Battle-tested** - Handles all known API quirks automatically
✅ **Well-documented** - Extensive examples and guides
✅ **Testable** - Full mock support for CI/CD and local development

**Start building with the IBKR SDK today for the best Interactive Brokers development experience!**
