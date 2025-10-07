using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ORGRegulatorType
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("regulatorName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string RegulatorName { get; set; }

    [JsonProperty("regulatorCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string RegulatorCountry { get; set; }

    [JsonProperty("regulatedInCapacity", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string RegulatedInCapacity { get; set; }

    [JsonProperty("regulatorId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string RegulatorId { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}