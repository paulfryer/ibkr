using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;

namespace IBKR.Api.Kiota.MockClient;

/// <summary>
/// Mock implementation of IRequestAdapter for testing Kiota-based clients.
/// Returns canned responses without making actual HTTP requests.
/// </summary>
public class MockRequestAdapter : IRequestAdapter
{
    private readonly Dictionary<string, object> _cannedResponses = new();

    public ISerializationWriterFactory SerializationWriterFactory { get; set; } = null!;
    public IParseNodeFactory ParseNodeFactory { get; set; } = null!;
    public string? BaseUrl { get; set; } = "https://mock.api.ibkr.com";

    /// <summary>
    /// Register a canned response for a specific request path.
    /// </summary>
    public void SetCannedResponse<T>(string path, T response)
    {
        _cannedResponses[path] = response!;
    }

    public Task<T?> ConvertToNativeRequestAsync<T>(RequestInformation requestInfo, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("ConvertToNativeRequestAsync is not supported in mock mode");
    }

    public async Task<ModelType?> SendAsync<ModelType>(
        RequestInformation requestInfo,
        ParsableFactory<ModelType> factory,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default) where ModelType : IParsable
    {
        var path = requestInfo.URI.PathAndQuery;

        if (_cannedResponses.TryGetValue(path, out var response))
        {
            return await Task.FromResult((ModelType?)response);
        }

        throw new InvalidOperationException($"No canned response configured for: {path}");
    }

    public async Task<IEnumerable<ModelType>?> SendCollectionAsync<ModelType>(
        RequestInformation requestInfo,
        ParsableFactory<ModelType> factory,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default) where ModelType : IParsable
    {
        var path = requestInfo.URI.PathAndQuery;

        if (_cannedResponses.TryGetValue(path, out var response))
        {
            return await Task.FromResult((IEnumerable<ModelType>?)response);
        }

        throw new InvalidOperationException($"No canned response configured for: {path}");
    }

    public async Task<ModelType?> SendPrimitiveAsync<ModelType>(
        RequestInformation requestInfo,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default)
    {
        var path = requestInfo.URI.PathAndQuery;

        if (_cannedResponses.TryGetValue(path, out var response))
        {
            return await Task.FromResult((ModelType?)response);
        }

        throw new InvalidOperationException($"No canned response configured for: {path}");
    }

    public async Task<IEnumerable<ModelType>?> SendPrimitiveCollectionAsync<ModelType>(
        RequestInformation requestInfo,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default)
    {
        var path = requestInfo.URI.PathAndQuery;

        if (_cannedResponses.TryGetValue(path, out var response))
        {
            return await Task.FromResult((IEnumerable<ModelType>?)response);
        }

        throw new InvalidOperationException($"No canned response configured for: {path}");
    }

    public Task SendNoContentAsync(
        RequestInformation requestInfo,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public void EnableBackingStore(IBackingStoreFactory backingStoreFactory)
    {
        // No-op for mock
    }

    public IAuthenticationProvider AuthenticationProvider { get; set; } = null!;
}
