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

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
/// Implementation of FyiService
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class FyiService : IFyiService
{
	private readonly HttpClient _httpClient;
	private readonly Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;
	private readonly string _baseUrl;

	public FyiService(HttpClient httpClient)
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

	public virtual async System.Threading.Tasks.Task DeliveryoptionsDELETEAsync(object deviceId, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (deviceId == null)
		{
			throw new ArgumentNullException("deviceId");
		}
		HttpClient client_ = _httpClient;
		bool disposeClient_ = false;
		try
		{
			using HttpRequestMessage request_ = new HttpRequestMessage();
			request_.Method = new HttpMethod("DELETE");
			StringBuilder urlBuilder_ = new StringBuilder();
			if (!string.IsNullOrEmpty(_baseUrl))
			{
				urlBuilder_.Append(_baseUrl);
			}
			urlBuilder_.Append("fyi/deliveryoptions/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(deviceId, CultureInfo.InvariantCulture)));
			string url_ = urlBuilder_.ToString();
			request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
			HttpResponseMessage response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool disposeResponse_ = true;
			try
			{
				Dictionary<string, IEnumerable<string>> headers_ = new Dictionary<string, IEnumerable<string>>();
				foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Headers)
				{
					headers_[item_.Key] = item_.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Content.Headers)
					{
						headers_[item_2.Key] = item_2.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				if (status_ == 200)
				{
					return;
				}
				string text = ((response_.Content != null) ? (await response_.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
				string responseData_ = text;
				throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
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

	public virtual async Task<DeliveryOptions> DeliveryoptionsGETAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
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
			urlBuilder_.Append("fyi/deliveryoptions");
			string url_ = urlBuilder_.ToString();
			request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
			HttpResponseMessage response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool disposeResponse_ = true;
			try
			{
				Dictionary<string, IEnumerable<string>> headers_ = new Dictionary<string, IEnumerable<string>>();
				foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Headers)
				{
					headers_[item_.Key] = item_.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Content.Headers)
					{
						headers_[item_2.Key] = item_2.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 200:
				{
					ObjectResponseResult<DeliveryOptions> objectResponse_ = await ReadObjectResponseAsync<DeliveryOptions>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 401:
				{
					ObjectResponseResult<string?> objectResponse_3 = await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_2 = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
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

	public virtual async Task<FyiVT> DeviceAsync(FyiEnableDeviceOption body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (body == null)
		{
			throw new ArgumentNullException("body");
		}
		HttpClient client_ = _httpClient;
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
			urlBuilder_.Append("fyi/deliveryoptions/device");
			string url_ = urlBuilder_.ToString();
			request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
			HttpResponseMessage response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool disposeResponse_ = true;
			try
			{
				Dictionary<string, IEnumerable<string>> headers_ = new Dictionary<string, IEnumerable<string>>();
				foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Headers)
				{
					headers_[item_.Key] = item_.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Content.Headers)
					{
						headers_[item_2.Key] = item_2.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 200:
				{
					ObjectResponseResult<FyiVT> objectResponse_5 = await ReadObjectResponseAsync<FyiVT>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
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
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_ = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

	public virtual async Task<DisclaimerInfo> DisclaimerGETAsync(Typecodes typecode, CancellationToken cancellationToken = default(CancellationToken))
	{
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
			urlBuilder_.Append("fyi/disclaimer/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(typecode, CultureInfo.InvariantCulture)));
			string url_ = urlBuilder_.ToString();
			request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
			HttpResponseMessage response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool disposeResponse_ = true;
			try
			{
				Dictionary<string, IEnumerable<string>> headers_ = new Dictionary<string, IEnumerable<string>>();
				foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Headers)
				{
					headers_[item_.Key] = item_.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Content.Headers)
					{
						headers_[item_2.Key] = item_2.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 200:
				{
					ObjectResponseResult<DisclaimerInfo> objectResponse_ = await ReadObjectResponseAsync<DisclaimerInfo>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 401:
				{
					ObjectResponseResult<string?> objectResponse_3 = await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_2 = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
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

	public virtual async Task<FyiVT> DisclaimerPUTAsync(Typecodes typecode, CancellationToken cancellationToken = default(CancellationToken))
	{
		HttpClient client_ = _httpClient;
		bool disposeClient_ = false;
		try
		{
			using HttpRequestMessage request_ = new HttpRequestMessage();
			request_.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
			request_.Method = new HttpMethod("PUT");
			request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
			StringBuilder urlBuilder_ = new StringBuilder();
			if (!string.IsNullOrEmpty(_baseUrl))
			{
				urlBuilder_.Append(_baseUrl);
			}
			urlBuilder_.Append("fyi/disclaimer/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(typecode, CultureInfo.InvariantCulture)));
			string url_ = urlBuilder_.ToString();
			request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
			HttpResponseMessage response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool disposeResponse_ = true;
			try
			{
				Dictionary<string, IEnumerable<string>> headers_ = new Dictionary<string, IEnumerable<string>>();
				foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Headers)
				{
					headers_[item_.Key] = item_.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Content.Headers)
					{
						headers_[item_2.Key] = item_2.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 200:
				{
					ObjectResponseResult<FyiVT> objectResponse_5 = await ReadObjectResponseAsync<FyiVT>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
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
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_ = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

	public virtual async Task<FyiVT> EmailAsync(object enabled, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (enabled == null)
		{
			throw new ArgumentNullException("enabled");
		}
		HttpClient client_ = _httpClient;
		bool disposeClient_ = false;
		try
		{
			using HttpRequestMessage request_ = new HttpRequestMessage();
			request_.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
			request_.Method = new HttpMethod("PUT");
			request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
			StringBuilder urlBuilder_ = new StringBuilder();
			if (!string.IsNullOrEmpty(_baseUrl))
			{
				urlBuilder_.Append(_baseUrl);
			}
			urlBuilder_.Append("fyi/deliveryoptions/email");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("enabled")).Append('=').Append(Uri.EscapeDataString(ConvertToString(enabled, CultureInfo.InvariantCulture)))
				.Append('&');
			urlBuilder_.Length--;
			string url_ = urlBuilder_.ToString();
			request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
			HttpResponseMessage response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool disposeResponse_ = true;
			try
			{
				Dictionary<string, IEnumerable<string>> headers_ = new Dictionary<string, IEnumerable<string>>();
				foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Headers)
				{
					headers_[item_.Key] = item_.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Content.Headers)
					{
						headers_[item_2.Key] = item_2.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 200:
				{
					ObjectResponseResult<FyiVT> objectResponse_ = await ReadObjectResponseAsync<FyiVT>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 401:
				{
					ObjectResponseResult<string?> objectResponse_3 = await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_2 = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
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

	public virtual async Task<ICollection<Anonymous>> NotificationsAllAsync(string max, object? include = null, object? exclude = null, object? id = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (max == null)
		{
			throw new ArgumentNullException("max");
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
			urlBuilder_.Append("fyi/notifications");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("max")).Append('=').Append(Uri.EscapeDataString(ConvertToString(max, CultureInfo.InvariantCulture)))
				.Append('&');
			if (include != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("include")).Append('=').Append(Uri.EscapeDataString(ConvertToString(include, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (exclude != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("exclude")).Append('=').Append(Uri.EscapeDataString(ConvertToString(exclude, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (id != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("id")).Append('=').Append(Uri.EscapeDataString(ConvertToString(id, CultureInfo.InvariantCulture)))
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
				foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Headers)
				{
					headers_[item_.Key] = item_.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Content.Headers)
					{
						headers_[item_2.Key] = item_2.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 200:
				{
					ObjectResponseResult<ICollection<Anonymous>> objectResponse_5 = await ReadObjectResponseAsync<ICollection<Anonymous>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
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
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_ = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

	public virtual async Task<NotificationReadAcknowledge> NotificationsAsync(object notificationId, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (notificationId == null)
		{
			throw new ArgumentNullException("notificationId");
		}
		HttpClient client_ = _httpClient;
		bool disposeClient_ = false;
		try
		{
			using HttpRequestMessage request_ = new HttpRequestMessage();
			request_.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
			request_.Method = new HttpMethod("PUT");
			request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
			StringBuilder urlBuilder_ = new StringBuilder();
			if (!string.IsNullOrEmpty(_baseUrl))
			{
				urlBuilder_.Append(_baseUrl);
			}
			urlBuilder_.Append("fyi/notifications/");
			string url_ = urlBuilder_.ToString();
			request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
			HttpResponseMessage response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool disposeResponse_ = true;
			try
			{
				Dictionary<string, IEnumerable<string>> headers_ = new Dictionary<string, IEnumerable<string>>();
				foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Headers)
				{
					headers_[item_.Key] = item_.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Content.Headers)
					{
						headers_[item_2.Key] = item_2.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 200:
				{
					ObjectResponseResult<NotificationReadAcknowledge> objectResponse_5 = await ReadObjectResponseAsync<NotificationReadAcknowledge>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
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
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_ = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

	public virtual async Task<ICollection<Anonymous2>> SettingsAllAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
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
			urlBuilder_.Append("fyi/settings");
			string url_ = urlBuilder_.ToString();
			request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
			HttpResponseMessage response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool disposeResponse_ = true;
			try
			{
				Dictionary<string, IEnumerable<string>> headers_ = new Dictionary<string, IEnumerable<string>>();
				foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Headers)
				{
					headers_[item_.Key] = item_.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Content.Headers)
					{
						headers_[item_2.Key] = item_2.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 200:
				{
					ObjectResponseResult<ICollection<Anonymous2>> objectResponse_ = await ReadObjectResponseAsync<ICollection<Anonymous2>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 401:
				{
					ObjectResponseResult<string?> objectResponse_3 = await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_2 = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
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

	public virtual async Task<FyiVT> SettingsAsync(Typecodes typecode, Body body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (body == null)
		{
			throw new ArgumentNullException("body");
		}
		HttpClient client_ = _httpClient;
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
			urlBuilder_.Append("fyi/settings/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(typecode, CultureInfo.InvariantCulture)));
			string url_ = urlBuilder_.ToString();
			request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
			HttpResponseMessage response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool disposeResponse_ = true;
			try
			{
				Dictionary<string, IEnumerable<string>> headers_ = new Dictionary<string, IEnumerable<string>>();
				foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Headers)
				{
					headers_[item_.Key] = item_.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Content.Headers)
					{
						headers_[item_2.Key] = item_2.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 200:
				{
					ObjectResponseResult<FyiVT> objectResponse_ = await ReadObjectResponseAsync<FyiVT>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 401:
				{
					ObjectResponseResult<string?> objectResponse_3 = await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					throw new ApiException<string>("access denied", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_2 = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
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

	public virtual async Task<Response> UnreadnumberAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
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
			urlBuilder_.Append("fyi/unreadnumber");
			string url_ = urlBuilder_.ToString();
			request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
			HttpResponseMessage response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool disposeResponse_ = true;
			try
			{
				Dictionary<string, IEnumerable<string>> headers_ = new Dictionary<string, IEnumerable<string>>();
				foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Headers)
				{
					headers_[item_.Key] = item_.Value;
				}
				if (response_.Content != null && response_.Content.Headers != null)
				{
					foreach (KeyValuePair<string, IEnumerable<string>> item_2 in response_.Content.Headers)
					{
						headers_[item_2.Key] = item_2.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 200:
				{
					ObjectResponseResult<Response> objectResponse_5 = await ReadObjectResponseAsync<Response>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
				}
				case 401:
				{
					ObjectResponseResult<string?> objectResponse_2 = await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					throw new ApiException<string>("access denied", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 423:
				{
					ObjectResponseResult<Response25> objectResponse_3 = await ReadObjectResponseAsync<Response25>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<Response25>("Return if called too frequently. Should not be called more than 1 time in 5 minutes", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ErrorOnlyResponse> objectResponse_ = await ReadObjectResponseAsync<ErrorOnlyResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ErrorOnlyResponse>("internal server error, returned when incoming request cannot be processed. It can sometimes include subset of bad requests.  For example, wrong accountId passed and it can only be detected later in handling request. Error contains reason of the problem.\n", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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
