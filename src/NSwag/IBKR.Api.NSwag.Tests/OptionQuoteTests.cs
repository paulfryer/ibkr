using System.Threading.Tasks;
using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.Contract.Models;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace IBKR.Api.NSwag.Tests;

/// <summary>
/// Tests for getting option quotes via the IBKR API.
/// These tests demonstrate the workflow:
/// 1. Find an option contract (either by searching or knowing the conid)
/// 2. Request market data snapshot for the option
/// 3. Parse option quote data (bid, ask, last price, implied volatility, greeks)
/// </summary>
public class OptionQuoteTests : IClassFixture<TestFixture>
{
    private readonly IIserverService _iserverService;

    public OptionQuoteTests(TestFixture fixture)
    {
        _iserverService = fixture.GetService<IIserverService>();
    }

    [Fact]
    public async Task GetOptionQuote_WithConid_ReturnsMarketData()
    {
        // Arrange
        // This would be the conid of a specific option contract
        // In practice, you'd get this from Info2Async after selecting a strike
        var optionConid = "12345678"; // Example option conid

        // Act - Pre-flight request (initializes data stream)
        await _iserverService.SnapshotAsync(conids: optionConid, fields: MdFields._31);

        // Act - Get market data snapshot for the option
        var quotes = await _iserverService.SnapshotAsync(
            conids: optionConid,
            fields: MdFields._31 // Field 31 = Last Price
        );

        // Assert
        Assert.NotNull(quotes);
        Assert.NotEmpty(quotes);

        var quote = quotes.First();

        // Market data is returned in AdditionalProperties dictionary
        // with field codes as keys
        Assert.NotNull(quote.AdditionalProperties);
    }

    [Fact]
    public async Task GetOptionQuote_WithMultipleFields_ReturnsFullQuote()
    {
        // Arrange
        var optionConid = "12345678"; // Example option conid

        // Request multiple option-specific market data fields:
        // Request multiple fields including Greeks:
        // 31 = Last Price, 84 = Bid, 86 = Ask, 85 = Ask Size, 88 = Bid Size
        // 7295 = Implied Volatility, 7308 = Delta, 7309 = Gamma
        // 7310 = Vega, 7311 = Theta

        // Act - Pre-flight request (initializes data stream)
        await _iserverService.SnapshotAsync(conids: optionConid, fields: null);

        // Act - Get actual option data with Greeks
        var quotes = await _iserverService.SnapshotAsync(
            conids: optionConid,
            fields: null // Could pass string like "31,84,86,85,88,7295,7308,7309,7310,7311"
        );

        // Assert
        Assert.NotNull(quotes);
        Assert.NotEmpty(quotes);

        var quote = quotes.First();
        Assert.NotNull(quote.AdditionalProperties);

        // Verify all price fields are present
        Assert.True(quote.AdditionalProperties.ContainsKey("31")); // Last
        Assert.True(quote.AdditionalProperties.ContainsKey("84")); // Bid
        Assert.True(quote.AdditionalProperties.ContainsKey("86")); // Ask
        Assert.True(quote.AdditionalProperties.ContainsKey("85")); // Ask Size
        Assert.True(quote.AdditionalProperties.ContainsKey("88")); // Bid Size

        // Verify Greeks are present
        Assert.True(quote.AdditionalProperties.ContainsKey("7295")); // IV
        Assert.True(quote.AdditionalProperties.ContainsKey("7308")); // Delta
        Assert.True(quote.AdditionalProperties.ContainsKey("7309")); // Gamma
        Assert.True(quote.AdditionalProperties.ContainsKey("7310")); // Vega
        Assert.True(quote.AdditionalProperties.ContainsKey("7311")); // Theta

        // Verify values can be parsed
        Assert.Equal("5.25", quote.AdditionalProperties["31"].ToString());
        Assert.Equal("0.52", quote.AdditionalProperties["7308"].ToString()); // Delta
    }

    [Fact(Skip = "Requires mock implementation of Info2Async and SnapshotAsync")]
    public async Task FullWorkflow_GetStrikeAndQuote_Succeeds()
    {
        // Arrange
        var underlyingConid = "265598"; // AAPL
        var month = "20250117"; // January 17, 2025
        var strike = 150.0;

        // Act - Step 1: Get option contract info to get the option conid
        var optionInfo = await _iserverService.Info2Async(
            conid: underlyingConid,
            sectype: "OPT",
            month: month,
            exchange: "SMART",
            strike: strike,
            right: Right.C // Call option
        );

        Assert.NotNull(optionInfo);
        var optionConid = optionInfo.Conid.ToString();
        Assert.NotNull(optionConid);

        // Act - Step 2: Get quote for the specific option contract
        var quotes = await _iserverService.SnapshotAsync(
            conids: optionConid,
            fields: MdFields._31
        );

        // Assert
        Assert.NotNull(quotes);
        Assert.NotEmpty(quotes);

        var quote = quotes.First();
        Assert.NotNull(quote.AdditionalProperties);
    }

    [Fact]
    public async Task GetOptionQuote_ForPut_ReturnsMarketData()
    {
        // Arrange
        var putOptionConid = "87654321"; // Example put option conid

        // Act - Pre-flight request (initializes data stream)
        await _iserverService.SnapshotAsync(conids: putOptionConid, fields: MdFields._31);

        // Act - Get actual data
        var quotes = await _iserverService.SnapshotAsync(
            conids: putOptionConid,
            fields: MdFields._31
        );

        // Assert
        Assert.NotNull(quotes);
        Assert.NotEmpty(quotes);

        var quote = quotes.First();
        Assert.NotNull(quote.AdditionalProperties);
    }

    [Fact]
    public async Task GetOptionQuote_MultipleOptions_ReturnsBatch()
    {
        // Arrange
        // Multiple option conids separated by comma
        var optionConids = "12345678,87654321";

        // Act - Pre-flight request (initializes data stream)
        await _iserverService.SnapshotAsync(conids: optionConids, fields: MdFields._31);

        // Act - Get quotes for multiple options at once
        var quotes = await _iserverService.SnapshotAsync(
            conids: optionConids,
            fields: MdFields._31
        );

        // Assert
        Assert.NotNull(quotes);
        Assert.NotEmpty(quotes);

        // In a real response, you would get an array of FyiVT objects
        // Each object would contain the market data for one option
    }

    [Fact]
    public async Task GetOptionQuote_WithGreeks_ReturnsRiskMetrics()
    {
        // Arrange
        var optionConid = "12345678";

        // Request option greeks:
        // 7308 = Delta, 7309 = Gamma, 7310 = Vega
        // 7311 = Theta, 7295 = Implied Volatility

        // Act - Pre-flight request (initializes data stream)
        await _iserverService.SnapshotAsync(conids: optionConid, fields: null);

        // Act - Get actual data with Greeks
        var quotes = await _iserverService.SnapshotAsync(
            conids: optionConid,
            fields: null // Could pass string like "7308,7309,7310,7311,7295"
        );

        // Assert
        Assert.NotNull(quotes);
        Assert.NotEmpty(quotes);

        var quote = quotes.First();
        Assert.NotNull(quote.AdditionalProperties);

        // Extract and verify Greeks from AdditionalProperties
        Assert.True(quote.AdditionalProperties.ContainsKey("7308"), "Delta missing");
        Assert.True(quote.AdditionalProperties.ContainsKey("7309"), "Gamma missing");
        Assert.True(quote.AdditionalProperties.ContainsKey("7310"), "Vega missing");
        Assert.True(quote.AdditionalProperties.ContainsKey("7311"), "Theta missing");
        Assert.True(quote.AdditionalProperties.ContainsKey("7295"), "IV missing");

        var delta = decimal.Parse(quote.AdditionalProperties["7308"].ToString()!);
        var gamma = decimal.Parse(quote.AdditionalProperties["7309"].ToString()!);
        var vega = decimal.Parse(quote.AdditionalProperties["7310"].ToString()!);
        var theta = decimal.Parse(quote.AdditionalProperties["7311"].ToString()!);
        var iv = decimal.Parse(quote.AdditionalProperties["7295"].ToString()!);

        // Verify Greeks have reasonable values
        Assert.True(delta >= -1 && delta <= 1, $"Delta out of range: {delta}");
        Assert.True(gamma >= 0, $"Gamma should be positive: {gamma}");
        Assert.True(vega >= 0, $"Vega should be positive: {vega}");
        Assert.True(theta <= 0, $"Theta should be negative: {theta}");
        Assert.True(iv > 0 && iv < 5, $"IV out of reasonable range: {iv}");
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

        var optionConid = "12345678";

        // Act - Pre-flight request (initializes data stream)
        await _iserverService.SnapshotAsync(conids: optionConid, fields: MdFields._31);

        // Act - Get actual data
        var quotes = await _iserverService.SnapshotAsync(
            conids: optionConid,
            fields: MdFields._31
        );

        Assert.NotNull(quotes);
        Assert.NotEmpty(quotes);

        var quote = quotes.First();
    }
}
