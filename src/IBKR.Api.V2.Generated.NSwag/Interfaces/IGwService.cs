using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IBKR.Api.V2.Generated.NSwag.Models;

namespace IBKR.Api.V2.Generated.NSwag.Interfaces;

/// <summary>
/// Gw service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IGwService
{
	Task<FileDetailsResponse> AccountsGETAsync(string? accountId = null, string? externalId = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<StatusResponse> AccountsPATCHAsync(AccountManagementRequestsPayload body, CancellationToken cancellationToken = default(CancellationToken));

	Task<StatusResponse> AccountsPOSTAsync(ApplicationPayload body, CancellationToken cancellationToken = default(CancellationToken));

	Task<GetAvailableTaxFormsResponse> Available2Async(string authorization, string accountId, int year, CancellationToken cancellationToken = default(CancellationToken));

	Task<GetAvailableTradeConfirmationDatesResponse> Available3Async(string authorization, string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<GetAvailableStmtDatesResponse> AvailableAsync(string authorization, string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> BankInstructionsAsync(string client_id, Body2 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> CancelAsync(string client_id, Body7 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response3> ClientInstructionsAsync(string client_id, int clientInstructionId, CancellationToken cancellationToken = default(CancellationToken));

	Task<GetBrokerListResponse> ComplexAssetTransferAsync(string client_id, string instructionType, CancellationToken cancellationToken = default(CancellationToken));

	Task<AccountDetailsResponse> DetailsAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<StatusResponse> DocumentsAsync(ProcessDocumentsPayload body, CancellationToken cancellationToken = default(CancellationToken));

	Task<EnumerationResponse> EnumerationsAsync(EnumerationType type, string? currency = null, string? ibEntity = null, string? mdStatusNonPro = null, string? form_number = null, Language? language = null, string? accountId = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> ExternalAssetTransfersAsync(string client_id, Body4 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> ExternalCashTransfersAsync(string client_id, Body5 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<FormFileResponse> FormsAsync(IEnumerable<int>? formNo = null, string? getDocs = null, string? fromDate = null, string? toDate = null, string? language = null, Projection? projection = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<EchoResponse> HttpsAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<Response5> InstructionsAsync(string client_id, int instructionId, CancellationToken cancellationToken = default(CancellationToken));

	Task<BulkMultiStatusResponse> InstructionSetsAsync(string client_id, int instructionSetId, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> InternalAssetTransfersAsync(string client_id, Body9 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> InternalCashTransfersAsync(string client_id, Body10 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Au10TixDetailResponse> KycAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<LoginMessageResponse> LoginMessages2Async(string accountId, string? type = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<LoginMessageResponse> LoginMessagesAsync(LoginMessageRequest loginMessageRequest, CancellationToken cancellationToken = default(CancellationToken));

	Task<GetParticipatingListResponse> ParticipatingBanksAsync(string client_id, string type, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response4> Query2Async(string client_id, Body6 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AsynchronousInstructionResponse> Query3Async(string client_id, Body8 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response2> QueryAsync(string client_id, Body3 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<RequestDetailsResponse> RequestsAsync(RequestDetailsRequest requestDetails, CancellationToken cancellationToken = default(CancellationToken));

	Task<EchoResponse> SignedJwtAsync(object? body = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<CreateBrowserSessionResponse> SsoBrowserSessionsAsync(string authorization, object? body = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<CreateSessionResponse> SsoSessionsAsync(string authorization, object? body = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<GetStatementsResponse> StatementsAsync(string authorization, StmtRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AccountStatusResponse> StatusGET2Async(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<AmRequestStatusResponse> StatusGET3Async(int requestId, Type2 type, CancellationToken cancellationToken = default(CancellationToken));

	Task<AccountStatusBulkResponse> StatusGETAsync(AccountStatusRequest accountStatusRequest, CancellationToken cancellationToken = default(CancellationToken));

	Task<RegistrationTasksResponse> TasksAsync(string accountId, Models.Type? type = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<TaxFormResponse> TaxDocumentsAsync(string authorization, TaxFormRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<TradeConfirmationResponse> TradeConfirmationsAsync(string authorization, TradeConfirmationRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<UserNameAvailableResponse> UsernamesAsync(string username, CancellationToken cancellationToken = default(CancellationToken));

}
