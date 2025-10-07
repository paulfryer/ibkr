using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Anonymous12
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("order_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Order_id { get; set; }

    [JsonProperty("order_status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Order_status { get; set; }

    [JsonProperty("encrypt_message", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Encrypt_message { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}