using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IBKR.Api.NSwag.Contract.Models;
using IBKR.Api.NSwag.Contract.Interfaces;

namespace IBKR.Api.NSwag.Client.Services;

/// <summary>
/// Implementation of HmdsService
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class HmdsService : IHmdsService
{
	private readonly System.Net.Http.HttpClient _httpClient;
	private readonly Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;
	private readonly string _baseUrl;

	public HmdsService(System.Net.Http.HttpClient httpClient)
	{
		_httpClient = httpClient;
		_settings = new Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
		_baseUrl = "https://api.ibkr.com";
	}

	protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings => _settings.Value;

	private Newtonsoft.Json.JsonSerializerSettings CreateSerializerSettings()
	{
		var settings = new Newtonsoft.Json.JsonSerializerSettings();
		UpdateJsonSerializerSettings(settings);
		return settings;
	}

	partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);

	public virtual async Task<HmdsHistoryResponse> HistoryAsync(string conid, string period, string bar, BarType? barType = null, string? startTime = null, string? direction = null, bool? outsideRth = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (conid == null)
		{
			throw new ArgumentNullException("conid");
		}
		if (period == null)
		{
			throw new ArgumentNullException("period");
		}
		if (bar == null)
		{
			throw new ArgumentNullException("bar");
		}
		System.Net.Http.HttpClient client_ = _httpClient;
		bool disposeClient_ = false;
		try
		{
			using HttpRequestMessage request_ = new HttpRequestMessage();
			request_.Method = new HttpMethod("GET");
			request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
			StringBuilder urlBuilder_ = new StringBuilder();
			if (!string.IsNullOrEmpty(_baseUrl))
			{
				urlBuilder_.Append(_baseUrl);
			}
			urlBuilder_.Append("hmds/history");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("conid")).Append('=').Append(Uri.EscapeDataString(ConvertToString(conid, CultureInfo.InvariantCulture)))
				.Append('&');
			urlBuilder_.Append(Uri.EscapeDataString("period")).Append('=').Append(Uri.EscapeDataString(ConvertToString(period, CultureInfo.InvariantCulture)))
				.Append('&');
			urlBuilder_.Append(Uri.EscapeDataString("bar")).Append('=').Append(Uri.EscapeDataString(ConvertToString(bar, CultureInfo.InvariantCulture)))
				.Append('&');
			if (barType.HasValue)
			{
				urlBuilder_.Append(Uri.EscapeDataString("barType")).Append('=').Append(Uri.EscapeDataString(ConvertToString(barType, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (startTime != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("startTime")).Append('=').Append(Uri.EscapeDataString(ConvertToString(startTime, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (direction != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("direction")).Append('=').Append(Uri.EscapeDataString(ConvertToString(direction, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (outsideRth.HasValue)
			{
				urlBuilder_.Append(Uri.EscapeDataString("outsideRth")).Append('=').Append(Uri.EscapeDataString(ConvertToString(outsideRth, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			urlBuilder_.Length--;
			string url_ = urlBuilder_.ToString();
			request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
			HttpResponseMessage response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool disposeResponse_ = true;
			try
			{
				Dictionary<string, IEnumerable<string>> headers_ = new Dictionary<string, IEnumerable<string>>();
				foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Headers)
				{
					headers_[item_2.Key] = item_2.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Content.Headers)
					{
						headers_[item_.Key] = item_.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 200:
				{
					ObjectResponseResult<HmdsHistoryResponse> objectResponse_ = await ReadObjectResponseAsync<HmdsHistoryResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 400:
				{
					ObjectResponseResult<ErrorResponse> objectResponse_2 = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ErrorResponse>("bad request", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<string?> objectResponse_3 = await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_4 = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
				}
				case 503:
				{
					ObjectResponseResult<ErrorResponse> objectResponse_5 = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ErrorResponse>("service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				default:
				{
					string text = ((response_.Content != null) ? (await response_.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
					string responseData_ = text;
					throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
				}
				}
			}
			finally
			{
				if (disposeResponse_)
				{
					response_.Dispose();
				}
			}
		}
		finally
		{
			if (disposeClient_)
			{
				client_.Dispose();
			}
		}
	}

	public virtual async Task<HmdsScannerParams> ParamsAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		System.Net.Http.HttpClient client_ = _httpClient;
		bool disposeClient_ = false;
		try
		{
			using HttpRequestMessage request_ = new HttpRequestMessage();
			request_.Method = new HttpMethod("GET");
			request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
			StringBuilder urlBuilder_ = new StringBuilder();
			if (!string.IsNullOrEmpty(_baseUrl))
			{
				urlBuilder_.Append(_baseUrl);
			}
			urlBuilder_.Append("hmds/scanner/params");
			string url_ = urlBuilder_.ToString();
			request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
			HttpResponseMessage response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool disposeResponse_ = true;
			try
			{
				Dictionary<string, IEnumerable<string>> headers_ = new Dictionary<string, IEnumerable<string>>();
				foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Headers)
				{
					headers_[item_2.Key] = item_2.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Content.Headers)
					{
						headers_[item_.Key] = item_.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 200:
				{
					ObjectResponseResult<HmdsScannerParams> objectResponse_ = await ReadObjectResponseAsync<HmdsScannerParams>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 400:
				{
					ObjectResponseResult<ErrorResponse> objectResponse_2 = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ErrorResponse>("bad request", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<string?> objectResponse_3 = await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_4 = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
				}
				case 503:
				{
					ObjectResponseResult<ErrorResponse> objectResponse_5 = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ErrorResponse>("service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				default:
				{
					string text = ((response_.Content != null) ? (await response_.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
					string responseData_ = text;
					throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
				}
				}
			}
			finally
			{
				if (disposeResponse_)
				{
					response_.Dispose();
				}
			}
		}
		finally
		{
			if (disposeClient_)
			{
				client_.Dispose();
			}
		}
	}

	public virtual async Task<Response6> RunAsync(HmdsScannerRunRequest body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (body == null)
		{
			throw new ArgumentNullException("body");
		}
		System.Net.Http.HttpClient client_ = _httpClient;
		bool disposeClient_ = false;
		try
		{
			using HttpRequestMessage request_ = new HttpRequestMessage();
			string json_ = JsonConvert.SerializeObject(body, _settings.Value);
			StringContent content_ = new StringContent(json_);
			content_.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
			request_.Content = content_;
			request_.Method = new HttpMethod("POST");
			request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
			StringBuilder urlBuilder_ = new StringBuilder();
			if (!string.IsNullOrEmpty(_baseUrl))
			{
				urlBuilder_.Append(_baseUrl);
			}
			urlBuilder_.Append("hmds/scanner/run");
			string url_ = urlBuilder_.ToString();
			request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
			HttpResponseMessage response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool disposeResponse_ = true;
			try
			{
				Dictionary<string, IEnumerable<string>> headers_ = new Dictionary<string, IEnumerable<string>>();
				foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Headers)
				{
					headers_[item_2.Key] = item_2.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Content.Headers)
					{
						headers_[item_.Key] = item_.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 200:
				{
					ObjectResponseResult<Response6> objectResponse_ = await ReadObjectResponseAsync<Response6>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 400:
				{
					ObjectResponseResult<ErrorResponse> objectResponse_2 = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ErrorResponse>("bad request", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<string?> objectResponse_3 = await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 404:
				{
					string text2 = ((response_.Content != null) ? (await response_.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : string.Empty);
					string responseText_ = text2;
					throw new ApiException("Returned on the first successful request. Used as a preflight message.", status_, responseText_, headers_, null);
				}
				case 500:
				{
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_4 = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
				}
				case 503:
				{
					ObjectResponseResult<ErrorResponse> objectResponse_5 = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ErrorResponse>("service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				default:
				{
					string text = ((response_.Content != null) ? (await response_.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
					string responseData_ = text;
					throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
				}
				}
			}
			finally
			{
				if (disposeResponse_)
				{
					response_.Dispose();
				}
			}
		}
		finally
		{
			if (disposeClient_)
			{
				client_.Dispose();
			}
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

	protected string ConvertToString(object? value, CultureInfo cultureInfo)
	{
		if (value == null) return "";
		if (value is Enum) return string.Format(cultureInfo, "{0}", Convert.ToInt32(value));
		if (value is bool b) return Convert.ToString(b, cultureInfo)?.ToLowerInvariant() ?? "";
		if (value is byte[] bytes) return Convert.ToBase64String(bytes);
		return Convert.ToString(value, cultureInfo) ?? "";
	}

	protected virtual async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken)
	{
		if (response?.Content == null) return new ObjectResponseResult<T>(default(T), string.Empty);
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

}
