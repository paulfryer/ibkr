using System.CodeDom.Compiler;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
///     Implementation of SsoService
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SsoService : ISsoService
{
    private readonly string _baseUrl;
    private readonly HttpClient _httpClient;
    private readonly Lazy<JsonSerializerSettings> _settings;

    public SsoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _settings = new Lazy<JsonSerializerSettings>(CreateSerializerSettings);
        _baseUrl = "https://api.ibkr.com";
    }

    protected JsonSerializerSettings JsonSerializerSettings => _settings.Value;

    public virtual async Task<SsoValidateResponse> ValidateAsync(CancellationToken cancellationToken = default)
    {
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            request_.Method = new HttpMethod("GET");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("sso/validate");
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
                switch (status_)
                {
                    case 200:
                    {
                        var objectResponse_2 =
                            await ReadObjectResponseAsync<SsoValidateResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_2.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_2.Text, headers_, null);
                        return objectResponse_2.Object;
                    }
                    case 401:
                    {
                        ObjectResponseResult<string?> objectResponse_ =
                            await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        throw new ApiException<string>("access denied", status_, objectResponse_.Text, headers_,
                            objectResponse_.Object, null);
                    }
                    default:
                    {
                        var text = response_.Content != null
                            ? await response_.Content.ReadAsStringAsync().ConfigureAwait(false)
                            : null;
                        var responseData_ = text;
                        throw new ApiException(
                            "The HTTP status code of the response was not expected (" + status_ + ").", status_,
                            responseData_, headers_, null);
                    }
                }
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