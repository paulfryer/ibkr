using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountData
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountId { get; set; }

    [JsonProperty("masterAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MasterAccountId { get; set; }

    [JsonProperty("mainAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MainAccount { get; set; }

    [JsonProperty("sourceAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SourceAccountId { get; set; }

    [JsonProperty("primaryUser", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string PrimaryUser { get; set; }

    [JsonProperty("clearingStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ClearingStatus { get; set; }

    [JsonProperty("clearingStatusDescription", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string ClearingStatusDescription { get; set; }

    [JsonProperty("stateCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string StateCode { get; set; }

    [JsonProperty("baseCurrency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string BaseCurrency { get; set; }

    [JsonProperty("dateBegun", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DateBegun { get; set; }

    [JsonProperty("dateApproved", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DateApproved { get; set; }

    [JsonProperty("dateOpened", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DateOpened { get; set; }

    [JsonProperty("dateFunded", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DateFunded { get; set; }

    [JsonProperty("dateClosed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DateClosed { get; set; }

    [JsonProperty("dateLinked", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DateLinked { get; set; }

    [JsonProperty("dateDelinked", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DateDelinked { get; set; }

    [JsonProperty("accountTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountTitle { get; set; }

    [JsonProperty("officialTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string OfficialTitle { get; set; }

    [JsonProperty("accountAlias", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountAlias { get; set; }

    [JsonProperty("emailAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string EmailAddress { get; set; }

    [JsonProperty("margin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Margin { get; set; }

    [JsonProperty("applicantType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ApplicantType { get; set; }

    [JsonProperty("subType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SubType { get; set; }

    [JsonProperty("stockYieldProgram", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> StockYieldProgram { get; set; }

    [JsonProperty("feeTemplate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> FeeTemplate { get; set; }

    [JsonProperty("capabilities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, ICollection<string>> Capabilities { get; set; }

    [JsonProperty("limitedOptionTrading", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string LimitedOptionTrading { get; set; }

    [JsonProperty("InvestmentObjectives", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> InvestmentObjectives { get; set; }

    [JsonProperty("dividendReinvestment", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, bool> DividendReinvestment { get; set; }

    [JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalId { get; set; }

    [JsonProperty("mifidCategory", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MifidCategory { get; set; }

    [JsonProperty("mifirStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MifirStatus { get; set; }

    [JsonProperty("equity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Equity { get; set; }

    [JsonProperty("household", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Household { get; set; }

    [JsonProperty("propertyProfile", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string PropertyProfile { get; set; }

    [JsonProperty("processType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ProcessType { get; set; }

    [JsonProperty("riskScore", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int RiskScore { get; set; }

    [JsonProperty("class_action_program", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Class_action_program { get; set; }

    [JsonProperty("trustType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TrustType { get; set; }

    [JsonProperty("orgType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string OrgType { get; set; }

    [JsonProperty("businessDescription", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string BusinessDescription { get; set; }

    [JsonProperty("usTaxPurposeType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string UsTaxPurposeType { get; set; }

    [JsonProperty("tradeIntentionType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TradeIntentionType { get; set; }

    [JsonProperty("registeredAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> RegisteredAddress { get; set; }

    [JsonProperty("mailing", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> Mailing { get; set; }

    [JsonProperty("countryOfCorporation", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string CountryOfCorporation { get; set; }

    [JsonProperty("taxIds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IDictionary<string, string>> TaxIds { get; set; }

    [JsonProperty("taxTreatyDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IDictionary<string, string>> TaxTreatyDetails { get; set; }

    [JsonProperty("signatures", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> Signatures { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}