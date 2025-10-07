using System.CodeDom.Compiler;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FileResponse : IDisposable
{
    private readonly IDisposable? _client;

    private readonly IDisposable? _response;

    public FileResponse(int statusCode, IReadOnlyDictionary<string, IEnumerable<string>> headers, Stream stream,
        IDisposable? client, IDisposable? response)
    {
        StatusCode = statusCode;
        Headers = headers;
        Stream = stream;
        _client = client;
        _response = response;
    }

    public int StatusCode { get; }

    public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; private set; }

    public Stream Stream { get; }

    public bool IsPartial => StatusCode == 206;

    public void Dispose()
    {
        Stream.Dispose();
        if (_response != null) _response.Dispose();
        if (_client != null) _client.Dispose();
    }
}