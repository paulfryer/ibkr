using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Orders
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("acct", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Acct { get; set; }

    [JsonProperty("exchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Exchange { get; set; }

    [JsonProperty("conidex", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Conidex { get; set; }

    [JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Conid { get; set; }

    [JsonProperty("account", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Account { get; set; }

    [JsonProperty("orderId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int OrderId { get; set; }

    [JsonProperty("cashCcy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CashCcy { get; set; }

    [JsonProperty("sizeAndFills", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SizeAndFills { get; set; }

    [JsonProperty("orderDesc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string OrderDesc { get; set; }

    [JsonProperty("description1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Description1 { get; set; }

    [JsonProperty("ticker", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Ticker { get; set; }

    [JsonProperty("secType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SecType { get; set; }

    [JsonProperty("listingExchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ListingExchange { get; set; }

    [JsonProperty("remainingQuantity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string RemainingQuantity { get; set; }

    [JsonProperty("filledQuantity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FilledQuantity { get; set; }

    [JsonProperty("totalSize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TotalSize { get; set; }

    [JsonProperty("totalCashSize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TotalCashSize { get; set; }

    [JsonProperty("companyName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyName { get; set; }

    [JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public OrdersStatus Status { get; set; } = OrdersStatus.Inactive;

    [JsonProperty("order_ccp_status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Order_ccp_status { get; set; }

    [JsonProperty("origOrderType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string OrigOrderType { get; set; }

    [JsonProperty("supportsTaxOpt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public OrdersSupportsTaxOpt SupportsTaxOpt { get; set; } = OrdersSupportsTaxOpt._0;

    [JsonProperty("lastExecutionTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string LastExecutionTime { get; set; }

    [JsonProperty("orderType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string OrderType { get; set; }

    [JsonProperty("bgColor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string BgColor { get; set; }

    [JsonProperty("fgColor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FgColor { get; set; }

    [JsonProperty("isEventTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public OrdersIsEventTrading IsEventTrading { get; set; } = OrdersIsEventTrading._0;

    [JsonProperty("price", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Price { get; set; }

    [JsonProperty("timeInForce", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TimeInForce { get; set; }

    [JsonProperty("lastExecutionTime_r", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string LastExecutionTime_r { get; set; }

    [JsonProperty("side", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Side { get; set; }

    [JsonProperty("avgPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AvgPrice { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}