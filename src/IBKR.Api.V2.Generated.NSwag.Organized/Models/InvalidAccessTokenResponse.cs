using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class InvalidAccessTokenResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("type", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string Type { get; set; }

    [JsonProperty("title", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string Title { get; set; }

    [JsonProperty("status", Required = Required.Always)]
    public int Status { get; set; }

    [JsonProperty("detail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Detail { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}