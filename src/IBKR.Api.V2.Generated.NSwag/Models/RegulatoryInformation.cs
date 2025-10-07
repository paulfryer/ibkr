using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RegulatoryInformation
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("regulatoryDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<RegulatoryDetail> RegulatoryDetails { get; set; } = null;


	[JsonProperty("regulatoryDetail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<RegulatoryDetail> RegulatoryDetail { get; set; } = null;


	[JsonProperty("selfRegulatedMembership", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public SelfRegulatedMembershipType SelfRegulatedMembership { get; set; } = null;


	[JsonProperty("affiliationDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AffiliationDetailsType AffiliationDetails { get; set; } = null;


	[JsonProperty("financialOrgTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> FinancialOrgTypes { get; set; } = null;


	[JsonProperty("orgRegulatoryInfo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ORGRegulatoryInfoType OrgRegulatoryInfo { get; set; } = null;


	[JsonProperty("ausExposureDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AUSExposureDetailsType AusExposureDetails { get; set; } = null;


	[JsonProperty("controllerExchangeCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ControllerExchangeCode { get; set; } = null;


	[JsonProperty("politicalMilitaryDiplomaticDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public PoliticalMilitaryDiplomaticDetailsType PoliticalMilitaryDiplomaticDetails { get; set; } = null;


	[JsonProperty("translated", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Translated { get; set; } = false;


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
