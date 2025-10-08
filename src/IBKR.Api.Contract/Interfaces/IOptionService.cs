using IBKR.Api.Contract.Models;

namespace IBKR.Api.Contract.Interfaces;

/// <summary>
/// Service for option chain discovery and option contract operations.
/// Provides a clean, strongly-typed interface over the IBKR API.
/// </summary>
public interface IOptionService
{
    /// <summary>
    /// Get the complete option chain for a stock symbol within a date range.
    /// Handles the complete workflow: search → get contract info → discover expirations → get strikes → get contract details.
    /// </summary>
    /// <param name="symbol">Stock ticker symbol (e.g., "AAPL")</param>
    /// <param name="expirationStart">Start of expiration date range (inclusive)</param>
    /// <param name="expirationEnd">End of expiration date range (inclusive)</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Complete option chain with all contracts in the date range</returns>
    Task<OptionChain> GetOptionChainAsync(
        string symbol,
        DateTime expirationStart,
        DateTime expirationEnd,
        CancellationToken cancellationToken = default);
}
