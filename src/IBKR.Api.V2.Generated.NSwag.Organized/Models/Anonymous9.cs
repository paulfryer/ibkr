using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Anonymous9
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("chineseName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ChineseName { get; set; }

    [JsonProperty("assetClass", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AssetClass { get; set; }

    [JsonProperty("Contracts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Contracts> Contracts { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}