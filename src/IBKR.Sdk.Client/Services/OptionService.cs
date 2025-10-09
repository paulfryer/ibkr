using IBKR.Sdk.Contract.Enums;
using IBKR.Sdk.Contract.Interfaces;
using IBKR.Sdk.Contract.Models;
using IBKR.Sdk.Client.Mappers;
using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.Contract.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IBKR.Sdk.Client.Services;

/// <summary>
/// Clean implementation of IOptionService that wraps messy generated SDKs.
/// Handles array deserialization workarounds and maps to clean models.
/// </summary>
public class OptionService : IOptionService
{
    private readonly IIserverService _nswagIserver;
    private readonly OptionMapper _mapper;
    private readonly ILogger<OptionService> _logger;

    public OptionService(IIserverService nswagIserver, ILogger<OptionService> logger)
    {
        _nswagIserver = nswagIserver ?? throw new ArgumentNullException(nameof(nswagIserver));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = new OptionMapper();
    }

    public async Task<OptionChain> GetOptionChainAsync(
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

        var allContracts = new List<OptionContract>();

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

                // 4. Sample strikes (take first 2 for demo - in production, process all or filter)
                var sampleStrikes = strikes.Call?.Take(2).ToList() ?? new List<double>();

                foreach (var strike in sampleStrikes)
                {
                    // 5. Get contract details WITH WORKAROUND for array response
                    var contractDetails = await GetOptionDetailsWithWorkaround(
                        conidStr, month, strike, OptionRight.Call, cancellationToken);

                    foreach (var detail in contractDetails)
                    {
                        var cleanContract = _mapper.ToCleanModel(detail, conid);

                        // Filter by expiration range
                        if (cleanContract.Expiration >= expirationStart && cleanContract.Expiration <= expirationEnd)
                        {
                            allContracts.Add(cleanContract);
                        }
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
            Contracts = allContracts,
            RequestedExpirationStart = expirationStart,
            RequestedExpirationEnd = expirationEnd,
            RetrievedAt = DateTime.UtcNow
        };
    }

    /// <summary>
    /// WORKAROUND: API returns array but SDK expects single object.
    /// This method isolates the messy try/catch logic.
    /// </summary>
    private async Task<List<SecDefInfoResponse>> GetOptionDetailsWithWorkaround(
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
}
