using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Transactions
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("date", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Date { get; set; }

    [JsonProperty("cur", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Cur { get; set; }

    [JsonProperty("fxRate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int FxRate { get; set; }

    [JsonProperty("pr", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Pr { get; set; }

    [JsonProperty("qty", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Qty { get; set; }

    [JsonProperty("acctid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Acctid { get; set; }

    [JsonProperty("amt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Amt { get; set; }

    [JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Conid { get; set; }

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }

    [JsonProperty("desc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Desc { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}