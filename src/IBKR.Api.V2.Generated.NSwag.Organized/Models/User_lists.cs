using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class User_lists
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("is_open", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Is_open { get; set; }

    [JsonProperty("read_only", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Read_only { get; set; }

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("modified", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Modified { get; set; }

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public User_listsType Type { get; set; } = User_listsType.Watchlist;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}