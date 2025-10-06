using System.Text.Json.Serialization;
using IBKR.Api.Client.Models.Enums;

namespace IBKR.Api.Client.Models.Instruments;

/// <summary>
/// Detailed information about a security.
/// </summary>
public record SecurityInfo
{
    /// <summary>
    /// Gets or sets the contract ID.
    /// </summary>
    [JsonPropertyName("conid")]
    public int? Conid { get; init; }

    /// <summary>
    /// Gets or sets the symbol.
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; init; }

    /// <summary>
    /// Gets or sets the security type.
    /// </summary>
    [JsonPropertyName("secType")]
    public string? SecType { get; init; }

    /// <summary>
    /// Gets or sets the exchange.
    /// </summary>
    [JsonPropertyName("exchange")]
    public string? Exchange { get; init; }

    /// <summary>
    /// Gets or sets the listing exchange.
    /// </summary>
    [JsonPropertyName("listingExchange")]
    public string? ListingExchange { get; init; }

    /// <summary>
    /// Gets or sets the option right (C for Call, P for Put).
    /// </summary>
    [JsonPropertyName("right")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OptionRight? Right { get; init; }

    /// <summary>
    /// Gets or sets the strike price (for options).
    /// </summary>
    [JsonPropertyName("strike")]
    public decimal? Strike { get; init; }

    /// <summary>
    /// Gets or sets the currency.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; init; }

    /// <summary>
    /// Gets or sets the CUSIP identifier.
    /// </summary>
    [JsonPropertyName("cusip")]
    public string? Cusip { get; init; }

    /// <summary>
    /// Gets or sets the coupon rate (for bonds).
    /// </summary>
    [JsonPropertyName("coupon")]
    public string? Coupon { get; init; }

    /// <summary>
    /// Gets or sets the first description line.
    /// </summary>
    [JsonPropertyName("desc1")]
    public string? Desc1 { get; init; }

    /// <summary>
    /// Gets or sets the second description line.
    /// </summary>
    [JsonPropertyName("desc2")]
    public string? Desc2 { get; init; }

    /// <summary>
    /// Gets or sets the maturity date.
    /// </summary>
    [JsonPropertyName("maturityDate")]
    public string? MaturityDate { get; init; }

    /// <summary>
    /// Gets or sets the contract multiplier.
    /// </summary>
    [JsonPropertyName("multiplier")]
    public string? Multiplier { get; init; }

    /// <summary>
    /// Gets or sets the trading class.
    /// </summary>
    [JsonPropertyName("tradingClass")]
    public string? TradingClass { get; init; }

    /// <summary>
    /// Gets or sets the valid exchanges.
    /// </summary>
    [JsonPropertyName("validExchanges")]
    public string? ValidExchanges { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether PRIIPs information should be shown.
    /// </summary>
    [JsonPropertyName("showPrips")]
    public bool? ShowPrips { get; init; }
}
