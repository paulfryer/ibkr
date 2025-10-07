using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Error2
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("errorCode", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string ErrorCode { get; set; }

    [JsonProperty("errorMessage", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string ErrorMessage { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}