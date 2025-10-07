using System.CodeDom.Compiler;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
///     Tickle service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface ITickleService
{
    Task<SuccessfulTickleResponse> TickleAsync(CancellationToken cancellationToken = default);
}