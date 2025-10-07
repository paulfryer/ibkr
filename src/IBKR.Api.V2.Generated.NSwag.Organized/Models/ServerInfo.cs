using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ServerInfo
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("serverName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ServerName { get; set; }

    [JsonProperty("serverVersion", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ServerVersion { get; set; }

    [JsonProperty("fail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Fail { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}