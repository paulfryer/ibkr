using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IBKR.Api.V2.Generated.NSwag.Models;

namespace IBKR.Api.V2.Generated.NSwag.Interfaces;

/// <summary>
/// Iserver service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IIserverService
{
	Task<SetAccountResponse> AccountAsync(Body11 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<SubAccounts> AccountsGET2Async(CancellationToken cancellationToken = default(CancellationToken));

	Task<UserAccountsResponse> AccountsGET3Async(CancellationToken cancellationToken = default(CancellationToken));

	Task<AlertActivationResponse> ActivateAsync(string accountId, AlertActivationRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AlertDeletionResponse> AlertDELETEAsync(string accountId, string alertId, object body, CancellationToken cancellationToken = default(CancellationToken));

	Task<AlertDetails> AlertGETAsync(string alertId, Type3 type, CancellationToken cancellationToken = default(CancellationToken));

	Task<AlertCreationResponse> AlertPOSTAsync(string accountId, AlertCreationRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Alert>> AlertsAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<AlgosResponse> AlgosAsync(string conid, Algos? algos = null, string? addDescription = null, string? addParams = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<AvailableFundsResponse> Available_fundsAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<SummaryOfAccountBalancesResponse> BalancesAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<BondFiltersResponse> BondFiltersAsync(string symbol, string issueId, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response9> DeleteAsync(Body14 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<SetAccountResponse> DynaccountAsync(Body17 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response12> ExchangerateAsync(string target, string source, CancellationToken cancellationToken = default(CancellationToken));

	Task<AllocationGroups> GroupGETAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<Response8> GroupPOSTAsync(Body13 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response7> GroupPUTAsync(Body12 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<IserverHistoryResponse> History2Async(string conid, string period, string bar, string? exchange = null, string? startTime = null, bool? outsideRth = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<SecDefInfoResponse> Info2Async(string? conid = null, object? sectype = null, object? month = null, object? exchange = null, object? strike = null, Right? right = null, string? issuerId = null, object? filters = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response11> InfoAndRulesAsync(string conid, CancellationToken cancellationToken = default(CancellationToken));

	Task<ContractInfo> InfoAsync(string conid, CancellationToken cancellationToken = default(CancellationToken));

	Task<BrokerageSessionStatus> InitAsync(BrokerageSessionInitRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<SummaryOfAccountMarginResponse> MarginsAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<SummaryMarketValueResponse> Market_valueAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<AlertDetails> MtaAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<string> NotificationAsync(Body19 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<OrderCancelSuccess> OrderDELETEAsync(string accountId, string orderId, CancellationToken cancellationToken = default(CancellationToken));

	Task<OrderSubmitSuccess> OrderPOSTAsync(string accountId, string orderId, SingleOrderSubmissionRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<LiveOrdersResponse> OrdersGETAsync(Filters? filters = null, bool? force = null, string? accountId = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<OrderSubmitSuccess> OrdersPOSTAsync(string accountId, IEnumerable<SingleOrderSubmissionRequest> body, CancellationToken cancellationToken = default(CancellationToken));

	Task<IDictionary<string, ICollection<Anonymous4>>> PairsAsync(string currency, CancellationToken cancellationToken = default(CancellationToken));

	Task<IserverScannerParams> Params2Async(CancellationToken cancellationToken = default(CancellationToken));

	Task<PnlPartitionedResponse> PartitionedAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<Presets> PresetsGETAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<Response10> PresetsPOSTAsync(Presets body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response17> ReauthenticateAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<OrderSubmitSuccess> ReplyAsync(string replyId, Body21 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response16> ResetAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<ContractRules> RulesAsync(Body16 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<IserverScannerRunResponse> Run2Async(IserverScannerRunRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Anonymous5>> SearchAllGETAsync(string? symbol = null, SecType? secType = null, bool? name = null, bool? more = null, bool? fund = null, string? fundFamilyConidEx = null, bool? pattern = null, string? referrer = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Anonymous5>> SearchAllPOSTAsync(Body22 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<DynAccountSearchResponse> SearchAsync(string searchPattern, CancellationToken cancellationToken = default(CancellationToken));

	Task<AllocationGroup> SingleAsync(Body15 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<FyiVT> SnapshotAsync(string conids, MdFields? fields = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<OrderStatus> StatusGET4Async(string orderId, CancellationToken cancellationToken = default(CancellationToken));

	Task<BrokerageSessionStatus> StatusPOSTAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<Response18> StrikesAsync(string conid, string sectype, string month, string? exchange = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<AccountSummaryResponse> SummaryAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response15> SuppressAsync(Body20 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Anonymous3>> TradesAsync(string? days = null, string? accountId = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response14> UnsubscribeallAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<Response13> UnsubscribeAsync(Body18 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<WatchlistDeleteSuccess> WatchlistDELETEAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

	Task<SingleWatchlist> WatchlistGETAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response19> WatchlistPOSTAsync(Body23 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<WatchlistsResponse> WatchlistsAsync(SC? sC = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<OrderPreview> WhatifAsync(string accountId, IEnumerable<SingleOrderSubmissionRequest> body, CancellationToken cancellationToken = default(CancellationToken));

}
