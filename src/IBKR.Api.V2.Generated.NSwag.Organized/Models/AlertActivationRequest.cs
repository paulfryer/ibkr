using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AlertActivationRequest
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("alertId", Required = Required.Always)]
    public int AlertId { get; set; }

    [JsonProperty("alertActive", Required = Required.Always)]
    public int AlertActive { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}