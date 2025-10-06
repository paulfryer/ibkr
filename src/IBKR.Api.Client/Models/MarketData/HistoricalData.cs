using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.MarketData;

/// <summary>
/// Historical market data response.
/// </summary>
public record HistoricalData
{
    /// <summary>
    /// Gets or sets the array of bar data.
    /// </summary>
    [JsonPropertyName("data")]
    public List<BarData>? Data { get; init; }
}

/// <summary>
/// Represents a single OHLC bar of market data.
/// </summary>
public record BarData
{
    /// <summary>
    /// Gets or sets the open price.
    /// </summary>
    [JsonPropertyName("o")]
    public decimal? Open { get; init; }

    /// <summary>
    /// Gets or sets the high price.
    /// </summary>
    [JsonPropertyName("h")]
    public decimal? High { get; init; }

    /// <summary>
    /// Gets or sets the low price.
    /// </summary>
    [JsonPropertyName("l")]
    public decimal? Low { get; init; }

    /// <summary>
    /// Gets or sets the close price.
    /// </summary>
    [JsonPropertyName("c")]
    public decimal? Close { get; init; }

    /// <summary>
    /// Gets or sets the volume.
    /// </summary>
    [JsonPropertyName("v")]
    public decimal? Volume { get; init; }

    /// <summary>
    /// Gets or sets the timestamp.
    /// </summary>
    [JsonPropertyName("t")]
    public long? Timestamp { get; init; }
}
