using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class YodleeSession
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("request", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Request { get; set; }

    [JsonProperty("username", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Username { get; set; }

    [JsonProperty("itemAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ItemAccountId { get; set; }

    [JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountId { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}