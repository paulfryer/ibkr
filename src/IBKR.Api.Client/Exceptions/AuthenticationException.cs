using System.Net;

namespace IBKR.Api.Client.Exceptions;

/// <summary>
/// Exception thrown when authentication fails or credentials are invalid.
/// </summary>
public class AuthenticationException : IBKRApiException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public AuthenticationException(string message)
        : base(message, HttpStatusCode.Unauthorized)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationException"/> class with inner exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public AuthenticationException(string message, Exception innerException)
        : base(message, HttpStatusCode.Unauthorized, null, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationException"/> class with response content.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="responseContent">The response content from the API.</param>
    public AuthenticationException(string message, string? responseContent)
        : base(message, HttpStatusCode.Unauthorized, responseContent)
    {
    }
}
