using IBKR.Api.Contract.Enums;
using IBKR.Api.Contract.Interfaces;
using Xunit;
using Xunit.Abstractions;

namespace IBKR.Api.Tests;

/// <summary>
/// Tests for IOptionService - the CLEAN API.
///
/// Notice what's NOT here:
/// - No try/catch blocks
/// - No JSON deserialization
/// - No string parsing for dates
/// - No manual enum conversion
/// - No CSV splitting
/// - No workarounds for array vs single object
/// - No knowledge of NSwag or Kiota
///
/// This is production-ready code showing developers how to use the API.
/// </summary>
public class OptionServiceTests : IClassFixture<CleanApiTestFixture>
{
    private readonly IOptionService _optionService;
    private readonly ITestOutputHelper _output;

    public OptionServiceTests(CleanApiTestFixture fixture, ITestOutputHelper output)
    {
        // Get the clean service - no knowledge of underlying implementation
        _optionService = fixture.GetService<IOptionService>();
        _output = output;
    }

    [Theory]
    [InlineData("AAPL", 30)]
    [InlineData("TSLA", 60)]
    [InlineData("AMZN", 45)]
    public async Task GetOptionChain_ReturnsStronglyTypedResults(string symbol, int daysAhead)
    {
        // Arrange
        _output.WriteLine($"\n{'='*80}");
        _output.WriteLine($"TEST: GetOptionChain for {symbol} within {daysAhead} days");
        _output.WriteLine($"{'='*80}\n");

        var now = DateTime.UtcNow;
        var expirationStart = now;
        var expirationEnd = now.AddDays(daysAhead);

        _output.WriteLine($"Date Range:");
        _output.WriteLine($"  Start: {expirationStart:yyyy-MM-dd HH:mm:ss} UTC");
        _output.WriteLine($"  End:   {expirationEnd:yyyy-MM-dd HH:mm:ss} UTC");
        _output.WriteLine($"  Days:  {daysAhead}");
        _output.WriteLine("");

        // Act - LOOK HOW CLEAN THIS IS!
        _output.WriteLine($"Calling GetOptionChainAsync('{symbol}', ...)");
        var optionChain = await _optionService.GetOptionChainAsync(
            symbol,
            expirationStart,
            expirationEnd);
        _output.WriteLine($"✓ API call completed\n");

        // Assert - Clean, strongly-typed models
        Assert.NotNull(optionChain);

        _output.WriteLine($"Option Chain Summary:");
        _output.WriteLine($"  Symbol: {optionChain.Symbol}");
        _output.WriteLine($"  Underlying ConId: {optionChain.UnderlyingContractId}");
        _output.WriteLine($"  Total Contracts: {optionChain.Contracts.Count}");
        _output.WriteLine($"  Retrieved At: {optionChain.RetrievedAt:yyyy-MM-dd HH:mm:ss} UTC");
        _output.WriteLine("");

        Assert.Equal(symbol, optionChain.Symbol);
        Assert.True(optionChain.UnderlyingContractId > 0,
            $"UnderlyingContractId should be > 0, was: {optionChain.UnderlyingContractId}");
        Assert.NotEmpty(optionChain.Contracts);
        Assert.Equal(expirationStart, optionChain.RequestedExpirationStart);
        Assert.Equal(expirationEnd, optionChain.RequestedExpirationEnd);

        // Verify all contracts have clean, properly typed data
        _output.WriteLine($"Validating {optionChain.Contracts.Count} contracts...");

        int contractIndex = 0;
        foreach (var contract in optionChain.Contracts)
        {
            contractIndex++;

            try
            {
                // DateTime, not string!
                Assert.True(contract.Expiration >= expirationStart,
                    $"Contract #{contractIndex}: Expiration {contract.Expiration:yyyy-MM-dd} should be >= {expirationStart:yyyy-MM-dd}");
                Assert.True(contract.Expiration <= expirationEnd,
                    $"Contract #{contractIndex}: Expiration {contract.Expiration:yyyy-MM-dd} should be <= {expirationEnd:yyyy-MM-dd}");

                // Enum, not string!
                Assert.True(contract.Right == OptionRight.Call || contract.Right == OptionRight.Put,
                    $"Contract #{contractIndex}: Right should be Call or Put, was: {contract.Right}");

                // Decimal, not object or double!
                Assert.True(contract.Strike > 0,
                    $"Contract #{contractIndex}: Strike should be > 0, was: {contract.Strike}");
                Assert.True(contract.Multiplier > 0,
                    $"Contract #{contractIndex}: Multiplier should be > 0, was: {contract.Multiplier}");

                // Proper IDs
                Assert.True(contract.ContractId > 0,
                    $"Contract #{contractIndex}: ContractId should be > 0, was: {contract.ContractId}");
                Assert.Equal(optionChain.UnderlyingContractId, contract.UnderlyingContractId);

                // Clean strings
                Assert.False(string.IsNullOrEmpty(contract.Symbol),
                    $"Contract #{contractIndex} (ConId: {contract.ContractId}): Symbol is null or empty. " +
                    $"Full contract: Strike={contract.Strike}, Right={contract.Right}, Exp={contract.Expiration:yyyy-MM-dd}, " +
                    $"TradingClass='{contract.TradingClass}', Exchange='{contract.Exchange}'");

                Assert.False(string.IsNullOrEmpty(contract.Currency),
                    $"Contract #{contractIndex} (ConId: {contract.ContractId}, Symbol: {contract.Symbol}): Currency is null or empty");

                // Array, not CSV string!
                Assert.NotNull(contract.ValidExchanges);
                Assert.NotEmpty(contract.ValidExchanges);

                // Calculated field
                if (contract.DaysUntilExpiration.HasValue)
                {
                    Assert.True(contract.DaysUntilExpiration.Value >= 0,
                        $"Contract #{contractIndex}: DaysUntilExpiration should be >= 0, was: {contract.DaysUntilExpiration.Value}");
                }
            }
            catch (Exception ex)
            {
                // Enhanced failure message with full contract details
                _output.WriteLine($"\n❌ VALIDATION FAILED for Contract #{contractIndex}:");
                _output.WriteLine($"  ContractId: {contract.ContractId}");
                _output.WriteLine($"  Symbol: '{contract.Symbol}' (IsNullOrEmpty: {string.IsNullOrEmpty(contract.Symbol)})");
                _output.WriteLine($"  UnderlyingContractId: {contract.UnderlyingContractId}");
                _output.WriteLine($"  Strike: {contract.Strike}");
                _output.WriteLine($"  Right: {contract.Right}");
                _output.WriteLine($"  Expiration: {contract.Expiration:yyyy-MM-dd HH:mm:ss}");
                _output.WriteLine($"  TradingClass: '{contract.TradingClass}'");
                _output.WriteLine($"  Exchange: '{contract.Exchange}'");
                _output.WriteLine($"  Currency: '{contract.Currency}'");
                _output.WriteLine($"  Multiplier: {contract.Multiplier}");
                _output.WriteLine($"  ValidExchanges: [{string.Join(", ", contract.ValidExchanges ?? Array.Empty<string>())}]");
                _output.WriteLine($"  DaysUntilExpiration: {contract.DaysUntilExpiration?.ToString() ?? "null"}");
                _output.WriteLine($"\n  Error: {ex.Message}\n");

                throw; // Re-throw to fail the test
            }
        }

        _output.WriteLine($"✓ All {contractIndex} contracts validated successfully\n");
    }

    [Fact]
    public async Task GetOptionChain_FiltersByExpirationRange()
    {
        // Arrange
        var symbol = "AAPL";
        var start = DateTime.UtcNow;
        var end = start.AddDays(30);

        // Act
        var chain = await _optionService.GetOptionChainAsync(symbol, start, end);

        // Assert - All contracts should be within the date range
        Assert.All(chain.Contracts, contract =>
        {
            Assert.True(contract.Expiration >= start);
            Assert.True(contract.Expiration <= end);
        });
    }

    [Fact]
    public async Task GetOptionChain_ReturnsBothCallsAndPuts()
    {
        // Arrange
        var symbol = "AAPL";
        var start = DateTime.UtcNow;
        var end = start.AddDays(30);

        // Act
        var chain = await _optionService.GetOptionChainAsync(symbol, start, end);

        // Assert - Should have both calls and puts
        Assert.Contains(chain.Contracts, c => c.Right == OptionRight.Call);
        Assert.Contains(chain.Contracts, c => c.Right == OptionRight.Put);
    }

    [Fact]
    public async Task GetOptionChain_GroupsByStrike()
    {
        // Arrange
        var symbol = "TSLA";
        var start = DateTime.UtcNow;
        var end = start.AddDays(45);

        // Act
        var chain = await _optionService.GetOptionChainAsync(symbol, start, end);

        // Assert - Should have multiple strikes
        var uniqueStrikes = chain.Contracts
            .Select(c => c.Strike)
            .Distinct()
            .ToList();

        Assert.True(uniqueStrikes.Count > 1, "Should have multiple strike prices");
    }

    [Fact]
    public async Task GetOptionChain_IncludesExchangeInformation()
    {
        // Arrange
        var symbol = "AMZN";
        var start = DateTime.UtcNow;
        var end = start.AddDays(30);

        // Act
        var chain = await _optionService.GetOptionChainAsync(symbol, start, end);

        // Assert - All contracts should have exchange info
        Assert.All(chain.Contracts, contract =>
        {
            Assert.False(string.IsNullOrEmpty(contract.Exchange));
            Assert.NotNull(contract.ValidExchanges);
            Assert.NotEmpty(contract.ValidExchanges);
        });
    }

    [Fact]
    public async Task GetOptionChain_CalculatesDaysUntilExpiration()
    {
        // Arrange
        var symbol = "AAPL";
        var start = DateTime.UtcNow;
        var end = start.AddDays(30);

        // Act
        var chain = await _optionService.GetOptionChainAsync(symbol, start, end);

        // Assert - DaysUntilExpiration should be calculated correctly
        var today = DateTime.UtcNow.Date;
        Assert.All(chain.Contracts, contract =>
        {
            if (contract.DaysUntilExpiration.HasValue)
            {
                var expectedDays = (int)(contract.Expiration.Date - today).TotalDays;
                Assert.Equal(expectedDays, contract.DaysUntilExpiration.Value);
            }
        });
    }

    [Fact]
    public async Task GetOptionChain_DemoTest_ShowsCleanAPIUsage()
    {
        // This test demonstrates how clean and intuitive the API is
        var chain = await _optionService.GetOptionChainAsync(
            "AAPL",
            DateTime.UtcNow,
            DateTime.UtcNow.AddDays(30));

        // Look at the results - clean, intuitive, strongly-typed:
        foreach (var contract in chain.Contracts.Take(5))
        {
            Console.WriteLine($"Contract: {contract.Symbol} " +
                             $"{contract.Right} " +  // Enum: Call or Put
                             $"Strike: {contract.Strike:C} " +  // Decimal
                             $"Exp: {contract.Expiration:yyyy-MM-dd} " +  // DateTime
                             $"DTE: {contract.DaysUntilExpiration} " +  // Calculated int
                             $"Exchanges: [{string.Join(", ", contract.ValidExchanges)}]");  // Array
        }

        // This is production-ready code!
        // No try/catch, no parsing, no workarounds - just clean business logic
        Assert.NotNull(chain);
        Assert.True(chain.Contracts.Count > 0);
    }
}
