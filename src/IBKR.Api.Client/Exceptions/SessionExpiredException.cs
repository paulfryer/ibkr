using System.Net;

namespace IBKR.Api.Client.Exceptions;

/// <summary>
/// Exception thrown when the current session has expired and requires re-authentication.
/// </summary>
public class SessionExpiredException : AuthenticationException
{
    /// <summary>
    /// Gets the time when the session expired.
    /// </summary>
    public DateTimeOffset ExpiredAt { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SessionExpiredException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public SessionExpiredException(string message)
        : base(message)
    {
        ExpiredAt = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SessionExpiredException"/> class with expiration time.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="expiredAt">The time when the session expired.</param>
    public SessionExpiredException(string message, DateTimeOffset expiredAt)
        : base(message)
    {
        ExpiredAt = expiredAt;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SessionExpiredException"/> class with response content.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="responseContent">The response content from the API.</param>
    /// <param name="expiredAt">The time when the session expired.</param>
    public SessionExpiredException(string message, string? responseContent, DateTimeOffset? expiredAt = null)
        : base(message, responseContent)
    {
        ExpiredAt = expiredAt ?? DateTimeOffset.UtcNow;
    }
}
