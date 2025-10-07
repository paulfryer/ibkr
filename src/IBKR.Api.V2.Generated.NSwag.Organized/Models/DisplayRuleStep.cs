using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class DisplayRuleStep
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("decimalDigits", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int DecimalDigits { get; set; }

    [JsonProperty("lowerEdge", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double LowerEdge { get; set; }

    [JsonProperty("wholeDigits", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int WholeDigits { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}