using System.CodeDom.Compiler;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
///     Trsrv service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface ITrsrvService
{
    Task<ICollection<Anonymous7>> AllConidsAsync(string exchange, object? assetClass = null,
        CancellationToken cancellationToken = default);

    Task<Features> FuturesAsync(string symbols, object? exchange = null, CancellationToken cancellationToken = default);

    Task<ICollection<Anonymous8>> ScheduleAsync(AssetClass assetClass, string symbol, string? exchange = null,
        string? exchangeFilter = null, CancellationToken cancellationToken = default);

    Task<TrsrvSecDefResponse> SecdefAsync(string conids, object? criteria = null, object? bondp = null,
        CancellationToken cancellationToken = default);

    Task<IDictionary<string, ICollection<Anonymous9>>> StocksAsync(string symbols,
        CancellationToken cancellationToken = default);
}