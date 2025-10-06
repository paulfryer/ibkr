namespace IBKR.Api.Client.Models.Enums;

/// <summary>
/// Represents the type of financial security/instrument.
/// </summary>
public enum SecurityType
{
    /// <summary>
    /// Stock
    /// </summary>
    STK,

    /// <summary>
    /// Option
    /// </summary>
    OPT,

    /// <summary>
    /// Future
    /// </summary>
    FUT,

    /// <summary>
    /// Future Option
    /// </summary>
    FOP,

    /// <summary>
    /// Index
    /// </summary>
    IND,

    /// <summary>
    /// Cash/Forex
    /// </summary>
    CASH,

    /// <summary>
    /// Bond
    /// </summary>
    BOND,

    /// <summary>
    /// Mutual Fund
    /// </summary>
    FUND
}
