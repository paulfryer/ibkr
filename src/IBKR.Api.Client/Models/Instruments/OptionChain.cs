using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Instruments;

/// <summary>
/// Represents an option chain with available expiration dates and strikes.
/// </summary>
public record OptionChain
{
    /// <summary>
    /// Gets or sets the underlying contract ID.
    /// </summary>
    [JsonPropertyName("conid")]
    public int Conid { get; init; }

    /// <summary>
    /// Gets or sets the underlying symbol.
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; init; }

    /// <summary>
    /// Gets or sets the exchange.
    /// </summary>
    [JsonPropertyName("exchange")]
    public string? Exchange { get; init; }

    /// <summary>
    /// Gets or sets the available expiration dates.
    /// </summary>
    [JsonPropertyName("expirations")]
    public List<OptionExpiration>? Expirations { get; init; }
}

/// <summary>
/// Represents an option expiration date with available strikes.
/// </summary>
public record OptionExpiration
{
    /// <summary>
    /// Gets or sets the expiration date (YYYYMMDD format).
    /// </summary>
    [JsonPropertyName("expiration")]
    public string? Expiration { get; init; }

    /// <summary>
    /// Gets or sets the number of days until expiration.
    /// </summary>
    [JsonPropertyName("daysToExpiration")]
    public int? DaysToExpiration { get; init; }

    /// <summary>
    /// Gets or sets the available strike prices.
    /// </summary>
    [JsonPropertyName("strikes")]
    public List<decimal>? Strikes { get; init; }
}

/// <summary>
/// Represents a specific option contract.
/// </summary>
public record OptionContract
{
    /// <summary>
    /// Gets or sets the contract ID.
    /// </summary>
    [JsonPropertyName("conid")]
    public int Conid { get; init; }

    /// <summary>
    /// Gets or sets the symbol.
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; init; }

    /// <summary>
    /// Gets or sets the strike price.
    /// </summary>
    [JsonPropertyName("strike")]
    public decimal Strike { get; init; }

    /// <summary>
    /// Gets or sets the option right (C for Call, P for Put).
    /// </summary>
    [JsonPropertyName("right")]
    public string? Right { get; init; }

    /// <summary>
    /// Gets or sets the expiration date.
    /// </summary>
    [JsonPropertyName("expiration")]
    public string? Expiration { get; init; }

    /// <summary>
    /// Gets or sets the exchange.
    /// </summary>
    [JsonPropertyName("exchange")]
    public string? Exchange { get; init; }

    /// <summary>
    /// Gets or sets the multiplier.
    /// </summary>
    [JsonPropertyName("multiplier")]
    public string? Multiplier { get; init; }
}
