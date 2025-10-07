using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IndividualApplicant
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("accountHolderDetails", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AssociatedIndividual> AccountHolderDetails { get; set; }

    [JsonProperty("associatedIndividual", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public AssociatedIndividual AssociatedIndividual { get; set; }

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

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}