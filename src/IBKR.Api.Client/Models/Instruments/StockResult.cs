using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Instruments;

/// <summary>
/// Stock search result from the /trsrv/stocks endpoint.
/// </summary>
public record StockResult
{
    /// <summary>
    /// Gets or sets the company name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets or sets the asset class.
    /// </summary>
    [JsonPropertyName("assetClass")]
    public string? AssetClass { get; init; }

    /// <summary>
    /// Gets or sets the list of contracts for this stock across different exchanges.
    /// </summary>
    [JsonPropertyName("contracts")]
    public List<StockContract>? Contracts { get; init; }
}

/// <summary>
/// Represents a stock contract on a specific exchange.
/// </summary>
public record StockContract
{
    /// <summary>
    /// Gets or sets the contract ID (conid).
    /// </summary>
    [JsonPropertyName("conid")]
    public int Conid { get; init; }

    /// <summary>
    /// Gets or sets the exchange code.
    /// </summary>
    [JsonPropertyName("exchange")]
    public string? Exchange { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a US contract.
    /// </summary>
    [JsonPropertyName("isUS")]
    public bool IsUS { get; init; }
}
