using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class SignatureAndOwners
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountId { get; set; }

    [JsonProperty("users", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<User> Users { get; set; }

    [JsonProperty("applicant", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Applicant Applicant { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}