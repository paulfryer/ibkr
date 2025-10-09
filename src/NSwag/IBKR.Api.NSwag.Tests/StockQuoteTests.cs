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

        // Act - First call (pre-flight initialization)
        await _iserverService.SnapshotAsync(conids: conid, fields: null);

        // Act - Second call (actual data)
        var quotes = await _iserverService.SnapshotAsync(
            conids: conid,
            fields: null // Could pass MdFields enum or string like "31,84,86,85,88"
        );

        // Assert
        Assert.NotNull(quotes);
        Assert.NotEmpty(quotes);

        var quote = quotes.First();
        Assert.NotNull(quote.AdditionalProperties);

        // Verify all basic price fields are present
        Assert.True(quote.AdditionalProperties.ContainsKey("31"), "Last price missing");
        Assert.True(quote.AdditionalProperties.ContainsKey("84"), "Bid missing");
        Assert.True(quote.AdditionalProperties.ContainsKey("86"), "Ask missing");
        Assert.True(quote.AdditionalProperties.ContainsKey("85"), "Ask size missing");
        Assert.True(quote.AdditionalProperties.ContainsKey("88"), "Bid size missing");

        // Verify additional stock fields
        Assert.True(quote.AdditionalProperties.ContainsKey("87"), "Volume missing");
        Assert.True(quote.AdditionalProperties.ContainsKey("70"), "High missing");
        Assert.True(quote.AdditionalProperties.ContainsKey("71"), "Low missing");

        // Verify values can be parsed
        Assert.Equal("150.25", quote.AdditionalProperties["31"].ToString());
        Assert.Equal("150.20", quote.AdditionalProperties["84"].ToString());
        Assert.Equal("150.30", quote.AdditionalProperties["86"].ToString());
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

    [Fact]
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

        // Act - Step 2a: Pre-flight request (initializes data stream)
        await _iserverService.SnapshotAsync(conids: conid, fields: MdFields._31);

        // Act - Step 2b: Get actual quote data
        var quotes = await _iserverService.SnapshotAsync(
            conids: conid,
            fields: MdFields._31
        );

        // Assert
        Assert.NotNull(quotes);
        Assert.NotEmpty(quotes);

        var quote = quotes.First();
        Assert.NotNull(quote.AdditionalProperties);

        // Verify we got valid quote data
        Assert.True(quote.AdditionalProperties.ContainsKey("31"), "Last price missing");
        Assert.True(quote.AdditionalProperties.ContainsKey("84"), "Bid missing");
        Assert.True(quote.AdditionalProperties.ContainsKey("86"), "Ask missing");

        // Verify prices are numeric
        var last = decimal.Parse(quote.AdditionalProperties["31"].ToString()!);
        var bid = decimal.Parse(quote.AdditionalProperties["84"].ToString()!);
        var ask = decimal.Parse(quote.AdditionalProperties["86"].ToString()!);

        Assert.True(last > 0, "Last price should be positive");
        Assert.True(bid > 0, "Bid should be positive");
        Assert.True(ask > bid, "Ask should be greater than bid");
    }
}

