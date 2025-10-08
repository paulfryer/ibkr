namespace IBKR.Sdk.Authentication;

/// <summary>
/// Simple in-memory token cache with expiration
/// </summary>
internal class TokenCache
{
    private string? _token;
    private DateTimeOffset _expiration = DateTimeOffset.MinValue;
    private readonly SemaphoreSlim _lock = new(1, 1);

    /// <summary>
    /// Get cached token if valid, otherwise return null
    /// </summary>
    public async Task<string?> GetTokenAsync()
    {
        await _lock.WaitAsync();
        try
        {
            if (_token != null && DateTimeOffset.UtcNow < _expiration)
            {
                return _token;
            }
            return null;
        }
        finally
        {
            _lock.Release();
        }
    }

    /// <summary>
    /// Store token with expiration
    /// </summary>
    public async Task SetTokenAsync(string token, int lifetimeMinutes)
    {
        await _lock.WaitAsync();
        try
        {
            _token = token;
            _expiration = DateTimeOffset.UtcNow.AddMinutes(lifetimeMinutes);
        }
        finally
        {
            _lock.Release();
        }
    }

    /// <summary>
    /// Clear cached token
    /// </summary>
    public async Task ClearAsync()
    {
        await _lock.WaitAsync();
        try
        {
            _token = null;
            _expiration = DateTimeOffset.MinValue;
        }
        finally
        {
            _lock.Release();
        }
    }
}
