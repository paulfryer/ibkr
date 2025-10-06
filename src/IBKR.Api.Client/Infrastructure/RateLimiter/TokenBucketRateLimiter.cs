using System.Diagnostics;

namespace IBKR.Api.Client.Infrastructure.RateLimiter;

/// <summary>
/// Token bucket rate limiter implementation.
/// Allows bursts up to the bucket capacity while maintaining an average rate.
/// </summary>
public class TokenBucketRateLimiter : IRateLimiter
{
    private readonly int _maxTokens;
    private readonly TimeSpan _refillInterval;
    private readonly SemaphoreSlim _semaphore = new(1, 1);
    private double _availableTokens;
    private long _lastRefillTicks;

    /// <summary>
    /// Initializes a new instance of the <see cref="TokenBucketRateLimiter"/> class.
    /// </summary>
    /// <param name="requestsPerSecond">Maximum number of requests per second.</param>
    public TokenBucketRateLimiter(int requestsPerSecond)
    {
        if (requestsPerSecond <= 0)
        {
            throw new ArgumentException("Requests per second must be greater than zero.", nameof(requestsPerSecond));
        }

        _maxTokens = requestsPerSecond;
        _availableTokens = requestsPerSecond;
        _refillInterval = TimeSpan.FromSeconds(1.0 / requestsPerSecond);
        _lastRefillTicks = Stopwatch.GetTimestamp();
    }

    /// <inheritdoc/>
    public async Task WaitAsync(CancellationToken cancellationToken = default)
    {
        await _semaphore.WaitAsync(cancellationToken);
        try
        {
            while (true)
            {
                RefillTokens();

                if (_availableTokens >= 1.0)
                {
                    _availableTokens -= 1.0;
                    return;
                }

                // Calculate how long to wait for the next token
                var tokensNeeded = 1.0 - _availableTokens;
                var waitTime = TimeSpan.FromTicks((long)(tokensNeeded * _refillInterval.Ticks));

                // Release the semaphore while waiting
                _semaphore.Release();

                try
                {
                    await Task.Delay(waitTime, cancellationToken);
                }
                finally
                {
                    await _semaphore.WaitAsync(cancellationToken);
                }
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }

    /// <inheritdoc/>
    public bool TryAcquire()
    {
        if (!_semaphore.Wait(0))
        {
            return false;
        }

        try
        {
            RefillTokens();

            if (_availableTokens >= 1.0)
            {
                _availableTokens -= 1.0;
                return true;
            }

            return false;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    private void RefillTokens()
    {
        var now = Stopwatch.GetTimestamp();
        var elapsed = TimeSpan.FromTicks(now - _lastRefillTicks);
        var tokensToAdd = elapsed.TotalSeconds * _maxTokens;

        _availableTokens = Math.Min(_maxTokens, _availableTokens + tokensToAdd);
        _lastRefillTicks = now;
    }
}
