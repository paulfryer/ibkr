using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.MarketData;

/// <summary>
/// Market data snapshot for a contract.
/// Field IDs: 31=last, 84=bid, 85=bid size, 86=ask, 88=ask size, 7059=last size
/// </summary>
public record MarketDataSnapshot
{
    /// <summary>
    /// Gets or sets the contract ID.
    /// </summary>
    [JsonPropertyName("conid")]
    public int? Conid { get; init; }

    /// <summary>
    /// Gets or sets the extended contract ID.
    /// </summary>
    [JsonPropertyName("conidEx")]
    public string? ConidEx { get; init; }

    /// <summary>
    /// Gets or sets the server ID.
    /// </summary>
    [JsonPropertyName("server_id")]
    public string? ServerId { get; init; }

    /// <summary>
    /// Gets or sets the last update timestamp.
    /// </summary>
    [JsonPropertyName("_updated")]
    public long? Updated { get; init; }

    /// <summary>
    /// Gets or sets the last price (field 31).
    /// </summary>
    [JsonPropertyName("31")]
    public string? LastPrice { get; init; }

    /// <summary>
    /// Gets or sets the bid price (field 84).
    /// </summary>
    [JsonPropertyName("84")]
    public string? BidPrice { get; init; }

    /// <summary>
    /// Gets or sets the bid size (field 85).
    /// </summary>
    [JsonPropertyName("85")]
    public string? BidSize { get; init; }

    /// <summary>
    /// Gets or sets the ask price (field 86).
    /// </summary>
    [JsonPropertyName("86")]
    public string? AskPrice { get; init; }

    /// <summary>
    /// Gets or sets the ask size (field 88).
    /// </summary>
    [JsonPropertyName("88")]
    public string? AskSize { get; init; }

    /// <summary>
    /// Gets or sets the last size (field 7059).
    /// </summary>
    [JsonPropertyName("7059")]
    public string? LastSize { get; init; }

    /// <summary>
    /// Gets or sets additional fields returned by the API.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, object>? AdditionalFields { get; init; }
}
