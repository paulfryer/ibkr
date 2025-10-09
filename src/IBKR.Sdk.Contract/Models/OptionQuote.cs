using IBKR.Sdk.Contract.Enums;

namespace IBKR.Sdk.Contract.Models;

/// <summary>
/// Real-time quote data for an option contract.
/// Extends StockQuote with option-specific data including Greeks.
/// </summary>
public class OptionQuote : StockQuote
{
    /// <summary>
    /// Underlying contract identifier
    /// </summary>
    public int UnderlyingContractId { get; set; }

    /// <summary>
    /// Underlying symbol (e.g., "AAPL")
    /// </summary>
    public string UnderlyingSymbol { get; set; } = string.Empty;

    /// <summary>
    /// Strike price
    /// </summary>
    public decimal Strike { get; set; }

    /// <summary>
    /// Expiration date
    /// </summary>
    public DateTime Expiration { get; set; }

    /// <summary>
    /// Option right - Call or Put
    /// </summary>
    public OptionRight Right { get; set; }

    /// <summary>
    /// Days until expiration
    /// </summary>
    public int? DaysUntilExpiration { get; set; }

    /// <summary>
    /// Open interest - number of outstanding contracts
    /// </summary>
    public long? OpenInterest { get; set; }

    /// <summary>
    /// Option Greeks (Delta, Gamma, Vega, Theta, IV)
    /// </summary>
    public OptionGreeks? Greeks { get; set; }

    /// <summary>
    /// Contract multiplier (typically 100 for equity options)
    /// </summary>
    public decimal Multiplier { get; set; } = 100;

    /// <summary>
    /// Returns true if this option is in-the-money based on the underlying price
    /// </summary>
    public bool? IsInTheMoney(decimal underlyingPrice)
    {
        if (Right == OptionRight.Call)
            return underlyingPrice > Strike;
        else if (Right == OptionRight.Put)
            return underlyingPrice < Strike;
        return null;
    }

    /// <summary>
    /// Calculates intrinsic value based on underlying price
    /// </summary>
    public decimal IntrinsicValue(decimal underlyingPrice)
    {
        if (Right == OptionRight.Call)
            return Math.Max(0, underlyingPrice - Strike);
        else if (Right == OptionRight.Put)
            return Math.Max(0, Strike - underlyingPrice);
        return 0;
    }

    /// <summary>
    /// Time value (extrinsic value) = Option Price - Intrinsic Value
    /// </summary>
    public decimal? TimeValue(decimal underlyingPrice)
    {
        if (!Last.HasValue)
            return null;
        return Last.Value - IntrinsicValue(underlyingPrice);
    }

    /// <summary>
    /// Returns true if Greeks data is available and complete
    /// </summary>
    public bool HasGreeks => Greeks != null && Greeks.IsComplete;

    /// <summary>
    /// Returns a formatted string representation of the option quote
    /// </summary>
    public override string ToString()
    {
        var rightStr = Right == OptionRight.Call ? "C" : "P";
        return $"{UnderlyingSymbol} {Expiration:yyyy-MM-dd} {Strike:F2}{rightStr}: " +
               $"Last={Last:C}, Bid={Bid:C}x{BidSize}, Ask={Ask:C}x{AskSize}, " +
               $"IV={Greeks?.ImpliedVolatility:P2}, Delta={Greeks?.Delta:F4}, OI={OpenInterest:N0}";
    }
}
