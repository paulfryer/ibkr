namespace IBKR.Api.Authentication;

/// <summary>
/// Interface for IBKR OAuth2 authentication provider
/// </summary>
public interface IIBKRAuthenticationProvider
{
    /// <summary>
    /// Get a valid bearer token for API requests.
    /// Handles token caching and automatic refresh.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Bearer token string</returns>
    Task<string> GetBearerTokenAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Initialize brokerage session (ssodh/init).
    /// Must be called after authentication before making API calls.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if session initialized successfully</returns>
    Task<bool> InitializeSessionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Force token refresh (clear cache and re-authenticate)
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    Task RefreshAsync(CancellationToken cancellationToken = default);
}
