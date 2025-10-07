using System.CodeDom.Compiler;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
///     OAuth service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IOAuthService
{
    Task<Response21> Access_tokenAsync(string? authorization = null, CancellationToken cancellationToken = default);

    Task<TokenResponse> GenerateTokenAsync(TokenRequest body, CancellationToken cancellationToken = default);

    Task<Response22> Live_session_tokenAsync(string? authorization = null,
        CancellationToken cancellationToken = default);

    Task<Response23> Request_tokenAsync(string? authorization = null, CancellationToken cancellationToken = default);
}