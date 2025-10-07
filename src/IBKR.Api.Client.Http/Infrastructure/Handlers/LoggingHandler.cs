using System.Diagnostics;
using IBKR.Api.Client.Core;
using Microsoft.Extensions.Options;

namespace IBKR.Api.Client.Http.Infrastructure.Handlers;

/// <summary>
/// Delegating handler that logs HTTP requests and responses for debugging.
/// Only active when logging is enabled in options.
/// </summary>
public class LoggingHandler : DelegatingHandler
{
    private readonly bool _loggingEnabled;

    public LoggingHandler(IOptions<IBKRClientOptions> options)
    {
        var opts = options?.Value ?? throw new ArgumentNullException(nameof(options));
        _loggingEnabled = opts.EnableLogging;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (!_loggingEnabled)
        {
            return await base.SendAsync(request, cancellationToken);
        }

        // Log request
        var stopwatch = Stopwatch.StartNew();
        var requestId = Guid.NewGuid().ToString("N")[..8];

        LogRequest(requestId, request);

        // Send request
        var response = await base.SendAsync(request, cancellationToken);

        // Log response
        stopwatch.Stop();
        await LogResponseAsync(requestId, response, stopwatch.ElapsedMilliseconds);

        return response;
    }

    private static void LogRequest(string requestId, HttpRequestMessage request)
    {
        Debug.WriteLine($"[{requestId}] HTTP {request.Method} {request.RequestUri}");

        if (request.Headers.Any())
        {
            Debug.WriteLine($"[{requestId}] Headers:");
            foreach (var header in request.Headers)
            {
                // Don't log sensitive authorization headers
                if (header.Key.Contains("Auth", StringComparison.OrdinalIgnoreCase) ||
                    header.Key.Contains("Token", StringComparison.OrdinalIgnoreCase))
                {
                    Debug.WriteLine($"[{requestId}]   {header.Key}: [REDACTED]");
                }
                else
                {
                    Debug.WriteLine($"[{requestId}]   {header.Key}: {string.Join(", ", header.Value)}");
                }
            }
        }
    }

    private static async Task LogResponseAsync(
        string requestId,
        HttpResponseMessage response,
        long elapsedMs)
    {
        Debug.WriteLine($"[{requestId}] HTTP {(int)response.StatusCode} {response.StatusCode} ({elapsedMs}ms)");

        if (response.Headers.Any())
        {
            Debug.WriteLine($"[{requestId}] Response Headers:");
            foreach (var header in response.Headers)
            {
                Debug.WriteLine($"[{requestId}]   {header.Key}: {string.Join(", ", header.Value)}");
            }
        }

        // Optionally log response body for debugging (be careful with large responses)
        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrWhiteSpace(content))
            {
                var preview = content.Length > 500 ? content[..500] + "..." : content;
                Debug.WriteLine($"[{requestId}] Error Response: {preview}");
            }
        }
    }
}
