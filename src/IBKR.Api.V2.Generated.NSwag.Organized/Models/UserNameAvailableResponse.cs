using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class UserNameAvailableResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("error", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ErrorResponse Error { get; set; }

    [JsonProperty("hasError", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool HasError { get; set; }

    [JsonProperty("errorDescription", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ErrorDescription { get; set; }

    [JsonProperty("isValid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsValid { get; set; }

    [JsonProperty("isAvailable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsAvailable { get; set; }

    [JsonProperty("suggestedUserName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> SuggestedUserName { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}