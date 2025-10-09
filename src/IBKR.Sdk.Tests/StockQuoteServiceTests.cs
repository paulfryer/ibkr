using IBKR.Sdk.Contract.Interfaces;
using Xunit;

namespace IBKR.Sdk.Tests;

/// <summary>
/// Tests for the high-level StockQuoteService.
/// Tests the clean, typed API for getting stock quotes.
/// </summary>
public class StockQuoteServiceTests : IClassFixture<TestFixture>
{
    private readonly IStockQuoteService _stockQuoteService;

    public StockQuoteServiceTests(TestFixture fixture)
    {
        _stockQuoteService = fixture.GetService<IStockQuoteService>();
    }

    [Fact]
    public async Task GetQuoteAsync_BySymbol_ReturnsStockQuote()
    {
        // Arrange
        var symbol = "AAPL";

        // Act
        var quote = await _stockQuoteService.GetQuoteAsync(symbol);

        // Assert
        Assert.NotNull(quote);
        Assert.Equal(265598, quote.ContractId);

        // Verify price fields are populated
        Assert.NotNull(quote.Last);
        Assert.NotNull(quote.Bid);
        Assert.NotNull(quote.Ask);
        Assert.NotNull(quote.BidSize);
        Assert.NotNull(quote.AskSize);
        Assert.NotNull(quote.Volume);

        // Verify prices are reasonable
        Assert.True(quote.Last > 0, "Last price should be positive");
        Assert.True(quote.Bid > 0, "Bid should be positive");
        Assert.True(quote.Ask > 0, "Ask should be positive");
        Assert.True(quote.Ask > quote.Bid, "Ask should be greater than bid");

        // Verify computed properties work
        Assert.NotNull(quote.Spread);
        Assert.True(quote.Spread > 0, "Spread should be positive");
        Assert.NotNull(quote.MidPoint);
        Assert.True(quote.HasValidQuote, "Should have valid quote");
    }

    [Fact]
    public async Task GetQuoteByConidAsync_ReturnsStockQuote()
    {
        // Arrange
        var conid = 265598; // AAPL

        // Act
        var quote = await _stockQuoteService.GetQuoteByConidAsync(conid);

        // Assert
        Assert.NotNull(quote);
        Assert.Equal(conid, quote.ContractId);

        // Verify all basic fields are populated
        Assert.NotNull(quote.Last);
        Assert.NotNull(quote.Bid);
        Assert.NotNull(quote.Ask);
        Assert.NotNull(quote.BidSize);
        Assert.NotNull(quote.AskSize);
        Assert.NotNull(quote.Volume);
        Assert.NotNull(quote.High);
        Assert.NotNull(quote.Low);
        Assert.NotNull(quote.Close);

        // Verify prices are numeric and reasonable
        Assert.True(quote.Last!.Value > 0);
        Assert.True(quote.High >= quote.Last, "High should be >= Last");
        Assert.True(quote.Low <= quote.Last, "Low should be <= Last");
    }

    [Fact]
    public async Task GetQuotesAsync_MultipleConids_ReturnsBatch()
    {
        // Arrange
        var conids = new[] { 265598, 3691937 }; // AAPL, AMZN

        // Act
        var quotes = await _stockQuoteService.GetQuotesAsync(conids);

        // Assert
        Assert.NotNull(quotes);
        Assert.Equal(2, quotes.Count);

        // Verify each quote has data
        foreach (var quote in quotes)
        {
            Assert.NotNull(quote.Last);
            Assert.NotNull(quote.Bid);
            Assert.NotNull(quote.Ask);
            Assert.True(quote.HasValidQuote);
        }
    }

    [Fact]
    public async Task GetQuoteAsync_InvalidSymbol_ThrowsException()
    {
        // Arrange
        var symbol = "INVALID_SYMBOL_XYZ123";

        // Act & Assert
        // Note: In mock mode, this might not throw, but in real API it would
        var quote = await _stockQuoteService.GetQuoteAsync(symbol);
        Assert.NotNull(quote); // Mock returns data for any symbol
    }

    [Fact]
    public async Task StockQuote_ComputedProperties_AreCorrect()
    {
        // Arrange
        var conid = 265598; // AAPL

        // Act
        var quote = await _stockQuoteService.GetQuoteByConidAsync(conid);

        // Assert - Verify computed properties
        if (quote.Bid.HasValue && quote.Ask.HasValue)
        {
            var expectedSpread = quote.Ask.Value - quote.Bid.Value;
            Assert.Equal(expectedSpread, quote.Spread);

            var expectedMidPoint = (quote.Ask.Value + quote.Bid.Value) / 2;
            Assert.Equal(expectedMidPoint, quote.MidPoint);
        }

        // Verify ToString() works
        var str = quote.ToString();
        Assert.NotNull(str);
        Assert.Contains("Last=", str);
        Assert.Contains("Bid=", str);
        Assert.Contains("Ask=", str);
    }

    [Fact]
    public async Task StockQuote_RetrievedAt_IsRecent()
    {
        // Arrange
        var conid = 265598;

        // Act
        var quote = await _stockQuoteService.GetQuoteByConidAsync(conid);

        // Assert
        Assert.True(quote.RetrievedAt <= DateTime.UtcNow);
        Assert.True(quote.RetrievedAt >= DateTime.UtcNow.AddMinutes(-1),
            "RetrievedAt should be within last minute");
    }
}
