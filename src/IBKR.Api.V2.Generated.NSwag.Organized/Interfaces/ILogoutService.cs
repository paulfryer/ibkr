using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
/// Logout service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface ILogoutService
{
	Task<Response20> LogoutAsync(CancellationToken cancellationToken = default(CancellationToken));

}
