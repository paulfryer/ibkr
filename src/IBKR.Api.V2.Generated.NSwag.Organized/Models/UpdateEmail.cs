using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class UpdateEmail
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Email { get; set; }

    [JsonProperty("token", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Token { get; set; }

    [JsonProperty("access", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Access { get; set; }

    [JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalId { get; set; }

    [JsonProperty("entityId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string EntityId { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}