using IBKR.Api.Client.Models.Instruments;
using IBKR.Api.Client.Services;

namespace IBKR.Api.Client.Mock.Services;

/// <summary>
/// In-memory mock implementation of IInstrumentApiService.
/// This is a REAL implementation (not Moq) that stores data in memory.
/// Can be used for testing or development without HTTP dependencies.
/// </summary>
public class MockInstrumentApiService : IInstrumentApiService
{
    private readonly Dictionary<string, Dictionary<string, List<StockResult>>> _stockData;
    private readonly Dictionary<string, Dictionary<string, List<SecurityInfo>>> _futuresData;
    private readonly Dictionary<string, List<SecurityDefinition>> _securityDefinitions;
    private readonly Dictionary<int, List<SecurityInfo>> _securityInfo;
    private readonly Dictionary<string, StrikeData> _strikes; // Key: "conid:exchange:secType:month"
    private readonly Dictionary<int, OptionChain> _optionChains;
    private readonly Dictionary<string, List<OptionContract>> _optionContracts; // Key: "conid:exp:strike:right"

    public MockInstrumentApiService()
    {
        _stockData = new Dictionary<string, Dictionary<string, List<StockResult>>>();
        _futuresData = new Dictionary<string, Dictionary<string, List<SecurityInfo>>>();
        _securityDefinitions = new Dictionary<string, List<SecurityDefinition>>();
        _securityInfo = new Dictionary<int, List<SecurityInfo>>();
        _strikes = new Dictionary<string, StrikeData>();
        _optionChains = new Dictionary<int, OptionChain>();
        _optionContracts = new Dictionary<string, List<OptionContract>>();
    }

    #region Setup Methods (for configuring mock data)

    /// <summary>
    /// Adds stock search data for a symbol.
    /// </summary>
    public void AddStockData(string symbols, Dictionary<string, List<StockResult>> results)
    {
        _stockData[symbols] = results;
    }

    /// <summary>
    /// Adds futures search data for a symbol.
    /// </summary>
    public void AddFuturesData(string symbols, Dictionary<string, List<SecurityInfo>> results)
    {
        _futuresData[symbols] = results;
    }

    /// <summary>
    /// Adds security definition search results.
    /// </summary>
    public void AddSecurityDefinitions(string symbol, List<SecurityDefinition> definitions)
    {
        _securityDefinitions[symbol] = definitions;
    }

    /// <summary>
    /// Adds security info for a contract ID.
    /// </summary>
    public void AddSecurityInfo(int conid, List<SecurityInfo> info)
    {
        _securityInfo[conid] = info;
    }

    /// <summary>
    /// Adds strike data.
    /// </summary>
    public void AddStrikes(int conid, string exchange, string secType, string month, StrikeData strikes)
    {
        var key = $"{conid}:{exchange}:{secType}:{month}";
        _strikes[key] = strikes;
    }

    /// <summary>
    /// Adds option chain data for a contract ID.
    /// </summary>
    public void AddOptionChain(int conid, OptionChain chain)
    {
        _optionChains[conid] = chain;
    }

    /// <summary>
    /// Adds option contracts for specific parameters.
    /// </summary>
    public void AddOptionContracts(int conid, string expiration, decimal strike, string right, List<OptionContract> contracts)
    {
        var key = $"{conid}:{expiration}:{strike}:{right}";
        _optionContracts[key] = contracts;
    }

    #endregion

    #region IInstrumentApiService Implementation

    public Task<Dictionary<string, List<StockResult>>> SearchStocksAsync(
        string symbols,
        CancellationToken cancellationToken = default)
    {
        if (_stockData.TryGetValue(symbols, out var result))
        {
            return Task.FromResult(result);
        }

        // Return empty result if not found
        return Task.FromResult(new Dictionary<string, List<StockResult>>());
    }

    public Task<Dictionary<string, List<SecurityInfo>>> SearchFuturesAsync(
        string symbols,
        CancellationToken cancellationToken = default)
    {
        if (_futuresData.TryGetValue(symbols, out var result))
        {
            return Task.FromResult(result);
        }

        return Task.FromResult(new Dictionary<string, List<SecurityInfo>>());
    }

    public Task<List<SecurityDefinition>> SearchSecuritiesAsync(
        string symbol,
        string? secType = null,
        CancellationToken cancellationToken = default)
    {
        if (_securityDefinitions.TryGetValue(symbol, out var result))
        {
            // Filter by secType if provided
            if (!string.IsNullOrEmpty(secType))
            {
                var filtered = result.Where(s =>
                    s.Sections?.Any(section => section.SecType == secType) ?? false).ToList();
                return Task.FromResult(filtered);
            }

            return Task.FromResult(result);
        }

        return Task.FromResult(new List<SecurityDefinition>());
    }

    public Task<List<SecurityInfo>> GetSecurityInfoAsync(
        int conid,
        string? exchange = null,
        string? secType = null,
        CancellationToken cancellationToken = default)
    {
        if (_securityInfo.TryGetValue(conid, out var result))
        {
            return Task.FromResult(result);
        }

        return Task.FromResult(new List<SecurityInfo>());
    }

    public Task<StrikeData> GetStrikesAsync(
        int conid,
        string exchange,
        string secType,
        string month,
        CancellationToken cancellationToken = default)
    {
        var key = $"{conid}:{exchange}:{secType}:{month}";

        if (_strikes.TryGetValue(key, out var result))
        {
            return Task.FromResult(result);
        }

        // Return empty strike data if not found
        return Task.FromResult(new StrikeData());
    }

    public Task<OptionChain> GetOptionChainAsync(
        int conid,
        string? exchange = null,
        CancellationToken cancellationToken = default)
    {
        if (_optionChains.TryGetValue(conid, out var result))
        {
            return Task.FromResult(result);
        }

        // Return empty option chain if not found
        return Task.FromResult(new OptionChain { Conid = conid });
    }

    public Task<List<OptionContract>> GetOptionContractsAsync(
        int conid,
        string expiration,
        decimal strike,
        string right,
        CancellationToken cancellationToken = default)
    {
        var key = $"{conid}:{expiration}:{strike}:{right}";

        if (_optionContracts.TryGetValue(key, out var result))
        {
            return Task.FromResult(result);
        }

        return Task.FromResult(new List<OptionContract>());
    }

    #endregion
}
