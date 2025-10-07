using IBKR.Api.Authentication;

namespace IBKR.Api.NSwag.Authentication;

/// <summary>
/// HTTP message handler that adds IBKR authentication to outgoing requests
/// </summary>
public class IBKRAuthenticationHandler : DelegatingHandler
{
    private readonly IIBKRAuthenticationProvider _authProvider;
    private bool _sessionInitialized;
    private readonly SemaphoreSlim _initLock = new(1, 1);

    public IBKRAuthenticationHandler(IIBKRAuthenticationProvider authProvider)
    {
        _authProvider = authProvider ?? throw new ArgumentNullException(nameof(authProvider));
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // Ensure session is initialized (only once)
        if (!_sessionInitialized)
        {
            await _initLock.WaitAsync(cancellationToken);
            try
            {
                if (!_sessionInitialized)
                {
                    await _authProvider.InitializeSessionAsync(cancellationToken);
                    _sessionInitialized = true;
                }
            }
            finally
            {
                _initLock.Release();
            }
        }

        // Get bearer token
        var bearerToken = await _authProvider.GetBearerTokenAsync(cancellationToken);

        // Add authorization header
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

        // Send the request
        return await base.SendAsync(request, cancellationToken);
    }
}
