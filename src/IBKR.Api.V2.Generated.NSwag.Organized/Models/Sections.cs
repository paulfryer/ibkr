using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Sections
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("secType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SecType { get; set; }

    [JsonProperty("months", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Months { get; set; }

    [JsonProperty("exchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Exchange { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}