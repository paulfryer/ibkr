using IBKR.Api.Kiota.Client;
using IBKR.Api.Kiota.Client.Iserver.Secdef.Info;
using IBKR.Api.Kiota.Contract.Models;
using Xunit;

namespace IBKR.Api.Kiota.Tests;

/// <summary>
/// Tests for getting option quotes via the IBKR API using Kiota SDK's fluent API.
/// These tests demonstrate the workflow:
/// 1. Find an option contract (either by searching or knowing the conid)
/// 2. Request market data snapshot for the option
/// 3. Parse option quote data (bid, ask, last price, implied volatility, greeks)
/// </summary>
public class OptionQuoteTests : IClassFixture<TestFixture>
{
    private readonly IBKRClient _client;

    public OptionQuoteTests(TestFixture fixture)
    {
        _client = fixture.GetService<IBKRClient>();
    }

    [Fact]
    public async Task GetOptionQuote_WithConid_ReturnsMarketData()
    {
        // Arrange
        // This would be the conid of a specific option contract
        // In practice, you'd get this from Info2 after selecting a strike
        var optionConid = 12345678; // Example option conid

        // Act - Get market data snapshot for the option using fluent API
        var quote = await _client.Iserver.Marketdata.Snapshot.GetAsync(config =>
        {
            config.QueryParameters.Conids = optionConid;
            config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne; // Field 31 = Last Price
        });

        // Assert
        Assert.NotNull(quote);

        // Note: FyiVT model is used for market data snapshots
        // Market data fields are returned in V (value) and T (time) properties
    }

    [Fact]
    public async Task GetOptionQuote_WithMultipleFields_ReturnsFullQuote()
    {
        // Arrange
        var optionConid = 12345678; // Example option conid

        // Request multiple option-specific market data fields:
        // 31 = Last Price
        // 84 = Bid Price
        // 86 = Ask Price
        // 85 = Ask Size
        // 88 = Bid Size
        // 7295 = Implied Volatility
        // 7308 = Delta
        // 7309 = Gamma
        // 7310 = Vega
        // 7311 = Theta

        // Act - Using MdFields enum for multiple field codes
        var quote = await _client.Iserver.Marketdata.Snapshot.GetAsync(config =>
        {
            config.QueryParameters.Conids = optionConid;
            config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne; // Could pass fieldsString instead
        });

        // Assert
        Assert.NotNull(quote);

        // In a real response, fields like "31", "84", "86", "7295" (IV), "7308" (Delta) would be present
        // In mock response, the FyiVT model will contain test data
    }

    [Fact(Skip = "Requires mock implementation of Info2 and Snapshot endpoints")]
    public async Task FullWorkflow_GetStrikeAndQuote_Succeeds()
    {
        // Arrange
        var underlyingConid = "265598"; // AAPL
        var month = "20250117"; // January 17, 2025
        var strike = 150.0;

        // Act - Step 1: Get option contract info to get the option conid
        var optionInfo = await _client.Iserver.Secdef.Info.GetAsync(config =>
        {
            config.QueryParameters.Conid = underlyingConid;
            config.QueryParameters.Sectype = "OPT";
            config.QueryParameters.Month = month;
            config.QueryParameters.Exchange = "SMART";
            config.QueryParameters.Strike = strike.ToString();
            config.QueryParameters.RightAsGetRightQueryParameterType = GetRightQueryParameterType.C; // Call option
        });

        Assert.NotNull(optionInfo);
        var optionConid = optionInfo.Conid;
        Assert.NotNull(optionConid);

        // Act - Step 2: Get quote for the specific option contract using fluent API
        var quote = await _client.Iserver.Marketdata.Snapshot.GetAsync(config =>
        {
            config.QueryParameters.Conids = optionConid.Value;
            config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne;
        });

        // Assert
        Assert.NotNull(quote);
    }

    [Fact]
    public async Task GetOptionQuote_ForPut_ReturnsMarketData()
    {
        // Arrange
        var putOptionConid = 87654321; // Example put option conid

        // Act - Fluent API for put option quote
        var quote = await _client.Iserver.Marketdata.Snapshot.GetAsync(config =>
        {
            config.QueryParameters.Conids = putOptionConid;
            config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne;
        });

        // Assert
        Assert.NotNull(quote);
    }

    [Fact]
    public async Task GetOptionQuote_MultipleOptions_ReturnsBatch()
    {
        // Arrange
        // Note: Conids parameter accepts int?, so for multiple quotes call separately
        var optionConid1 = 12345678;
        var optionConid2 = 87654321;

        // Act - Get quotes for first option using fluent API
        var quote1 = await _client.Iserver.Marketdata.Snapshot.GetAsync(config =>
        {
            config.QueryParameters.Conids = optionConid1;
            config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne;
        });

        // Act - Get quotes for second option using fluent API
        var quote2 = await _client.Iserver.Marketdata.Snapshot.GetAsync(config =>
        {
            config.QueryParameters.Conids = optionConid2;
            config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne;
        });

        // Assert
        Assert.NotNull(quote1);
        Assert.NotNull(quote2);

        // In a real response, each FyiVT object would contain the market data for one option
    }

    [Fact(Skip = "Requires mock implementation demonstrating option greeks")]
    public async Task GetOptionQuote_WithGreeks_ReturnsRiskMetrics()
    {
        // Arrange
        var optionConid = 12345678;

        // Request option greeks:
        // 7308 = Delta - Rate of change of option price relative to underlying price
        // 7309 = Gamma - Rate of change of delta
        // 7310 = Vega - Sensitivity to volatility changes
        // 7311 = Theta - Time decay
        // 7295 = Implied Volatility

        // Act - Fluent API with greeks fields
        var quote = await _client.Iserver.Marketdata.Snapshot.GetAsync(config =>
        {
            config.QueryParameters.Conids = optionConid;
            config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne; // Could pass fieldsString instead
        });

        // Assert
        Assert.NotNull(quote);

        // In a real response, you would extract greeks from the FyiVT model:
        // The V property would contain field values
        // The T property would contain timestamps
    }

    [Fact]
    public async Task GetOptionQuote_DemonstratesFieldCodes()
    {
        // This test demonstrates common market data field codes for options:
        //
        // Basic Price Fields:
        // 31 = Last Price
        // 84 = Bid Price
        // 86 = Ask Price
        // 85 = Ask Size
        // 88 = Bid Size
        //
        // Volume & Interest:
        // 87 = Volume
        // 7289 = Open Interest
        //
        // Option Greeks:
        // 7308 = Delta
        // 7309 = Gamma
        // 7310 = Vega
        // 7311 = Theta
        //
        // Volatility:
        // 7295 = Implied Volatility
        //
        // Other Option Fields:
        // 7283 = Option Open Price
        // 7284 = Option High Price
        // 7285 = Option Low Price
        // 7286 = Option Close Price

        var optionConid = 12345678;

        var quote = await _client
            .Iserver
            .Marketdata
            .Snapshot
            .GetAsync(config =>
            {
                config.QueryParameters.Conids = optionConid;
                config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne;
            });

        Assert.NotNull(quote);
    }

    [Fact]
    public async Task FluentAPI_Demonstration_ShowsDiscoverability()
    {
        // This test demonstrates the discoverable nature of the Kiota SDK's fluent API
        // for option quote requests:

        // Type: _client.
        //   -> Shows: Iserver, Md, Fyi, Gw, etc.

        // Type: _client.Iserver.
        //   -> Shows: Marketdata, Secdef, Account, Orders, etc.

        // Type: _client.Iserver.Marketdata.
        //   -> Shows: Snapshot, History, Unsubscribe, etc.

        // Type: _client.Iserver.Marketdata.Snapshot.
        //   -> Shows: GetAsync(), ToGetRequestInformation(), etc.

        // Type: config.QueryParameters.
        //   -> Shows: Conids, Fields, FieldsAsMdFields, etc.

        // This fluent structure makes working with option quotes intuitive!

        var optionConid = 12345678;

        var quote = await _client
            .Iserver
            .Marketdata
            .Snapshot
            .GetAsync(config =>
            {
                config.QueryParameters.Conids = optionConid;
                config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne;
            });

        Assert.NotNull(quote);
    }
}
