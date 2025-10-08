using System.Net.Http.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IBKR.Sdk.Authentication;

/// <summary>
/// IBKR OAuth2 authentication provider implementing 3-step flow:
/// 1. Request Access Token (OAuth2 with JWT client assertion)
/// 2. Request Bearer Token (SSO session with signed JWT)
/// 3. Initialize Brokerage Session
/// </summary>
public class IBKRAuthenticationProvider : IIBKRAuthenticationProvider, IDisposable
{
    private readonly IBKRAuthenticationOptions _options;
    private readonly HttpClient _httpClient;
    private readonly JwtSigner _jwtSigner;
    private readonly TokenCache _tokenCache;
    private bool _sessionInitialized;
    private readonly SemaphoreSlim _sessionInitLock = new(1, 1);

    public IBKRAuthenticationProvider(IBKRAuthenticationOptions options, HttpClient? httpClient = null)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _options.Validate();

        _httpClient = httpClient ?? new HttpClient();
        _jwtSigner = new JwtSigner(_options.ClientPemPath, _options.ClientKeyId);
        _tokenCache = new TokenCache();
        _sessionInitialized = false;
    }

    /// <summary>
    /// Get bearer token (with automatic caching and refresh)
    /// </summary>
    public async Task<string> GetBearerTokenAsync(CancellationToken cancellationToken = default)
    {
        // Check cache first
        var cachedToken = await _tokenCache.GetTokenAsync();
        if (cachedToken != null)
        {
            return cachedToken;
        }

        // Token expired or not cached - authenticate
        await AuthenticateAsync(cancellationToken);

        // Return newly cached token
        var token = await _tokenCache.GetTokenAsync();
        return token ?? throw new InvalidOperationException("Failed to obtain bearer token");
    }

    /// <summary>
    /// Initialize brokerage session (must be called after authentication).
    /// Thread-safe: Multiple simultaneous calls will result in only one initialization.
    /// </summary>
    public async Task<bool> InitializeSessionAsync(CancellationToken cancellationToken = default)
    {
        // Fast path: if already initialized, return immediately without locking
        if (_sessionInitialized)
        {
            return true;
        }

        // Thread-safe initialization: only one thread will initialize
        await _sessionInitLock.WaitAsync(cancellationToken);
        try
        {
            // Double-check after acquiring lock (another thread may have initialized)
            if (_sessionInitialized)
            {
                return true;
            }

            var bearerToken = await GetBearerTokenAsync(cancellationToken);

            var endpoint = $"{_options.BaseUrl}/v1/api/iserver/auth/ssodh/init";
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

            AddStandardHeaders(request);
            request.Headers.Add("Authorization", $"Bearer {bearerToken}");

            var content = JsonConvert.SerializeObject(new { compete = true, publish = true });
            request.Content = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            var session = JsonConvert.DeserializeObject<SessionResponse>(responseContent);

            _sessionInitialized = session?.Authenticated == true && session?.Connected == true;

            if (!_sessionInitialized)
            {
                throw new InvalidOperationException("Session not authenticated or connected");
            }

            return _sessionInitialized;
        }
        finally
        {
            _sessionInitLock.Release();
        }
    }

    /// <summary>
    /// Force token refresh
    /// </summary>
    public async Task RefreshAsync(CancellationToken cancellationToken = default)
    {
        await _tokenCache.ClearAsync();
        _sessionInitialized = false;
        await AuthenticateAsync(cancellationToken);
        await InitializeSessionAsync(cancellationToken);
    }

    /// <summary>
    /// Complete 2-step authentication flow
    /// </summary>
    private async Task AuthenticateAsync(CancellationToken cancellationToken)
    {
        // Step 1: Request Access Token
        var accessToken = await RequestAccessTokenAsync(cancellationToken);

        // Step 2: Request Bearer Token
        var bearerToken = await RequestBearerTokenAsync(accessToken, cancellationToken);

        // Cache bearer token
        await _tokenCache.SetTokenAsync(bearerToken, _options.TokenCacheMinutes);
    }

    /// <summary>
    /// Step 1: Request OAuth2 access token using JWT client assertion
    /// </summary>
    private async Task<string> RequestAccessTokenAsync(CancellationToken cancellationToken)
    {
        var endpoint = $"{_options.BaseUrl}/oauth2/api/v1/token";
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

        AddStandardHeaders(request);

        // Create JWT client assertion
        var clientAssertion = _jwtSigner.CreateClientAssertion(_options.ClientId);

        // Build form content
        var formData = new Dictionary<string, string>
        {
            { "client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer" },
            { "client_assertion", clientAssertion },
            { "grant_type", "client_credentials" },
            { "scope", "sso-sessions.write" }
        };

        request.Content = new FormUrlEncodedContent(formData);

        var response = await _httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        var json = JObject.Parse(responseContent);

        var accessToken = json.SelectToken("access_token")?.ToString();
        if (string.IsNullOrEmpty(accessToken))
        {
            throw new InvalidOperationException("Failed to obtain access token");
        }

        return accessToken;
    }

    /// <summary>
    /// Step 2: Request bearer token (SSO session) using access token and signed JWT
    /// </summary>
    private async Task<string> RequestBearerTokenAsync(string accessToken, CancellationToken cancellationToken)
    {
        var endpoint = $"{_options.BaseUrl}/gw/api/v1/sso-sessions";
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

        AddStandardHeaders(request);
        request.Headers.Add("Authorization", $"Bearer {accessToken}");

        // Get public IP address
        var ipAddress = await GetPublicIpAddressAsync(cancellationToken);

        // Create signed request JWT
        var signedRequest = _jwtSigner.CreateSignedRequest(_options.ClientId, _options.Credential, ipAddress);

        request.Content = new StringContent(signedRequest, System.Text.Encoding.UTF8, "application/text");

        var response = await _httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        var json = JObject.Parse(responseContent);

        var bearerToken = json.SelectToken("access_token")?.ToString();
        if (string.IsNullOrEmpty(bearerToken))
        {
            throw new InvalidOperationException("Failed to obtain bearer token");
        }

        return bearerToken;
    }

    /// <summary>
    /// Get public IP address via api.ipify.org
    /// </summary>
    private async Task<string> GetPublicIpAddressAsync(CancellationToken cancellationToken)
    {
        try
        {
            var response = await _httpClient.GetStringAsync("https://api.ipify.org", cancellationToken);
            return response.Trim();
        }
        catch
        {
            // Fallback to localhost if ipify fails
            return "127.0.0.1";
        }
    }

    /// <summary>
    /// Add standard headers to request
    /// </summary>
    private void AddStandardHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("Host", "api.ibkr.com");
        request.Headers.Add("Cache-Control", "no-cache");
        request.Headers.Add("User-Agent", "CSharp/IBKR-SDK");
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("Connection", "keep-alive");
    }

    /// <summary>
    /// Session response model
    /// </summary>
    private class SessionResponse
    {
        public bool Authenticated { get; set; }
        public bool Connected { get; set; }
        public bool Competing { get; set; }
        public string? Message { get; set; }
    }

    /// <summary>
    /// Dispose pattern to clean up semaphore
    /// </summary>
    public void Dispose()
    {
        _sessionInitLock?.Dispose();
    }
}
