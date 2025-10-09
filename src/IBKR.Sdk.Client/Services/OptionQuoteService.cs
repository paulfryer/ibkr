using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.Contract.Models;
using IBKR.Sdk.Contract.Constants;
using IBKR.Sdk.Contract.Enums;
using IBKR.Sdk.Contract.Interfaces;
using IBKR.Sdk.Contract.Models;
using Microsoft.Extensions.Logging;

namespace IBKR.Sdk.Client.Services;

/// <summary>
/// Production implementation of IOptionQuoteService that wraps the NSwag IIserverService.
/// Handles market data requests for options including Greeks and IV.
/// </summary>
public class OptionQuoteService : IOptionQuoteService
{
    private readonly IIserverService _iserverService;
    private readonly IOptionService _optionService;
    private readonly ILogger<OptionQuoteService> _logger;

    public OptionQuoteService(
        IIserverService iserverService,
        IOptionService optionService,
        ILogger<OptionQuoteService> logger)
    {
        _iserverService = iserverService ?? throw new ArgumentNullException(nameof(iserverService));
        _optionService = optionService ?? throw new ArgumentNullException(nameof(optionService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<OptionQuote> GetQuoteAsync(int optionConid, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Getting option quote for conid: {Conid}", optionConid);

        // Request all option fields including Greeks with retry for pre-flight
        // Options may need longer retry due to Greek calculations
        var quotes = await SnapshotWithRetryAsync(
            optionConid.ToString(),
            fields: null, // null = get all available fields
            maxRetries: 1,
            delayMs: 1500, // Longer delay for options due to Greek calculations
            cancellationToken: cancellationToken);

        var quote = quotes.FirstOrDefault()
            ?? throw new InvalidOperationException($"No quote data returned for option conid {optionConid}");

        // Get contract metadata (we need this for strike, expiration, etc.)
        var contractInfo = await _iserverService.InfoAsync(
            conid: optionConid.ToString(),
            cancellationToken: cancellationToken);

        return MapToOptionQuote(optionConid, quote, contractInfo);
    }

    public async Task<List<OptionQuote>> GetQuotesAsync(int[] optionConids, CancellationToken cancellationToken = default)
    {
        if (optionConids == null || optionConids.Length == 0)
            throw new ArgumentException("At least one option contract ID must be provided", nameof(optionConids));

        _logger.LogDebug("Getting option quotes for {Count} contracts", optionConids.Length);

        // Join conids with commas for batch request
        var conidsStr = string.Join(",", optionConids);

        // Request with retry for pre-flight - options need longer delays for Greek calculations
        var quotes = await SnapshotWithRetryAsync(
            conids: conidsStr,
            fields: null,
            maxRetries: 1,
            delayMs: 1500,
            cancellationToken: cancellationToken);

        var result = new List<OptionQuote>();
        var quotesList = quotes.ToList();

        // Get contract info for each option (needed for metadata)
        // Note: This could be optimized by caching contract info
        for (int i = 0; i < Math.Min(optionConids.Length, quotesList.Count); i++)
        {
            try
            {
                var contractInfo = await _iserverService.InfoAsync(
                    conid: optionConids[i].ToString(),
                    cancellationToken: cancellationToken);

                var optionQuote = MapToOptionQuote(optionConids[i], quotesList[i], contractInfo);
                result.Add(optionQuote);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error mapping option quote for conid {Conid}", optionConids[i]);
                // Continue processing other quotes
            }
        }

        return result;
    }

    public async Task<List<OptionQuote>> GetChainQuotesAsync(
        string symbol,
        DateTime expirationStart,
        DateTime expirationEnd,
        CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Getting option chain quotes for {Symbol} from {Start} to {End}",
            symbol, expirationStart, expirationEnd);

        // Step 1: Get the option chain
        var chain = await _optionService.GetOptionChainAsync(
            symbol,
            expirationStart,
            expirationEnd,
            cancellationToken);

        // Step 2: Extract all contract IDs
        var optionConids = chain.Contracts
            .Select(c => c.ContractId)
            .ToArray();

        if (optionConids.Length == 0)
        {
            _logger.LogWarning("No option contracts found for {Symbol} in date range", symbol);
            return new List<OptionQuote>();
        }

        // Step 3: Get quotes for all contracts (in batches if needed)
        const int batchSize = 100; // API limit
        var allQuotes = new List<OptionQuote>();

        for (int i = 0; i < optionConids.Length; i += batchSize)
        {
            var batch = optionConids.Skip(i).Take(batchSize).ToArray();
            var batchQuotes = await GetQuotesAsync(batch, cancellationToken);
            allQuotes.AddRange(batchQuotes);
        }

        return allQuotes;
    }

    /// <summary>
    /// Calls SnapshotAsync with retry logic to handle IBKR pre-flight behavior.
    /// First request may return 503 error or empty data (pre-flight initialization),
    /// subsequent requests return actual market data.
    /// Options may need longer delays due to Greek calculations.
    /// </summary>
    private async Task<ICollection<FyiVT>> SnapshotWithRetryAsync(
        string conids,
        MdFields? fields,
        int maxRetries = 1,
        int delayMs = 1500,
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
            "This may indicate the data stream could not be initialized, Greeks are still being calculated, or the contract ID is invalid.");
    }

    /// <summary>
    /// Checks if the FyiVT response contains valid market data (not a pre-flight response).
    /// Pre-flight responses have empty or null AdditionalProperties.
    /// For options, we also check for at least basic price data (Greeks may take longer).
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

    private OptionQuote MapToOptionQuote(int conid, FyiVT data, ContractInfo contractInfo)
    {
        var props = data.AdditionalProperties ?? new Dictionary<string, object>();
        var contractProps = contractInfo.AdditionalProperties ?? new Dictionary<string, object>();

        // Parse contract metadata
        var symbol = GetStringValue(contractProps, "symbol") ?? "";
        var strikeStr = GetStringValue(contractProps, "strike");
        var expirationStr = GetStringValue(contractProps, "maturity_date");
        var rightStr = GetStringValue(contractProps, "right");

        var strike = decimal.TryParse(strikeStr, out var s) ? s : 0;
        var expiration = DateTime.TryParseExact(expirationStr, "yyyyMMdd",
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out var exp) ? exp : DateTime.MinValue;
        var right = rightStr?.ToUpperInvariant() == "C" ? OptionRight.Call : OptionRight.Put;

        var daysUntilExp = expiration > DateTime.Today ? (int)(expiration - DateTime.Today).TotalDays : 0;

        return new OptionQuote
        {
            ContractId = conid,
            UnderlyingSymbol = symbol,
            Symbol = symbol,
            Strike = strike,
            Expiration = expiration,
            Right = right,
            DaysUntilExpiration = daysUntilExp,

            // Price fields
            Last = ParseDecimal(props, MarketDataFields.Last),
            Bid = ParseDecimal(props, MarketDataFields.Bid),
            Ask = ParseDecimal(props, MarketDataFields.Ask),
            BidSize = ParseInt(props, MarketDataFields.BidSize),
            AskSize = ParseInt(props, MarketDataFields.AskSize),
            Volume = ParseLong(props, MarketDataFields.Volume),

            // Option-specific fields
            OpenInterest = ParseLong(props, MarketDataFields.OpenInterest),

            // Greeks
            Greeks = new OptionGreeks
            {
                Delta = ParseDecimal(props, MarketDataFields.Delta),
                Gamma = ParseDecimal(props, MarketDataFields.Gamma),
                Vega = ParseDecimal(props, MarketDataFields.Vega),
                Theta = ParseDecimal(props, MarketDataFields.Theta),
                ImpliedVolatility = ParseDecimal(props, MarketDataFields.ImpliedVolatility)
            },

            RetrievedAt = DateTime.UtcNow
        };
    }

    private static string? GetStringValue(IDictionary<string, object> props, string key)
    {
        if (!props.TryGetValue(key, out var value) || value == null)
            return null;
        return value.ToString();
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
