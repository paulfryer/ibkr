using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PortfolioAllocations
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("assetClass", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AssetClass2 AssetClass { get; set; }

    [JsonProperty("group", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Group Group { get; set; }

    [JsonProperty("sector", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Sector Sector { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}