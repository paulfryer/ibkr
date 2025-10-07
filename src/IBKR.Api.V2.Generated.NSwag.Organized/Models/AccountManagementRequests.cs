using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountManagementRequests
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("updateExternalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public UpdateExternalId UpdateExternalId { get; set; }

    [JsonProperty("updatePropertyProfile", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public UpdatePropertyProfile UpdatePropertyProfile { get; set; }

    [JsonProperty("updateAccountAlias", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public UpdateAccountAlias UpdateAccountAlias { get; set; }

    [JsonProperty("changeBaseCurrency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ChangeBaseCurrency ChangeBaseCurrency { get; set; }

    [JsonProperty("abandonAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AbandonAccount AbandonAccount { get; set; }

    [JsonProperty("addNewUser", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AddNewUser AddNewUser { get; set; }

    [JsonProperty("addLevFxCapability", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AddLEVFXCapability AddLevFxCapability { get; set; }

    [JsonProperty("addMiFirData", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AddMiFIRData AddMiFirData { get; set; }

    [JsonProperty("addTradingPermissions", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public AddTradingPermissions AddTradingPermissions { get; set; }

    [JsonProperty("removeTradingPermissions", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public RemoveTradingPermissions RemoveTradingPermissions { get; set; }

    [JsonProperty("changeMarginType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ChangeMarginType ChangeMarginType { get; set; }

    [JsonProperty("addCLPCapability", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AddCLPCapability AddCLPCapability { get; set; }

    [JsonProperty("changeFinancialInformation", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ChangeFinancialInformation ChangeFinancialInformation { get; set; }

    [JsonProperty("resetAbandonedAccount", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ResetAbandonedAccount ResetAbandonedAccount { get; set; }

    [JsonProperty("updateCredentials", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public UpdateCredentials UpdateCredentials { get; set; }

    [JsonProperty("updateAccountRepresentatives", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public UpdateAccountRepresentatives UpdateAccountRepresentatives { get; set; }

    [JsonProperty("completeLoginMessage", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public CompleteLoginMessage CompleteLoginMessage { get; set; }

    [JsonProperty("reopenAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ReopenAccount ReopenAccount { get; set; }

    [JsonProperty("enrollInSyep", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public EnrollInSYEP EnrollInSyep { get; set; }

    [JsonProperty("leaveSyep", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public LeaveSYEP LeaveSyep { get; set; }

    [JsonProperty("enrollInDrip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public EnrollInDRIP EnrollInDrip { get; set; }

    [JsonProperty("leaveDrip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public LeaveDRIP LeaveDrip { get; set; }

    [JsonProperty("updateW8Ben", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public UpdateW8BEN UpdateW8Ben { get; set; }

    [JsonProperty("yodleeSession", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public YodleeSession YodleeSession { get; set; }

    [JsonProperty("enableAccountInBrokerage", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public EnableAccountInBrokerage EnableAccountInBrokerage { get; set; }

    [JsonProperty("disableAccountInBrokerage", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public DisableAccountInBrokerage DisableAccountInBrokerage { get; set; }

    [JsonProperty("linkDuplicateAccount", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public LinkDuplicateAccount LinkDuplicateAccount { get; set; }

    [JsonProperty("duplicateAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DuplicateAccount DuplicateAccount { get; set; }

    [JsonProperty("achInstruction", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ACHInstruction AchInstruction { get; set; }

    [JsonProperty("recurringTransaction", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public RecurringTransaction RecurringTransaction { get; set; }

    [JsonProperty("depositNotification", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public DepositNotification DepositNotification { get; set; }

    [JsonProperty("documentSubmission", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DocumentSubmission DocumentSubmission { get; set; }

    [JsonProperty("processDocuments", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ProcessDocuments ProcessDocuments { get; set; }

    [JsonProperty("updateBcan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public UpdateBCAN UpdateBcan { get; set; }

    [JsonProperty("prohibitedCountryQuestionnaire", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ProhibitedCountryQuestionnaire ProhibitedCountryQuestionnaire { get; set; }

    [JsonProperty("updateWithholdingStatement", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public UpdateWithholdingStatement UpdateWithholdingStatement { get; set; }

    [JsonProperty("accreditedInvestor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AccreditedInvestor AccreditedInvestor { get; set; }

    [JsonProperty("changeAccountHolderDetail", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ChangeAccountHolderDetail ChangeAccountHolderDetail { get; set; }

    [JsonProperty("getJavaScript", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public GetJavaScript GetJavaScript { get; set; }

    [JsonProperty("updateUserAccessRights", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public UpdateUserAccessRights UpdateUserAccessRights { get; set; }

    [JsonProperty("informationChange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public InformationChange InformationChange { get; set; }

    [JsonProperty("addAdditionalAccount", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public AddAdditionalAccount AddAdditionalAccount { get; set; }

    [JsonProperty("accountConfiguration", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public AccountConfiguration AccountConfiguration { get; set; }

    [JsonProperty("allocateVan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AllocateVAN AllocateVan { get; set; }

    [JsonProperty("createUser", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public CreateUser CreateUser { get; set; }

    [JsonProperty("updateTaxForm", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public UpdateTaxForm UpdateTaxForm { get; set; }

    [JsonProperty("questionnaires", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Questionnaires Questionnaires { get; set; }

    [JsonProperty("securityQuestions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public SecurityQuestions SecurityQuestions { get; set; }

    [JsonProperty("applyFeeTemplate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ApplyFeeTemplate ApplyFeeTemplate { get; set; }

    [JsonProperty("accountClose", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AccountClose AccountClose { get; set; }

    [JsonProperty("manageMarketDataSubscriptions", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ManageMarketDataSubscriptions ManageMarketDataSubscriptions { get; set; }

    [JsonProperty("quizQuestionnaires", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public QuizQuestionnaires QuizQuestionnaires { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}