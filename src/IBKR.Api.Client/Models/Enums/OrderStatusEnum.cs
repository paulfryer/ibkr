namespace IBKR.Api.Client.Models.Enums;

/// <summary>
/// Represents the current status of an order.
/// </summary>
public enum OrderStatusEnum
{
    /// <summary>
    /// Order has been submitted but not yet acknowledged
    /// </summary>
    Submitted,

    /// <summary>
    /// Order has been filled completely
    /// </summary>
    Filled,

    /// <summary>
    /// Order has been canceled
    /// </summary>
    Cancelled,

    /// <summary>
    /// Order has been partially filled
    /// </summary>
    PartiallyFilled,

    /// <summary>
    /// Order is pending submission
    /// </summary>
    PendingSubmit,

    /// <summary>
    /// Order is pending cancellation
    /// </summary>
    PendingCancel,

    /// <summary>
    /// Order has been pre-submitted
    /// </summary>
    PreSubmitted,

    /// <summary>
    /// Order is inactive
    /// </summary>
    Inactive,

    /// <summary>
    /// Order status is unknown
    /// </summary>
    Unknown
}
