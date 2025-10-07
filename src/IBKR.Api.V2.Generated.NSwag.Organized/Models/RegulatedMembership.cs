using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RegulatedMembership
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("organizationCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string OrganizationCode { get; set; }

    [JsonProperty("membershipId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MembershipId { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}