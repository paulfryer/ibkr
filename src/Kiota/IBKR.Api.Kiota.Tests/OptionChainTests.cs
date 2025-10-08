using IBKR.Api.Kiota.Client;
using IBKR.Api.Kiota.Client.V1.Api.Iserver.Secdef.Info;
using IBKR.Api.Kiota.Client.V1.Api.Iserver.Secdef.Search;
using IBKR.Api.Kiota.Client.V1.Api.Iserver.Secdef.Strikes;
using IBKR.Api.Kiota.Contract.Models;
using Xunit;

namespace IBKR.Api.Kiota.Tests;

/// <summary>
/// Tests for getting stock option chains via the IBKR API using Kiota SDK's fluent API.
/// These tests demonstrate the workflow:
/// 1. Search for an underlying stock to get its contract ID (conid)
/// 2. Get available option strikes for a specific expiration month
/// 3. Get option contract details for specific strikes
/// </summary>
public class OptionChainTests : IClassFixture<TestFixture>
{
    private readonly IBKRClient _client;

    public OptionChainTests(TestFixture fixture)
    {
        _client = fixture.GetService<IBKRClient>();
    }

    [Fact]
    public async Task GetOptionStrikes_ForUnderlying_ReturnsCallsAndPuts()
    {
        // Arrange
        var conid = "265598"; // AAPL
        var sectype = "OPT"; // Option security type
        var month = "202501"; // January 2025 (YYYYMM format)

        // Act - Fluent API: client.Iserver.Secdef.Strikes
        var strikes = await _client.V1.Api.Iserver.Secdef.Strikes.GetAsStrikesGetResponseAsync(config =>
        {
            config.QueryParameters.Conid = conid;
            config.QueryParameters.Sectype = sectype;
            config.QueryParameters.Month = month;
            config.QueryParameters.Exchange = "SMART";
        });

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

        // Act - Get call option info using fluent API
        var callInfo = await _client.V1.Api.Iserver.Secdef.Info.GetAsync(config =>
        {
            config.QueryParameters.Conid = conid;
            config.QueryParameters.Sectype = "OPT";
            config.QueryParameters.Month = month;
            config.QueryParameters.Exchange = "SMART";
            config.QueryParameters.Strike = strike.ToString();
            config.QueryParameters.RightAsGetRightQueryParameterType = GetRightQueryParameterType.C; // Call option
        });

        // Assert
        Assert.NotNull(callInfo);
        Assert.Equal(strike, callInfo.Strike);
        Assert.Equal(SecDefInfoResponse_right.C, callInfo.Right);
        Assert.Contains("AAPL", callInfo.Ticker ?? "");
    }

    [Fact]
    public async Task GetOptionChain_BothCallsAndPuts_ReturnsFullChain()
    {
        // Arrange
        var underlyingConid = "265598"; // AAPL
        var month = "202501"; // January 2025

        // Act - Step 1: Get available strikes using fluent API
        var strikes = await _client.V1.Api.Iserver.Secdef.Strikes.GetAsStrikesGetResponseAsync(config =>
        {
            config.QueryParameters.Conid = underlyingConid;
            config.QueryParameters.Sectype = "OPT";
            config.QueryParameters.Month = month;
        });

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

            // You could then call Info2 for this specific strike
            // to get the full contract details including conid
        }
    }

    [Fact(Skip = "Requires mock implementation of Search and Strikes endpoints")]
    public async Task FullWorkflow_SearchStockAndGetOptions_Succeeds()
    {
        // Arrange
        var symbol = "AAPL";
        var month = "202501";

        // Act - Step 1: Search for underlying stock using fluent API
        var searchResults = await _client.V1.Api.Iserver.Secdef.Search.GetAsync(config =>
        {
            config.QueryParameters.Symbol = symbol;
            config.QueryParameters.SecTypeAsGetSecTypeQueryParameterType = GetSecTypeQueryParameterType.STK;
        });

        var stock = searchResults.First();
        var conid = stock.Conid;
        Assert.NotNull(conid);

        // Act - Step 2: Get option strikes using fluent API
        var strikes = await _client.V1.Api.Iserver.Secdef.Strikes.GetAsStrikesGetResponseAsync(config =>
        {
            config.QueryParameters.Conid = conid;
            config.QueryParameters.Sectype = "OPT";
            config.QueryParameters.Month = month;
        });

        // Assert
        Assert.NotNull(strikes);
        Assert.NotNull(strikes.Call);
        Assert.NotNull(strikes.Put);

        // Act - Step 3: Get contract info for a specific strike using fluent API
        if (strikes.Call.Any())
        {
            var targetStrike = strikes.Call.First();

            var contractInfo = await _client.V1.Api.Iserver.Secdef.Info.GetAsync(config =>
            {
                config.QueryParameters.Conid = conid;
                config.QueryParameters.Sectype = "OPT";
                config.QueryParameters.Month = "20250117";
                config.QueryParameters.Strike = targetStrike.ToString();
                config.QueryParameters.RightAsGetRightQueryParameterType = GetRightQueryParameterType.C;
            });

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

        // Act - Get put option info using fluent API
        var putInfo = await _client.V1.Api.Iserver.Secdef.Info.GetAsync(config =>
        {
            config.QueryParameters.Conid = conid;
            config.QueryParameters.Sectype = "OPT";
            config.QueryParameters.Month = month;
            config.QueryParameters.Exchange = "SMART";
            config.QueryParameters.Strike = strike.ToString();
            config.QueryParameters.RightAsGetRightQueryParameterType = GetRightQueryParameterType.P; // Put option
        });

        // Assert
        Assert.NotNull(putInfo);
        Assert.Equal(strike, putInfo.Strike);
        Assert.Equal(SecDefInfoResponse_right.P, putInfo.Right);
    }

    [Fact]
    public async Task GetOptionChain_MultipleExpirations_DemonstratesDateFormats()
    {
        // This test demonstrates different date formats used in the API:
        // - YYYYMM format for Strikes (e.g., "202501" for January 2025)
        // - YYYYMMDD format for Info2 (e.g., "20250117" for January 17, 2025)

        var conid = "265598"; // AAPL

        // Format 1: YYYYMM for getting strikes
        var monthFormat1 = "202501"; // January 2025

        var strikes = await _client.V1.Api.Iserver.Secdef.Strikes.GetAsStrikesGetResponseAsync(config =>
        {
            config.QueryParameters.Conid = conid;
            config.QueryParameters.Sectype = "OPT";
            config.QueryParameters.Month = monthFormat1;
        });

        Assert.NotNull(strikes);

        // Format 2: YYYYMMDD for getting contract details
        var monthFormat2 = "20250117"; // January 17, 2025

        if (strikes.Call.Any())
        {
            var contractInfo = await _client.V1.Api.Iserver.Secdef.Info.GetAsync(config =>
            {
                config.QueryParameters.Conid = conid;
                config.QueryParameters.Sectype = "OPT";
                config.QueryParameters.Month = monthFormat2;
                config.QueryParameters.Strike = strikes.Call.First().ToString();
                config.QueryParameters.RightAsGetRightQueryParameterType = GetRightQueryParameterType.C;
            });

            Assert.NotNull(contractInfo);
        }
    }

    [Fact]
    public async Task FluentAPI_Demonstration_ShowsDiscoverability()
    {
        // This test demonstrates the discoverable nature of the Kiota SDK's fluent API
        // IntelliSense guides you through the API structure:

        // Type: _client.
        //   -> Shows: V1, Iserver, Md, Fyi, Gw, etc.

        // Type: _client.V1.Api.Iserver.
        //   -> Shows: Marketdata, Secdef, Account, Orders, etc.

        // Type: _client.V1.Api.Iserver.Secdef.
        //   -> Shows: Search, Strikes, Info, etc.

        // Type: _client.V1.Api.Iserver.Secdef.Strikes.
        //   -> Shows: GetAsync(), ToGetRequestInformation(), etc.

        // This fluent structure makes API exploration intuitive!

        var conid = "265598"; // AAPL

        var strikes = await _client
            .V1
            .Api
            .Iserver
            .Secdef
            .Strikes
            .GetAsStrikesGetResponseAsync(config =>
            {
                config.QueryParameters.Conid = conid;
                config.QueryParameters.Sectype = "OPT";
                config.QueryParameters.Month = "202501";
            });

        Assert.NotNull(strikes);
    }
}
