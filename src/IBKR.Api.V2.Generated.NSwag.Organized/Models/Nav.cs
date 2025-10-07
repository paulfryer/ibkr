using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Nav
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("Data", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Data> Data { get; set; }

    [JsonProperty("freq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Freq { get; set; }

    [JsonProperty("dates", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<object> Dates { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}