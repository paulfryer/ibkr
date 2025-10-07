using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Body16
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Conid { get; set; }

    [JsonProperty("isBuy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsBuy { get; set; } = true;

    [JsonProperty("modifyOrder", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool ModifyOrder { get; set; }

    [JsonProperty("orderId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int OrderId { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}