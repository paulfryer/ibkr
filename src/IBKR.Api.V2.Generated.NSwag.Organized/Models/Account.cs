using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Account
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("accountConfiguration", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public AccountConfigurationType AccountConfiguration { get; set; }

    [JsonProperty("InvestmentObjectives", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
    public ICollection<InvestmentObjectives> InvestmentObjectives { get; set; }

    [JsonProperty("brokerageServiceCodes", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
    public ICollection<BrokerageServiceCodes> BrokerageServiceCodes { get; set; }

    [JsonProperty("capabilities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore,
        ItemConverterType = typeof(StringEnumConverter))]
    public ICollection<Capabilities> Capabilities { get; set; }

    [JsonProperty("optionLevel", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int OptionLevel { get; set; }

    [JsonProperty("tradingPermissions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<TradingPermission> TradingPermissions { get; set; }

    [JsonProperty("commissionConfigs", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<CommissionConfig> CommissionConfigs { get; set; }

    [JsonProperty("allExchangeAccess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<ExchangeAccess> AllExchangeAccess { get; set; }

    [JsonProperty("dvpInstructions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<DVPInstruction> DvpInstructions { get; set; }

    [JsonProperty("tradingLimits", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public TradingLimits TradingLimits { get; set; }

    [JsonProperty("advisorWrapFees", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AdvisorWrapFeesType AdvisorWrapFees { get; set; }

    [JsonProperty("feesTemplateName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FeesTemplateName { get; set; }

    [JsonProperty("clientCommissionSchedule", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public CommissionScheduleType ClientCommissionSchedule { get; set; }

    [JsonProperty("clientInterestMarkupSchedules", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<InterestMarkupType> ClientInterestMarkupSchedules { get; set; }

    [JsonProperty("decendent", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IRADecedent Decendent { get; set; }

    [JsonProperty("iraBeneficiaries", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IRABeneficiariesType IraBeneficiaries { get; set; }

    [JsonProperty("extPositionsTransfers", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<ExtPositionsTransferType> ExtPositionsTransfers { get; set; }

    [JsonProperty("depositNotification", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public DepositNotification DepositNotification { get; set; }

    [JsonProperty("achInstructions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<ACHInstruction> AchInstructions { get; set; }

    [JsonProperty("recurringTransactions", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<RecurringTransaction> RecurringTransactions { get; set; }

    [JsonProperty("custodian", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public CustodianType Custodian { get; set; }

    [JsonProperty("successorCustodian", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public CustodianType SuccessorCustodian { get; set; }

    [JsonProperty("accountRep", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AccountRep AccountRep { get; set; }

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalId { get; set; }

    [JsonProperty("propertyProfile", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string PropertyProfile { get; set; }

    [JsonProperty("baseCurrency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AccountBaseCurrency BaseCurrency { get; set; } = AccountBaseCurrency.USD;

    [JsonProperty("employeePlan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string EmployeePlan { get; set; }

    [JsonProperty("multiCurrency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool MultiCurrency { get; set; }

    [JsonProperty("migration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Migration { get; set; }

    [JsonProperty("sourceAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SourceAccountId { get; set; }

    [JsonProperty("margin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Margin { get; set; }

    [JsonProperty("ira", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Ira { get; set; }

    [JsonProperty("iraType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AccountIraType IraType { get; set; } = AccountIraType.RI;

    [JsonProperty("iraOfficialTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string IraOfficialTitle { get; set; }

    [JsonProperty("clientActiveTrading", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool ClientActiveTrading { get; set; }

    [JsonProperty("duplicate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Duplicate { get; set; }

    [JsonProperty("numberOfDuplicates", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int NumberOfDuplicates { get; set; }

    [JsonProperty("stockYieldProgram", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool StockYieldProgram { get; set; }

    [JsonProperty("alias", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Alias { get; set; }

    [JsonProperty("accountType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AccountType AccountType { get; set; } = AccountType.Investment;

    [JsonProperty("drip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Drip { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}