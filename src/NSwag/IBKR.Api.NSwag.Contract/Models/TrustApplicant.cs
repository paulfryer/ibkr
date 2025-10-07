using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TrustApplicant
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("identification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<TrustIdentification> Identification { get; set; } = null;


	[JsonProperty("financialInformation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<FinancialInformation> FinancialInformation { get; set; } = null;


	[JsonProperty("regulatoryInformation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<RegulatoryInformation> RegulatoryInformation { get; set; } = null;


	[JsonProperty("regulatedMemberships", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<RegulatedMembership> RegulatedMemberships { get; set; } = null;


	[JsonProperty("accreditedInvestorInformation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccreditedInvestorInformation AccreditedInvestorInformation { get; set; } = null;


	[JsonProperty("trustees", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public TrusteesType Trustees { get; set; } = null;


	[JsonProperty("beneficiaries", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AssociationTypeEntities Beneficiaries { get; set; } = null;


	[JsonProperty("grantors", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AssociationTypeEntities Grantors { get; set; } = null;


	[JsonProperty("taxResidencies", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<TaxResidency> TaxResidencies { get; set; } = null;


	[JsonProperty("w8BenE", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FormW8BENE W8BenE { get; set; } = null;


	[JsonProperty("w8IMY", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FormW8IMY W8IMY { get; set; } = null;


	[JsonProperty("withholdingStatement", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public WithholdingStatementType WithholdingStatement { get; set; } = null;


	[JsonProperty("thirdPartyManagement", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ThirdPartyManagement { get; set; } = false;


	[JsonProperty("trustType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public TrustApplicantTrustType TrustType { get; set; } = TrustApplicantTrustType.COMPLEX_TRUST;


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
