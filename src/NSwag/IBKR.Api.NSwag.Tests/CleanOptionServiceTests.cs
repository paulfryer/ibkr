using IBKR.Sdk.Client.Services;
using IBKR.Sdk.Contract.Enums;
using IBKR.Sdk.Contract.Interfaces;
using IBKR.Api.NSwag.Contract.Interfaces;
using Microsoft.Extensions.Logging;
using Xunit;

namespace IBKR.Api.NSwag.Tests;

/// <summary>
/// Tests demonstrating the CLEAN API usage.
/// Notice: No try/catch, no workarounds, no JSON deserialization, no magic strings.
/// All the messy logic is isolated in IBKR.Api.Client implementation.
/// </summary>
[Collection("IBKR API Sequential")]
public class CleanOptionServiceTests : IClassFixture<TestFixture>
{
    private readonly IOptionService _optionService;

    public CleanOptionServiceTests(TestFixture fixture)
    {
        // Get the raw NSwag service from TestFixture
        var nswagIserver = fixture.GetService<IIserverService>();
        var logger = fixture.GetService<ILogger<OptionService>>();

        // Wrap it with our clean service
        _optionService = new OptionService(nswagIserver, logger);
    }

    [Theory(Skip = "Requires authenticated IBKR session")]
    [InlineData("AAPL", 30)]
    [InlineData("TSLA", 60)]
    [InlineData("AMZN", 45)]
    public async Task GetOptionChain_WithCleanAPI_ReturnsStronglyTypedResults(string symbol, int daysAhead)
    {

        // Arrange
        var now = DateTime.UtcNow;
        var expirationStart = now;
        var expirationEnd = now.AddDays(daysAhead);

        // Act - LOOK HOW CLEAN THIS IS!
        var optionChain = await _optionService.GetOptionChainAsync(
            symbol,
            expirationStart,
            expirationEnd);

        // Assert - Clean, strongly-typed models
        Assert.NotNull(optionChain);
        Assert.Equal(symbol, optionChain.Symbol);
        Assert.True(optionChain.UnderlyingContractId > 0);
        Assert.NotEmpty(optionChain.Contracts);
        Assert.Equal(expirationStart, optionChain.RequestedExpirationStart);
        Assert.Equal(expirationEnd, optionChain.RequestedExpirationEnd);

        // Verify all contracts have clean, properly typed data
        foreach (var contract in optionChain.Contracts)
        {
            // DateTime, not string!
            Assert.True(contract.Expiration >= expirationStart);
            Assert.True(contract.Expiration <= expirationEnd);

            // Enum, not string!
            Assert.True(contract.Right == OptionRight.Call || contract.Right == OptionRight.Put);

            // Decimal, not object or double!
            Assert.True(contract.Strike > 0);
            Assert.True(contract.Multiplier > 0);

            // Proper IDs
            Assert.True(contract.ContractId > 0);
            Assert.Equal(optionChain.UnderlyingContractId, contract.UnderlyingContractId);

            // Clean strings
            Assert.False(string.IsNullOrEmpty(contract.Symbol));
            Assert.False(string.IsNullOrEmpty(contract.Currency));

            // Array, not CSV string!
            Assert.NotNull(contract.ValidExchanges);

            // Calculated field
            if (contract.DaysUntilExpiration.HasValue)
            {
                Assert.True(contract.DaysUntilExpiration.Value >= 0);
            }
        }
    }

    [Fact(Skip = "Requires authenticated IBKR session - Demo test showing clean API")]
    public async Task GetOptionChain_DemoTest_ShowsCleanAPIVsRawSDK()
    {
        // CLEAN API - This is what consumers use
        var optionChain = await _optionService.GetOptionChainAsync(
            "AAPL",
            DateTime.UtcNow,
            DateTime.UtcNow.AddDays(30));

        // Look at the results - clean, intuitive, strongly-typed:
        foreach (var contract in optionChain.Contracts.Take(5))
        {
            Console.WriteLine($"Contract: {contract.Symbol} " +
                             $"{contract.Right} " +  // Enum: Call or Put
                             $"Strike: {contract.Strike:C} " +  // Decimal
                             $"Exp: {contract.Expiration:yyyy-MM-dd} " +  // DateTime
                             $"DTE: {contract.DaysUntilExpiration} " +  // Calculated int
                             $"Exchanges: [{string.Join(", ", contract.ValidExchanges)}]");  // Array
        }

        // Compare this to the raw SDK version (in OptionDiscoveryWorkflowTests.cs):
        // - No try/catch blocks
        // - No JSON deserialization
        // - No string parsing for dates
        // - No manual enum conversion
        // - No CSV splitting for exchanges
        // - No workarounds for array vs single object
        //
        // ALL THAT MESS IS HIDDEN in IBKR.Api.Client.Services.OptionService!

        Assert.NotNull(optionChain);
        Assert.True(optionChain.Contracts.Count > 0);
    }
}
