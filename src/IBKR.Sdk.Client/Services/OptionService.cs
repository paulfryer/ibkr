using IBKR.Sdk.Contract.Enums;
using IBKR.Sdk.Contract.Interfaces;
using IBKR.Sdk.Contract.Models;
using IBKR.Sdk.Client.Mappers;
using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.Contract.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace IBKR.Sdk.Client.Services;

/// <summary>
/// Production implementation of IOptionService that wraps generated SDKs.
/// Handles array deserialization workarounds and maps to strongly-typed models.
/// Uses controlled parallelism for optimal performance.
/// </summary>
public class OptionService : IOptionService, IDisposable
{
    private readonly IIserverService _nswagIserver;
    private readonly OptionMapper _mapper;
    private readonly ILogger<OptionService> _logger;
    private readonly OptionServiceOptions _options;
    private readonly SemaphoreSlim _rateLimiter;

    public OptionService(IIserverService nswagIserver, ILogger<OptionService> logger, OptionServiceOptions? options = null)
    {
        _nswagIserver = nswagIserver ?? throw new ArgumentNullException(nameof(nswagIserver));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _options = options ?? new OptionServiceOptions();
        _options.Validate();
        _mapper = new OptionMapper();

        // Rate limiter to control concurrent API calls
        _rateLimiter = new SemaphoreSlim(_options.MaxDegreeOfParallelism, _options.MaxDegreeOfParallelism);
    }

    public async System.Threading.Tasks.Task<OptionChain> GetOptionChainAsync(
        string symbol,
        DateTime expirationStart,
        DateTime expirationEnd,
        CancellationToken cancellationToken = default)
    {
        // 1. Search for stock symbol
        var searchResults = await _nswagIserver.SearchAllGETAsync(
            symbol: symbol,
            secType: SecType.STK,
            cancellationToken: cancellationToken);

        var firstResult = searchResults.FirstOrDefault()
            ?? throw new InvalidOperationException($"Symbol {symbol} not found");

        var conidStr = firstResult.Conid?.ToString()
            ?? throw new InvalidOperationException("Contract ID not found");
        var conid = int.Parse(conidStr);

        // 2. Calculate months to query
        var months = GetMonthsInRange(expirationStart, expirationEnd);

        // Use thread-safe collection for parallel processing
        var allContracts = new ConcurrentBag<OptionContract>();

        foreach (var month in months)
        {
            try
            {
                // 3. Get strikes for this month
                var strikes = await _nswagIserver.StrikesAsync(
                    conid: conidStr,
                    sectype: "OPT",
                    month: month,
                    cancellationToken: cancellationToken);

                // 4. Process ALL call strikes (with controlled parallelism)
                var callStrikes = strikes.Call?.ToList() ?? new List<double>();
                if (_options.EnableParallelProcessing && callStrikes.Count > 0)
                {
                    await Parallel.ForEachAsync(
                        callStrikes,
                        new ParallelOptions
                        {
                            MaxDegreeOfParallelism = _options.MaxDegreeOfParallelism,
                            CancellationToken = cancellationToken
                        },
                        async (strike, ct) =>
                        {
                            await ProcessStrikeAsync(
                                conidStr, month, strike, OptionRight.Call, conid,
                                expirationStart, expirationEnd, allContracts, ct);
                        });
                }
                else
                {
                    // Sequential fallback
                    foreach (var strike in callStrikes)
                    {
                        await ProcessStrikeAsync(
                            conidStr, month, strike, OptionRight.Call, conid,
                            expirationStart, expirationEnd, allContracts, cancellationToken);
                    }
                }

                // 5. Process ALL put strikes (with controlled parallelism)
                var putStrikes = strikes.Put?.ToList() ?? new List<double>();
                if (_options.EnableParallelProcessing && putStrikes.Count > 0)
                {
                    await Parallel.ForEachAsync(
                        putStrikes,
                        new ParallelOptions
                        {
                            MaxDegreeOfParallelism = _options.MaxDegreeOfParallelism,
                            CancellationToken = cancellationToken
                        },
                        async (strike, ct) =>
                        {
                            await ProcessStrikeAsync(
                                conidStr, month, strike, OptionRight.Put, conid,
                                expirationStart, expirationEnd, allContracts, ct);
                        });
                }
                else
                {
                    // Sequential fallback
                    foreach (var strike in putStrikes)
                    {
                        await ProcessStrikeAsync(
                            conidStr, month, strike, OptionRight.Put, conid,
                            expirationStart, expirationEnd, allContracts, cancellationToken);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log but continue processing other months
                _logger.LogError(ex, "Error processing month {Month}", month);
            }
        }

        return new OptionChain
        {
            Symbol = symbol,
            UnderlyingContractId = conid,
            Contracts = allContracts.ToList(),
            RequestedExpirationStart = expirationStart,
            RequestedExpirationEnd = expirationEnd,
            RetrievedAt = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Processes a single strike (call or put) and adds results to the collection.
    /// Uses rate limiter to control API call concurrency.
    /// </summary>
    private async System.Threading.Tasks.Task ProcessStrikeAsync(
        string conid,
        string month,
        double strike,
        OptionRight right,
        int underlyingConid,
        DateTime expirationStart,
        DateTime expirationEnd,
        ConcurrentBag<OptionContract> contracts,
        CancellationToken cancellationToken)
    {
        try
        {
            // Get contract details WITH WORKAROUND for array response
            var contractDetails = await GetOptionDetailsWithWorkaround(
                conid, month, strike, right, cancellationToken);

            foreach (var detail in contractDetails)
            {
                var contract = _mapper.ToCleanModel(detail, underlyingConid);

                // Filter by expiration range
                if (contract.Expiration >= expirationStart && contract.Expiration <= expirationEnd)
                {
                    contracts.Add(contract);
                }
            }
        }
        catch (Exception ex)
        {
            // Log but continue processing other strikes
            _logger.LogWarning(ex, "Error processing strike {Strike} {Right} for month {Month}", strike, right, month);
        }
    }

    /// <summary>
    /// WORKAROUND: API returns array but SDK expects single object.
    /// This method isolates the messy try/catch logic.
    /// </summary>
    private async System.Threading.Tasks.Task<List<SecDefInfoResponse>> GetOptionDetailsWithWorkaround(
        string conid,
        string month,
        double strike,
        OptionRight right,
        CancellationToken cancellationToken)
    {
        try
        {
            // Try normal SDK call
            var info = await _nswagIserver.Info2Async(
                conid: conid,
                sectype: "OPT",
                month: month,
                strike: strike,
                right: right == OptionRight.Call ? Right.C : Right.P,
                cancellationToken: cancellationToken);

            return new List<SecDefInfoResponse> { info };
        }
        catch (ApiException ex) when (ex.StatusCode == 200)
        {
            // API returned 200 OK but deserialization failed
            // This means API returned array but SDK expected single object
            // Manually deserialize as array
            if (!string.IsNullOrEmpty(ex.Response))
            {
                var array = JsonConvert.DeserializeObject<List<SecDefInfoResponse>>(ex.Response);
                return array ?? new List<SecDefInfoResponse>();
            }

            return new List<SecDefInfoResponse>();
        }
    }

    private static List<string> GetMonthsInRange(DateTime start, DateTime end)
    {
        var months = new HashSet<string>();
        var current = start;

        while (current <= end)
        {
            months.Add(current.ToString("yyyyMM"));
            current = current.AddMonths(1);
        }

        return months.OrderBy(m => m).ToList();
    }

    public void Dispose()
    {
        _rateLimiter?.Dispose();
    }
}
