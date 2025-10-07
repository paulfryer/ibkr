using IBKR.Api.Client.Infrastructure.RateLimiter;

namespace IBKR.Api.Client.Http.Infrastructure.Handlers;

/// <summary>
/// Delegating handler that enforces rate limiting on outgoing requests.
/// Uses the TokenBucketRateLimiter to ensure compliance with API rate limits.
/// </summary>
public class RateLimitHandler : DelegatingHandler
{
    private readonly IRateLimiter _rateLimiter;

    public RateLimitHandler(IRateLimiter rateLimiter)
    {
        _rateLimiter = rateLimiter ?? throw new ArgumentNullException(nameof(rateLimiter));
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // Wait for rate limiter to allow the request
        await _rateLimiter.WaitAsync(cancellationToken);

        // Send the request
        return await base.SendAsync(request, cancellationToken);
    }
}
