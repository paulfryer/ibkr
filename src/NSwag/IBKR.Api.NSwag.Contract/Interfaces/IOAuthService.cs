using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IBKR.Api.NSwag.Contract.Models;

namespace IBKR.Api.NSwag.Contract.Interfaces;

/// <summary>
/// OAuth service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IOAuthService
{
	Task<Response21> Access_tokenAsync(string? authorization = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<TokenResponse> GenerateTokenAsync(TokenRequest body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response22> Live_session_tokenAsync(string? authorization = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response23> Request_tokenAsync(string? authorization = null, CancellationToken cancellationToken = default(CancellationToken));

}
