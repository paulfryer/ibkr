using Microsoft.Extensions.Logging;

namespace IBKR.Api.NSwag.Authentication;

/// <summary>
/// HTTP message handler that logs all request and response details for debugging
/// </summary>
public class LoggingHttpHandler : DelegatingHandler
{
    private readonly ILogger<LoggingHttpHandler> _logger;

    public LoggingHttpHandler(ILogger<LoggingHttpHandler> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        _logger.LogDebug("=== HTTP REQUEST ===");
        _logger.LogDebug("Method: {Method}", request.Method);
        _logger.LogDebug("URI: {Uri}", request.RequestUri);
        _logger.LogDebug("Headers:");
        foreach (var header in request.Headers)
        {
            _logger.LogDebug("  {HeaderKey}: {HeaderValue}", header.Key, string.Join(", ", header.Value));
        }

        if (request.Content != null)
        {
            _logger.LogDebug("Content Headers:");
            foreach (var header in request.Content.Headers)
            {
                _logger.LogDebug("  {HeaderKey}: {HeaderValue}", header.Key, string.Join(", ", header.Value));
            }

            var content = await request.Content.ReadAsStringAsync(cancellationToken);
            if (!string.IsNullOrEmpty(content))
            {
                _logger.LogDebug("Body: {Body}", content);
            }
        }

        var response = await base.SendAsync(request, cancellationToken);

        _logger.LogDebug("=== HTTP RESPONSE ===");
        _logger.LogDebug("Status: {StatusCode} {StatusText}", (int)response.StatusCode, response.StatusCode);
        _logger.LogDebug("Headers:");
        foreach (var header in response.Headers)
        {
            _logger.LogDebug("  {HeaderKey}: {HeaderValue}", header.Key, string.Join(", ", header.Value));
        }

        if (response.Content != null)
        {
            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogDebug("Body: {Body}", responseContent);
        }

        _logger.LogDebug("===================");

        return response;
    }
}
