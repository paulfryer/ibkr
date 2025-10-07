using IBKR.Api.Kiota.Client;
using IBKR.Api.Kiota.Client.Iserver.Secdef.Search;
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

        // Act - Fluent API: client.Iserver.Secdef.Search
        var results = await _client.Iserver.Secdef.Search.GetAsync(config =>
        {
            config.QueryParameters.Symbol = symbol;
            config.QueryParameters.SecTypeAsGetSecTypeQueryParameterType = GetSecTypeQueryParameterType.STK;
            config.QueryParameters.Name = false;
        });

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
        var quote = await _client.Iserver.Marketdata.Snapshot.GetAsync(config =>
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

        // Request multiple market data fields using Fields string
        // 31 = Last Price, 84 = Bid Price, 86 = Ask Price
        var fieldsString = "31,84,86,85,88";

        // Act - Fluent API with string fields
        var quote = await _client.Iserver.Marketdata.Snapshot.GetAsync(config =>
        {
            config.QueryParameters.Conids = conid;
            config.QueryParameters.Fields = fieldsString;
        });

        // Assert
        Assert.NotNull(quote);

        // Note: FyiVT model is used for market data snapshots
        // Market data fields are returned in V (value) and T (time) properties
    }

    [Fact]
    public async Task GetRegulatorySnapshot_WithConid_ReturnsSnapshot()
    {
        // Arrange
        var conid = 265598; // AAPL

        // Act - Fluent API: client.Md.Regsnapshot with query parameter
        var snapshot = await _client.Md.Regsnapshot.GetAsync(config =>
        {
            config.QueryParameters.Conid = conid;
        });

        // Assert
        Assert.NotNull(snapshot);
        Assert.Equal(265598, snapshot.Conid);
    }

    [Fact(Skip = "Requires mock implementation of search and snapshot endpoints")]
    public async Task FullWorkflow_SearchAndGetQuote_Succeeds()
    {
        // Arrange
        var symbol = "AAPL";

        // Act - Step 1: Search for stock using fluent API
        var searchResults = await _client.Iserver.Secdef.Search.GetAsync(config =>
        {
            config.QueryParameters.Symbol = symbol;
            config.QueryParameters.SecTypeAsGetSecTypeQueryParameterType = GetSecTypeQueryParameterType.STK;
        });

        var stock = searchResults.First();
        var conidString = stock.Conid;
        Assert.NotNull(conidString);
        var conid = int.Parse(conidString);

        // Act - Step 2: Get quote using fluent API
        var quote = await _client.Iserver.Marketdata.Snapshot.GetAsync(config =>
        {
            config.QueryParameters.Conids = conid;
            config.QueryParameters.FieldsAsMdFields = MdFields.ThreeOne;
        });

        // Assert
        Assert.NotNull(quote);
    }

    [Fact]
    public async Task FluentAPI_Demonstration_ShowsDiscoverability()
    {
        // This test demonstrates the discoverable nature of the Kiota SDK's fluent API
        // IntelliSense guides you through the API structure:

        // Type: _client.
        //   -> Shows: Iserver, Md, Fyi, Gw, etc.

        // Type: _client.Iserver.
        //   -> Shows: Marketdata, Secdef, Account, Orders, etc.

        // Type: _client.Iserver.Marketdata.
        //   -> Shows: Snapshot, History, Unsubscribe, etc.

        // Type: _client.Iserver.Marketdata.Snapshot.
        //   -> Shows: GetAsync(), ToGetRequestInformation(), etc.

        // This fluent structure makes API exploration intuitive!

        var conid = 265598; // AAPL

        var quote = await _client
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
