using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class SingleWatchlist
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("hash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Hash { get; set; }

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("readOnly", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool ReadOnly { get; set; }

    [JsonProperty("instruments", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<SingleWatchlistEntry> Instruments { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}