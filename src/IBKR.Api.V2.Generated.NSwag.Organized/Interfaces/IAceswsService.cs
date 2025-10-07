using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
/// Acesws service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IAceswsService
{
	Task<SignatureAndOwners> SignaturesAndOwnersAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

}
