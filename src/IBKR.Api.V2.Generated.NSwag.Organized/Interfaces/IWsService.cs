using System.CodeDom.Compiler;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
///     Ws service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IWsService
{
    System.Threading.Tasks.Task WsAsync(Connection connection, Upgrade upgrade, string api, string oauth_token,
        CancellationToken cancellationToken = default);
}