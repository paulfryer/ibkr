using IBKR.Sdk.Contract.Enums;
using IBKR.Sdk.Contract.Interfaces;
using Xunit;

namespace IBKR.Sdk.Tests;

/// <summary>
/// Tests for the high-level OptionQuoteService.
/// Tests the clean, typed API for getting option quotes with Greeks.
/// </summary>
public class OptionQuoteServiceTests : IClassFixture<TestFixture>
{
    private readonly IOptionQuoteService _optionQuoteService;

    public OptionQuoteServiceTests(TestFixture fixture)
    {
        _optionQuoteService = fixture.GetService<IOptionQuoteService>();
    }

    [Fact]
    public async Task GetQuoteAsync_ByConid_ReturnsOptionQuoteWithGreeks()
    {
        // Arrange
        var optionConid = 123456; // Example option conid (mock returns Greeks for conid > 100000)

        // Act
        var quote = await _optionQuoteService.GetQuoteAsync(optionConid);

        // Assert
        Assert.NotNull(quote);
        Assert.Equal(optionConid, quote.ContractId);

        // Verify basic price fields
        Assert.NotNull(quote.Last);
        Assert.NotNull(quote.Bid);
        Assert.NotNull(quote.Ask);
        Assert.NotNull(quote.BidSize);
        Assert.NotNull(quote.AskSize);

        // Verify option-specific fields
        Assert.True(quote.Strike > 0, "Strike should be positive");
        Assert.NotEqual(DateTime.MinValue, quote.Expiration);
        Assert.True(quote.Right == OptionRight.Call || quote.Right == OptionRight.Put);

        // Verify Greeks are populated
        Assert.NotNull(quote.Greeks);
        Assert.NotNull(quote.Greeks.Delta);
        Assert.NotNull(quote.Greeks.Gamma);
        Assert.NotNull(quote.Greeks.Vega);
        Assert.NotNull(quote.Greeks.Theta);
        Assert.NotNull(quote.Greeks.ImpliedVolatility);

        // Verify Greeks have reasonable values
        Assert.True(quote.Greeks.Delta >= -1 && quote.Greeks.Delta <= 1, $"Delta out of range: {quote.Greeks.Delta}");
        Assert.True(quote.Greeks.Gamma >= 0, $"Gamma should be positive: {quote.Greeks.Gamma}");
        Assert.True(quote.Greeks.Vega >= 0, $"Vega should be positive: {quote.Greeks.Vega}");
        Assert.True(quote.Greeks.Theta <= 0, $"Theta should be negative: {quote.Greeks.Theta}");
        Assert.True(quote.Greeks.ImpliedVolatility > 0 && quote.Greeks.ImpliedVolatility < 5,
            $"IV out of reasonable range: {quote.Greeks.ImpliedVolatility}");
    }

    [Fact]
    public async Task GetQuotesAsync_MultipleOptions_ReturnsBatch()
    {
        // Arrange
        var optionConids = new[] { 123456, 123457, 123458 }; // Multiple option conids

        // Act
        var quotes = await _optionQuoteService.GetQuotesAsync(optionConids);

        // Assert
        Assert.NotNull(quotes);
        Assert.Equal(3, quotes.Count);

        // Verify each quote has Greeks
        foreach (var quote in quotes)
        {
            Assert.NotNull(quote.Last);
            Assert.NotNull(quote.Greeks);
            Assert.NotNull(quote.Greeks.Delta);
            Assert.True(quote.HasGreeks, "Should have complete Greeks");
        }
    }

    [Fact]
    public async Task OptionQuote_Greeks_IsComplete()
    {
        // Arrange
        var optionConid = 123456;

        // Act
        var quote = await _optionQuoteService.GetQuoteAsync(optionConid);

        // Assert
        Assert.True(quote.Greeks!.IsComplete, "All Greeks should be present");

        // Verify Greeks.ToString() works
        var greeksStr = quote.Greeks.ToString();
        Assert.Contains("Delta:", greeksStr);
        Assert.Contains("Gamma:", greeksStr);
        Assert.Contains("Vega:", greeksStr);
        Assert.Contains("Theta:", greeksStr);
        Assert.Contains("IV:", greeksStr);
    }

    [Fact]
    public async Task OptionQuote_IsInTheMoney_CalculatesCorrectly()
    {
        // Arrange
        var optionConid = 123456;

        // Act
        var quote = await _optionQuoteService.GetQuoteAsync(optionConid);

        // Assert
        var underlyingPrice = 150m; // Assume underlying is at $150

        if (quote.Right == OptionRight.Call)
        {
            if (underlyingPrice > quote.Strike)
            {
                Assert.True(quote.IsInTheMoney(underlyingPrice), "Call should be ITM when underlying > strike");
            }
            else
            {
                Assert.False(quote.IsInTheMoney(underlyingPrice), "Call should be OTM when underlying <= strike");
            }
        }
        else if (quote.Right == OptionRight.Put)
        {
            if (underlyingPrice < quote.Strike)
            {
                Assert.True(quote.IsInTheMoney(underlyingPrice), "Put should be ITM when underlying < strike");
            }
            else
            {
                Assert.False(quote.IsInTheMoney(underlyingPrice), "Put should be OTM when underlying >= strike");
            }
        }
    }

    [Fact]
    public async Task OptionQuote_IntrinsicValue_CalculatesCorrectly()
    {
        // Arrange
        var optionConid = 123456;

        // Act
        var quote = await _optionQuoteService.GetQuoteAsync(optionConid);

        // Assert
        var underlyingPrice = 150m;
        var intrinsicValue = quote.IntrinsicValue(underlyingPrice);

        if (quote.Right == OptionRight.Call)
        {
            var expectedIntrinsic = Math.Max(0, underlyingPrice - quote.Strike);
            Assert.Equal(expectedIntrinsic, intrinsicValue);
        }
        else if (quote.Right == OptionRight.Put)
        {
            var expectedIntrinsic = Math.Max(0, quote.Strike - underlyingPrice);
            Assert.Equal(expectedIntrinsic, intrinsicValue);
        }

        Assert.True(intrinsicValue >= 0, "Intrinsic value should never be negative");
    }

    [Fact]
    public async Task OptionQuote_TimeValue_CalculatesCorrectly()
    {
        // Arrange
        var optionConid = 123456;

        // Act
        var quote = await _optionQuoteService.GetQuoteAsync(optionConid);

        // Assert
        var underlyingPrice = 150m;
        var timeValue = quote.TimeValue(underlyingPrice);

        Assert.NotNull(timeValue);

        // Time value = Option Price - Intrinsic Value
        var expectedTimeValue = quote.Last!.Value - quote.IntrinsicValue(underlyingPrice);
        Assert.Equal(expectedTimeValue, timeValue);

        // Time value should typically be positive (though can be negative near expiration)
        // For at-the-money options, time value should be significant
    }

    [Fact]
    public async Task OptionQuote_DaysUntilExpiration_IsCalculated()
    {
        // Arrange
        var optionConid = 123456;

        // Act
        var quote = await _optionQuoteService.GetQuoteAsync(optionConid);

        // Assert
        Assert.NotNull(quote.DaysUntilExpiration);
        Assert.True(quote.DaysUntilExpiration >= 0, "Days until expiration should be non-negative");
    }

    [Fact]
    public async Task OptionQuote_ToString_FormatsCorrectly()
    {
        // Arrange
        var optionConid = 123456;

        // Act
        var quote = await _optionQuoteService.GetQuoteAsync(optionConid);

        // Assert
        var str = quote.ToString();
        Assert.NotNull(str);

        // Verify key information is in the string
        Assert.Contains(quote.Strike.ToString("F2"), str);
        Assert.Contains(quote.Right == OptionRight.Call ? "C" : "P", str);
        Assert.Contains("Last=", str);
        Assert.Contains("Bid=", str);
        Assert.Contains("Ask=", str);
        Assert.Contains("IV=", str);
        Assert.Contains("Delta=", str);
    }

    [Fact]
    public async Task OptionQuote_HasValidQuote_ChecksSpread()
    {
        // Arrange
        var optionConid = 123456;

        // Act
        var quote = await _optionQuoteService.GetQuoteAsync(optionConid);

        // Assert
        Assert.True(quote.HasValidQuote, "Should have valid quote with positive bid/ask");

        // Verify spread properties work
        Assert.NotNull(quote.Spread);
        Assert.True(quote.Spread > 0, "Spread should be positive");
        Assert.NotNull(quote.MidPoint);
    }

    [Fact]
    public async Task OptionQuote_OpenInterest_IsPopulated()
    {
        // Arrange
        var optionConid = 123456;

        // Act
        var quote = await _optionQuoteService.GetQuoteAsync(optionConid);

        // Assert
        Assert.NotNull(quote.OpenInterest);
        Assert.True(quote.OpenInterest > 0, "Open interest should be positive");
    }

    [Fact(Skip = "Requires integration with OptionService - test with real chain")]
    public async Task GetChainQuotesAsync_ReturnsQuotesForFullChain()
    {
        // Arrange
        var symbol = "AAPL";
        var expirationStart = DateTime.Today;
        var expirationEnd = DateTime.Today.AddDays(30);

        // Act
        var quotes = await _optionQuoteService.GetChainQuotesAsync(
            symbol, expirationStart, expirationEnd);

        // Assert
        Assert.NotNull(quotes);
        Assert.NotEmpty(quotes);

        // Verify all quotes have Greeks
        foreach (var quote in quotes)
        {
            Assert.NotNull(quote.Greeks);
            Assert.True(quote.HasGreeks);
        }
    }
}
