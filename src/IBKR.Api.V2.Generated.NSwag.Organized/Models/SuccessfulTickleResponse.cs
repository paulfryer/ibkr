using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class SuccessfulTickleResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("session", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Session { get; set; }

    [JsonProperty("ssoExpires", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int SsoExpires { get; set; }

    [JsonProperty("collission", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Collission { get; set; }

    [JsonProperty("userId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int UserId { get; set; }

    [JsonProperty("hmds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Hmds Hmds { get; set; }

    [JsonProperty("iserver", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Iserver Iserver { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}