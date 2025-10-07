using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class JointApplicant
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("firstHolderDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AssociatedIndividual> FirstHolderDetails { get; set; }

    [JsonProperty("secondHolderDetails", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AssociatedIndividual> SecondHolderDetails { get; set; }

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

    [JsonProperty("taxInformation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IndividualTaxInformation TaxInformation { get; set; }

    [JsonProperty("withholdingStatement", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public WithholdingStatementType WithholdingStatement { get; set; }

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public JointApplicantType Type { get; set; } = JointApplicantType.Community;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}