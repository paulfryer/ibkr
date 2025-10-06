using System.Net;

namespace IBKR.Api.Client.Exceptions;

/// <summary>
/// Exception thrown when the API rate limit has been exceeded.
/// </summary>
public class RateLimitExceededException : IBKRApiException
{
    /// <summary>
    /// Gets the time when the rate limit will reset, if known.
    /// </summary>
    public DateTimeOffset? RetryAfter { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RateLimitExceededException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public RateLimitExceededException(string message)
        : base(message, HttpStatusCode.TooManyRequests)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RateLimitExceededException"/> class with retry information.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="retryAfter">The time when the rate limit will reset.</param>
    public RateLimitExceededException(string message, DateTimeOffset retryAfter)
        : base(message, HttpStatusCode.TooManyRequests)
    {
        RetryAfter = retryAfter;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RateLimitExceededException"/> class with response content.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="responseContent">The response content from the API.</param>
    /// <param name="retryAfter">The time when the rate limit will reset.</param>
    public RateLimitExceededException(string message, string? responseContent, DateTimeOffset? retryAfter = null)
        : base(message, HttpStatusCode.TooManyRequests, responseContent)
    {
        RetryAfter = retryAfter;
    }
}
