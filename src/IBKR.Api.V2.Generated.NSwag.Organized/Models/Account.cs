using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Account
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("accountConfiguration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccountConfigurationType AccountConfiguration { get; set; } = null;

	[JsonProperty("InvestmentObjectives", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
	public ICollection<InvestmentObjectives> InvestmentObjectives { get; set; } = null;

	[JsonProperty("brokerageServiceCodes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
	public ICollection<BrokerageServiceCodes> BrokerageServiceCodes { get; set; } = null;

	[JsonProperty("capabilities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
	public ICollection<Capabilities> Capabilities { get; set; } = null;

	[JsonProperty("optionLevel", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int OptionLevel { get; set; } = 0;

	[JsonProperty("tradingPermissions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<TradingPermission> TradingPermissions { get; set; } = null;

	[JsonProperty("commissionConfigs", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<CommissionConfig> CommissionConfigs { get; set; } = null;

	[JsonProperty("allExchangeAccess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<ExchangeAccess> AllExchangeAccess { get; set; } = null;

	[JsonProperty("dvpInstructions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<DVPInstruction> DvpInstructions { get; set; } = null;

	[JsonProperty("tradingLimits", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public TradingLimits TradingLimits { get; set; } = null;

	[JsonProperty("advisorWrapFees", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AdvisorWrapFeesType AdvisorWrapFees { get; set; } = null;

	[JsonProperty("feesTemplateName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FeesTemplateName { get; set; } = null;

	[JsonProperty("clientCommissionSchedule", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public CommissionScheduleType ClientCommissionSchedule { get; set; } = null;

	[JsonProperty("clientInterestMarkupSchedules", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<InterestMarkupType> ClientInterestMarkupSchedules { get; set; } = null;

	[JsonProperty("decendent", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IRADecedent Decendent { get; set; } = null;

	[JsonProperty("iraBeneficiaries", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IRABeneficiariesType IraBeneficiaries { get; set; } = null;

	[JsonProperty("extPositionsTransfers", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<ExtPositionsTransferType> ExtPositionsTransfers { get; set; } = null;

	[JsonProperty("depositNotification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DepositNotification DepositNotification { get; set; } = null;

	[JsonProperty("achInstructions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<ACHInstruction> AchInstructions { get; set; } = null;

	[JsonProperty("recurringTransactions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<RecurringTransaction> RecurringTransactions { get; set; } = null;

	[JsonProperty("custodian", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public CustodianType Custodian { get; set; } = null;

	[JsonProperty("successorCustodian", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public CustodianType SuccessorCustodian { get; set; } = null;

	[JsonProperty("accountRep", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccountRep AccountRep { get; set; } = null;

	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Id { get; set; } = null;

	[JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalId { get; set; } = null;

	[JsonProperty("propertyProfile", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PropertyProfile { get; set; } = null;

	[JsonProperty("baseCurrency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AccountBaseCurrency BaseCurrency { get; set; } = AccountBaseCurrency.USD;

	[JsonProperty("employeePlan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string EmployeePlan { get; set; } = null;

	[JsonProperty("multiCurrency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool MultiCurrency { get; set; } = false;

	[JsonProperty("migration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Migration { get; set; } = false;

	[JsonProperty("sourceAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SourceAccountId { get; set; } = null;

	[JsonProperty("margin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Margin { get; set; } = null;

	[JsonProperty("ira", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Ira { get; set; } = false;

	[JsonProperty("iraType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AccountIraType IraType { get; set; } = AccountIraType.RI;

	[JsonProperty("iraOfficialTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string IraOfficialTitle { get; set; } = null;

	[JsonProperty("clientActiveTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ClientActiveTrading { get; set; } = false;

	[JsonProperty("duplicate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Duplicate { get; set; } = false;

	[JsonProperty("numberOfDuplicates", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int NumberOfDuplicates { get; set; } = 0;

	[JsonProperty("stockYieldProgram", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool StockYieldProgram { get; set; } = false;

	[JsonProperty("alias", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Alias { get; set; } = null;

	[JsonProperty("accountType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AccountType AccountType { get; set; } = AccountType.Investment;

	[JsonProperty("drip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Drip { get; set; } = false;

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
