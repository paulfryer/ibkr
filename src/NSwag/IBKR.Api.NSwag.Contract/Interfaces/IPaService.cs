using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IBKR.Api.NSwag.Contract.Models;

namespace IBKR.Api.NSwag.Contract.Interfaces;

/// <summary>
/// Pa service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IPaService
{
	Task<DetailedContractInformation> AllperiodsAsync(Body24 body, string? param0 = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<PerformanceResponse> PerformanceAsync(Body25 body, CancellationToken cancellationToken = default(CancellationToken));

	Task<TransactionsResponse> TransactionsAsync(Body26 body, CancellationToken cancellationToken = default(CancellationToken));

}
