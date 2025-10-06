using System.Net;

namespace IBKR.Api.Client.Exceptions;

/// <summary>
/// Base exception for all IBKR API-related errors.
/// </summary>
public class IBKRApiException : Exception
{
    /// <summary>
    /// Gets the HTTP status code associated with this exception, if applicable.
    /// </summary>
    public HttpStatusCode? StatusCode { get; }

    /// <summary>
    /// Gets the response content from the API, if available.
    /// </summary>
    public string? ResponseContent { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="IBKRApiException"/> class.
    /// </summary>
    public IBKRApiException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IBKRApiException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public IBKRApiException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IBKRApiException"/> class with a specified error message and inner exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public IBKRApiException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IBKRApiException"/> class with HTTP details.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="responseContent">The response content from the API.</param>
    public IBKRApiException(string message, HttpStatusCode statusCode, string? responseContent = null)
        : base(message)
    {
        StatusCode = statusCode;
        ResponseContent = responseContent;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IBKRApiException"/> class with HTTP details and inner exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="responseContent">The response content from the API.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public IBKRApiException(string message, HttpStatusCode statusCode, string? responseContent, Exception innerException)
        : base(message, innerException)
    {
        StatusCode = statusCode;
        ResponseContent = responseContent;
    }
}
