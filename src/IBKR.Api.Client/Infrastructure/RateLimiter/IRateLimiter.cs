namespace IBKR.Api.Client.Infrastructure.RateLimiter;

/// <summary>
/// Interface for rate limiting HTTP requests.
/// </summary>
public interface IRateLimiter
{
    /// <summary>
    /// Waits asynchronously until a request can be made without exceeding the rate limit.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task that completes when the request can proceed.</returns>
    Task WaitAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Tries to acquire permission to make a request immediately.
    /// </summary>
    /// <returns>True if the request can proceed immediately; otherwise, false.</returns>
    bool TryAcquire();
}
