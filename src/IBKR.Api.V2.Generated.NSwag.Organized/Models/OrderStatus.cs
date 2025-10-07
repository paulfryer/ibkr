using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class OrderStatus
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("sub_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Sub_type { get; set; }

    [JsonProperty("request_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Request_id { get; set; }

    [JsonProperty("server_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Server_id { get; set; }

    [JsonProperty("order_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Order_id { get; set; }

    [JsonProperty("conidex", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Conidex { get; set; }

    [JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Conid { get; set; }

    [JsonProperty("symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Symbol { get; set; }

    [JsonProperty("side", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public OrderStatusSide Side { get; set; } = OrderStatusSide.BUY;

    [JsonProperty("contract_description_1", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Contract_description_1 { get; set; }

    [JsonProperty("listing_exchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Listing_exchange { get; set; }

    [JsonProperty("option_acct", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Option_acct { get; set; }

    [JsonProperty("company_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Company_name { get; set; }

    [JsonProperty("size", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Size { get; set; }

    [JsonProperty("total_size", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Total_size { get; set; }

    [JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Currency { get; set; }

    [JsonProperty("account", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Account { get; set; }

    [JsonProperty("order_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Order_type { get; set; }

    [JsonProperty("cum_fill", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Cum_fill { get; set; }

    [JsonProperty("order_status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public OrderStatusOrder_status Order_status { get; set; } = OrderStatusOrder_status.Inactive;

    [JsonProperty("order_ccp_status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Order_ccp_status { get; set; }

    [JsonProperty("order_status_description", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Order_status_description { get; set; }

    [JsonProperty("tif", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public OrderStatusTif Tif { get; set; } = OrderStatusTif.DAY;

    [JsonProperty("fgColor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FgColor { get; set; }

    [JsonProperty("bgColor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string BgColor { get; set; }

    [JsonProperty("order_not_editable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Order_not_editable { get; set; }

    [JsonProperty("editable_fields", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Editable_fields { get; set; }

    [JsonProperty("cannot_cancel_order", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool Cannot_cancel_order { get; set; }

    [JsonProperty("deactivate_order", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Deactivate_order { get; set; }

    [JsonProperty("sec_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public OrderStatusSec_type Sec_type { get; set; } = OrderStatusSec_type.STK;

    [JsonProperty("available_chart_periods", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Available_chart_periods { get; set; }

    [JsonProperty("order_description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Order_description { get; set; }

    [JsonProperty("order_description_with_contract", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Order_description_with_contract { get; set; }

    [JsonProperty("alert_active", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Alert_active { get; set; }

    [JsonProperty("child_order_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public OrderStatusChild_order_type Child_order_type { get; set; } = OrderStatusChild_order_type._0;

    [JsonProperty("order_clearing_account", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Order_clearing_account { get; set; }

    [JsonProperty("size_and_fills", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Size_and_fills { get; set; }

    [JsonProperty("exit_strategy_display_price", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Exit_strategy_display_price { get; set; }

    [JsonProperty("exit_strategy_chart_description", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Exit_strategy_chart_description { get; set; }

    [JsonProperty("average_price", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Average_price { get; set; }

    [JsonProperty("exit_strategy_tool_availability", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Exit_strategy_tool_availability { get; set; }

    [JsonProperty("allowed_duplicate_opposite", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool Allowed_duplicate_opposite { get; set; }

    [JsonProperty("order_time", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Order_time { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}