using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Portfolio;

/// <summary>
/// Represents a summary value for portfolio/account information.
/// </summary>
public record SummaryValue
{
    /// <summary>
    /// Gets or sets the numeric amount.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal? Amount { get; init; }

    /// <summary>
    /// Gets or sets the currency.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the value is null.
    /// </summary>
    [JsonPropertyName("isNull")]
    public bool IsNull { get; init; }

    /// <summary>
    /// Gets or sets the timestamp.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>
    /// Gets or sets the string value representation.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; init; }

    /// <summary>
    /// Gets or sets the severity level.
    /// </summary>
    [JsonPropertyName("severity")]
    public int? Severity { get; init; }
}
