using IBKR.Sdk.Contract.Models;

namespace IBKR.Sdk.Contract.Interfaces;

/// <summary>
/// Service for getting real-time stock quotes.
/// Provides a clean, strongly-typed interface over the IBKR market data API.
/// </summary>
public interface IStockQuoteService
{
    /// <summary>
    /// Get a real-time quote for a stock by symbol.
    /// This method performs a search first to find the contract ID, then gets the quote.
    /// </summary>
    /// <param name="symbol">Stock ticker symbol (e.g., "AAPL")</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Stock quote with current prices</returns>
    Task<StockQuote> GetQuoteAsync(
        string symbol,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a real-time quote for a stock by contract ID.
    /// More efficient if you already know the contract ID.
    /// </summary>
    /// <param name="conid">Contract identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Stock quote with current prices</returns>
    Task<StockQuote> GetQuoteByConidAsync(
        int conid,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get real-time quotes for multiple stocks at once.
    /// More efficient than calling GetQuoteAsync multiple times.
    /// </summary>
    /// <param name="conids">Array of contract identifiers</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of stock quotes</returns>
    Task<List<StockQuote>> GetQuotesAsync(
        int[] conids,
        CancellationToken cancellationToken = default);
}
