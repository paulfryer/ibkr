using IBKR.Sdk.Contract.Models;

namespace IBKR.Sdk.Contract.Interfaces;

/// <summary>
/// Service for getting real-time option quotes including Greeks.
/// Provides a clean, strongly-typed interface over the IBKR market data API.
/// </summary>
public interface IOptionQuoteService
{
    /// <summary>
    /// Get a real-time quote for an option contract by contract ID.
    /// Includes prices, Greeks (Delta, Gamma, Vega, Theta), and implied volatility.
    /// </summary>
    /// <param name="optionConid">Option contract identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Option quote with prices and Greeks</returns>
    Task<OptionQuote> GetQuoteAsync(
        int optionConid,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get real-time quotes for multiple option contracts at once.
    /// More efficient than calling GetQuoteAsync multiple times.
    /// Useful for getting quotes for an entire option chain or strategy.
    /// </summary>
    /// <param name="optionConids">Array of option contract identifiers</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of option quotes with prices and Greeks</returns>
    Task<List<OptionQuote>> GetQuotesAsync(
        int[] optionConids,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get real-time quotes for all options in an option chain.
    /// This is a convenience method that combines GetOptionChainAsync with GetQuotesAsync.
    /// </summary>
    /// <param name="symbol">Stock ticker symbol (e.g., "AAPL")</param>
    /// <param name="expirationStart">Start of expiration date range (inclusive)</param>
    /// <param name="expirationEnd">End of expiration date range (inclusive)</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of option quotes for all contracts in the chain</returns>
    Task<List<OptionQuote>> GetChainQuotesAsync(
        string symbol,
        DateTime expirationStart,
        DateTime expirationEnd,
        CancellationToken cancellationToken = default);
}
