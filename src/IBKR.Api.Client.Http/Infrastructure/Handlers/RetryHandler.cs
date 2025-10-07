using System.Net;
using IBKR.Api.Client.Core;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;

namespace IBKR.Api.Client.Http.Infrastructure.Handlers;

/// <summary>
/// Delegating handler that implements retry logic for transient HTTP failures.
/// Uses Polly for exponential backoff retry policy.
/// </summary>
public class RetryHandler : DelegatingHandler
{
    private readonly ResiliencePipeline<HttpResponseMessage> _retryPipeline;

    public RetryHandler(IOptions<IBKRClientOptions> options)
    {
        var opts = options?.Value ?? throw new ArgumentNullException(nameof(options));

        // Build Polly resilience pipeline if retry is enabled
        if (opts.EnableRetry)
        {
            _retryPipeline = new ResiliencePipelineBuilder<HttpResponseMessage>()
                .AddRetry(new RetryStrategyOptions<HttpResponseMessage>
                {
                    MaxRetryAttempts = opts.MaxRetryAttempts,
                    Delay = TimeSpan.FromMilliseconds(opts.RetryDelayMilliseconds),
                    BackoffType = DelayBackoffType.Exponential,
                    ShouldHandle = new PredicateBuilder<HttpResponseMessage>()
                        .Handle<HttpRequestException>()
                        .HandleResult(response => IsTransientHttpError(response.StatusCode)),
                    OnRetry = args =>
                    {
                        // TODO: Add logging here when logger is available
                        // _logger.LogWarning($"Retry attempt {args.AttemptNumber} after {args.RetryDelay}");
                        return ValueTask.CompletedTask;
                    }
                })
                .Build();
        }
        else
        {
            // No retry - pass through
            _retryPipeline = ResiliencePipeline<HttpResponseMessage>.Empty;
        }
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await _retryPipeline.ExecuteAsync(
            async ct => await base.SendAsync(request, ct),
            cancellationToken);
    }

    /// <summary>
    /// Determines if an HTTP status code represents a transient error that should be retried.
    /// </summary>
    private static bool IsTransientHttpError(HttpStatusCode statusCode)
    {
        return statusCode switch
        {
            HttpStatusCode.RequestTimeout => true,
            HttpStatusCode.TooManyRequests => true,
            HttpStatusCode.InternalServerError => true,
            HttpStatusCode.BadGateway => true,
            HttpStatusCode.ServiceUnavailable => true,
            HttpStatusCode.GatewayTimeout => true,
            _ => false
        };
    }
}
