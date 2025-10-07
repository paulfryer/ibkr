using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountData
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountId { get; set; } = null;

	[JsonProperty("masterAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MasterAccountId { get; set; } = null;

	[JsonProperty("mainAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MainAccount { get; set; } = null;

	[JsonProperty("sourceAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SourceAccountId { get; set; } = null;

	[JsonProperty("primaryUser", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PrimaryUser { get; set; } = null;

	[JsonProperty("clearingStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ClearingStatus { get; set; } = null;

	[JsonProperty("clearingStatusDescription", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ClearingStatusDescription { get; set; } = null;

	[JsonProperty("stateCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string StateCode { get; set; } = null;

	[JsonProperty("baseCurrency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BaseCurrency { get; set; } = null;

	[JsonProperty("dateBegun", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DateBegun { get; set; } = null;

	[JsonProperty("dateApproved", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DateApproved { get; set; } = null;

	[JsonProperty("dateOpened", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DateOpened { get; set; } = null;

	[JsonProperty("dateFunded", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DateFunded { get; set; } = null;

	[JsonProperty("dateClosed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DateClosed { get; set; } = null;

	[JsonProperty("dateLinked", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DateLinked { get; set; } = null;

	[JsonProperty("dateDelinked", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DateDelinked { get; set; } = null;

	[JsonProperty("accountTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountTitle { get; set; } = null;

	[JsonProperty("officialTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string OfficialTitle { get; set; } = null;

	[JsonProperty("accountAlias", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountAlias { get; set; } = null;

	[JsonProperty("emailAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string EmailAddress { get; set; } = null;

	[JsonProperty("margin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Margin { get; set; } = null;

	[JsonProperty("applicantType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ApplicantType { get; set; } = null;

	[JsonProperty("subType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SubType { get; set; } = null;

	[JsonProperty("stockYieldProgram", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, string> StockYieldProgram { get; set; } = null;

	[JsonProperty("feeTemplate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, string> FeeTemplate { get; set; } = null;

	[JsonProperty("capabilities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, ICollection<string>> Capabilities { get; set; } = null;

	[JsonProperty("limitedOptionTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string LimitedOptionTrading { get; set; } = null;

	[JsonProperty("InvestmentObjectives", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> InvestmentObjectives { get; set; } = null;

	[JsonProperty("dividendReinvestment", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, bool> DividendReinvestment { get; set; } = null;

	[JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalId { get; set; } = null;

	[JsonProperty("mifidCategory", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MifidCategory { get; set; } = null;

	[JsonProperty("mifirStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MifirStatus { get; set; } = null;

	[JsonProperty("equity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Equity { get; set; } = 0.0;

	[JsonProperty("household", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Household { get; set; } = null;

	[JsonProperty("propertyProfile", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PropertyProfile { get; set; } = null;

	[JsonProperty("processType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ProcessType { get; set; } = null;

	[JsonProperty("riskScore", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int RiskScore { get; set; } = 0;

	[JsonProperty("class_action_program", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Class_action_program { get; set; } = null;

	[JsonProperty("trustType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TrustType { get; set; } = null;

	[JsonProperty("orgType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string OrgType { get; set; } = null;

	[JsonProperty("businessDescription", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BusinessDescription { get; set; } = null;

	[JsonProperty("usTaxPurposeType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string UsTaxPurposeType { get; set; } = null;

	[JsonProperty("tradeIntentionType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TradeIntentionType { get; set; } = null;

	[JsonProperty("registeredAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, string> RegisteredAddress { get; set; } = null;

	[JsonProperty("mailing", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, string> Mailing { get; set; } = null;

	[JsonProperty("countryOfCorporation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CountryOfCorporation { get; set; } = null;

	[JsonProperty("taxIds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IDictionary<string, string>> TaxIds { get; set; } = null;

	[JsonProperty("taxTreatyDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IDictionary<string, string>> TaxTreatyDetails { get; set; } = null;

	[JsonProperty("signatures", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> Signatures { get; set; } = null;

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
