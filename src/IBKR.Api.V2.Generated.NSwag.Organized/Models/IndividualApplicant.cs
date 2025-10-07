using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IndividualApplicant
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("accountHolderDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<AssociatedIndividual> AccountHolderDetails { get; set; } = null;

	[JsonProperty("associatedIndividual", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AssociatedIndividual AssociatedIndividual { get; set; } = null;

	[JsonProperty("financialInformation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<FinancialInformation> FinancialInformation { get; set; } = null;

	[JsonProperty("regulatoryInformation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<RegulatoryInformation> RegulatoryInformation { get; set; } = null;

	[JsonProperty("regulatedMemberships", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<RegulatedMembership> RegulatedMemberships { get; set; } = null;

	[JsonProperty("accreditedInvestorInformation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccreditedInvestorInformation AccreditedInvestorInformation { get; set; } = null;

	[JsonProperty("taxInformation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IndividualTaxInformation TaxInformation { get; set; } = null;

	[JsonProperty("withholdingStatement", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public WithholdingStatementType WithholdingStatement { get; set; } = null;

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get
		{
			return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
		}
		set
		{
			_additionalProperties = value;
		}
	}
}
