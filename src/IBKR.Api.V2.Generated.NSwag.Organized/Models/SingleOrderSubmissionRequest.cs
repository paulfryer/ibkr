using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class SingleOrderSubmissionRequest
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("acctId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AcctId { get; set; }

    [JsonProperty("conid", Required = Required.Always)]
    public int Conid { get; set; }

    [JsonProperty("conidex", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Conidex { get; set; }

    [JsonProperty("secType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SecType { get; set; }

    [JsonProperty("cOID", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string COID { get; set; }

    [JsonProperty("parentId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ParentId { get; set; }

    [JsonProperty("listingExchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ListingExchange { get; set; }

    [JsonProperty("isSingleGroup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsSingleGroup { get; set; }

    [JsonProperty("outsideRTH", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool OutsideRTH { get; set; }

    [JsonProperty("auxPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double AuxPrice { get; set; }

    [JsonProperty("ticker", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Ticker { get; set; }

    [JsonProperty("trailingAmt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double TrailingAmt { get; set; }

    [JsonProperty("trailingType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SingleOrderSubmissionRequestTrailingType TrailingType { get; set; } =
        SingleOrderSubmissionRequestTrailingType.Amt;

    [JsonProperty("referrer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Referrer { get; set; }

    [JsonProperty("cashQty", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double CashQty { get; set; }

    [JsonProperty("useAdaptive", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool UseAdaptive { get; set; }

    [JsonProperty("isCcyConv", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsCcyConv { get; set; }

    [JsonProperty("orderType", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string OrderType { get; set; }

    [JsonProperty("price", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Price { get; set; }

    [JsonProperty("side", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SingleOrderSubmissionRequestSide Side { get; set; } = SingleOrderSubmissionRequestSide.BUY;

    [JsonProperty("tif", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SingleOrderSubmissionRequestTif Tif { get; set; } = SingleOrderSubmissionRequestTif.DAY;

    [JsonProperty("quantity", Required = Required.Always)]
    public double Quantity { get; set; }

    [JsonProperty("strategy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Strategy { get; set; }

    [JsonProperty("strategyParameters", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public StrategyParameters StrategyParameters { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}