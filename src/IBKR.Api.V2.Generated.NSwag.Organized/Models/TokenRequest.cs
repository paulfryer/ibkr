using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TokenRequest
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("clientAssertionType", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string ClientAssertionType { get; set; }

    [JsonProperty("clientAssertion", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ClientAssertion { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}