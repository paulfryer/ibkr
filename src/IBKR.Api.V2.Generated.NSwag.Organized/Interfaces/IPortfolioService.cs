using System.CodeDom.Compiler;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
///     Portfolio service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IPortfolioService
{
    Task<ICollection<AccountAttributes>> AccountsAllAsync(CancellationToken cancellationToken = default);

    Task<PortfolioAllocations> AllocationAsync(string accountId, object? model = null,
        CancellationToken cancellationToken = default);

    Task<Response24> InvalidateAsync(string accountId, CancellationToken cancellationToken = default);

    Task<IDictionary<string, Anonymous6>> LedgerAsync(string accountId, CancellationToken cancellationToken = default);

    Task<AccountAttributes> MetaAsync(string accountId, CancellationToken cancellationToken = default);

    Task<ICollection<IndividualPosition>> PositionAsync(string accountId, string conid,
        CancellationToken cancellationToken = default);

    Task<ICollection<IndividualPosition>> PositionsAllAsync(string accountId, string? pageId = null,
        object? model = null, object? sort = null, object? direction = null, bool? waitForSecDef = null,
        CancellationToken cancellationToken = default);

    Task<IDictionary<string, IndividualPosition>> PositionsAsync(string conid,
        CancellationToken cancellationToken = default);

    Task<ICollection<AccountAttributes>> SubaccountsAsync(CancellationToken cancellationToken = default);

    Task<PortfolioSummary> Summary2Async(string accountId, CancellationToken cancellationToken = default);
}