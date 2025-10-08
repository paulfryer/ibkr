using System.Threading.Tasks;
using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.Contract.Models;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace IBKR.Api.NSwag.Tests;

/// <summary>
/// Tests for getting stock quotes via the IBKR API.
/// These tests demonstrate the workflow:
/// 1. Search for a stock by symbol to get the contract ID (conid)
/// 2. Request market data snapshot for the stock
/// 3. Parse quote data (bid, ask, last price)
/// </summary>
public class StockQuoteTests : IClassFixture<TestFixture>
{
    private readonly IIserverService _iserverService;
    private readonly IMdService _mdService;

    public StockQuoteTests(TestFixture fixture)
    {
        _iserverService = fixture.GetService<IIserverService>();
        _mdService = fixture.GetService<IMdService>();
    }

    [Fact]
    public async Task SearchStock_BySymbol_ReturnsContracts()
    {
        // Arrange
        var symbol = "AAPL";


        var results = await _iserverService.SearchAllPOSTAsync(new Body22
        {
            Symbol = symbol,
            Name = true,
            SecType = Body22SecType.STK
        });


        // Act
       // var results = await _iserverService.SearchAllGETAsync(
       //     symbol: symbol,
      //      secType: SecType.STK,
        //    name: false
        //);

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
        var conid = "265598"; // AAPL

        // Act
        var quotes = await _iserverService.SnapshotAsync(
            conids: conid,
            fields: MdFields._31 // Field 31 = Last Price
        );

        // Assert
        Assert.NotNull(quotes);
        Assert.NotEmpty(quotes);

        var quote = quotes.First();
        // Market data is returned in AdditionalProperties dictionary
        // with field codes as keys (e.g., "31" for last price, "84" for bid, "86" for ask)
        Assert.NotNull(quote.AdditionalProperties);
    }

    [Fact]
    public async Task GetStockQuote_WithMultipleFields_ReturnsFullQuote()
    {
        // Arrange
        var conid = "265598"; // AAPL

        // Request multiple market data fields:
        // 31 = Last Price, 84 = Bid Price, 86 = Ask Price
        // 85 = Ask Size, 88 = Bid Size

        // Act
        var quotes = await _iserverService.SnapshotAsync(
            conids: conid,
            fields: null // Could pass MdFields enum or string like "31,84,86,85,88"
        );

        // Assert
        Assert.NotNull(quotes);
        Assert.NotEmpty(quotes);

        var quote = quotes.First();
        Assert.NotNull(quote.AdditionalProperties);

        // Verify we can access market data fields
        // In a real response, fields like "31", "84", "86" would be present
        // In mock response, AdditionalProperties will contain test data
    }

    [Fact]
    public async Task GetRegulatorySnapshot_WithConid_ReturnsSnapshot()
    {
        // Arrange
        var conid = "265598"; // AAPL

        // Act
        var snapshot = await _mdService.RegsnapshotAsync(conid);

        // Assert
        Assert.NotNull(snapshot);
        Assert.Equal(265598, snapshot.Conid);
    }

    [Fact(Skip = "Requires mock implementation of SearchAllGETAsync and SnapshotAsync")]
    public async Task FullWorkflow_SearchAndGetQuote_Succeeds()
    {
        // Arrange
        var symbol = "AAPL";

        // Act - Step 1: Search for stock
        var searchResults = await _iserverService.SearchAllGETAsync(
            symbol: symbol,
            secType: SecType.STK
        );

        var stock = searchResults.First();
        var conid = stock.Conid?.ToString();
        Assert.NotNull(conid);

        // Act - Step 2: Get quote
        var quotes = await _iserverService.SnapshotAsync(
            conids: conid,
            fields: MdFields._31
        );

        // Assert
        Assert.NotNull(quotes);
        Assert.NotEmpty(quotes);

        var quote = quotes.First();
        Assert.NotNull(quote.AdditionalProperties);
    }
}
