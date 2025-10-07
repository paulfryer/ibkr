using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Data6
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("scanners_only", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Scanners_only { get; set; }

    [JsonProperty("show_scanners", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Show_scanners { get; set; }

    [JsonProperty("bulk_delete", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Bulk_delete { get; set; }

    [JsonProperty("user_lists", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<User_lists> User_lists { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}