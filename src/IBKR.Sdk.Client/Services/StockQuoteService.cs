using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.Contract.Models;
using IBKR.Sdk.Contract.Constants;
using IBKR.Sdk.Contract.Interfaces;
using IBKR.Sdk.Contract.Models;
using Microsoft.Extensions.Logging;

namespace IBKR.Sdk.Client.Services;

/// <summary>
/// Production implementation of IStockQuoteService that wraps the NSwag IIserverService.
/// Handles market data requests and maps to strongly-typed StockQuote models.
/// </summary>
public class StockQuoteService : IStockQuoteService
{
    private readonly IIserverService _iserverService;
    private readonly ILogger<StockQuoteService> _logger;

    public StockQuoteService(IIserverService iserverService, ILogger<StockQuoteService> logger)
    {
        _iserverService = iserverService ?? throw new ArgumentNullException(nameof(iserverService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<StockQuote> GetQuoteAsync(string symbol, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Getting stock quote for symbol: {Symbol}", symbol);

        // Step 1: Search for the symbol to get contract ID
        var searchResults = await _iserverService.SearchAllGETAsync(
            symbol: symbol,
            secType: SecType.STK,
            cancellationToken: cancellationToken);

        var firstResult = searchResults.FirstOrDefault()
            ?? throw new InvalidOperationException($"Stock symbol '{symbol}' not found");

        var conidStr = firstResult.Conid
            ?? throw new InvalidOperationException($"Contract ID not found for symbol '{symbol}'");

        var conid = int.Parse(conidStr);

        // Step 2: Get the quote
        return await GetQuoteByConidAsync(conid, cancellationToken);
    }

    public async Task<StockQuote> GetQuoteByConidAsync(int conid, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Getting stock quote for conid: {Conid}", conid);

        // Request all stock quote fields with retry for pre-flight
        var quotes = await SnapshotWithRetryAsync(
            conid.ToString(),
            fields: null, // null = get all available fields
            maxRetries: 1,
            delayMs: 1000,
            cancellationToken: cancellationToken);

        var quote = quotes.FirstOrDefault()
            ?? throw new InvalidOperationException($"No quote data returned for conid {conid}");

        return MapToStockQuote(conid, quote);
    }

    public async Task<List<StockQuote>> GetQuotesAsync(int[] conids, CancellationToken cancellationToken = default)
    {
        if (conids == null || conids.Length == 0)
            throw new ArgumentException("At least one contract ID must be provided", nameof(conids));

        _logger.LogDebug("Getting stock quotes for {Count} contracts", conids.Length);

        // Join conids with commas for batch request
        var conidsStr = string.Join(",", conids);

        // Request with retry for pre-flight
        var quotes = await SnapshotWithRetryAsync(
            conids: conidsStr,
            fields: null,
            maxRetries: 1,
            delayMs: 1000,
            cancellationToken: cancellationToken);

        var result = new List<StockQuote>();
        var quotesList = quotes.ToList();

        // Map each quote - API returns them in same order as requested
        for (int i = 0; i < Math.Min(conids.Length, quotesList.Count); i++)
        {
            try
            {
                var stockQuote = MapToStockQuote(conids[i], quotesList[i]);
                result.Add(stockQuote);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error mapping quote for conid {Conid}", conids[i]);
                // Continue processing other quotes
            }
        }

        return result;
    }

    /// <summary>
    /// Calls SnapshotAsync with retry logic to handle IBKR pre-flight behavior.
    /// First request may return 503 error or empty data (pre-flight initialization),
    /// subsequent requests return actual market data.
    /// </summary>
    private async Task<ICollection<FyiVT>> SnapshotWithRetryAsync(
        string conids,
        MdFields? fields,
        int maxRetries = 1,
        int delayMs = 1000,
        CancellationToken cancellationToken = default)
    {
        for (int attempt = 0; attempt <= maxRetries; attempt++)
        {
            try
            {
                var result = await _iserverService.SnapshotAsync(conids, fields, cancellationToken);

                // Check if pre-flight (empty data)
                if (result.Any() && IsValidMarketData(result.First()))
                {
                    _logger.LogDebug("Successfully retrieved market data for conids {Conids} (attempt {Attempt})", conids, attempt + 1);
                    return result; // Success!
                }

                // Pre-flight detected (empty AdditionalProperties) - retry
                if (attempt < maxRetries)
                {
                    _logger.LogDebug("Pre-flight response detected for conids {Conids}, retrying in {Delay}ms (attempt {Attempt}/{Max})",
                        conids, delayMs, attempt + 1, maxRetries);
                    await System.Threading.Tasks.Task.Delay(delayMs, cancellationToken);
                }
            }
            catch (ApiException ex) when (ex.StatusCode == 503 && attempt < maxRetries)
            {
                // 503 Service Unavailable = pre-flight initialization, retry
                _logger.LogDebug("503 error (pre-flight) for conids {Conids}, retrying in {Delay}ms (attempt {Attempt}/{Max})",
                    conids, delayMs, attempt + 1, maxRetries);
                await System.Threading.Tasks.Task.Delay(delayMs, cancellationToken);
            }
            catch (ApiException ex) when (ex.StatusCode == 429)
            {
                // 429 Too Many Requests - don't retry, throw immediately
                _logger.LogWarning("Rate limited (429) for conids {Conids} - too many requests", conids);
                throw;
            }
        }

        throw new InvalidOperationException(
            $"Failed to get market data for conids {conids} after {maxRetries + 1} attempts. " +
            "This may indicate the data stream could not be initialized or the contract ID is invalid.");
    }

    /// <summary>
    /// Checks if the FyiVT response contains valid market data (not a pre-flight response).
    /// Pre-flight responses have empty or null AdditionalProperties.
    /// </summary>
    private bool IsValidMarketData(FyiVT response)
    {
        var props = response.AdditionalProperties;
        if (props == null || props.Count == 0)
        {
            return false;
        }

        // Check for at least one price field (Last, Bid, or Ask)
        return props.ContainsKey(MarketDataFields.Last) ||
               props.ContainsKey(MarketDataFields.Bid) ||
               props.ContainsKey(MarketDataFields.Ask);
    }

    /// <summary>
    /// Maps FyiVT response to StockQuote model by parsing AdditionalProperties field codes
    /// </summary>
    private StockQuote MapToStockQuote(int conid, FyiVT data)
    {
        var props = data.AdditionalProperties ?? new Dictionary<string, object>();

        return new StockQuote
        {
            ContractId = conid,
            Last = ParseDecimal(props, MarketDataFields.Last),
            Bid = ParseDecimal(props, MarketDataFields.Bid),
            Ask = ParseDecimal(props, MarketDataFields.Ask),
            BidSize = ParseInt(props, MarketDataFields.BidSize),
            AskSize = ParseInt(props, MarketDataFields.AskSize),
            Volume = ParseLong(props, MarketDataFields.Volume),
            High = ParseDecimal(props, MarketDataFields.High),
            Low = ParseDecimal(props, MarketDataFields.Low),
            Close = ParseDecimal(props, MarketDataFields.Close),
            PercentChange = ParseDecimal(props, MarketDataFields.PercentChange),
            RetrievedAt = DateTime.UtcNow
        };
    }

    private static decimal? ParseDecimal(IDictionary<string, object> props, string key)
    {
        if (!props.TryGetValue(key, out var value) || value == null)
            return null;

        var str = value.ToString();
        if (string.IsNullOrWhiteSpace(str))
            return null;

        if (decimal.TryParse(str, out var result))
            return result;

        return null;
    }

    private static int? ParseInt(IDictionary<string, object> props, string key)
    {
        if (!props.TryGetValue(key, out var value) || value == null)
            return null;

        if (value is int intValue)
            return intValue;

        var str = value.ToString();
        if (string.IsNullOrWhiteSpace(str))
            return null;

        if (int.TryParse(str, out var result))
            return result;

        return null;
    }

    private static long? ParseLong(IDictionary<string, object> props, string key)
    {
        if (!props.TryGetValue(key, out var value) || value == null)
            return null;

        if (value is long longValue)
            return longValue;

        if (value is int intValue)
            return intValue;

        var str = value.ToString();
        if (string.IsNullOrWhiteSpace(str))
            return null;

        if (long.TryParse(str, out var result))
            return result;

        return null;
    }
}
