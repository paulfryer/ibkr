namespace IBKR.Api.Contract.Models;

/// <summary>
/// Represents a complete option chain for an underlying security within a date range.
/// </summary>
public class OptionChain
{
    /// <summary>
    /// Ticker symbol of the underlying security
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Contract identifier of the underlying security
    /// </summary>
    public int UnderlyingContractId { get; set; }

    /// <summary>
    /// All option contracts in the chain
    /// </summary>
    public List<OptionContract> Contracts { get; set; } = new();

    /// <summary>
    /// Start of the expiration date range that was requested
    /// </summary>
    public DateTime RequestedExpirationStart { get; set; }

    /// <summary>
    /// End of the expiration date range that was requested
    /// </summary>
    public DateTime RequestedExpirationEnd { get; set; }

    /// <summary>
    /// When this chain data was retrieved
    /// </summary>
    public DateTime RetrievedAt { get; set; } = DateTime.UtcNow;
}
