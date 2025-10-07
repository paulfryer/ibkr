using System.Threading.Tasks;
using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.Contract.Models;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace IBKR.Api.NSwag.Tests;

/// <summary>
/// Tests for getting stock option chains via the IBKR API.
/// These tests demonstrate the workflow:
/// 1. Search for an underlying stock to get its contract ID (conid)
/// 2. Get available option strikes for a specific expiration month
/// 3. Get option contract details for specific strikes
/// </summary>
public class OptionChainTests : IClassFixture<TestFixture>
{
    private readonly IIserverService _iserverService;

    public OptionChainTests(TestFixture fixture)
    {
        _iserverService = fixture.GetService<IIserverService>();
    }

    [Fact]
    public async Task GetOptionStrikes_ForUnderlying_ReturnsCallsAndPuts()
    {
        // Arrange
        var conid = "265598"; // AAPL
        var sectype = "OPT"; // Option security type
        var month = "202501"; // January 2025 (YYYYMM format)

        // Act
        var strikes = await _iserverService.StrikesAsync(
            conid: conid,
            sectype: sectype,
            month: month,
            exchange: "SMART"
        );

        // Assert
        Assert.NotNull(strikes);

        // Response contains collections of strike prices for calls and puts
        Assert.NotNull(strikes.Call);
        Assert.NotNull(strikes.Put);

        // Each collection should contain strike prices (e.g., 150.0, 155.0, 160.0)
        if (strikes.Call.Any())
        {
            Assert.All(strikes.Call, strike => Assert.True(strike > 0));
        }

        if (strikes.Put.Any())
        {
            Assert.All(strikes.Put, strike => Assert.True(strike > 0));
        }
    }

    [Fact]
    public async Task GetOptionContractInfo_ForSpecificStrike_ReturnsDetails()
    {
        // Arrange
        var conid = "265598"; // AAPL underlying
        var strike = 150.0;
        var month = "20250117"; // January 17, 2025 (YYYYMMDD format)

        // Act - Get call option info
        var callInfo = await _iserverService.Info2Async(
            conid: conid,
            sectype: "OPT",
            month: month,
            exchange: "SMART",
            strike: strike,
            right: Right.C // Call option
        );

        // Assert
        Assert.NotNull(callInfo);
        Assert.Equal(strike, callInfo.Strike);
        Assert.Equal(SecDefInfoResponseRight.C, callInfo.Right);
        Assert.Contains("AAPL", callInfo.Ticker ?? "");
    }

    [Fact]
    public async Task GetOptionChain_BothCallsAndPuts_ReturnsFullChain()
    {
        // Arrange
        var underlyingConid = "265598"; // AAPL
        var month = "202501"; // January 2025

        // Act - Step 1: Get available strikes
        var strikes = await _iserverService.StrikesAsync(
            conid: underlyingConid,
            sectype: "OPT",
            month: month
        );

        // Assert - Step 1: Verify strikes returned
        Assert.NotNull(strikes);
        Assert.NotNull(strikes.Call);
        Assert.NotNull(strikes.Put);

        // Step 2 (conceptual): For each strike, you could get contract details
        // This would typically be done for a specific strike of interest
        if (strikes.Call.Any())
        {
            var firstCallStrike = strikes.Call.First();
            Assert.True(firstCallStrike > 0);

            // You could then call Info2Async for this specific strike
            // to get the full contract details including conid
        }
    }

    [Fact(Skip = "Requires mock implementation of StrikesAsync and Info2Async")]
    public async Task FullWorkflow_SearchStockAndGetOptions_Succeeds()
    {
        // Arrange
        var symbol = "AAPL";
        var month = "202501";

        // Act - Step 1: Search for underlying stock
        var searchResults = await _iserverService.SearchAllGETAsync(
            symbol: symbol,
            secType: SecType.STK
        );

        var stock = searchResults.First();
        var conid = stock.Conid?.ToString();
        Assert.NotNull(conid);

        // Act - Step 2: Get option strikes
        var strikes = await _iserverService.StrikesAsync(
            conid: conid,
            sectype: "OPT",
            month: month
        );

        // Assert
        Assert.NotNull(strikes);
        Assert.NotNull(strikes.Call);
        Assert.NotNull(strikes.Put);

        // Act - Step 3: Get contract info for a specific strike
        if (strikes.Call.Any())
        {
            var targetStrike = strikes.Call.First();

            var contractInfo = await _iserverService.Info2Async(
                conid: conid,
                sectype: "OPT",
                month: "20250117",
                strike: targetStrike,
                right: Right.C
            );

            // Assert
            Assert.NotNull(contractInfo);
            Assert.Equal(targetStrike, contractInfo.Strike);
        }
    }

    [Fact]
    public async Task GetOptionInfo_ForPutOption_ReturnsPutDetails()
    {
        // Arrange
        var conid = "265598"; // AAPL underlying
        var strike = 145.0;
        var month = "20250117"; // January 17, 2025

        // Act - Get put option info
        var putInfo = await _iserverService.Info2Async(
            conid: conid,
            sectype: "OPT",
            month: month,
            exchange: "SMART",
            strike: strike,
            right: Right.P // Put option
        );

        // Assert
        Assert.NotNull(putInfo);
        Assert.Equal(strike, putInfo.Strike);
        Assert.Equal(SecDefInfoResponseRight.P, putInfo.Right);
    }

    [Fact]
    public async Task GetOptionChain_MultipleExpirations_DemonstratesDateFormats()
    {
        // This test demonstrates different date formats used in the API:
        // - YYYYMM format for StrikesAsync (e.g., "202501" for January 2025)
        // - YYYYMMDD format for Info2Async (e.g., "20250117" for January 17, 2025)

        var conid = "265598"; // AAPL

        // Format 1: YYYYMM for getting strikes
        var monthFormat1 = "202501"; // January 2025

        var strikes = await _iserverService.StrikesAsync(
            conid: conid,
            sectype: "OPT",
            month: monthFormat1
        );

        Assert.NotNull(strikes);

        // Format 2: YYYYMMDD for getting contract details
        var monthFormat2 = "20250117"; // January 17, 2025

        if (strikes.Call.Any())
        {
            var contractInfo = await _iserverService.Info2Async(
                conid: conid,
                sectype: "OPT",
                month: monthFormat2,
                strike: strikes.Call.First(),
                right: Right.C
            );

            Assert.NotNull(contractInfo);
        }
    }
}
