using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AffiliationDetailsType
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("affiliationRelationship", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AffiliationDetailsTypeAffiliationRelationship AffiliationRelationship { get; set; } =
        AffiliationDetailsTypeAffiliationRelationship.Self;

    [JsonProperty("personName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string PersonName { get; set; }

    [JsonProperty("companyId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int CompanyId { get; set; }

    [JsonProperty("company", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Company { get; set; }

    [JsonProperty("companyMailingAddress", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Address CompanyMailingAddress { get; set; }

    [JsonProperty("companyPhone", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyPhone { get; set; }

    [JsonProperty("companyEmailAddress", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyEmailAddress { get; set; }

    [JsonProperty("duplicateStmtRequired", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool DuplicateStmtRequired { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}