using System.Net;

namespace IBKR.Api.Client.Exceptions;

/// <summary>
/// Exception thrown when an order operation fails.
/// </summary>
public class OrderException : IBKRApiException
{
    /// <summary>
    /// Gets the order ID associated with this exception, if available.
    /// </summary>
    public string? OrderId { get; }

    /// <summary>
    /// Gets the account ID associated with this exception, if available.
    /// </summary>
    public string? AccountId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public OrderException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderException"/> class with order details.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="orderId">The order ID associated with this exception.</param>
    /// <param name="accountId">The account ID associated with this exception.</param>
    public OrderException(string message, string? orderId, string? accountId = null)
        : base(message)
    {
        OrderId = orderId;
        AccountId = accountId;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderException"/> class with HTTP details.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="responseContent">The response content from the API.</param>
    /// <param name="orderId">The order ID associated with this exception.</param>
    /// <param name="accountId">The account ID associated with this exception.</param>
    public OrderException(string message, HttpStatusCode statusCode, string? responseContent, string? orderId = null, string? accountId = null)
        : base(message, statusCode, responseContent)
    {
        OrderId = orderId;
        AccountId = accountId;
    }
}
