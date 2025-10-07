using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Anonymous3
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("execution_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Execution_id { get; set; }

    [JsonProperty("symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Symbol { get; set; }

    [JsonProperty("supports_tax_opt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Supports_tax_opt Supports_tax_opt { get; set; } = Supports_tax_opt._0;

    [JsonProperty("side", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Side Side { get; set; } = Side.B;

    [JsonProperty("order_description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Order_description { get; set; }

    [JsonProperty("trade_time", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Trade_time { get; set; }

    [JsonProperty("trade_time_r", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Trade_time_r { get; set; }

    [JsonProperty("size", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Size { get; set; }

    [JsonProperty("price", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Price { get; set; }

    [JsonProperty("order_ref", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Order_ref { get; set; }

    [JsonProperty("submitter", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Submitter { get; set; }

    [JsonProperty("exchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Exchange { get; set; }

    [JsonProperty("commission", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Commission { get; set; }

    [JsonProperty("net_amount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Net_amount { get; set; }

    [JsonProperty("account", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Account { get; set; }

    [JsonProperty("accountCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountCode { get; set; }

    [JsonProperty("account_allocation_name", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Account_allocation_name { get; set; }

    [JsonProperty("company_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Company_name { get; set; }

    [JsonProperty("contract_description_1", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Contract_description_1 { get; set; }

    [JsonProperty("sec_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Sec_type Sec_type { get; set; } = Sec_type.STK;

    [JsonProperty("listing_exchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Listing_exchange { get; set; }

    [JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Conid { get; set; }

    [JsonProperty("conidEx", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ConidEx { get; set; }

    [JsonProperty("clearing_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Clearing_id { get; set; }

    [JsonProperty("clearing_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Clearing_name { get; set; }

    [JsonProperty("liquidation_trade", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Liquidation_trade Liquidation_trade { get; set; } = Liquidation_trade._0;

    [JsonProperty("is_event_trading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Is_event_trading Is_event_trading { get; set; } = Is_event_trading._0;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}