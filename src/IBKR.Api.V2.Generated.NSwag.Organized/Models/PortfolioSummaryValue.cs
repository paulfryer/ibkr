using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PortfolioSummaryValue
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("amount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Amount { get; set; }

    [JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Currency { get; set; }

    [JsonProperty("isNull", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsNull { get; set; }

    [JsonProperty("severity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Severity { get; set; }

    [JsonProperty("timestamp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Timestamp { get; set; }

    [JsonProperty("value", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Value { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}