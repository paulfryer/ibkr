using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AssetClass2
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("long", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, double> Long { get; set; }

    [JsonProperty("short", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, double> Short { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}