using IBKR.Api.Kiota.Client;
using IBKR.Api.Kiota.Client.V1.Api.Iserver.Secdef.Search;
using IBKR.Api.Kiota.Contract.Models;
using Xunit;

namespace IBKR.Api.Kiota.Tests;

/// <summary>
/// Tests for getting stock quotes via the IBKR API using Kiota SDK's fluent API.
/// These tests demonstrate the workflow:
/// 1. Search for a stock by symbol to get the contract ID (conid)
/// 2. Request market data snapshot for the stock
/// 3. Parse quote data (bid, ask, last price)
/// </summary>
public class StockQuoteTests : IClassFixture<TestFixture>
{
    private readonly IBKRClient _client;

    public StockQuoteTests(TestFixture fixture)
    {
        _client = fixture.GetService<IBKRClient>();
    }

    [Fact]
    public async Task SearchStock_BySymbol_ReturnsContracts()
    {
        // Arrange
        var symbol = "AAPL";

        // Act - Fluent API: client.V1.Api.Iserver.Secdef.Search using POST (correct path with /v1/api)
        var requestBody = new IBKR.Api.Kiota.Client.V1.Api.Iserver.Secdef.Search.SearchPostRequestBody
        {
            Symbol = symbol,
            SecType = IBKR.Api.Kiota.Client.V1.Api.Iserver.Secdef.Search.SearchPostRequestBody_secType.STK,
            Name = true
        };

        var results = await _client.V1.Api.Iserver.Secdef.Search.PostAsync(requestBody);

        // Assert
        Assert.NotNull(results);
        Assert.NotEmpty(results);

        var stock = results.First();
        Assert.NotNull(stock.Conid);
        Assert.Contains(symbol, stock.Symbol ?? "", StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GetStockQuote_WithConid_ReturnsMarketData()
    {
        // Arrange
        var conid = 265598; // AAPL

        // Act - Fluent API: client.Iserver.Marketdata.Snapshot
        var quote = await _client.V1.Api.Iserver.Marketdata.Snapshot.GetAsync(config =>
        {
            config.QueryParameters.Conids = conid;
            config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne; // Field 31 = Last Price
        });

        // Assert
        Assert.NotNull(quote);

        // Note: FyiVT model is used for market data snapshots
        // Market data fields are returned in V (value) and T (time) properties
    }

    [Fact]
    public async Task GetStockQuote_WithMultipleFields_ReturnsFullQuote()
    {
        // Arrange
        var conid = 265598; // AAPL

        // Request multiple market data fields using MdFields enum
        // 31 = Last Price, 84 = Bid Price, 86 = Ask Price, 85 = Ask Size, 88 = Bid Size

        // Act - Fluent API with MdFields enum
        var quote = await _client.V1.Api.Iserver.Marketdata.Snapshot.GetAsync(config =>
        {
            config.QueryParameters.Conids = conid;
            config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne; // Could pass fieldsString instead
        });

        // Assert
        Assert.NotNull(quote);
        Assert.NotNull(quote.AdditionalData);

        // Verify all basic price fields are present
        Assert.True(quote.AdditionalData.ContainsKey("31"), "Last price missing");
        Assert.True(quote.AdditionalData.ContainsKey("84"), "Bid missing");
        Assert.True(quote.AdditionalData.ContainsKey("86"), "Ask missing");
        Assert.True(quote.AdditionalData.ContainsKey("85"), "Ask size missing");
        Assert.True(quote.AdditionalData.ContainsKey("88"), "Bid size missing");

        // Verify additional stock fields
        Assert.True(quote.AdditionalData.ContainsKey("87"), "Volume missing");
        Assert.True(quote.AdditionalData.ContainsKey("70"), "High missing");
        Assert.True(quote.AdditionalData.ContainsKey("71"), "Low missing");

        // Verify values can be parsed
        Assert.Equal("150.25", quote.AdditionalData["31"].ToString());
        Assert.Equal("150.20", quote.AdditionalData["84"].ToString());
    }

    [Fact]
    public async Task GetRegulatorySnapshot_WithConid_ReturnsSnapshot()
    {
        // Arrange
        var conid = 265598; // AAPL

        // Act - Fluent API: client.Md.Regsnapshot with query parameter
        var snapshot = await _client.V1.Api.Md.Regsnapshot.GetAsync(config =>
        {
            config.QueryParameters.Conid = conid;
        });

        // Assert
        Assert.NotNull(snapshot);
        Assert.Equal(265598, snapshot.Conid);
    }

    [Fact]
    public async Task FullWorkflow_SearchAndGetQuote_Succeeds()
    {
        // Arrange
        var symbol = "AAPL";

        // Act - Step 1: Search for stock using fluent API
        var searchResults = await _client.V1.Api.Iserver.Secdef.Search.GetAsync(config =>
        {
            config.QueryParameters.Symbol = symbol;
            config.QueryParameters.SecTypeAsGetSecTypeQueryParameterType = GetSecTypeQueryParameterType.STK;
        });

        var stock = searchResults.First();
        var conidString = stock.Conid;
        Assert.NotNull(conidString);
        var conid = int.Parse(conidString);

        // Act - Step 2: Get quote using fluent API
        var quote = await _client.V1.Api.Iserver.Marketdata.Snapshot.GetAsync(config =>
        {
            config.QueryParameters.Conids = conid;
            config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne;
        });

        // Assert
        Assert.NotNull(quote);
        Assert.NotNull(quote.AdditionalData);

        // Verify we got valid quote data
        Assert.True(quote.AdditionalData.ContainsKey("31"), "Last price missing");
        Assert.True(quote.AdditionalData.ContainsKey("84"), "Bid missing");
        Assert.True(quote.AdditionalData.ContainsKey("86"), "Ask missing");

        // Verify prices are numeric
        var last = decimal.Parse(quote.AdditionalData["31"].ToString()!);
        var bid = decimal.Parse(quote.AdditionalData["84"].ToString()!);
        var ask = decimal.Parse(quote.AdditionalData["86"].ToString()!);

        Assert.True(last > 0, "Last price should be positive");
        Assert.True(bid > 0, "Bid should be positive");
        Assert.True(ask > bid, "Ask should be greater than bid");
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

        // Type: _client.V1.Api.Iserver.Marketdata.
        //   -> Shows: Snapshot, History, Unsubscribe, etc.

        // Type: _client.V1.Api.Iserver.Marketdata.Snapshot.
        //   -> Shows: GetAsync(), ToGetRequestInformation(), etc.

        // This fluent structure makes API exploration intuitive!

        var conid = 265598; // AAPL

        var quote = await _client
            .V1
            .Api
            .Iserver
            .Marketdata
            .Snapshot
            .GetAsync(config =>
            {
                config.QueryParameters.Conids = conid;
                config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne;
            });

        Assert.NotNull(quote);
    }
}
