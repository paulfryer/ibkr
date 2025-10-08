using IBKR.Api.Contract.Enums;

namespace IBKR.Api.Contract.Models;

/// <summary>
/// Represents a single option contract with clean, strongly-typed properties.
/// </summary>
public class OptionContract
{
    /// <summary>
    /// Unique contract identifier for this option
    /// </summary>
    public int ContractId { get; set; }

    /// <summary>
    /// Contract identifier of the underlying security
    /// </summary>
    public int UnderlyingContractId { get; set; }

    /// <summary>
    /// Ticker symbol of the underlying security (e.g., "AAPL")
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Option right - Call or Put
    /// </summary>
    public OptionRight Right { get; set; }

    /// <summary>
    /// Strike price
    /// </summary>
    public decimal Strike { get; set; }

    /// <summary>
    /// Expiration date
    /// </summary>
    public DateTime Expiration { get; set; }

    /// <summary>
    /// Trading class (often same as symbol, e.g., "AAPL")
    /// </summary>
    public string TradingClass { get; set; } = string.Empty;

    /// <summary>
    /// Primary exchange
    /// </summary>
    public string Exchange { get; set; } = string.Empty;

    /// <summary>
    /// Currency (e.g., "USD")
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Contract multiplier (typically 100 for equity options)
    /// </summary>
    public decimal Multiplier { get; set; }

    /// <summary>
    /// List of valid exchanges where this contract trades
    /// </summary>
    public string[] ValidExchanges { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Days until expiration from when the contract was retrieved
    /// </summary>
    public int? DaysUntilExpiration { get; set; }
}
