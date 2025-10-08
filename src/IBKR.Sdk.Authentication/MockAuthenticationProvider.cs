namespace IBKR.Sdk.Authentication;

/// <summary>
/// Mock authentication provider for testing without real IBKR credentials.
/// Returns fake bearer tokens and always reports successful session initialization.
/// </summary>
public class MockAuthenticationProvider : IIBKRAuthenticationProvider
{
    private readonly string _mockToken;

    /// <summary>
    /// Create mock authentication provider with default token
    /// </summary>
    public MockAuthenticationProvider()
        : this("mock-bearer-token-12345")
    {
    }

    /// <summary>
    /// Create mock authentication provider with custom token
    /// </summary>
    /// <param name="mockToken">Token to return from GetBearerTokenAsync</param>
    public MockAuthenticationProvider(string mockToken)
    {
        _mockToken = mockToken ?? throw new ArgumentNullException(nameof(mockToken));
    }

    /// <summary>
    /// Get mock bearer token (always returns the same token)
    /// </summary>
    public Task<string> GetBearerTokenAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_mockToken);
    }

    /// <summary>
    /// Mock session initialization (always succeeds)
    /// </summary>
    public Task<bool> InitializeSessionAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }

    /// <summary>
    /// Mock refresh (no-op)
    /// </summary>
    public Task RefreshAsync(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}
