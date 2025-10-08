using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.Contract.Models;
using Task = System.Threading.Tasks.Task;

namespace IBKR.Api.NSwag.MockClient.Services;

/// <summary>
/// Minimal mock implementation of IIserverService for testing.
/// Only implements the 4 methods actually used in tests.
/// All other methods throw NotImplementedException.
/// </summary>
public class MockIserverService : IIserverService
{
    #region Implemented Methods (Used in Tests)

    public async System.Threading.Tasks.Task<ICollection<Anonymous5>> SearchAllGETAsync(
        string? symbol = null,
        SecType? secType = null,
        bool? name = null,
        bool? more = null,
        bool? fund = null,
        string? fundFamilyConidEx = null,
        bool? pattern = null,
        string? referrer = null,
        CancellationToken cancellationToken = default)
    {
        // Return mock search results
        return await System.Threading.Tasks.Task.FromResult<ICollection<Anonymous5>>(new List<Anonymous5>
        {
            new Anonymous5
            {
                Conid = "265598",
                Symbol = "AAPL",
                CompanyName = "Apple Inc.",
                CompanyHeader = "AAPL - NASDAQ",
                Description = "NASDAQ"
            }
        });
    }

    public async System.Threading.Tasks.Task<ICollection<FyiVT>> SnapshotAsync(
        string conids,
        MdFields? fields = null,
        CancellationToken cancellationToken = default)
    {
        // Return mock market data snapshot (as array)
        return await System.Threading.Tasks.Task.FromResult<ICollection<FyiVT>>(new List<FyiVT>
        {
            new FyiVT
            {
                AdditionalProperties = new Dictionary<string, object>
                {
                    { "31", "150.25" },  // Last Price
                    { "84", "150.20" },  // Bid
                    { "86", "150.30" },  // Ask
                    { "85", "100" },     // Ask Size
                    { "88", "200" }      // Bid Size
                }
            }
        });
    }

    public async System.Threading.Tasks.Task<Response18> StrikesAsync(
        string conid,
        string sectype,
        string month,
        string? exchange = null,
        CancellationToken cancellationToken = default)
    {
        // Return mock option strikes
        return await System.Threading.Tasks.Task.FromResult(new Response18
        {
            Call = new List<double> { 145, 150, 155, 160 },
            Put = new List<double> { 145, 150, 155, 160 }
        });
    }

    public async System.Threading.Tasks.Task<SecDefInfoResponse> Info2Async(
        string? conid = null,
        object? sectype = null,
        object? month = null,
        object? exchange = null,
        object? strike = null,
        Right? right = null,
        string? issuerId = null,
        object? filters = null,
        CancellationToken cancellationToken = default)
    {
        // Determine strike and right based on parameters
        var strikeValue = strike != null ? double.Parse(strike.ToString()!) : 150.0;
        var isPut = right == Right.P;

        return await System.Threading.Tasks.Task.FromResult(new SecDefInfoResponse
        {
            Conid = 12345,
            Ticker = "AAPL",
            Right = isPut ? SecDefInfoResponseRight.P : SecDefInfoResponseRight.C,
            Strike = strikeValue,
            MaturityDate = "20250117"
        });
    }

    #endregion

    #region Not Implemented Methods (Not Used in Tests)

    public Task<SetAccountResponse> AccountAsync(Body11 body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<SubAccounts> AccountsGET2Async(CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<UserAccountsResponse> AccountsGET3Async(CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<AlertActivationResponse> ActivateAsync(string accountId, AlertActivationRequest body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<AlertDeletionResponse> AlertDELETEAsync(string accountId, string alertId, object body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<AlertDetails> AlertGETAsync(string alertId, Type3 type, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<AlertCreationResponse> AlertPOSTAsync(string accountId, AlertCreationRequest body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<ICollection<Alert>> AlertsAsync(string accountId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<AlgosResponse> AlgosAsync(string conid, Algos? algos = null, string? addDescription = null, string? addParams = null, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<AvailableFundsResponse> Available_fundsAsync(string accountId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<SummaryOfAccountBalancesResponse> BalancesAsync(string accountId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<BondFiltersResponse> BondFiltersAsync(string symbol, string issueId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<Response9> DeleteAsync(Body14 body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<SetAccountResponse> DynaccountAsync(Body17 body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<Response12> ExchangerateAsync(string target, string source, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<AllocationGroups> GroupGETAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<Response8> GroupPOSTAsync(Body13 body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<Response7> GroupPUTAsync(Body12 body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<IserverHistoryResponse> History2Async(string conid, string period, string bar, string? exchange = null, string? startTime = null, bool? outsideRth = null, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<Response11> InfoAndRulesAsync(string conid, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<ContractInfo> InfoAsync(string conid, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<BrokerageSessionStatus> InitAsync(BrokerageSessionInitRequest body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<SummaryOfAccountMarginResponse> MarginsAsync(string accountId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<SummaryMarketValueResponse> Market_valueAsync(string accountId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<AlertDetails> MtaAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<string> NotificationAsync(Body19 body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<OrderCancelSuccess> OrderDELETEAsync(string accountId, string orderId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<OrderSubmitSuccess> OrderPOSTAsync(string accountId, string orderId, SingleOrderSubmissionRequest body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<LiveOrdersResponse> OrdersGETAsync(Filters? filters = null, bool? force = null, string? accountId = null, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<OrderSubmitSuccess> OrdersPOSTAsync(string accountId, IEnumerable<SingleOrderSubmissionRequest> body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<IDictionary<string, ICollection<Anonymous4>>> PairsAsync(string currency, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<IserverScannerParams> Params2Async(CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<PnlPartitionedResponse> PartitionedAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<Presets> PresetsGETAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<Response10> PresetsPOSTAsync(Presets body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<Response17> ReauthenticateAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<OrderSubmitSuccess> ReplyAsync(string replyId, Body21 body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<Response16> ResetAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<ContractRules> RulesAsync(Body16 body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<IserverScannerRunResponse> Run2Async(IserverScannerRunRequest body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<ICollection<Anonymous5>> SearchAllPOSTAsync(Body22 body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<DynAccountSearchResponse> SearchAsync(string searchPattern, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<AllocationGroup> SingleAsync(Body15 body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<OrderStatus> StatusGET4Async(string orderId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<BrokerageSessionStatus> StatusPOSTAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<AccountSummaryResponse> SummaryAsync(string accountId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<Response15> SuppressAsync(Body20 body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<ICollection<Anonymous3>> TradesAsync(string? days = null, string? accountId = null, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<Response14> UnsubscribeallAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<Response13> UnsubscribeAsync(Body18 body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<WatchlistDeleteSuccess> WatchlistDELETEAsync(string id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<SingleWatchlist> WatchlistGETAsync(string id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<Response19> WatchlistPOSTAsync(Body23 body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<WatchlistsResponse> WatchlistsAsync(SC? sC = null, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    public Task<OrderPreview> WhatifAsync(string accountId, IEnumerable<SingleOrderSubmissionRequest> body, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("This method is not implemented in the mock.");

    #endregion
}
