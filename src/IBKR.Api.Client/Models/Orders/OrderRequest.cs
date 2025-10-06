using System.Text.Json.Serialization;
using IBKR.Api.Client.Models.Enums;

namespace IBKR.Api.Client.Models.Orders;

/// <summary>
/// Request to place or modify an order.
/// </summary>
public record OrderRequest
{
    /// <summary>
    /// Gets or sets the contract ID (required).
    /// </summary>
    [JsonPropertyName("conid")]
    public required int Conid { get; init; }

    /// <summary>
    /// Gets or sets the extended contract ID for combos/spreads.
    /// </summary>
    [JsonPropertyName("conidex")]
    public string? Conidex { get; init; }

    /// <summary>
    /// Gets or sets the order side (BUY or SELL) (required).
    /// </summary>
    [JsonPropertyName("side")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required OrderSide Side { get; init; }

    /// <summary>
    /// Gets or sets the order type (required).
    /// </summary>
    [JsonPropertyName("orderType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required OrderType OrderType { get; init; }

    /// <summary>
    /// Gets or sets the limit price (for limit orders).
    /// </summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; init; }

    /// <summary>
    /// Gets or sets the auxiliary price (stop price for stop orders).
    /// </summary>
    [JsonPropertyName("auxPrice")]
    public decimal? AuxPrice { get; init; }

    /// <summary>
    /// Gets or sets the order quantity (required).
    /// </summary>
    [JsonPropertyName("quantity")]
    public required decimal Quantity { get; init; }

    /// <summary>
    /// Gets or sets the time in force (required).
    /// </summary>
    [JsonPropertyName("tif")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required TimeInForce Tif { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether to allow trading outside regular hours.
    /// </summary>
    [JsonPropertyName("outsideRth")]
    public bool? OutsideRth { get; init; }

    /// <summary>
    /// Gets or sets the client order ID (for bracket orders).
    /// </summary>
    [JsonPropertyName("cOID")]
    public string? COID { get; init; }

    /// <summary>
    /// Gets or sets the parent order ID (for child orders in bracket orders).
    /// </summary>
    [JsonPropertyName("parentId")]
    public string? ParentId { get; init; }

    /// <summary>
    /// Gets or sets the listing exchange.
    /// </summary>
    [JsonPropertyName("listingExchange")]
    public string? ListingExchange { get; init; }

    /// <summary>
    /// Gets or sets the referrer.
    /// </summary>
    [JsonPropertyName("referrer")]
    public string? Referrer { get; init; }

    /// <summary>
    /// Gets or sets the user-defined order reference.
    /// </summary>
    [JsonPropertyName("orderRef")]
    public string? OrderRef { get; init; }
}
