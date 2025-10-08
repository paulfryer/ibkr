using IBKR.Api.Authentication;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

namespace IBKR.Api.Kiota.Authentication;

/// <summary>
/// Kiota authentication provider that adds IBKR bearer token to requests
/// </summary>
public class IBKRKiotaAuthenticationProvider : IAuthenticationProvider
{
    private readonly IIBKRAuthenticationProvider _authProvider;
    private bool _sessionInitialized;
    private readonly SemaphoreSlim _initLock = new(1, 1);

    public IBKRKiotaAuthenticationProvider(IIBKRAuthenticationProvider authProvider)
    {
        _authProvider = authProvider ?? throw new ArgumentNullException(nameof(authProvider));
    }

    /// <summary>
    /// Authenticate request by adding bearer token header
    /// </summary>
    public async Task AuthenticateRequestAsync(
        RequestInformation request,
        Dictionary<string, object>? additionalAuthenticationContext = null,
        CancellationToken cancellationToken = default)
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

        // Add required IBKR API headers (matching working implementation)
        request.Headers.Add("Host", "api.ibkr.com");
        request.Headers.Add("User-Agent", "CSharp/IBKR-SDK");
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("Connection", "keep-alive");

        // Add authorization header
        request.Headers.Add("Authorization", $"Bearer {bearerToken}");
    }
}
