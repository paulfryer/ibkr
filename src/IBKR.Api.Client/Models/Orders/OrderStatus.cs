using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Orders;

/// <summary>
/// Detailed status information for an order.
/// </summary>
public record OrderStatus
{
    /// <summary>
    /// Gets or sets the order ID.
    /// </summary>
    [JsonPropertyName("orderId")]
    public int? OrderId { get; init; }

    /// <summary>
    /// Gets or sets the order status.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Gets or sets the filled quantity.
    /// </summary>
    [JsonPropertyName("filled")]
    public decimal? Filled { get; init; }

    /// <summary>
    /// Gets or sets the remaining quantity.
    /// </summary>
    [JsonPropertyName("remaining")]
    public decimal? Remaining { get; init; }

    /// <summary>
    /// Gets or sets the average fill price.
    /// </summary>
    [JsonPropertyName("avgFillPrice")]
    public decimal? AvgFillPrice { get; init; }

    /// <summary>
    /// Gets or sets the permanent order ID.
    /// </summary>
    [JsonPropertyName("permId")]
    public int? PermId { get; init; }

    /// <summary>
    /// Gets or sets the parent order ID.
    /// </summary>
    [JsonPropertyName("parentId")]
    public int? ParentId { get; init; }

    /// <summary>
    /// Gets or sets the last fill price.
    /// </summary>
    [JsonPropertyName("lastFillPrice")]
    public decimal? LastFillPrice { get; init; }

    /// <summary>
    /// Gets or sets the client ID.
    /// </summary>
    [JsonPropertyName("clientId")]
    public int? ClientId { get; init; }

    /// <summary>
    /// Gets or sets the reason why the order is held.
    /// </summary>
    [JsonPropertyName("whyHeld")]
    public string? WhyHeld { get; init; }

    /// <summary>
    /// Gets or sets the market cap price.
    /// </summary>
    [JsonPropertyName("mktCapPrice")]
    public decimal? MktCapPrice { get; init; }
}
