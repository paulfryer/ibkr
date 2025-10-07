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
using IBKR.Api.V2.Generated.NSwag.Models;
using IBKR.Api.V2.Generated.NSwag.Interfaces;

namespace IBKR.Api.V2.Generated.NSwag.Services;

/// <summary>
/// Implementation of TrsrvService
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class TrsrvService : ITrsrvService
{
	private readonly HttpClient _httpClient;
	private readonly Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;
	private readonly string _baseUrl;

	public TrsrvService(HttpClient httpClient)
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

	public virtual async Task<ICollection<Anonymous7>> AllConidsAsync(string exchange, object? assetClass = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (exchange == null)
		{
			throw new ArgumentNullException("exchange");
		}
		HttpClient client_ = _httpClient;
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
			urlBuilder_.Append("trsrv/all-conids");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("exchange")).Append('=').Append(Uri.EscapeDataString(ConvertToString(exchange, CultureInfo.InvariantCulture)))
				.Append('&');
			if (assetClass != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("assetClass")).Append('=').Append(Uri.EscapeDataString(ConvertToString(assetClass, CultureInfo.InvariantCulture)))
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
					ObjectResponseResult<ICollection<Anonymous7>> objectResponse_ = await ReadObjectResponseAsync<ICollection<Anonymous7>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 401:
				{
					ObjectResponseResult<string?> objectResponse_2 = await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					throw new ApiException<string>("access denied", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_3 = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 503:
				{
					ObjectResponseResult<ErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ErrorResponse>("service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<Features> FuturesAsync(string symbols, object? exchange = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (symbols == null)
		{
			throw new ArgumentNullException("symbols");
		}
		HttpClient client_ = _httpClient;
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
			urlBuilder_.Append("trsrv/futures");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("symbols")).Append('=').Append(Uri.EscapeDataString(ConvertToString(symbols, CultureInfo.InvariantCulture)))
				.Append('&');
			if (exchange != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("exchange")).Append('=').Append(Uri.EscapeDataString(ConvertToString(exchange, CultureInfo.InvariantCulture)))
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
					ObjectResponseResult<Features> objectResponse_ = await ReadObjectResponseAsync<Features>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 401:
				{
					ObjectResponseResult<string?> objectResponse_2 = await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					throw new ApiException<string>("access denied", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_3 = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 503:
				{
					ObjectResponseResult<ErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ErrorResponse>("service is unavailable. For example if request takes more than 10s due to some internal service unavailability,  request aborted and this status returned\n", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<ICollection<Anonymous8>> ScheduleAsync(AssetClass assetClass, string symbol, string? exchange = null, string? exchangeFilter = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (symbol == null)
		{
			throw new ArgumentNullException("symbol");
		}
		HttpClient client_ = _httpClient;
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
			urlBuilder_.Append("trsrv/secdef/schedule");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("assetClass")).Append('=').Append(Uri.EscapeDataString(ConvertToString(assetClass, CultureInfo.InvariantCulture)))
				.Append('&');
			urlBuilder_.Append(Uri.EscapeDataString("symbol")).Append('=').Append(Uri.EscapeDataString(ConvertToString(symbol, CultureInfo.InvariantCulture)))
				.Append('&');
			if (exchange != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("exchange")).Append('=').Append(Uri.EscapeDataString(ConvertToString(exchange, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (exchangeFilter != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("exchangeFilter")).Append('=').Append(Uri.EscapeDataString(ConvertToString(exchangeFilter, CultureInfo.InvariantCulture)))
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
					ObjectResponseResult<ICollection<Anonymous8>> objectResponse_ = await ReadObjectResponseAsync<ICollection<Anonymous8>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
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

	public virtual async Task<TrsrvSecDefResponse> SecdefAsync(string conids, object? criteria = null, object? bondp = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (conids == null)
		{
			throw new ArgumentNullException("conids");
		}
		HttpClient client_ = _httpClient;
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
			urlBuilder_.Append("trsrv/secdef");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("conids")).Append('=').Append(Uri.EscapeDataString(ConvertToString(conids, CultureInfo.InvariantCulture)))
				.Append('&');
			if (criteria != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("criteria")).Append('=').Append(Uri.EscapeDataString(ConvertToString(criteria, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (bondp != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("bondp")).Append('=').Append(Uri.EscapeDataString(ConvertToString(bondp, CultureInfo.InvariantCulture)))
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
					ObjectResponseResult<TrsrvSecDefResponse> objectResponse_ = await ReadObjectResponseAsync<TrsrvSecDefResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 204:
				{
					string text2 = ((response_.Content != null) ? (await response_.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : string.Empty);
					string responseText_ = text2;
					throw new ApiException("no content", status_, responseText_, headers_, null);
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

	public virtual async Task<IDictionary<string, ICollection<Anonymous9>>> StocksAsync(string symbols, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (symbols == null)
		{
			throw new ArgumentNullException("symbols");
		}
		HttpClient client_ = _httpClient;
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
			urlBuilder_.Append("trsrv/stocks");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("symbols")).Append('=').Append(Uri.EscapeDataString(ConvertToString(symbols, CultureInfo.InvariantCulture)))
				.Append('&');
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
					ObjectResponseResult<IDictionary<string, ICollection<Anonymous9>>> objectResponse_ = await ReadObjectResponseAsync<IDictionary<string, ICollection<Anonymous9>>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
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
