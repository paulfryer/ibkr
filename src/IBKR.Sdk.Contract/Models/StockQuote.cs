namespace IBKR.Sdk.Contract.Models;

/// <summary>
/// Real-time quote data for a stock.
/// Contains price, size, and volume information.
/// </summary>
public class StockQuote
{
    /// <summary>
    /// Contract identifier
    /// </summary>
    public int ContractId { get; set; }

    /// <summary>
    /// Stock symbol (e.g., "AAPL")
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Last traded price
    /// </summary>
    public decimal? Last { get; set; }

    /// <summary>
    /// Best bid price
    /// </summary>
    public decimal? Bid { get; set; }

    /// <summary>
    /// Best ask price
    /// </summary>
    public decimal? Ask { get; set; }

    /// <summary>
    /// Bid size (number of shares)
    /// </summary>
    public int? BidSize { get; set; }

    /// <summary>
    /// Ask size (number of shares)
    /// </summary>
    public int? AskSize { get; set; }

    /// <summary>
    /// Trading volume for the day
    /// </summary>
    public long? Volume { get; set; }

    /// <summary>
    /// High price of the day
    /// </summary>
    public decimal? High { get; set; }

    /// <summary>
    /// Low price of the day
    /// </summary>
    public decimal? Low { get; set; }

    /// <summary>
    /// Previous close price
    /// </summary>
    public decimal? Close { get; set; }

    /// <summary>
    /// Change from previous close
    /// </summary>
    public decimal? Change { get; set; }

    /// <summary>
    /// Percent change from previous close
    /// </summary>
    public decimal? PercentChange { get; set; }

    /// <summary>
    /// Timestamp when the quote was retrieved
    /// </summary>
    public DateTime RetrievedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Bid-ask spread
    /// </summary>
    public decimal? Spread => (Ask.HasValue && Bid.HasValue) ? Ask.Value - Bid.Value : null;

    /// <summary>
    /// Mid-point between bid and ask
    /// </summary>
    public decimal? MidPoint => (Ask.HasValue && Bid.HasValue) ? (Ask.Value + Bid.Value) / 2 : null;

    /// <summary>
    /// Returns true if quote has valid bid/ask prices
    /// </summary>
    public bool HasValidQuote => Bid.HasValue && Ask.HasValue && Bid.Value > 0 && Ask.Value > 0;

    /// <summary>
    /// Returns a formatted string representation of the quote
    /// </summary>
    public override string ToString()
    {
        return $"{Symbol}: Last={Last:C}, Bid={Bid:C}x{BidSize}, Ask={Ask:C}x{AskSize}, Vol={Volume:N0}";
    }
}
