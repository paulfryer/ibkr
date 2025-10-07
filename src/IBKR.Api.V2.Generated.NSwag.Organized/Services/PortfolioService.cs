using System.CodeDom.Compiler;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
///     Implementation of PortfolioService
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class PortfolioService : IPortfolioService
{
    private readonly string _baseUrl;
    private readonly HttpClient _httpClient;
    private readonly Lazy<JsonSerializerSettings> _settings;

    public PortfolioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _settings = new Lazy<JsonSerializerSettings>(CreateSerializerSettings);
        _baseUrl = "https://api.ibkr.com";
    }

    protected JsonSerializerSettings JsonSerializerSettings => _settings.Value;

    public virtual async Task<ICollection<AccountAttributes>> AccountsAllAsync(
        CancellationToken cancellationToken = default)
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
            urlBuilder_.Append("portfolio/accounts");
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
                        var objectResponse_ =
                            await ReadObjectResponseAsync<ICollection<AccountAttributes>>(response_, headers_,
                                cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        return objectResponse_.Object;
                    }
                    case 401:
                    {
                        ObjectResponseResult<string?> objectResponse_3 =
                            await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_,
                            objectResponse_3.Object, null);
                    }
                    case 500:
                    {
                        var objectResponse_2 =
                            await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_2.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_2.Text, headers_, null);
                        throw new ApiException<ErrorOnlyResponse>(
                            "internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n",
                            status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
                    }
                    case 503:
                    {
                        var objectResponse_4 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_4.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_4.Text, headers_, null);
                        throw new ApiException<ErrorResponse>(
                            "service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n",
                            status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

    public virtual async Task<PortfolioAllocations> AllocationAsync(string accountId, object? model = null,
        CancellationToken cancellationToken = default)
    {
        if (accountId == null) throw new ArgumentNullException("accountId");
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            request_.Method = new HttpMethod("GET");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("portfolio/");
            urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder_.Append("/allocation");
            urlBuilder_.Append('?');
            if (model != null)
                urlBuilder_.Append(Uri.EscapeDataString("model")).Append('=')
                    .Append(Uri.EscapeDataString(ConvertToString(model, CultureInfo.InvariantCulture)))
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
                switch (status_)
                {
                    case 200:
                    {
                        var objectResponse_5 =
                            await ReadObjectResponseAsync<PortfolioAllocations>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_5.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_5.Text, headers_, null);
                        return objectResponse_5.Object;
                    }
                    case 400:
                    {
                        var objectResponse_2 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_2.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_2.Text, headers_, null);
                        throw new ApiException<ErrorResponse>("bad request", status_, objectResponse_2.Text, headers_,
                            objectResponse_2.Object, null);
                    }
                    case 401:
                    {
                        ObjectResponseResult<string?> objectResponse_3 =
                            await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_,
                            objectResponse_3.Object, null);
                    }
                    case 500:
                    {
                        var objectResponse_ =
                            await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        throw new ApiException<ErrorOnlyResponse>(
                            "internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n",
                            status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    case 503:
                    {
                        var objectResponse_4 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_4.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_4.Text, headers_, null);
                        throw new ApiException<ErrorResponse>(
                            "service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n",
                            status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

    public virtual async Task<Response24> InvalidateAsync(string accountId,
        CancellationToken cancellationToken = default)
    {
        if (accountId == null) throw new ArgumentNullException("accountId");
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            request_.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            request_.Method = new HttpMethod("POST");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("portfolio/");
            urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder_.Append("/positions/invalidate");
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
                        var objectResponse_5 =
                            await ReadObjectResponseAsync<Response24>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_5.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_5.Text, headers_, null);
                        return objectResponse_5.Object;
                    }
                    case 400:
                    {
                        var objectResponse_2 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_2.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_2.Text, headers_, null);
                        throw new ApiException<ErrorResponse>("bad request", status_, objectResponse_2.Text, headers_,
                            objectResponse_2.Object, null);
                    }
                    case 401:
                    {
                        ObjectResponseResult<string?> objectResponse_3 =
                            await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_,
                            objectResponse_3.Object, null);
                    }
                    case 500:
                    {
                        var objectResponse_ =
                            await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        throw new ApiException<ErrorOnlyResponse>(
                            "internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n",
                            status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    case 503:
                    {
                        var objectResponse_4 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_4.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_4.Text, headers_, null);
                        throw new ApiException<ErrorResponse>(
                            "service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n",
                            status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

    public virtual async Task<IDictionary<string, Anonymous6>> LedgerAsync(string accountId,
        CancellationToken cancellationToken = default)
    {
        if (accountId == null) throw new ArgumentNullException("accountId");
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            request_.Method = new HttpMethod("GET");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("portfolio/");
            urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder_.Append("/ledger");
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
                        var objectResponse_ =
                            await ReadObjectResponseAsync<IDictionary<string, Anonymous6>>(response_, headers_,
                                cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        return objectResponse_.Object;
                    }
                    case 401:
                    {
                        ObjectResponseResult<string?> objectResponse_3 =
                            await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_,
                            objectResponse_3.Object, null);
                    }
                    case 500:
                    {
                        var objectResponse_2 =
                            await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_2.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_2.Text, headers_, null);
                        throw new ApiException<ErrorOnlyResponse>(
                            "internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n",
                            status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
                    }
                    case 503:
                    {
                        var objectResponse_4 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_4.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_4.Text, headers_, null);
                        throw new ApiException<ErrorResponse>(
                            "service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n",
                            status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

    public virtual async Task<AccountAttributes> MetaAsync(string accountId,
        CancellationToken cancellationToken = default)
    {
        if (accountId == null) throw new ArgumentNullException("accountId");
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            request_.Method = new HttpMethod("GET");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("portfolio/");
            urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder_.Append("/meta");
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
                        var objectResponse_ =
                            await ReadObjectResponseAsync<AccountAttributes>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        return objectResponse_.Object;
                    }
                    case 401:
                    {
                        ObjectResponseResult<string?> objectResponse_3 =
                            await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_,
                            objectResponse_3.Object, null);
                    }
                    case 500:
                    {
                        var objectResponse_2 =
                            await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_2.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_2.Text, headers_, null);
                        throw new ApiException<ErrorOnlyResponse>(
                            "internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n",
                            status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
                    }
                    case 503:
                    {
                        var objectResponse_4 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_4.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_4.Text, headers_, null);
                        throw new ApiException<ErrorResponse>(
                            "service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n",
                            status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

    public virtual async Task<ICollection<IndividualPosition>> PositionAsync(string accountId, string conid,
        CancellationToken cancellationToken = default)
    {
        if (accountId == null) throw new ArgumentNullException("accountId");
        if (conid == null) throw new ArgumentNullException("conid");
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            request_.Method = new HttpMethod("GET");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("portfolio/");
            urlBuilder_.Append("/position/");
            urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(conid, CultureInfo.InvariantCulture)));
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
                        var objectResponse_5 =
                            await ReadObjectResponseAsync<ICollection<IndividualPosition>>(response_, headers_,
                                cancellationToken).ConfigureAwait(false);
                        if (objectResponse_5.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_5.Text, headers_, null);
                        return objectResponse_5.Object;
                    }
                    case 400:
                    {
                        var objectResponse_2 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_2.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_2.Text, headers_, null);
                        throw new ApiException<ErrorResponse>("bad request", status_, objectResponse_2.Text, headers_,
                            objectResponse_2.Object, null);
                    }
                    case 401:
                    {
                        ObjectResponseResult<string?> objectResponse_3 =
                            await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_,
                            objectResponse_3.Object, null);
                    }
                    case 500:
                    {
                        var objectResponse_ =
                            await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        throw new ApiException<ErrorOnlyResponse>(
                            "internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n",
                            status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    case 503:
                    {
                        var objectResponse_4 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_4.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_4.Text, headers_, null);
                        throw new ApiException<ErrorResponse>(
                            "service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n",
                            status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

    public virtual async Task<ICollection<IndividualPosition>> PositionsAllAsync(string accountId,
        string? pageId = null, object? model = null, object? sort = null, object? direction = null,
        bool? waitForSecDef = null, CancellationToken cancellationToken = default)
    {
        if (accountId == null) throw new ArgumentNullException("accountId");
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            request_.Method = new HttpMethod("GET");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("portfolio/");
            urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder_.Append("/positions/");
            if (pageId != null)
                urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(pageId, CultureInfo.InvariantCulture)));
            else if (urlBuilder_.Length > 0) urlBuilder_.Length--;
            urlBuilder_.Append("{pageId}");
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
                        var objectResponse_5 =
                            await ReadObjectResponseAsync<ICollection<IndividualPosition>>(response_, headers_,
                                cancellationToken).ConfigureAwait(false);
                        if (objectResponse_5.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_5.Text, headers_, null);
                        return objectResponse_5.Object;
                    }
                    case 400:
                    {
                        var objectResponse_2 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_2.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_2.Text, headers_, null);
                        throw new ApiException<ErrorResponse>("bad request", status_, objectResponse_2.Text, headers_,
                            objectResponse_2.Object, null);
                    }
                    case 401:
                    {
                        ObjectResponseResult<string?> objectResponse_3 =
                            await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_,
                            objectResponse_3.Object, null);
                    }
                    case 500:
                    {
                        var objectResponse_ =
                            await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        throw new ApiException<ErrorOnlyResponse>(
                            "internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n",
                            status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    case 503:
                    {
                        var objectResponse_4 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_4.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_4.Text, headers_, null);
                        throw new ApiException<ErrorResponse>(
                            "service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n",
                            status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

    public virtual async Task<IDictionary<string, IndividualPosition>> PositionsAsync(string conid,
        CancellationToken cancellationToken = default)
    {
        if (conid == null) throw new ArgumentNullException("conid");
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            request_.Method = new HttpMethod("GET");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("portfolio/positions/");
            urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(conid, CultureInfo.InvariantCulture)));
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
                        var objectResponse_5 =
                            await ReadObjectResponseAsync<IDictionary<string, IndividualPosition>>(response_, headers_,
                                cancellationToken).ConfigureAwait(false);
                        if (objectResponse_5.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_5.Text, headers_, null);
                        return objectResponse_5.Object;
                    }
                    case 400:
                    {
                        var objectResponse_2 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_2.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_2.Text, headers_, null);
                        throw new ApiException<ErrorResponse>("bad request", status_, objectResponse_2.Text, headers_,
                            objectResponse_2.Object, null);
                    }
                    case 401:
                    {
                        ObjectResponseResult<string?> objectResponse_3 =
                            await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_,
                            objectResponse_3.Object, null);
                    }
                    case 500:
                    {
                        var objectResponse_ =
                            await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        throw new ApiException<ErrorOnlyResponse>(
                            "internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n",
                            status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    case 503:
                    {
                        var objectResponse_4 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_4.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_4.Text, headers_, null);
                        throw new ApiException<ErrorResponse>(
                            "service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n",
                            status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

    public virtual async Task<ICollection<AccountAttributes>> SubaccountsAsync(
        CancellationToken cancellationToken = default)
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
            urlBuilder_.Append("portfolio/subaccounts");
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
                        var objectResponse_ =
                            await ReadObjectResponseAsync<ICollection<AccountAttributes>>(response_, headers_,
                                cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        return objectResponse_.Object;
                    }
                    case 401:
                    {
                        ObjectResponseResult<string?> objectResponse_3 =
                            await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_,
                            objectResponse_3.Object, null);
                    }
                    case 500:
                    {
                        var objectResponse_2 =
                            await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_2.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_2.Text, headers_, null);
                        throw new ApiException<ErrorOnlyResponse>(
                            "internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n",
                            status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
                    }
                    case 503:
                    {
                        var objectResponse_4 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_4.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_4.Text, headers_, null);
                        throw new ApiException<ErrorResponse>(
                            "service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n",
                            status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

    public virtual async Task<PortfolioSummary> Summary2Async(string accountId,
        CancellationToken cancellationToken = default)
    {
        if (accountId == null) throw new ArgumentNullException("accountId");
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using var request_ = new HttpRequestMessage();
            request_.Method = new HttpMethod("GET");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var urlBuilder_ = new StringBuilder();
            if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder_.Append(_baseUrl);
            urlBuilder_.Append("portfolio/");
            urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder_.Append("/summary");
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
                        var objectResponse_ =
                            await ReadObjectResponseAsync<PortfolioSummary>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        return objectResponse_.Object;
                    }
                    case 401:
                    {
                        ObjectResponseResult<string?> objectResponse_3 =
                            await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_,
                            objectResponse_3.Object, null);
                    }
                    case 500:
                    {
                        var objectResponse_2 =
                            await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_2.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_2.Text, headers_, null);
                        throw new ApiException<ErrorOnlyResponse>(
                            "internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n",
                            status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
                    }
                    case 503:
                    {
                        var objectResponse_4 =
                            await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_4.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_4.Text, headers_, null);
                        throw new ApiException<ErrorResponse>(
                            "service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n",
                            status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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