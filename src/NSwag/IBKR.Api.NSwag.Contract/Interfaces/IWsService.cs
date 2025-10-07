using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IBKR.Api.NSwag.Contract.Models;

namespace IBKR.Api.NSwag.Contract.Interfaces;

/// <summary>
/// Ws service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IWsService
{
	System.Threading.Tasks.Task WsAsync(Connection connection, Upgrade upgrade, string api, string oauth_token, CancellationToken cancellationToken = default(CancellationToken));

}
