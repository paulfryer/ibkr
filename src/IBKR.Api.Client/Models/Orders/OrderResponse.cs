using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Orders;

/// <summary>
/// Response from order placement or modification.
/// </summary>
public record OrderResponse
{
    /// <summary>
    /// Gets or sets the order ID.
    /// </summary>
    [JsonPropertyName("order_id")]
    public string? OrderId { get; init; }

    /// <summary>
    /// Gets or sets the order status.
    /// </summary>
    [JsonPropertyName("order_status")]
    public string? OrderStatus { get; init; }

    /// <summary>
    /// Gets or sets the encrypted message.
    /// </summary>
    [JsonPropertyName("encrypt_message")]
    public string? EncryptMessage { get; init; }
}
