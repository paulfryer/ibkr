using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
/// Hmds service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IHmdsService
{
	Task<HmdsHistoryResponse> HistoryAsync(string conid, string period, string bar, BarType? barType = null, string? startTime = null, string? direction = null, bool? outsideRth = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<HmdsScannerParams> ParamsAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<Response6> RunAsync(HmdsScannerRunRequest body, CancellationToken cancellationToken = default(CancellationToken));

}
