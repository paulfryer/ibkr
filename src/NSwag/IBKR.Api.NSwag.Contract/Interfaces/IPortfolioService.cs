using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IBKR.Api.NSwag.Contract.Models;

namespace IBKR.Api.NSwag.Contract.Interfaces;

/// <summary>
/// Portfolio service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IPortfolioService
{
	Task<ICollection<AccountAttributes>> AccountsAllAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<PortfolioAllocations> AllocationAsync(string accountId, object? model = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response24> InvalidateAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<IDictionary<string, Anonymous6>> LedgerAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<AccountAttributes> MetaAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<IndividualPosition>> PositionAsync(string accountId, string conid, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<IndividualPosition>> PositionsAllAsync(string accountId, string? pageId = null, object? model = null, object? sort = null, object? direction = null, bool? waitForSecDef = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<IDictionary<string, IndividualPosition>> PositionsAsync(string conid, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<AccountAttributes>> SubaccountsAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<PortfolioSummary> Summary2Async(string accountId, CancellationToken cancellationToken = default(CancellationToken));

}
