namespace IBKR.Api.Client.Models.Enums;

/// <summary>
/// Represents the type of order to be placed.
/// </summary>
public enum OrderType
{
    /// <summary>
    /// Market order - executes at the current market price
    /// </summary>
    MKT,

    /// <summary>
    /// Limit order - executes at a specified price or better
    /// </summary>
    LMT,

    /// <summary>
    /// Stop order - becomes a market order when the stop price is reached
    /// </summary>
    STP,

    /// <summary>
    /// Stop-limit order - becomes a limit order when the stop price is reached
    /// </summary>
    STP_LMT,

    /// <summary>
    /// Relative order - price specified as an offset from the market
    /// </summary>
    REL,

    /// <summary>
    /// Trailing stop order - stop price follows the market by a specified amount
    /// </summary>
    TRAIL,

    /// <summary>
    /// Midpoint order - executes at the midpoint between bid and ask
    /// </summary>
    MIDPRICE
}
