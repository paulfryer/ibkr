using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IIBKRClient
{
	Task<SignatureAndOwners> SignaturesAndOwnersAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<DeliveryOptions> DeliveryoptionsGETAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<FyiVT> DeviceAsync(FyiEnableDeviceOption body, CancellationToken cancellationToken = default(CancellationToken));

	Task<FyiVT> EmailAsync(object enabled, CancellationToken cancellationToken = default(CancellationToken));

	System.Threading.Tasks.Task DeliveryoptionsDELETEAsync(object deviceId, CancellationToken cancellationToken = default(CancellationToken));

	Task<DisclaimerInfo> DisclaimerGETAsync(Typecodes typecode, CancellationToken cancellationToken = default(CancellationToken));

	Task<FyiVT> DisclaimerPUTAsync(Typecodes typecode, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Anonymous>> NotificationsAllAsync(string max, object? include = null, object? exclude = null, object? id = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<NotificationReadAcknowledge> NotificationsAsync(object notificationId, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Anonymous2>> SettingsAllAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<FyiVT> SettingsAsync(Typecodes typecode, Body body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response> UnreadnumberAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<FileDetailsResponse> AccountsGETAsync(string? accountId = null, string? externalId = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<StatusResponse> AccountsPOSTAsync(ApplicationPayload body, CancellationToken cancellationToken = default(CancellationToken));

	Task<StatusResponse> AccountsPATCHAsync(AccountManagementRequestsPayload body, CancellationToken cancellationToken = default(CancellationToken));

	Task<StatusResponse> DocumentsAsync(ProcessDocumentsPayload body, CancellationToken cancellationToken = default(CancellationToken));

	Task<LoginMessageResponse> LoginMessagesAsync(LoginMessageRequest loginMessageRequest, CancellationToken cancellationToken = default(CancellationToken));

	Task<AccountStatusBulkResponse> StatusGETAsync(AccountStatusRequest accountStatusRequest, CancellationToken cancellationToken = default(CancellationToken));

	Task<AccountDetailsResponse> DetailsAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<Au10TixDetailResponse> KycAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<LoginMessageResponse> LoginMessages2Async(string accountId, string? type = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<AccountStatusResponse> StatusGET2Async(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<RegistrationTasksResponse> TasksAsync(string accountId, Type? type = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> BankInstructionsAsync(string client_id, Body2 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response2> QueryAsync(string client_id, Body3 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response3> ClientInstructionsAsync(string client_id, int clientInstructionId, CancellationToken cancellationToken = default(CancellationToken));

	Task<EchoResponse> HttpsAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<EchoResponse> SignedJwtAsync(object? body = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<GetBrokerListResponse> ComplexAssetTransferAsync(string client_id, string instructionType, CancellationToken cancellationToken = default(CancellationToken));

	Task<EnumerationResponse> EnumerationsAsync(EnumerationType type, string? currency = null, string? ibEntity = null, string? mdStatusNonPro = null, string? form_number = null, Language? language = null, string? accountId = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> ExternalAssetTransfersAsync(string client_id, Body4 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> ExternalCashTransfersAsync(string client_id, Body5 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response4> Query2Async(string client_id, Body6 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<FormFileResponse> FormsAsync(IEnumerable<int>? formNo = null, string? getDocs = null, string? fromDate = null, string? toDate = null, string? language = null, Projection? projection = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<BulkMultiStatusResponse> InstructionSetsAsync(string client_id, int instructionSetId, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> CancelAsync(string client_id, Body7 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> Query3Async(string client_id, Body8 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response5> InstructionsAsync(string client_id, int instructionId, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> InternalAssetTransfersAsync(string client_id, Body9 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> InternalCashTransfersAsync(string client_id, Body10 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<GetParticipatingListResponse> ParticipatingBanksAsync(string client_id, string type, CancellationToken cancellationToken = default(CancellationToken));

	Task<RequestDetailsResponse> RequestsAsync(RequestDetailsRequest requestDetails, CancellationToken cancellationToken = default(CancellationToken));

	Task<AmRequestStatusResponse> StatusGET3Async(int requestId, Type2 type, CancellationToken cancellationToken = default(CancellationToken));

	Task<CreateBrowserSessionResponse> SsoBrowserSessionsAsync(string authorization, object? body = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<CreateSessionResponse> SsoSessionsAsync(string authorization, object? body = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<GetStatementsResponse> StatementsAsync(string authorization, StmtRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<GetAvailableStmtDatesResponse> AvailableAsync(string authorization, string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<TaxFormResponse> TaxDocumentsAsync(string authorization, TaxFormRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<GetAvailableTaxFormsResponse> Available2Async(string authorization, string accountId, int year, CancellationToken cancellationToken = default(CancellationToken));

	Task<TradeConfirmationResponse> TradeConfirmationsAsync(string authorization, TradeConfirmationRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<GetAvailableTradeConfirmationDatesResponse> Available3Async(string authorization, string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<UserNameAvailableResponse> UsernamesAsync(string username, CancellationToken cancellationToken = default(CancellationToken));

	Task<HmdsHistoryResponse> HistoryAsync(string conid, string period, string bar, BarType? barType = null, string? startTime = null, string? direction = null, bool? outsideRth = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<HmdsScannerParams> ParamsAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<Response6> RunAsync(HmdsScannerRunRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<SetAccountResponse> AccountAsync(Body11 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AlertDetails> AlertGETAsync(string alertId, Type3 type, CancellationToken cancellationToken = default(CancellationToken));

	Task<SubAccounts> AccountsGET2Async(CancellationToken cancellationToken = default(CancellationToken));

	Task<AllocationGroups> GroupGETAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<Response7> GroupPUTAsync(Body12 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response8> GroupPOSTAsync(Body13 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response9> DeleteAsync(Body14 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AllocationGroup> SingleAsync(Body15 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Presets> PresetsGETAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<Response10> PresetsPOSTAsync(Presets body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AlertDetails> MtaAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<OrderStatus> StatusGET4Async(string orderId, CancellationToken cancellationToken = default(CancellationToken));

	Task<LiveOrdersResponse> OrdersGETAsync(Filters? filters = null, bool? force = null, string? accountId = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<PnlPartitionedResponse> PartitionedAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<DynAccountSearchResponse> SearchAsync(string searchPattern, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Anonymous3>> TradesAsync(string? days = null, string? accountId = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<AlertCreationResponse> AlertPOSTAsync(string accountId, AlertCreationRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AlertActivationResponse> ActivateAsync(string accountId, AlertActivationRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AlertDeletionResponse> AlertDELETEAsync(string accountId, string alertId, object body, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Alert>> AlertsAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<OrderSubmitSuccess> OrderPOSTAsync(string accountId, string orderId, SingleOrderSubmissionRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<OrderCancelSuccess> OrderDELETEAsync(string accountId, string orderId, CancellationToken cancellationToken = default(CancellationToken));

	Task<OrderSubmitSuccess> OrdersPOSTAsync(string accountId, IEnumerable<SingleOrderSubmissionRequest> body, CancellationToken cancellationToken = default(CancellationToken));

	Task<OrderPreview> WhatifAsync(string accountId, IEnumerable<SingleOrderSubmissionRequest> body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AccountSummaryResponse> SummaryAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<AvailableFundsResponse> Available_fundsAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<SummaryOfAccountBalancesResponse> BalancesAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<SummaryOfAccountMarginResponse> MarginsAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<SummaryMarketValueResponse> Market_valueAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<UserAccountsResponse> AccountsGET3Async(CancellationToken cancellationToken = default(CancellationToken));

	Task<BrokerageSessionStatus> InitAsync(BrokerageSessionInitRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<BrokerageSessionStatus> StatusPOSTAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<ContractRules> RulesAsync(Body16 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AlgosResponse> AlgosAsync(string conid, Algos? algos = null, string? addDescription = null, string? addParams = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<ContractInfo> InfoAsync(string conid, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response11> InfoAndRulesAsync(string conid, CancellationToken cancellationToken = default(CancellationToken));

	Task<IDictionary<string, ICollection<Anonymous4>>> PairsAsync(string currency, CancellationToken cancellationToken = default(CancellationToken));

	Task<SetAccountResponse> DynaccountAsync(Body17 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response12> ExchangerateAsync(string target, string source, CancellationToken cancellationToken = default(CancellationToken));

	Task<IserverHistoryResponse> History2Async(string conid, string period, string bar, string? exchange = null, string? startTime = null, bool? outsideRth = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<FyiVT> SnapshotAsync(string conids, MdFields? fields = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response13> UnsubscribeAsync(Body18 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response14> UnsubscribeallAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<string> NotificationAsync(Body19 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response15> SuppressAsync(Body20 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response16> ResetAsync(CancellationToken cancellationToken = default(CancellationToken));

	[Obsolete]
	Task<Response17> ReauthenticateAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<OrderSubmitSuccess> ReplyAsync(string replyId, Body21 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<IserverScannerParams> Params2Async(CancellationToken cancellationToken = default(CancellationToken));

	Task<IserverScannerRunResponse> Run2Async(IserverScannerRunRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<BondFiltersResponse> BondFiltersAsync(string symbol, string issueId, CancellationToken cancellationToken = default(CancellationToken));

	Task<SecDefInfoResponse> Info2Async(string? conid = null, object? sectype = null, object? month = null, object? exchange = null, object? strike = null, Right? right = null, string? issuerId = null, object? filters = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Anonymous5>> SearchAllGETAsync(string? symbol = null, SecType? secType = null, bool? name = null, bool? more = null, bool? fund = null, string? fundFamilyConidEx = null, bool? pattern = null, string? referrer = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Anonymous5>> SearchAllPOSTAsync(Body22 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response18> StrikesAsync(string conid, string sectype, string month, string? exchange = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<SingleWatchlist> WatchlistGETAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response19> WatchlistPOSTAsync(Body23 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<WatchlistDeleteSuccess> WatchlistDELETEAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

	Task<WatchlistsResponse> WatchlistsAsync(SC? sC = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response20> LogoutAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<RegsnapshotData> RegsnapshotAsync(string conid, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response21> Access_tokenAsync(string? authorization = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response22> Live_session_tokenAsync(string? authorization = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response23> Request_tokenAsync(string? authorization = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<TokenResponse> GenerateTokenAsync(TokenRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<DetailedContractInformation> AllperiodsAsync(Body24 body, string? param0 = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<PerformanceResponse> PerformanceAsync(Body25 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<TransactionsResponse> TransactionsAsync(Body26 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<AccountAttributes>> AccountsAllAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<IDictionary<string, IndividualPosition>> PositionsAsync(string conid, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<AccountAttributes>> SubaccountsAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<PortfolioAllocations> AllocationAsync(string accountId, object? model = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<IDictionary<string, Anonymous6>> LedgerAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<AccountAttributes> MetaAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response24> InvalidateAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<IndividualPosition>> PositionsAllAsync(string accountId, string? pageId = null, object? model = null, object? sort = null, object? direction = null, bool? waitForSecDef = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<PortfolioSummary> Summary2Async(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<IndividualPosition>> PositionAsync(string accountId, string conid, CancellationToken cancellationToken = default(CancellationToken));

	Task<SsoValidateResponse> ValidateAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<SuccessfulTickleResponse> TickleAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Anonymous7>> AllConidsAsync(string exchange, object? assetClass = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Features> FuturesAsync(string symbols, object? exchange = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<TrsrvSecDefResponse> SecdefAsync(string conids, object? criteria = null, object? bondp = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Anonymous8>> ScheduleAsync(AssetClass assetClass, string symbol, string? exchange = null, string? exchangeFilter = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<IDictionary<string, ICollection<Anonymous9>>> StocksAsync(string symbols, CancellationToken cancellationToken = default(CancellationToken));

	System.Threading.Tasks.Task WsAsync(Connection connection, Upgrade upgrade, string api, string oauth_token, CancellationToken cancellationToken = default(CancellationToken));
}
