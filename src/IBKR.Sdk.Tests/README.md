# IBKR.Api.Tests - Clean API Test Suite

This test library demonstrates **best practices for unit testing with high explainability and diagnostic quality**.

## Philosophy

Tests serve three critical purposes:
1. **Validate behavior** - Ensure the code works correctly
2. **Document usage** - Show developers how to use the API
3. **Diagnose failures** - Provide actionable information when things break

## Key Principles

### 1. Comprehensive Logging with ITestOutputHelper

Every test uses `ITestOutputHelper` to provide detailed context:

```csharp
public OptionServiceTests(CleanApiTestFixture fixture, ITestOutputHelper output)
{
    _optionService = fixture.GetService<IOptionService>();
    _output = output;  // ← Critical for diagnostics
}
```

**Benefits:**
- See exactly what the test is doing at each step
- Understand the data being tested
- Identify where failures occur in complex workflows

### 2. Descriptive Assertion Messages

Compare these approaches:

❌ **BAD - No context:**
```csharp
Assert.False(string.IsNullOrEmpty(contract.Symbol));
```

When this fails, you get:
```
Assert.False() Failure
Expected: False
Actual:   True
```

✅ **GOOD - Full context:**
```csharp
Assert.False(string.IsNullOrEmpty(contract.Symbol),
    $"Contract #{contractIndex} (ConId: {contract.ContractId}): Symbol is null or empty. " +
    $"Full contract: Strike={contract.Strike}, Right={contract.Right}, Exp={contract.Expiration:yyyy-MM-dd}");
```

When this fails, you get:
```
Contract #1 (ConId: 774988992): Symbol is null or empty.
Full contract: Strike=90, Right=Call, Exp=2025-10-17
```

### 3. Try-Catch with Enhanced Failure Output

For complex validation loops, wrap assertions in try-catch to dump full context:

```csharp
foreach (var contract in optionChain.Contracts)
{
    try
    {
        Assert.True(contract.Strike > 0,
            $"Contract #{contractIndex}: Strike should be > 0, was: {contract.Strike}");
        // ... more assertions
    }
    catch (Exception ex)
    {
        _output.WriteLine($"\n❌ VALIDATION FAILED for Contract #{contractIndex}:");
        _output.WriteLine($"  ContractId: {contract.ContractId}");
        _output.WriteLine($"  Symbol: '{contract.Symbol}'");
        _output.WriteLine($"  Strike: {contract.Strike}");
        // ... dump all relevant state
        _output.WriteLine($"\n  Error: {ex.Message}\n");
        throw; // Re-throw to fail the test
    }
}
```

### 4. Progressive Logging

Log test progress as it happens:

```csharp
_output.WriteLine($"TEST: GetOptionChain for {symbol} within {daysAhead} days");
_output.WriteLine($"Date Range: {expirationStart:yyyy-MM-dd} to {expirationEnd:yyyy-MM-dd}");

_output.WriteLine($"Calling GetOptionChainAsync('{symbol}', ...)");
var chain = await _optionService.GetOptionChainAsync(...);
_output.WriteLine($"✓ API call completed\n");

_output.WriteLine($"Validating {chain.Contracts.Count} contracts...");
// ... validation
_output.WriteLine($"✓ All {contractIndex} contracts validated successfully\n");
```

**Benefits:**
- Know exactly where the test failed in a multi-step process
- See intermediate results even when assertions don't fail
- Easier to debug flaky or timing-sensitive tests

## Real-World Example

### The Problem

Initial test failure:
```
Assert.False() Failure
Expected: False
Actual:   True
Stack Trace:
  at OptionServiceTests.cs:line 75
```

**Questions we couldn't answer:**
- Which contract failed?
- What was the actual symbol value?
- Which test case (AAPL? TSLA? AMZN)?
- What iteration of the loop?

### The Solution

After adding comprehensive logging:

```
================================================================================
TEST: GetOptionChain for AAPL within 30 days
================================================================================

Date Range:
  Start: 2025-10-08 17:59:27 UTC
  End:   2025-11-07 17:59:27 UTC
  Days:  30

Calling GetOptionChainAsync('AAPL', ...)
✓ API call completed

Option Chain Summary:
  Symbol: AAPL
  Underlying ConId: 265598
  Total Contracts: 4
  Retrieved At: 2025-10-08 17:59:29 UTC

Validating 4 contracts...

❌ VALIDATION FAILED for Contract #1:
  ContractId: 774988992
  Symbol: '' (IsNullOrEmpty: True)
  UnderlyingContractId: 265598
  Strike: 90
  Right: Call
  Expiration: 2025-10-17 00:00:00
  TradingClass: ''
  Exchange: 'SMART'
  Currency: 'USD'
  Multiplier: 100
  ValidExchanges: [SMART, AMEX, CBOE, ...]
  DaysUntilExpiration: 9

  Error: Contract #1 (ConId: 774988992): Symbol is null or empty.
```

**Root cause identified in seconds:**
- The mapper was using `generated.Ticker` (null in OpenAPI spec)
- But the API returns `"symbol"` in AdditionalProperties
- Fix: Extract from AdditionalProperties with fallback

## Configuration Strategy

Tests automatically adapt to environment:

```csharp
// Use real API if credentials exist (local development)
var hasCredentials = !string.IsNullOrEmpty(Configuration["IBKR:ClientId"]) && ...;

// Allow CI/CD to force mock even with credentials
var forceMock = Configuration.GetValue<bool>("Testing:UseMockClient", false);

if (hasCredentials && !forceMock)
{
    // Use real IBKR API
    Console.WriteLine("[Clean API Tests] Using REAL IBKR API");
}
else
{
    // Use mock data
    Console.WriteLine("[Clean API Tests] Using MOCK implementation");
}
```

**Result:**
- Local dev with credentials → real API (catch real issues)
- CI/CD → mock data (fast, reliable, no credentials needed)

## Test Organization

### Clean API Layer (IBKR.Api.Tests)

**Purpose:** Production examples and documentation
- ✅ Tests ONLY the clean IOptionService interface
- ✅ NO knowledge of NSwag/Kiota internals
- ✅ Shows best practices for API consumers
- ✅ Comprehensive logging and diagnostics

### Discovery Layer (NSwag.Tests / Kiota.Tests)

**Purpose:** SDK validation and quirk discovery
- Tests raw generated SDKs
- Discovers API quirks and edge cases
- Contains workarounds (try/catch, manual deserialization)
- Informs generator fixes

## Running Tests

```bash
# Run all clean API tests
dotnet test src/IBKR.Api.Tests

# Run specific symbol test with verbose output
dotnet test src/IBKR.Api.Tests --filter "DisplayName~AAPL" --logger "console;verbosity=detailed"

# Force mock mode (override credentials)
dotnet test src/IBKR.Api.Tests -e Testing:UseMockClient=true
```

## Key Takeaways

1. **Invest in test diagnostics** - Time spent adding logging pays off exponentially when debugging
2. **Every assertion should explain itself** - Future you (or your teammates) will thank you
3. **Show your work** - Log intermediate steps so failures are easy to diagnose
4. **Fail loudly with context** - Don't just say "assertion failed", explain what went wrong and why
5. **Tests are documentation** - Write them for humans, not just machines

## Examples

See `OptionServiceTests.cs` for complete examples of:
- ✅ Progressive logging throughout test execution
- ✅ Descriptive assertion messages with full context
- ✅ Try-catch with comprehensive state dumps on failure
- ✅ Clean API usage patterns for documentation
