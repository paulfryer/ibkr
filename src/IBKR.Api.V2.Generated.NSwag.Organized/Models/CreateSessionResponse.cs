using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class CreateSessionResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("active", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Active { get; set; }

    [JsonProperty("access_token", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string Access_token { get; set; }

    [JsonProperty("token_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Token_type { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}