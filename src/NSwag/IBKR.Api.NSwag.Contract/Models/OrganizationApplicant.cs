using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class OrganizationApplicant
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("identifications", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<OrganizationIdentification> Identifications { get; set; } = null;


	[JsonProperty("accountSupport", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccountSupportType AccountSupport { get; set; } = null;


	[JsonProperty("financialInformation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<FinancialInformation> FinancialInformation { get; set; } = null;


	[JsonProperty("accreditedInvestorInformation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccreditedInvestorInformation AccreditedInvestorInformation { get; set; } = null;


	[JsonProperty("regulatoryInformation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<RegulatoryInformation> RegulatoryInformation { get; set; } = null;


	[JsonProperty("managingOwner", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ManagingOwner ManagingOwner { get; set; } = null;


	[JsonProperty("associatedEntities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AssociatedEntities AssociatedEntities { get; set; } = null;


	[JsonProperty("regulatedMemberships", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<RegulatedMembership> RegulatedMemberships { get; set; } = null;


	[JsonProperty("taxResidencies", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<TaxResidency> TaxResidencies { get; set; } = null;


	[JsonProperty("w8BenE", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FormW8BENE W8BenE { get; set; } = null;


	[JsonProperty("w8IMY", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FormW8IMY W8IMY { get; set; } = null;


	[JsonProperty("withholdingStatement", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public WithholdingStatementType WithholdingStatement { get; set; } = null;


	[JsonProperty("typeOfTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public OrganizationApplicantTypeOfTrading TypeOfTrading { get; set; } = OrganizationApplicantTypeOfTrading.FIRM;


	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public OrganizationApplicantType Type { get; set; } = OrganizationApplicantType.LLC;


	[JsonProperty("orgUsSubsidiary", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool OrgUsSubsidiary { get; set; } = false;


	[JsonProperty("qualifiedIntermediary", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool QualifiedIntermediary { get; set; } = false;


	[JsonProperty("assumedPrimaryReporting", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AssumedPrimaryReporting { get; set; } = false;


	[JsonProperty("acceptedPrimaryWithholding", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AcceptedPrimaryWithholding { get; set; } = false;


	[JsonProperty("usTaxPurposeType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public OrganizationApplicantUsTaxPurposeType UsTaxPurposeType { get; set; } = OrganizationApplicantUsTaxPurposeType.C;


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
