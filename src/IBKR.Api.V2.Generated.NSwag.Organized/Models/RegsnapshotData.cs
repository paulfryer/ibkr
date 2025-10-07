using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RegsnapshotData
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Conid { get; set; }

    [JsonProperty("conidEx", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ConidEx { get; set; }

    [JsonProperty("sizeMinTick", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double SizeMinTick { get; set; }

    [JsonProperty("BboExchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string BboExchange { get; set; }

    [JsonProperty("HasDelayed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool HasDelayed { get; set; }

    [JsonProperty("84", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string _84 { get; set; }

    [JsonProperty("86", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string _86 { get; set; }

    [JsonProperty("88", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int _88 { get; set; }

    [JsonProperty("85", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int _85 { get; set; }

    [JsonProperty("BestBidExch", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int BestBidExch { get; set; }

    [JsonProperty("BestAskExch", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int BestAskExch { get; set; }

    [JsonProperty("31", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string _31 { get; set; }

    [JsonProperty("7059", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string _7059 { get; set; }

    [JsonProperty("LastExch", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int LastExch { get; set; }

    [JsonProperty("7057", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string _7057 { get; set; }

    [JsonProperty("7068", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string _7068 { get; set; }

    [JsonProperty("7058", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string _7058 { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}