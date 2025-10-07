using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Items
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("date", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Date { get; set; }

    [JsonProperty("cur", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Cur { get; set; }

    [JsonProperty("fxRate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int FxRate { get; set; }

    [JsonProperty("side", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ItemsSide Side { get; set; } = ItemsSide.L;

    [JsonProperty("acctid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Acctid { get; set; }

    [JsonProperty("amt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Amt { get; set; }

    [JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Conid { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}