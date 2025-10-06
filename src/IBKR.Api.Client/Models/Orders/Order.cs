using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Orders;

/// <summary>
/// Represents an order with full details.
/// </summary>
public record Order
{
    [JsonPropertyName("acct")]
    public string? Acct { get; init; }

    [JsonPropertyName("conidex")]
    public string? Conidex { get; init; }

    [JsonPropertyName("conid")]
    public int? Conid { get; init; }

    [JsonPropertyName("account")]
    public string? Account { get; init; }

    [JsonPropertyName("orderId")]
    public int? OrderId { get; init; }

    [JsonPropertyName("cashCcy")]
    public string? CashCcy { get; init; }

    [JsonPropertyName("sizeAndFills")]
    public string? SizeAndFills { get; init; }

    [JsonPropertyName("orderDesc")]
    public string? OrderDesc { get; init; }

    [JsonPropertyName("description1")]
    public string? Description1 { get; init; }

    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    [JsonPropertyName("secType")]
    public string? SecType { get; init; }

    [JsonPropertyName("listingExchange")]
    public string? ListingExchange { get; init; }

    [JsonPropertyName("remainingQuantity")]
    public decimal? RemainingQuantity { get; init; }

    [JsonPropertyName("filledQuantity")]
    public decimal? FilledQuantity { get; init; }

    [JsonPropertyName("totalSize")]
    public decimal? TotalSize { get; init; }

    [JsonPropertyName("companyName")]
    public string? CompanyName { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("order_ccp_status")]
    public string? OrderCcpStatus { get; init; }

    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; init; }

    [JsonPropertyName("origOrderType")]
    public string? OrigOrderType { get; init; }

    [JsonPropertyName("supportsTaxOpt")]
    public string? SupportsTaxOpt { get; init; }

    [JsonPropertyName("lastExecutionTime")]
    public string? LastExecutionTime { get; init; }

    [JsonPropertyName("orderType")]
    public string? OrderType { get; init; }

    [JsonPropertyName("bgColor")]
    public string? BgColor { get; init; }

    [JsonPropertyName("fgColor")]
    public string? FgColor { get; init; }

    [JsonPropertyName("order_ref")]
    public string? OrderRef { get; init; }

    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; init; }

    [JsonPropertyName("lastExecutionTime_r")]
    public long? LastExecutionTimeR { get; init; }

    [JsonPropertyName("side")]
    public string? Side { get; init; }
}
