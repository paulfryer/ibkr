using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
///     Implementation of WsService
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class WsService : IWsService
{
    private readonly string _baseUrl;
    private readonly HttpClient _httpClient;
    private readonly Lazy<JsonSerializerSettings> _settings;

    public WsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _settings = new Lazy<JsonSerializerSettings>(CreateSerializerSettings);
        _baseUrl = "https://api.ibkr.com";
    }

    protected JsonSerializerSettings JsonSerializerSettings => _settings.Value;

    public virtual async System.Threading.Tasks.Task WsAsync(Connection connection, Upgrade upgrade, string api,
        string oauth_token, CancellationToken cancellationToken = default)
    {
        if (oauth_token == null) throw new ArgumentNullException("oauth_token");
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            request_.Headers.TryAddWithoutValidation("Connection",
                ConvertToString(connection, CultureInfo.InvariantCulture));
            request_.Headers.TryAddWithoutValidation("Upgrade", ConvertToString(upgrade, CultureInfo.InvariantCulture));
            request_.Method = new HttpMethod("GET");
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("ws");
            urlBuilder_.Append('?');
            urlBuilder_.Append(Uri.EscapeDataString("oauth_token")).Append('=')
                .Append(Uri.EscapeDataString(ConvertToString(oauth_token, CultureInfo.InvariantCulture)))
                .Append('&');
            urlBuilder_.Length--;
            var url_ = urlBuilder_.ToString();
            request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
            var response_ = await client_
                .SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            var disposeResponse_ = true;
            try
            {
                var headers_ = new Dictionary<string, IEnumerable<string>>();
                foreach (var item_ in response_.Headers) headers_[item_.Key] = item_.Value;
                if (response_.Content != null && response_.Content.Headers != null)
                    foreach (var item_2 in response_.Content.Headers)
                        headers_[item_2.Key] = item_2.Value;
                var status_ = (int)response_.StatusCode;
                int num;
                switch (status_)
                {
                    case 101:
                    {
                        var text = response_.Content != null
                            ? await response_.Content.ReadAsStringAsync().ConfigureAwait(false)
                            : string.Empty;
                        var responseText_ = text;
                        throw new ApiException("Successful request to switch protocols.", status_, responseText_,
                            headers_, null);
                    }
                    default:
                        num = status_ == 204 ? 1 : 0;
                        break;
                    case 200:
                        num = 1;
                        break;
                }

                if (num != 0) return;
                var text2 = response_.Content != null
                    ? await response_.Content.ReadAsStringAsync().ConfigureAwait(false)
                    : null;
                var responseData_ = text2;
                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").",
                    status_, responseData_, headers_, null);
            }
            finally
            {
                if (disposeResponse_) response_.Dispose();
            }
        }
        finally
        {
            if (disposeClient_) client_.Dispose();
        }
    }

    private JsonSerializerSettings CreateSerializerSettings()
    {
        var settings = new JsonSerializerSettings();
        UpdateJsonSerializerSettings(settings);
        return settings;
    }

    partial void UpdateJsonSerializerSettings(JsonSerializerSettings settings);

    protected string ConvertToString(object? value, CultureInfo cultureInfo)
    {
        if (value == null) return "";
        if (value is Enum) return string.Format(cultureInfo, "{0}", Convert.ToInt32(value));
        if (value is bool b) return Convert.ToString(b, cultureInfo)?.ToLowerInvariant() ?? "";
        if (value is byte[] bytes) return Convert.ToBase64String(bytes);
        return Convert.ToString(value, cultureInfo) ?? "";
    }

    protected virtual async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(HttpResponseMessage response,
        IReadOnlyDictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken)
    {
        if (response?.Content == null) return new ObjectResponseResult<T>(default, string.Empty);
        var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        try
        {
            var typedBody = JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
            return new ObjectResponseResult<T>(typedBody, responseText);
        }
        catch (JsonException exception)
        {
            var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
            throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
        }
    }

    // Helper methods from IBKRClient
    protected struct ObjectResponseResult<T>
    {
        public T Object { get; }
        public string Text { get; }

        public ObjectResponseResult(T responseObject, string responseText)
        {
            Object = responseObject;
            Text = responseText;
        }
    }
}