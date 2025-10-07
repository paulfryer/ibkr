using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Customer
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("organization", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public OrganizationApplicant Organization { get; set; } = null;

	[JsonProperty("accountHolder", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IndividualApplicant AccountHolder { get; set; } = null;

	[JsonProperty("jointHolders", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public JointApplicant JointHolders { get; set; } = null;

	[JsonProperty("trust", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public TrustApplicant Trust { get; set; } = null;

	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Id { get; set; } = null;

	[JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalId { get; set; } = null;

	[JsonProperty("transferUsMicroCapStock", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool TransferUsMicroCapStock { get; set; } = false;

	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public CustomerType Type { get; set; } = CustomerType.INDIVIDUAL;

	[JsonProperty("prefix", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Prefix { get; set; } = null;

	[JsonProperty("userName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string UserName { get; set; } = null;

	[JsonProperty("userNameAlias", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string UserNameAlias { get; set; } = null;

	[JsonProperty("userNameSource", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string UserNameSource { get; set; } = null;

	[JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Email { get; set; } = null;

	[JsonProperty("mdStatusNonPro", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool MdStatusNonPro { get; set; } = false;

	[JsonProperty("preferredPrimaryLanguage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PreferredPrimaryLanguage { get; set; } = null;

	[JsonProperty("preferredSecondaryLanguage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PreferredSecondaryLanguage { get; set; } = null;

	[JsonProperty("legalResidenceCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string LegalResidenceCountry { get; set; } = null;

	[JsonProperty("taxTreatyCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TaxTreatyCountry { get; set; } = null;

	[JsonProperty("meetAmlStandard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MeetAmlStandard { get; set; } = null;

	[JsonProperty("meetsAmlStandard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MeetsAmlStandard { get; set; } = null;

	[JsonProperty("directTradingAccess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool DirectTradingAccess { get; set; } = false;

	[JsonProperty("originCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string OriginCountry { get; set; } = null;

	[JsonProperty("terminationAge", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int TerminationAge { get; set; } = 0;

	[JsonProperty("governingState", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string GoverningState { get; set; } = null;

	[JsonProperty("optForDebitCard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool OptForDebitCard { get; set; } = false;

	[JsonProperty("roboFaClient", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool RoboFaClient { get; set; } = false;

	[JsonProperty("independentAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IndependentAccount { get; set; } = false;

	[JsonProperty("paperAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool PaperAccount { get; set; } = false;

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
