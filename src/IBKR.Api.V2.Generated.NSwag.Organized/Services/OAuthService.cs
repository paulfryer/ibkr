using System.CodeDom.Compiler;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
///     Implementation of OAuthService
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class OAuthService : IOAuthService
{
    private readonly string _baseUrl;
    private readonly HttpClient _httpClient;
    private readonly Lazy<JsonSerializerSettings> _settings;

    public OAuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _settings = new Lazy<JsonSerializerSettings>(CreateSerializerSettings);
        _baseUrl = "https://api.ibkr.com";
    }

    protected JsonSerializerSettings JsonSerializerSettings => _settings.Value;

    public virtual async Task<Response21> Access_tokenAsync(string? authorization = null,
        CancellationToken cancellationToken = default)
    {
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            if (authorization != null)
                request_.Headers.TryAddWithoutValidation("Authorization",
                    ConvertToString(authorization, CultureInfo.InvariantCulture));
            request_.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            request_.Method = new HttpMethod("POST");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("oauth/access_token");
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
                            await ReadObjectResponseAsync<Response21>(response_, headers_, cancellationToken)
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
                    case 503:
                    {
                        var objectResponse_3 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_3.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_3.Text, headers_, null);
                        throw new ApiException<ErrorResponse>(
                            "service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n",
                            status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
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

    public virtual async Task<TokenResponse> GenerateTokenAsync(TokenRequest body,
        CancellationToken cancellationToken = default)
    {
        if (body == null) throw new ArgumentNullException("body");
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            var json_ = JsonConvert.SerializeObject(body, _settings.Value);
            var dictionary_ = JsonConvert.DeserializeObject<Dictionary<string, string>>(json_, _settings.Value);
            var content_ = new FormUrlEncodedContent(dictionary_);
            content_.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            request_.Content = content_;
            request_.Method = new HttpMethod("POST");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("oauth2/api/v1/token");
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
                            await ReadObjectResponseAsync<TokenResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_2.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_2.Text, headers_, null);
                        return objectResponse_2.Object;
                    }
                    case 400:
                    {
                        var objectResponse_ =
                            await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        throw new ApiException<ProblemDetailResponse>(
                            "Returns a [Problem detail](https://datatracker.ietf.org/doc/html/rfc9457) instance representing a bad request.",
                            status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    case 500:
                    {
                        var objectResponse_3 =
                            await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_3.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_3.Text, headers_, null);
                        throw new ApiException<ProblemDetailResponse>(
                            "Returns a [Problem detail](https://datatracker.ietf.org/doc/html/rfc9457) instance representing an internal server error.",
                            status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
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

    public virtual async Task<Response22> Live_session_tokenAsync(string? authorization = null,
        CancellationToken cancellationToken = default)
    {
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            if (authorization != null)
                request_.Headers.TryAddWithoutValidation("Authorization",
                    ConvertToString(authorization, CultureInfo.InvariantCulture));
            request_.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            request_.Method = new HttpMethod("POST");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("oauth/live_session_token");
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
                            await ReadObjectResponseAsync<Response22>(response_, headers_, cancellationToken)
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
                    case 503:
                    {
                        var objectResponse_3 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_3.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_3.Text, headers_, null);
                        throw new ApiException<ErrorResponse>(
                            "service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n",
                            status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
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

    public virtual async Task<Response23> Request_tokenAsync(string? authorization = null,
        CancellationToken cancellationToken = default)
    {
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            if (authorization != null)
                request_.Headers.TryAddWithoutValidation("Authorization",
                    ConvertToString(authorization, CultureInfo.InvariantCulture));
            request_.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            request_.Method = new HttpMethod("POST");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("oauth/request_token");
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
                            await ReadObjectResponseAsync<Response23>(response_, headers_, cancellationToken)
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
                    case 503:
                    {
                        var objectResponse_3 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_3.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_3.Text, headers_, null);
                        throw new ApiException<ErrorResponse>(
                            "service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n",
                            status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
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