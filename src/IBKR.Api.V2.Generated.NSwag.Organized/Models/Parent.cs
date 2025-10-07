using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Parent
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("mmc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<object> Mmc { get; set; }

    [JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountId { get; set; }

    [JsonProperty("isMChild", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsMChild { get; set; }

    [JsonProperty("isMParent", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsMParent { get; set; }

    [JsonProperty("isMultiplex", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsMultiplex { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}