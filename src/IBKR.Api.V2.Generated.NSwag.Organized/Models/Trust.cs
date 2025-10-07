using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Trust
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("identification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public TrustIdentification Identification { get; set; }

    [JsonProperty("regulatoryInformation", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public RegulatoryInformation RegulatoryInformation { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}