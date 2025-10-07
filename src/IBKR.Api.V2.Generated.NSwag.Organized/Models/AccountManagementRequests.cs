using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountManagementRequests
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("updateExternalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public UpdateExternalId UpdateExternalId { get; set; } = null;

	[JsonProperty("updatePropertyProfile", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public UpdatePropertyProfile UpdatePropertyProfile { get; set; } = null;

	[JsonProperty("updateAccountAlias", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public UpdateAccountAlias UpdateAccountAlias { get; set; } = null;

	[JsonProperty("changeBaseCurrency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ChangeBaseCurrency ChangeBaseCurrency { get; set; } = null;

	[JsonProperty("abandonAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AbandonAccount AbandonAccount { get; set; } = null;

	[JsonProperty("addNewUser", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AddNewUser AddNewUser { get; set; } = null;

	[JsonProperty("addLevFxCapability", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AddLEVFXCapability AddLevFxCapability { get; set; } = null;

	[JsonProperty("addMiFirData", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AddMiFIRData AddMiFirData { get; set; } = null;

	[JsonProperty("addTradingPermissions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AddTradingPermissions AddTradingPermissions { get; set; } = null;

	[JsonProperty("removeTradingPermissions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public RemoveTradingPermissions RemoveTradingPermissions { get; set; } = null;

	[JsonProperty("changeMarginType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ChangeMarginType ChangeMarginType { get; set; } = null;

	[JsonProperty("addCLPCapability", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AddCLPCapability AddCLPCapability { get; set; } = null;

	[JsonProperty("changeFinancialInformation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ChangeFinancialInformation ChangeFinancialInformation { get; set; } = null;

	[JsonProperty("resetAbandonedAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ResetAbandonedAccount ResetAbandonedAccount { get; set; } = null;

	[JsonProperty("updateCredentials", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public UpdateCredentials UpdateCredentials { get; set; } = null;

	[JsonProperty("updateAccountRepresentatives", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public UpdateAccountRepresentatives UpdateAccountRepresentatives { get; set; } = null;

	[JsonProperty("completeLoginMessage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public CompleteLoginMessage CompleteLoginMessage { get; set; } = null;

	[JsonProperty("reopenAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ReopenAccount ReopenAccount { get; set; } = null;

	[JsonProperty("enrollInSyep", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public EnrollInSYEP EnrollInSyep { get; set; } = null;

	[JsonProperty("leaveSyep", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LeaveSYEP LeaveSyep { get; set; } = null;

	[JsonProperty("enrollInDrip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public EnrollInDRIP EnrollInDrip { get; set; } = null;

	[JsonProperty("leaveDrip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LeaveDRIP LeaveDrip { get; set; } = null;

	[JsonProperty("updateW8Ben", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public UpdateW8BEN UpdateW8Ben { get; set; } = null;

	[JsonProperty("yodleeSession", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public YodleeSession YodleeSession { get; set; } = null;

	[JsonProperty("enableAccountInBrokerage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public EnableAccountInBrokerage EnableAccountInBrokerage { get; set; } = null;

	[JsonProperty("disableAccountInBrokerage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DisableAccountInBrokerage DisableAccountInBrokerage { get; set; } = null;

	[JsonProperty("linkDuplicateAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LinkDuplicateAccount LinkDuplicateAccount { get; set; } = null;

	[JsonProperty("duplicateAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DuplicateAccount DuplicateAccount { get; set; } = null;

	[JsonProperty("achInstruction", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ACHInstruction AchInstruction { get; set; } = null;

	[JsonProperty("recurringTransaction", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public RecurringTransaction RecurringTransaction { get; set; } = null;

	[JsonProperty("depositNotification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DepositNotification DepositNotification { get; set; } = null;

	[JsonProperty("documentSubmission", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DocumentSubmission DocumentSubmission { get; set; } = null;

	[JsonProperty("processDocuments", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ProcessDocuments ProcessDocuments { get; set; } = null;

	[JsonProperty("updateBcan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public UpdateBCAN UpdateBcan { get; set; } = null;

	[JsonProperty("prohibitedCountryQuestionnaire", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ProhibitedCountryQuestionnaire ProhibitedCountryQuestionnaire { get; set; } = null;

	[JsonProperty("updateWithholdingStatement", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public UpdateWithholdingStatement UpdateWithholdingStatement { get; set; } = null;

	[JsonProperty("accreditedInvestor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccreditedInvestor AccreditedInvestor { get; set; } = null;

	[JsonProperty("changeAccountHolderDetail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ChangeAccountHolderDetail ChangeAccountHolderDetail { get; set; } = null;

	[JsonProperty("getJavaScript", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public GetJavaScript GetJavaScript { get; set; } = null;

	[JsonProperty("updateUserAccessRights", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public UpdateUserAccessRights UpdateUserAccessRights { get; set; } = null;

	[JsonProperty("informationChange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public InformationChange InformationChange { get; set; } = null;

	[JsonProperty("addAdditionalAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AddAdditionalAccount AddAdditionalAccount { get; set; } = null;

	[JsonProperty("accountConfiguration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccountConfiguration AccountConfiguration { get; set; } = null;

	[JsonProperty("allocateVan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AllocateVAN AllocateVan { get; set; } = null;

	[JsonProperty("createUser", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public CreateUser CreateUser { get; set; } = null;

	[JsonProperty("updateTaxForm", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public UpdateTaxForm UpdateTaxForm { get; set; } = null;

	[JsonProperty("questionnaires", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Questionnaires Questionnaires { get; set; } = null;

	[JsonProperty("securityQuestions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public SecurityQuestions SecurityQuestions { get; set; } = null;

	[JsonProperty("applyFeeTemplate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ApplyFeeTemplate ApplyFeeTemplate { get; set; } = null;

	[JsonProperty("accountClose", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccountClose AccountClose { get; set; } = null;

	[JsonProperty("manageMarketDataSubscriptions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ManageMarketDataSubscriptions ManageMarketDataSubscriptions { get; set; } = null;

	[JsonProperty("quizQuestionnaires", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public QuizQuestionnaires QuizQuestionnaires { get; set; } = null;

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
