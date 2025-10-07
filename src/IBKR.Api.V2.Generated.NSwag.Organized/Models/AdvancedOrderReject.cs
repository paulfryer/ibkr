using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AdvancedOrderReject
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("orderId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int OrderId { get; set; }

    [JsonProperty("reqId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ReqId { get; set; }

    [JsonProperty("dismissable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<object> Dismissable { get; set; }

    [JsonProperty("text", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Text { get; set; }

    [JsonProperty("options", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> Options { get; set; }

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }

    [JsonProperty("messageId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MessageId { get; set; }

    [JsonProperty("prompt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Prompt { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}