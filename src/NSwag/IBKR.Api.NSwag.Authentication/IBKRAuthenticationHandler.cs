using IBKR.Sdk.Authentication;

namespace IBKR.Api.NSwag.Authentication;

/// <summary>
/// HTTP message handler that adds IBKR authentication to outgoing requests.
/// Thread-safe: relies on IIBKRAuthenticationProvider's thread-safe session initialization.
/// </summary>
public class IBKRAuthenticationHandler : DelegatingHandler
{
    private readonly IIBKRAuthenticationProvider _authProvider;

    public IBKRAuthenticationHandler(IIBKRAuthenticationProvider authProvider)
    {
        _authProvider = authProvider ?? throw new ArgumentNullException(nameof(authProvider));
        Console.WriteLine("[IBKRAuthenticationHandler] Handler instance created");
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        Console.WriteLine($"[IBKRAuthenticationHandler] SendAsync called for: {request.RequestUri}");

        // Ensure session is initialized (provider handles thread-safety and idempotency)
        await _authProvider.InitializeSessionAsync(cancellationToken);

        // Get bearer token
        var bearerToken = await _authProvider.GetBearerTokenAsync(cancellationToken);
        Console.WriteLine($"[IBKRAuthenticationHandler] Got bearer token: {bearerToken?.Substring(0, Math.Min(20, bearerToken?.Length ?? 0))}...");

        // Add required IBKR API headers (matching working implementation)
        request.Headers.TryAddWithoutValidation("Host", "api.ibkr.com");
        request.Headers.TryAddWithoutValidation("User-Agent", "CSharp/IBKR-SDK");
        request.Headers.TryAddWithoutValidation("Accept", "*/*");
        request.Headers.TryAddWithoutValidation("Connection", "keep-alive");

        // Add authorization header
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
        Console.WriteLine($"[IBKRAuthenticationHandler] Authorization header set: {request.Headers.Authorization}");

        // Send the request
        return await base.SendAsync(request, cancellationToken);
    }
}
