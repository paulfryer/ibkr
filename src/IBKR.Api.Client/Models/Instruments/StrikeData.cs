using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Instruments;

/// <summary>
/// Available strike prices for options.
/// </summary>
public record StrikeData
{
    /// <summary>
    /// Gets or sets the available call option strike prices.
    /// </summary>
    [JsonPropertyName("call")]
    public List<decimal>? Call { get; init; }

    /// <summary>
    /// Gets or sets the available put option strike prices.
    /// </summary>
    [JsonPropertyName("put")]
    public List<decimal>? Put { get; init; }
}
