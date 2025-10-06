using FluentAssertions;
using IBKR.Api.Client.Mock.Data;
using IBKR.Api.Client.Services;
using IBKR.Api.Client.Tests.Infrastructure;

namespace IBKR.Api.Client.Tests.Scenarios;

/// <summary>
/// End-to-end scenario tests for looking up MSFT stock and retrieving option chains.
/// These tests demonstrate the complete workflow using the service interface.
/// Tests use dependency injection - NO knowledge of implementation (mock vs real API).
/// </summary>
public class MsftOptionChainScenarioTests : IClassFixture<InstrumentServiceFixture>
{
    private readonly IInstrumentApiService _instrumentService;

    /// <summary>
    /// Constructor receives the service via dependency injection.
    /// Tests don't know if this is a mock or real HTTP implementation.
    /// </summary>
    public MsftOptionChainScenarioTests(InstrumentServiceFixture fixture)
    {
        _instrumentService = fixture.Service;
    }
    /// <summary>
    /// Full scenario: Search MSFT → Get contract details → Get option chain for next 30 days
    /// </summary>
    [Fact]
    public async Task CompleteWorkflow_SearchMsftAndGetOptionChainForNext30Days()
    {
        // Act & Assert

        // Step 1: Search for MSFT stock
        var searchResults = await _instrumentService.SearchStocksAsync(MsftTestData.MsftSymbol);

        searchResults.Should().ContainKey(MsftTestData.MsftSymbol);
        var msftResults = searchResults[MsftTestData.MsftSymbol];
        msftResults.Should().NotBeEmpty();

        // Step 2: Extract the contract ID from the primary listing
        var primaryContract = msftResults[0].Contracts!
            .First(c => c.Exchange == MsftTestData.MsftExchange);
        var conid = primaryContract.Conid;

        conid.Should().Be(MsftTestData.MsftConid);

        // Step 3: Get detailed security information
        var securityInfo = await _instrumentService.GetSecurityInfoAsync(conid);

        securityInfo.Should().NotBeEmpty();
        securityInfo[0].Symbol.Should().Be(MsftTestData.MsftSymbol);
        securityInfo[0].SecType.Should().Be("STK");

        // Step 4: Get the option chain
        var optionChain = await _instrumentService.GetOptionChainAsync(conid);

        optionChain.Should().NotBeNull();
        optionChain.Symbol.Should().Be(MsftTestData.MsftSymbol);

        // Step 5: Filter for expirations within next 30 days
        var next30DaysOptions = optionChain.Expirations!
            .Where(e => e.DaysToExpiration <= 30)
            .ToList();

        next30DaysOptions.Should().NotBeEmpty();
        next30DaysOptions.Should().OnlyContain(e => e.DaysToExpiration <= 30);

        // Verify we have strikes for each expiration
        foreach (var expiration in next30DaysOptions)
        {
            expiration.Strikes.Should().NotBeNullOrEmpty();
            expiration.Strikes!.Should().HaveCountGreaterThan(10);
        }
    }

    /// <summary>
    /// Scenario: Get specific option contract (MSFT 420 Call expiring in 7 days)
    /// </summary>
    [Fact]
    public async Task GetSpecificOptionContract_Msft420Call()
    {
        // Arrange
        var expiration = DateTime.Today.AddDays(7).ToString("yyyyMMdd");
        var strike = 420m;
        var right = "C"; // Call option

        // Act

        // Step 1: Search for MSFT to get contract ID
        var searchResults = await _instrumentService.SearchStocksAsync(MsftTestData.MsftSymbol);
        var conid = searchResults[MsftTestData.MsftSymbol][0].Contracts![0].Conid;

        // Step 2: Get specific option contracts
        var optionContracts = await _instrumentService.GetOptionContractsAsync(
            conid,
            expiration,
            strike,
            right);

        // Assert
        optionContracts.Should().NotBeNullOrEmpty();

        var contract = optionContracts[0];
        contract.Symbol.Should().Be(MsftTestData.MsftSymbol);
        contract.Strike.Should().Be(strike);
        contract.Right.Should().Be(right);
        contract.Expiration.Should().Be(expiration);
        contract.Multiplier.Should().Be("100");
    }

    /// <summary>
    /// Scenario: Enumerate all strikes for near-term expirations
    /// </summary>
    [Fact]
    public async Task EnumerateAllStrikes_ForNearTermExpirations()
    {
        // Act

        // Get option chain
        var optionChain = await _instrumentService.GetOptionChainAsync(MsftTestData.MsftConid);

        // Filter for next 14 days (near-term)
        var nearTermExpirations = optionChain.Expirations!
            .Where(e => e.DaysToExpiration <= 14)
            .OrderBy(e => e.DaysToExpiration)
            .ToList();

        // Assert
        nearTermExpirations.Should().NotBeEmpty();

        // Collect all unique strikes across near-term expirations
        var allStrikes = nearTermExpirations
            .SelectMany(e => e.Strikes!)
            .Distinct()
            .OrderBy(s => s)
            .ToList();

        allStrikes.Should().NotBeEmpty();
        allStrikes.Should().HaveCountGreaterThan(10);

        // Verify strike increments are reasonable (typically $5 increments for MSFT)
        for (int i = 1; i < allStrikes.Count; i++)
        {
            var increment = allStrikes[i] - allStrikes[i - 1];
            increment.Should().BeGreaterThan(0);
            increment.Should().BeLessOrEqualTo(10m, "strike increments should be reasonable");
        }
    }

    /// <summary>
    /// Scenario: Find at-the-money options for a specific expiration
    /// </summary>
    [Fact]
    public async Task FindAtTheMoneyOptions_ForSpecificExpiration()
    {
        // Arrange
        var currentStockPrice = 425m; // Assume current MSFT price
        var targetDaysToExpiration = 7;

        // Act

        // Get option chain
        var optionChain = await _instrumentService.GetOptionChainAsync(MsftTestData.MsftConid);

        // Find expiration closest to target
        var targetExpiration = optionChain.Expirations!
            .OrderBy(e => Math.Abs(e.DaysToExpiration!.Value - targetDaysToExpiration))
            .First();

        // Find strike closest to current price (ATM)
        var atmStrike = targetExpiration.Strikes!
            .OrderBy(s => Math.Abs(s - currentStockPrice))
            .First();

        // Assert
        targetExpiration.DaysToExpiration.Should().BeLessOrEqualTo(30);
        atmStrike.Should().BeGreaterThan(0);
        Math.Abs(atmStrike - currentStockPrice).Should().BeLessOrEqualTo(20m,
            "ATM strike should be close to current price");
    }

    /// <summary>
    /// Scenario: Get both call and put contracts for a butterfly spread
    /// </summary>
    [Fact]
    public async Task GetOptionsForButterflySpread()
    {
        // Arrange
        var expiration = DateTime.Today.AddDays(7).ToString("yyyyMMdd");

        // Butterfly spread strikes (e.g., 420/425/430)
        var lowerStrike = 420m;
        var middleStrike = 425m;
        var upperStrike = 430m;

        // Act

        // Get option chain to verify strikes are available
        var optionChain = await _instrumentService.GetOptionChainAsync(MsftTestData.MsftConid);
        var targetExpiration = optionChain.Expirations!
            .First(e => e.Expiration == expiration);

        // Assert
        targetExpiration.Strikes.Should().Contain(lowerStrike);
        targetExpiration.Strikes.Should().Contain(middleStrike);
        targetExpiration.Strikes.Should().Contain(upperStrike);

        // Verify strikes are properly spaced (equal distance)
        var spacing1 = middleStrike - lowerStrike;
        var spacing2 = upperStrike - middleStrike;
        spacing1.Should().Be(spacing2, "butterfly spread requires equal strike spacing");
    }
}
