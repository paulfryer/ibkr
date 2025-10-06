using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Orders;

/// <summary>
/// Reply message that requires confirmation before order placement.
/// </summary>
public record OrderReplyMessage
{
    /// <summary>
    /// Gets or sets the message ID for confirmation.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the message text array.
    /// </summary>
    [JsonPropertyName("message")]
    public List<string>? Message { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the message is suppressed.
    /// </summary>
    [JsonPropertyName("isSuppressed")]
    public bool IsSuppressed { get; init; }

    /// <summary>
    /// Gets or sets the list of message IDs.
    /// </summary>
    [JsonPropertyName("messageIds")]
    public List<string>? MessageIds { get; init; }
}
