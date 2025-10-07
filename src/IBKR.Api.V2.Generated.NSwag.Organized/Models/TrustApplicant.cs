using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TrustApplicant
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("identification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<TrustIdentification> Identification { get; set; }

    [JsonProperty("financialInformation", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<FinancialInformation> FinancialInformation { get; set; }

    [JsonProperty("regulatoryInformation", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<RegulatoryInformation> RegulatoryInformation { get; set; }

    [JsonProperty("regulatedMemberships", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<RegulatedMembership> RegulatedMemberships { get; set; }

    [JsonProperty("accreditedInvestorInformation", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public AccreditedInvestorInformation AccreditedInvestorInformation { get; set; }

    [JsonProperty("trustees", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public TrusteesType Trustees { get; set; }

    [JsonProperty("beneficiaries", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AssociationTypeEntities Beneficiaries { get; set; }

    [JsonProperty("grantors", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AssociationTypeEntities Grantors { get; set; }

    [JsonProperty("taxResidencies", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<TaxResidency> TaxResidencies { get; set; }

    [JsonProperty("w8BenE", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public FormW8BENE W8BenE { get; set; }

    [JsonProperty("w8IMY", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public FormW8IMY W8IMY { get; set; }

    [JsonProperty("withholdingStatement", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public WithholdingStatementType WithholdingStatement { get; set; }

    [JsonProperty("thirdPartyManagement", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool ThirdPartyManagement { get; set; }

    [JsonProperty("trustType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public TrustApplicantTrustType TrustType { get; set; } = TrustApplicantTrustType.COMPLEX_TRUST;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}