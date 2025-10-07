using System.Net.Http.Headers;
using IBKR.Api.Client.Core;
using Microsoft.Extensions.Options;

namespace IBKR.Api.Client.Http.Infrastructure.Handlers;

/// <summary>
/// Delegating handler that adds authentication to outgoing requests.
/// Supports both Bearer token and Access token authentication.
/// </summary>
public class AuthenticationHandler : DelegatingHandler
{
    private readonly IBKRClientOptions _options;

    public AuthenticationHandler(IOptions<IBKRClientOptions> options)
    {
        _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // Add Bearer token if configured
        if (!string.IsNullOrEmpty(_options.BearerToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.BearerToken);
        }
        // Add Access token as custom header if configured
        else if (!string.IsNullOrEmpty(_options.AccessToken))
        {
            request.Headers.Add("X-IBKR-AccessToken", _options.AccessToken);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
