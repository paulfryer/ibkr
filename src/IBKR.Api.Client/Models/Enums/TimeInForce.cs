namespace IBKR.Api.Client.Models.Enums;

/// <summary>
/// Specifies how long an order remains active before it is executed or expires.
/// </summary>
public enum TimeInForce
{
    /// <summary>
    /// Day order - valid for the current trading day only
    /// </summary>
    DAY,

    /// <summary>
    /// Good Till Canceled - remains active until filled or manually canceled
    /// </summary>
    GTC,

    /// <summary>
    /// Immediate or Cancel - fills immediately (partially or fully) or cancels
    /// </summary>
    IOC,

    /// <summary>
    /// Fill or Kill - must be filled entirely immediately or is canceled
    /// </summary>
    FOK,

    /// <summary>
    /// At the Opening - executes at the market opening
    /// </summary>
    OPG,

    /// <summary>
    /// Day Till Canceled - valid until the end of the trading day
    /// </summary>
    DTC
}
