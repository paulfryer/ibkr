using System.CodeDom.Compiler;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
///     Iserver service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IIserverService
{
    Task<SetAccountResponse> AccountAsync(Body11 body, CancellationToken cancellationToken = default);

    Task<SubAccounts> AccountsGET2Async(CancellationToken cancellationToken = default);

    Task<UserAccountsResponse> AccountsGET3Async(CancellationToken cancellationToken = default);

    Task<AlertActivationResponse> ActivateAsync(string accountId, AlertActivationRequest body,
        CancellationToken cancellationToken = default);

    Task<AlertDeletionResponse> AlertDELETEAsync(string accountId, string alertId, object body,
        CancellationToken cancellationToken = default);

    Task<AlertDetails> AlertGETAsync(string alertId, Type3 type, CancellationToken cancellationToken = default);

    Task<AlertCreationResponse> AlertPOSTAsync(string accountId, AlertCreationRequest body,
        CancellationToken cancellationToken = default);

    Task<ICollection<Alert>> AlertsAsync(string accountId, CancellationToken cancellationToken = default);

    Task<AlgosResponse> AlgosAsync(string conid, Algos? algos = null, string? addDescription = null,
        string? addParams = null, CancellationToken cancellationToken = default);

    Task<AvailableFundsResponse> Available_fundsAsync(string accountId, CancellationToken cancellationToken = default);

    Task<SummaryOfAccountBalancesResponse> BalancesAsync(string accountId,
        CancellationToken cancellationToken = default);

    Task<BondFiltersResponse> BondFiltersAsync(string symbol, string issueId,
        CancellationToken cancellationToken = default);

    Task<Response9> DeleteAsync(Body14 body, CancellationToken cancellationToken = default);

    Task<SetAccountResponse> DynaccountAsync(Body17 body, CancellationToken cancellationToken = default);

    Task<Response12> ExchangerateAsync(string target, string source, CancellationToken cancellationToken = default);

    Task<AllocationGroups> GroupGETAsync(CancellationToken cancellationToken = default);

    Task<Response8> GroupPOSTAsync(Body13 body, CancellationToken cancellationToken = default);

    Task<Response7> GroupPUTAsync(Body12 body, CancellationToken cancellationToken = default);

    Task<IserverHistoryResponse> History2Async(string conid, string period, string bar, string? exchange = null,
        string? startTime = null, bool? outsideRth = null, CancellationToken cancellationToken = default);

    Task<SecDefInfoResponse> Info2Async(string? conid = null, object? sectype = null, object? month = null,
        object? exchange = null, object? strike = null, Right? right = null, string? issuerId = null,
        object? filters = null, CancellationToken cancellationToken = default);

    Task<Response11> InfoAndRulesAsync(string conid, CancellationToken cancellationToken = default);

    Task<ContractInfo> InfoAsync(string conid, CancellationToken cancellationToken = default);

    Task<BrokerageSessionStatus> InitAsync(BrokerageSessionInitRequest body,
        CancellationToken cancellationToken = default);

    Task<SummaryOfAccountMarginResponse> MarginsAsync(string accountId, CancellationToken cancellationToken = default);

    Task<SummaryMarketValueResponse> Market_valueAsync(string accountId, CancellationToken cancellationToken = default);

    Task<AlertDetails> MtaAsync(CancellationToken cancellationToken = default);

    Task<string> NotificationAsync(Body19 body, CancellationToken cancellationToken = default);

    Task<OrderCancelSuccess> OrderDELETEAsync(string accountId, string orderId,
        CancellationToken cancellationToken = default);

    Task<OrderSubmitSuccess> OrderPOSTAsync(string accountId, string orderId, SingleOrderSubmissionRequest body,
        CancellationToken cancellationToken = default);

    Task<LiveOrdersResponse> OrdersGETAsync(Filters? filters = null, bool? force = null, string? accountId = null,
        CancellationToken cancellationToken = default);

    Task<OrderSubmitSuccess> OrdersPOSTAsync(string accountId, IEnumerable<SingleOrderSubmissionRequest> body,
        CancellationToken cancellationToken = default);

    Task<IDictionary<string, ICollection<Anonymous4>>> PairsAsync(string currency,
        CancellationToken cancellationToken = default);

    Task<IserverScannerParams> Params2Async(CancellationToken cancellationToken = default);

    Task<PnlPartitionedResponse> PartitionedAsync(CancellationToken cancellationToken = default);

    Task<Presets> PresetsGETAsync(CancellationToken cancellationToken = default);

    Task<Response10> PresetsPOSTAsync(Presets body, CancellationToken cancellationToken = default);

    Task<Response17> ReauthenticateAsync(CancellationToken cancellationToken = default);

    Task<OrderSubmitSuccess> ReplyAsync(string replyId, Body21 body, CancellationToken cancellationToken = default);

    Task<Response16> ResetAsync(CancellationToken cancellationToken = default);

    Task<ContractRules> RulesAsync(Body16 body, CancellationToken cancellationToken = default);

    Task<IserverScannerRunResponse> Run2Async(IserverScannerRunRequest body,
        CancellationToken cancellationToken = default);

    Task<ICollection<Anonymous5>> SearchAllGETAsync(string? symbol = null, SecType? secType = null, bool? name = null,
        bool? more = null, bool? fund = null, string? fundFamilyConidEx = null, bool? pattern = null,
        string? referrer = null, CancellationToken cancellationToken = default);

    Task<ICollection<Anonymous5>> SearchAllPOSTAsync(Body22 body, CancellationToken cancellationToken = default);

    Task<DynAccountSearchResponse> SearchAsync(string searchPattern, CancellationToken cancellationToken = default);

    Task<AllocationGroup> SingleAsync(Body15 body, CancellationToken cancellationToken = default);

    Task<FyiVT> SnapshotAsync(string conids, MdFields? fields = null, CancellationToken cancellationToken = default);

    Task<OrderStatus> StatusGET4Async(string orderId, CancellationToken cancellationToken = default);

    Task<BrokerageSessionStatus> StatusPOSTAsync(CancellationToken cancellationToken = default);

    Task<Response18> StrikesAsync(string conid, string sectype, string month, string? exchange = null,
        CancellationToken cancellationToken = default);

    Task<AccountSummaryResponse> SummaryAsync(string accountId, CancellationToken cancellationToken = default);

    Task<Response15> SuppressAsync(Body20 body, CancellationToken cancellationToken = default);

    Task<ICollection<Anonymous3>> TradesAsync(string? days = null, string? accountId = null,
        CancellationToken cancellationToken = default);

    Task<Response14> UnsubscribeallAsync(CancellationToken cancellationToken = default);

    Task<Response13> UnsubscribeAsync(Body18 body, CancellationToken cancellationToken = default);

    Task<WatchlistDeleteSuccess> WatchlistDELETEAsync(string id, CancellationToken cancellationToken = default);

    Task<SingleWatchlist> WatchlistGETAsync(string id, CancellationToken cancellationToken = default);

    Task<Response19> WatchlistPOSTAsync(Body23 body, CancellationToken cancellationToken = default);

    Task<WatchlistsResponse> WatchlistsAsync(SC? sC = null, CancellationToken cancellationToken = default);

    Task<OrderPreview> WhatifAsync(string accountId, IEnumerable<SingleOrderSubmissionRequest> body,
        CancellationToken cancellationToken = default);
}