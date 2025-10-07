using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class BrokerageSessionStatus
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("authenticated", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Authenticated { get; set; }

    [JsonProperty("competing", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Competing { get; set; }

    [JsonProperty("connected", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Connected { get; set; }

    [JsonProperty("message", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }

    [JsonProperty("MAC", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MAC { get; set; }

    [JsonProperty("serverInfo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ServerInfo ServerInfo { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}