using IBKR.Api.Client.Models.Instruments;

namespace IBKR.Api.Client.Services;

/// <summary>
/// Service for instrument/security discovery and information.
/// </summary>
public interface IInstrumentApiService
{
    /// <summary>
    /// Searches for stocks by symbol.
    /// </summary>
    /// <param name="symbols">Comma-separated list of stock symbols (e.g., "AAPL,MSFT").</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Dictionary of symbol to stock search results.</returns>
    Task<Dictionary<string, List<StockResult>>> SearchStocksAsync(
        string symbols,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Searches for futures by symbol.
    /// </summary>
    /// <param name="symbols">Comma-separated list of futures symbols.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Dictionary of symbol to futures search results.</returns>
    Task<Dictionary<string, List<SecurityInfo>>> SearchFuturesAsync(
        string symbols,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// General security search.
    /// </summary>
    /// <param name="symbol">Symbol to search for.</param>
    /// <param name="secType">Optional security type filter.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of security definitions.</returns>
    Task<List<SecurityDefinition>> SearchSecuritiesAsync(
        string symbol,
        string? secType = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets detailed information about a security.
    /// </summary>
    /// <param name="conid">Contract ID.</param>
    /// <param name="exchange">Optional exchange filter.</param>
    /// <param name="secType">Optional security type.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of security information (may have multiple entries for different exchanges).</returns>
    Task<List<SecurityInfo>> GetSecurityInfoAsync(
        int conid,
        string? exchange = null,
        string? secType = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets available strike prices for options.
    /// </summary>
    /// <param name="conid">Underlying contract ID.</param>
    /// <param name="exchange">Exchange code.</param>
    /// <param name="secType">Security type (e.g., "OPT").</param>
    /// <param name="month">Contract month (YYYYMM format).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Available strike prices for calls and puts.</returns>
    Task<StrikeData> GetStrikesAsync(
        int conid,
        string exchange,
        string secType,
        string month,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the option chain for an underlying security.
    /// </summary>
    /// <param name="conid">Underlying contract ID.</param>
    /// <param name="exchange">Optional exchange filter.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Option chain with expirations and strikes.</returns>
    Task<OptionChain> GetOptionChainAsync(
        int conid,
        string? exchange = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets specific option contracts based on criteria.
    /// </summary>
    /// <param name="conid">Underlying contract ID.</param>
    /// <param name="expiration">Expiration date (YYYYMMDD format).</param>
    /// <param name="strike">Strike price.</param>
    /// <param name="right">Option right ("C" for Call, "P" for Put).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of matching option contracts.</returns>
    Task<List<OptionContract>> GetOptionContractsAsync(
        int conid,
        string expiration,
        decimal strike,
        string right,
        CancellationToken cancellationToken = default);
}
