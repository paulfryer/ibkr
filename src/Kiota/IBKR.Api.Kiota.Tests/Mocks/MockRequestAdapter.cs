using IBKR.Api.Kiota.Contract.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using Microsoft.Kiota.Serialization.Json;
using Microsoft.Kiota.Serialization.Text;

namespace IBKR.Api.Kiota.MockClient;

/// <summary>
/// Mock implementation of IRequestAdapter for testing Kiota-based clients.
/// Returns canned responses without making actual HTTP requests.
/// </summary>
public class MockRequestAdapter : IRequestAdapter
{
    public ISerializationWriterFactory SerializationWriterFactory { get; set; }
    public IParseNodeFactory ParseNodeFactory { get; set; }
    public string? BaseUrl { get; set; } = "https://mock.api.ibkr.com";
    public IAuthenticationProvider AuthenticationProvider { get; set; } = new AnonymousAuthenticationProvider();

    public MockRequestAdapter()
    {
        // Initialize the factories to avoid null reference exceptions
        SerializationWriterFactory = new JsonSerializationWriterFactory();
        ParseNodeFactory = new JsonParseNodeFactory();
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
        var path = requestInfo.URI.AbsolutePath;
        var fullPath = requestInfo.URI.ToString();

        try
        {
            var response = GetMockResponse(path, fullPath);

            if (response is ModelType typedResponse)
            {
                return await Task.FromResult(typedResponse);
            }

            throw new InvalidOperationException($"Mock response type mismatch. Expected {typeof(ModelType).Name}, got {response.GetType().Name} for path: {path}");
        }
        catch (Exception ex) when (ex is not InvalidOperationException)
        {
            throw new InvalidOperationException($"Error getting mock response for {path}: {ex.Message}", ex);
        }
    }

    public async Task<IEnumerable<ModelType>?> SendCollectionAsync<ModelType>(
        RequestInformation requestInfo,
        ParsableFactory<ModelType> factory,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default) where ModelType : IParsable
    {
        var path = requestInfo.URI.AbsolutePath;
        var fullPath = requestInfo.URI.ToString();
        var response = GetMockResponse(path, fullPath);

        if (response is IEnumerable<ModelType> typedResponse)
        {
            return await Task.FromResult(typedResponse);
        }

        throw new InvalidOperationException($"Mock response type mismatch for collection. Expected IEnumerable<{typeof(ModelType).Name}>, got {response.GetType().Name} for path: {path}");
    }

    public async Task<ModelType?> SendPrimitiveAsync<ModelType>(
        RequestInformation requestInfo,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default)
    {
        var path = requestInfo.URI.AbsolutePath;
        var fullPath = requestInfo.URI.ToString();
        var response = GetMockResponse(path, fullPath);

        if (response is ModelType typedResponse)
        {
            return await Task.FromResult(typedResponse);
        }

        throw new InvalidOperationException($"Mock response type mismatch. Expected {typeof(ModelType).Name}, got {response.GetType().Name} for path: {path}");
    }

    public async Task<IEnumerable<ModelType>?> SendPrimitiveCollectionAsync<ModelType>(
        RequestInformation requestInfo,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default)
    {
        var path = requestInfo.URI.AbsolutePath;
        var fullPath = requestInfo.URI.ToString();
        var response = GetMockResponse(path, fullPath);

        if (response is IEnumerable<ModelType> typedResponse)
        {
            return await Task.FromResult(typedResponse);
        }

        throw new InvalidOperationException($"Mock response type mismatch for primitive collection. Expected IEnumerable<{typeof(ModelType).Name}>, got {response.GetType().Name} for path: {path}");
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

    /// <summary>
    /// Returns mock data based on the request path.
    /// This method contains hardcoded mock responses for testing.
    /// </summary>
    private object GetMockResponse(string path, string fullPath)
    {
        // Stock search - /iserver/secdef/search
        if (path.Contains("/iserver/secdef/search") || path.EndsWith("/search"))
        {
            // Extract symbol from query string
            var symbol = "AAPL"; // default
            if (fullPath.Contains("symbol="))
            {
                var symbolParam = fullPath.Split(new[] { "symbol=" }, StringSplitOptions.None)[1].Split('&')[0];
                symbol = Uri.UnescapeDataString(symbolParam).ToUpper();
            }

            // Mock data for common symbols
            var mockData = new Dictionary<string, (string conid, string companyName)>
            {
                { "AAPL", ("265598", "Apple Inc.") },
                { "AMZN", ("3691937", "Amazon.com Inc.") },
                { "TSLA", ("76792991", "Tesla Inc.") },
                { "MSFT", ("272093", "Microsoft Corp.") },
                { "GOOGL", ("208813719", "Alphabet Inc.") }
            };

            if (mockData.TryGetValue(symbol, out var data))
            {
                return new List<SecdefSearchResponse>
                {
                    new SecdefSearchResponse
                    {
                        Conid = data.conid,
                        Symbol = symbol,
                        CompanyName = data.companyName,
                        CompanyHeader = $"{symbol} - NASDAQ",
                        Description = "NASDAQ"
                    }
                };
            }

            // Default fallback for unknown symbols
            return new List<SecdefSearchResponse>
            {
                new SecdefSearchResponse
                {
                    Conid = "999999",
                    Symbol = symbol,
                    CompanyName = $"{symbol} Test Company",
                    CompanyHeader = $"{symbol} - NYSE",
                    Description = "NYSE"
                }
            };
        }

        // Market data snapshot - /iserver/marketdata/snapshot
        if (path.Contains("/iserver/marketdata/snapshot") || path.EndsWith("/snapshot"))
        {
            return new FyiVT
            {
                V = 1,
                T = 100,
                AdditionalData = new Dictionary<string, object>
                {
                    { "31", "150.25" },  // Last Price
                    { "84", "150.20" },  // Bid
                    { "86", "150.30" },  // Ask
                    { "85", 100 },       // Ask Size
                    { "88", 200 }        // Bid Size
                }
            };
        }

        // Regulatory snapshot - /md/regsnapshot
        if (path.Contains("/md/regsnapshot") || path.EndsWith("/regsnapshot"))
        {
            return new RegsnapshotData
            {
                Conid = 265598,
                ConidEx = "265598",
                EightFour = "150.20",    // Bid (field 84)
                EightSix = "150.30",     // Ask (field 86)
                EightEight = 200,        // Bid Size (field 88)
                EightFive = 100,         // Ask Size (field 85)
                AdditionalData = new Dictionary<string, object>
                {
                    { "31", "150.25" }   // Last Price
                }
            };
        }

        // Option strikes - /v1/api/iserver/secdef/strikes
        if (path.Contains("/iserver/secdef/strikes") || path.EndsWith("/strikes"))
        {
            return new IBKR.Api.Kiota.Client.V1.Api.Iserver.Secdef.Strikes.StrikesGetResponse
            {
                Call = new List<double?> { 145, 150, 155, 160 },
                Put = new List<double?> { 145, 150, 155, 160 }
            };
        }

        // Option contract info - /iserver/secdef/info
        if (path.Contains("/iserver/secdef/info") || path.EndsWith("/info"))
        {
            // Parse query parameters
            var isPut = fullPath.Contains("right=P") || fullPath.Contains("right%3DP");
            var right = isPut ? SecDefInfoResponse_right.P : SecDefInfoResponse_right.C;

            // Extract strike from query string
            double strike = 150.0; // default
            if (fullPath.Contains("strike="))
            {
                var strikeParam = fullPath.Split(new[] { "strike=" }, StringSplitOptions.None)[1].Split('&')[0];
                if (double.TryParse(Uri.UnescapeDataString(strikeParam), out var parsedStrike))
                {
                    strike = parsedStrike;
                }
            }

            // Extract month/expiration from query string
            string maturityDate = "20250117"; // default
            if (fullPath.Contains("month="))
            {
                var monthParam = fullPath.Split(new[] { "month=" }, StringSplitOptions.None)[1].Split('&')[0];
                var monthStr = Uri.UnescapeDataString(monthParam);

                // If month is in YYYYMM format, convert to third Friday of that month
                if (monthStr.Length == 6)
                {
                    var year = int.Parse(monthStr.Substring(0, 4));
                    var monthNum = int.Parse(monthStr.Substring(4, 2));
                    var firstDay = new DateTime(year, monthNum, 1);
                    var firstFriday = firstDay;
                    while (firstFriday.DayOfWeek != DayOfWeek.Friday)
                        firstFriday = firstFriday.AddDays(1);
                    var thirdFriday = firstFriday.AddDays(14);
                    maturityDate = thirdFriday.ToString("yyyyMMdd");
                }
                else
                {
                    maturityDate = monthStr;
                }
            }

            return new SecDefInfoResponse
            {
                Conid = 12345 + (int)strike, // Unique conid per strike
                Ticker = "AAPL",
                Right = right,
                Strike = strike,
                MaturityDate = maturityDate
            };
        }

        throw new InvalidOperationException($"No mock response configured for path: {path}");
    }
}
