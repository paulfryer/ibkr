using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Data2
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("idType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string IdType { get; set; }

    [JsonProperty("start", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Start { get; set; }

    [JsonProperty("end", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string End { get; set; }

    [JsonProperty("returns", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<object> Returns { get; set; }

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("baseCurrency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string BaseCurrency { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}