using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class CashBalances
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Currency { get; set; }

    [JsonProperty("balance", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Balance { get; set; }

    [JsonProperty("settledCash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int SettledCash { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}