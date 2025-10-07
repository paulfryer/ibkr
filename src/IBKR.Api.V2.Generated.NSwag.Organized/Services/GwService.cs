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
/// Implementation of GwService
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class GwService : IGwService
{
	private readonly HttpClient _httpClient;
	private readonly Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;
	private readonly string _baseUrl;

	public GwService(HttpClient httpClient)
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

	public virtual async Task<FileDetailsResponse> AccountsGETAsync(string? accountId = null, string? externalId = null, CancellationToken cancellationToken = default(CancellationToken))
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
			urlBuilder_.Append("gw/api/v1/accounts");
			urlBuilder_.Append('?');
			if (accountId != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("accountId")).Append('=').Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (externalId != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("externalId")).Append('=').Append(Uri.EscapeDataString(ConvertToString(externalId, CultureInfo.InvariantCulture)))
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
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<FileDetailsResponse> objectResponse_3 = await ReadObjectResponseAsync<FileDetailsResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<StatusResponse> AccountsPATCHAsync(AccountManagementRequestsPayload body, CancellationToken cancellationToken = default(CancellationToken))
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
			content_.Headers.ContentType = MediaTypeHeaderValue.Parse("application/jwt");
			request_.Content = content_;
			request_.Method = new HttpMethod("PATCH");
			request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
			StringBuilder urlBuilder_ = new StringBuilder();
			if (!string.IsNullOrEmpty(_baseUrl))
			{
				urlBuilder_.Append(_baseUrl);
			}
			urlBuilder_.Append("gw/api/v1/accounts");
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
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_ = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_6 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_3 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<StatusResponse> objectResponse_2 = await ReadObjectResponseAsync<StatusResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					return objectResponse_2.Object;
				}
				case 202:
				{
					ObjectResponseResult<RequestInfoResponse> objectResponse_7 = await ReadObjectResponseAsync<RequestInfoResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_7.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_7.Text, headers_, null);
					}
					throw new ApiException<RequestInfoResponse>("Initiate update information for an existing accountId.", status_, objectResponse_7.Text, headers_, objectResponse_7.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<StatusResponse> AccountsPOSTAsync(ApplicationPayload body, CancellationToken cancellationToken = default(CancellationToken))
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
			content_.Headers.ContentType = MediaTypeHeaderValue.Parse("application/jwt");
			request_.Content = content_;
			request_.Method = new HttpMethod("POST");
			request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
			StringBuilder urlBuilder_ = new StringBuilder();
			if (!string.IsNullOrEmpty(_baseUrl))
			{
				urlBuilder_.Append(_baseUrl);
			}
			urlBuilder_.Append("gw/api/v1/accounts");
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
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_ = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_6 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_3 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<StatusResponse> objectResponse_2 = await ReadObjectResponseAsync<StatusResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					return objectResponse_2.Object;
				}
				case 202:
				{
					ObjectResponseResult<RequestInfoResponse> objectResponse_7 = await ReadObjectResponseAsync<RequestInfoResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_7.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_7.Text, headers_, null);
					}
					throw new ApiException<RequestInfoResponse>("Submit account application. This will initiate creation of brokerage account for the end User.", status_, objectResponse_7.Text, headers_, objectResponse_7.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<GetAvailableTaxFormsResponse> Available2Async(string authorization, string accountId, int year, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (accountId == null)
		{
			throw new ArgumentNullException("accountId");
		}
		HttpClient client_ = _httpClient;
		bool disposeClient_ = false;
		try
		{
			using HttpRequestMessage request_ = new HttpRequestMessage();
			if (authorization == null)
			{
				throw new ArgumentNullException("authorization");
			}
			request_.Headers.TryAddWithoutValidation("authorization", ConvertToString(authorization, CultureInfo.InvariantCulture));
			request_.Method = new HttpMethod("GET");
			request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
			StringBuilder urlBuilder_ = new StringBuilder();
			if (!string.IsNullOrEmpty(_baseUrl))
			{
				urlBuilder_.Append(_baseUrl);
			}
			urlBuilder_.Append("gw/api/v1/tax-documents/available");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("accountId")).Append('=').Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)))
				.Append('&');
			urlBuilder_.Append(Uri.EscapeDataString("year")).Append('=').Append(Uri.EscapeDataString(ConvertToString(year, CultureInfo.InvariantCulture)))
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
					ObjectResponseResult<GetAvailableTaxFormsResponse> objectResponse_ = await ReadObjectResponseAsync<GetAvailableTaxFormsResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_6 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<InvalidAccessTokenResponse> objectResponse_2 = await ReadObjectResponseAsync<InvalidAccessTokenResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<InvalidAccessTokenResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 402:
				{
					ObjectResponseResult<UnauthorizedAccessResponse> objectResponse_5 = await ReadObjectResponseAsync<UnauthorizedAccessResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<UnauthorizedAccessResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<InsufficientScopeResponse> objectResponse_3 = await ReadObjectResponseAsync<InsufficientScopeResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<InsufficientScopeResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<GetAvailableTradeConfirmationDatesResponse> Available3Async(string authorization, string accountId, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (accountId == null)
		{
			throw new ArgumentNullException("accountId");
		}
		HttpClient client_ = _httpClient;
		bool disposeClient_ = false;
		try
		{
			using HttpRequestMessage request_ = new HttpRequestMessage();
			if (authorization == null)
			{
				throw new ArgumentNullException("authorization");
			}
			request_.Headers.TryAddWithoutValidation("authorization", ConvertToString(authorization, CultureInfo.InvariantCulture));
			request_.Method = new HttpMethod("GET");
			request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
			StringBuilder urlBuilder_ = new StringBuilder();
			if (!string.IsNullOrEmpty(_baseUrl))
			{
				urlBuilder_.Append(_baseUrl);
			}
			urlBuilder_.Append("gw/api/v1/trade-confirmations/available");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("accountId")).Append('=').Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)))
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
					ObjectResponseResult<GetAvailableTradeConfirmationDatesResponse> objectResponse_ = await ReadObjectResponseAsync<GetAvailableTradeConfirmationDatesResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_6 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<InvalidAccessTokenResponse> objectResponse_2 = await ReadObjectResponseAsync<InvalidAccessTokenResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<InvalidAccessTokenResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 402:
				{
					ObjectResponseResult<UnauthorizedAccessResponse> objectResponse_5 = await ReadObjectResponseAsync<UnauthorizedAccessResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<UnauthorizedAccessResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<InsufficientScopeResponse> objectResponse_3 = await ReadObjectResponseAsync<InsufficientScopeResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<InsufficientScopeResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<GetAvailableStmtDatesResponse> AvailableAsync(string authorization, string accountId, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (accountId == null)
		{
			throw new ArgumentNullException("accountId");
		}
		HttpClient client_ = _httpClient;
		bool disposeClient_ = false;
		try
		{
			using HttpRequestMessage request_ = new HttpRequestMessage();
			if (authorization == null)
			{
				throw new ArgumentNullException("authorization");
			}
			request_.Headers.TryAddWithoutValidation("authorization", ConvertToString(authorization, CultureInfo.InvariantCulture));
			request_.Method = new HttpMethod("GET");
			request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
			StringBuilder urlBuilder_ = new StringBuilder();
			if (!string.IsNullOrEmpty(_baseUrl))
			{
				urlBuilder_.Append(_baseUrl);
			}
			urlBuilder_.Append("gw/api/v1/statements/available");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("accountId")).Append('=').Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)))
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
					ObjectResponseResult<GetAvailableStmtDatesResponse> objectResponse_ = await ReadObjectResponseAsync<GetAvailableStmtDatesResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_6 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<InvalidAccessTokenResponse> objectResponse_2 = await ReadObjectResponseAsync<InvalidAccessTokenResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<InvalidAccessTokenResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 402:
				{
					ObjectResponseResult<UnauthorizedAccessResponse> objectResponse_5 = await ReadObjectResponseAsync<UnauthorizedAccessResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<UnauthorizedAccessResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<InsufficientScopeResponse> objectResponse_3 = await ReadObjectResponseAsync<InsufficientScopeResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<InsufficientScopeResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<AsynchronousInstructionResponse> BankInstructionsAsync(string client_id, Body2 body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
		}
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
			urlBuilder_.Append("gw/api/v1/bank-instructions");
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
				case 202:
				{
					ObjectResponseResult<AsynchronousInstructionResponse> objectResponse_5 = await ReadObjectResponseAsync<AsynchronousInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_2 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<ForbiddenInstructionResponse> objectResponse_3 = await ReadObjectResponseAsync<ForbiddenInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<ForbiddenInstructionResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 422:
				{
					ObjectResponseResult<BusinessRejectResponse> objectResponse_ = await ReadObjectResponseAsync<BusinessRejectResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<BusinessRejectResponse>("Returns a Problem detail instance representing a business error.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<AsynchronousInstructionResponse> CancelAsync(string client_id, Body7 body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
		}
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
			urlBuilder_.Append("gw/api/v1/instructions/cancel");
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
				case 201:
				{
					ObjectResponseResult<AsynchronousInstructionResponse> objectResponse_5 = await ReadObjectResponseAsync<AsynchronousInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_2 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<ForbiddenInstructionResponse> objectResponse_3 = await ReadObjectResponseAsync<ForbiddenInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<ForbiddenInstructionResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 422:
				{
					ObjectResponseResult<BusinessRejectResponse> objectResponse_ = await ReadObjectResponseAsync<BusinessRejectResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<BusinessRejectResponse>("Returns a Problem detail instance representing a business error.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<Response3> ClientInstructionsAsync(string client_id, int clientInstructionId, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
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
			urlBuilder_.Append("gw/api/v1/client-instructions/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(clientInstructionId, CultureInfo.InvariantCulture)));
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
					ObjectResponseResult<Response3> objectResponse_ = await ReadObjectResponseAsync<Response3>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 208:
				{
					ObjectResponseResult<AsynchronousInstructionResponse> objectResponse_3 = await ReadObjectResponseAsync<AsynchronousInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<AsynchronousInstructionResponse>("Client tried to reuse the same instructionId for more than one transaction. Returning the status for the first registered transaction under given instructionId (when there were no duplicates yet). Reconcile based on instructionSetId", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 404:
				{
					ObjectResponseResult<NoSuchInstructionResponse> objectResponse_2 = await ReadObjectResponseAsync<NoSuchInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<NoSuchInstructionResponse>("Returns a Problem detail instance representing a not found request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Unable to process request due to an Internal Error. Please try again later.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<GetBrokerListResponse> ComplexAssetTransferAsync(string client_id, string instructionType, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
		}
		if (instructionType == null)
		{
			throw new ArgumentNullException("instructionType");
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
			urlBuilder_.Append("gw/api/v1/enumerations/complex-asset-transfer");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("instructionType")).Append('=').Append(Uri.EscapeDataString(ConvertToString(instructionType, CultureInfo.InvariantCulture)))
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
					ObjectResponseResult<GetBrokerListResponse> objectResponse_2 = await ReadObjectResponseAsync<GetBrokerListResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					return objectResponse_2.Object;
				}
				case 400:
				{
					ObjectResponseResult<NoSuchInstructionResponse> objectResponse_ = await ReadObjectResponseAsync<NoSuchInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<NoSuchInstructionResponse>("Returns a Problem detail instance representing a not found request.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_3 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Unable to process request due to an Internal Error. Please try again later.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
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

	public virtual async Task<AccountDetailsResponse> DetailsAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (accountId == null)
		{
			throw new ArgumentNullException("accountId");
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
			urlBuilder_.Append("gw/api/v1/accounts/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)));
			urlBuilder_.Append("/details");
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
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<AccountDetailsResponse> objectResponse_3 = await ReadObjectResponseAsync<AccountDetailsResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<StatusResponse> DocumentsAsync(ProcessDocumentsPayload body, CancellationToken cancellationToken = default(CancellationToken))
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
			content_.Headers.ContentType = MediaTypeHeaderValue.Parse("application/jwt");
			request_.Content = content_;
			request_.Method = new HttpMethod("POST");
			request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
			StringBuilder urlBuilder_ = new StringBuilder();
			if (!string.IsNullOrEmpty(_baseUrl))
			{
				urlBuilder_.Append(_baseUrl);
			}
			urlBuilder_.Append("gw/api/v1/accounts/documents");
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
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<StatusResponse> objectResponse_3 = await ReadObjectResponseAsync<StatusResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<EnumerationResponse> EnumerationsAsync(EnumerationType type, string? currency = null, string? ibEntity = null, string? mdStatusNonPro = null, string? form_number = null, Language? language = null, string? accountId = null, CancellationToken cancellationToken = default(CancellationToken))
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
			urlBuilder_.Append("gw/api/v1/enumerations/");
			urlBuilder_.Append('?');
			if (currency != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("currency")).Append('=').Append(Uri.EscapeDataString(ConvertToString(currency, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (ibEntity != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("ibEntity")).Append('=').Append(Uri.EscapeDataString(ConvertToString(ibEntity, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (mdStatusNonPro != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("mdStatusNonPro")).Append('=').Append(Uri.EscapeDataString(ConvertToString(mdStatusNonPro, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (form_number != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("form-number")).Append('=').Append(Uri.EscapeDataString(ConvertToString(form_number, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (language.HasValue)
			{
				urlBuilder_.Append(Uri.EscapeDataString("language")).Append('=').Append(Uri.EscapeDataString(ConvertToString(language, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (accountId != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("accountId")).Append('=').Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)))
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
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<EnumerationResponse> objectResponse_3 = await ReadObjectResponseAsync<EnumerationResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<AsynchronousInstructionResponse> ExternalAssetTransfersAsync(string client_id, Body4 body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
		}
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
			urlBuilder_.Append("gw/api/v1/external-asset-transfers");
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
				case 202:
				{
					ObjectResponseResult<AsynchronousInstructionResponse> objectResponse_5 = await ReadObjectResponseAsync<AsynchronousInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_2 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<ForbiddenInstructionResponse> objectResponse_3 = await ReadObjectResponseAsync<ForbiddenInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<ForbiddenInstructionResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 422:
				{
					ObjectResponseResult<BusinessRejectResponse> objectResponse_ = await ReadObjectResponseAsync<BusinessRejectResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<BusinessRejectResponse>("Returns a Problem detail instance representing a business error.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<AsynchronousInstructionResponse> ExternalCashTransfersAsync(string client_id, Body5 body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
		}
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
			urlBuilder_.Append("gw/api/v1/external-cash-transfers");
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
				case 202:
				{
					ObjectResponseResult<AsynchronousInstructionResponse> objectResponse_5 = await ReadObjectResponseAsync<AsynchronousInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_2 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<ForbiddenInstructionResponse> objectResponse_3 = await ReadObjectResponseAsync<ForbiddenInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<ForbiddenInstructionResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 422:
				{
					ObjectResponseResult<BusinessRejectResponse> objectResponse_ = await ReadObjectResponseAsync<BusinessRejectResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<BusinessRejectResponse>("Returns a Problem detail instance representing a business error.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<FormFileResponse> FormsAsync(IEnumerable<int>? formNo = null, string? getDocs = null, string? fromDate = null, string? toDate = null, string? language = null, Projection? projection = null, CancellationToken cancellationToken = default(CancellationToken))
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
			urlBuilder_.Append("gw/api/v1/forms");
			urlBuilder_.Append('?');
			if (formNo != null)
			{
				foreach (int item_ in formNo)
				{
					urlBuilder_.Append(Uri.EscapeDataString("formNo")).Append('=').Append(Uri.EscapeDataString(ConvertToString(item_, CultureInfo.InvariantCulture)))
						.Append('&');
				}
			}
			if (getDocs != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("getDocs")).Append('=').Append(Uri.EscapeDataString(ConvertToString(getDocs, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (fromDate != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("fromDate")).Append('=').Append(Uri.EscapeDataString(ConvertToString(fromDate, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (toDate != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("toDate")).Append('=').Append(Uri.EscapeDataString(ConvertToString(toDate, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (language != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("language")).Append('=').Append(Uri.EscapeDataString(ConvertToString(language, CultureInfo.InvariantCulture)))
					.Append('&');
			}
			if (projection.HasValue)
			{
				urlBuilder_.Append(Uri.EscapeDataString("projection")).Append('=').Append(Uri.EscapeDataString(ConvertToString(projection, CultureInfo.InvariantCulture)))
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
					foreach (KeyValuePair<string, IEnumerable<string>> item_3 in response_.Content.Headers)
					{
						headers_[item_3.Key] = item_3.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<FormFileResponse> objectResponse_3 = await ReadObjectResponseAsync<FormFileResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<EchoResponse> HttpsAsync(CancellationToken cancellationToken = default(CancellationToken))
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
			urlBuilder_.Append("gw/api/v1/echo/https");
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
					ObjectResponseResult<EchoResponse> objectResponse_ = await ReadObjectResponseAsync<EchoResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 401:
				{
					ObjectResponseResult<InvalidAccessTokenResponse> objectResponse_3 = await ReadObjectResponseAsync<InvalidAccessTokenResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<InvalidAccessTokenResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<InsufficientScopeResponse> objectResponse_2 = await ReadObjectResponseAsync<InsufficientScopeResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<InsufficientScopeResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<Response5> InstructionsAsync(string client_id, int instructionId, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
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
			urlBuilder_.Append("gw/api/v1/instructions/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(instructionId, CultureInfo.InvariantCulture)));
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
					ObjectResponseResult<Response5> objectResponse_ = await ReadObjectResponseAsync<Response5>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 208:
				{
					ObjectResponseResult<AsynchronousInstructionResponse> objectResponse_3 = await ReadObjectResponseAsync<AsynchronousInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<AsynchronousInstructionResponse>("Client tried to reuse the same instructionId for more than one transaction. Returning the status for the first registered transaction under given instructionId (when there were no duplicates yet). Reconcile based on instructionSetId", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 404:
				{
					ObjectResponseResult<NoSuchInstructionResponse> objectResponse_2 = await ReadObjectResponseAsync<NoSuchInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<NoSuchInstructionResponse>("Returns a Problem detail instance representing a not found request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Unable to process request due to an Internal Error. Please try again later.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<BulkMultiStatusResponse> InstructionSetsAsync(string client_id, int instructionSetId, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
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
			urlBuilder_.Append("gw/api/v1/instruction-sets/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(instructionSetId, CultureInfo.InvariantCulture)));
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
					ObjectResponseResult<BulkMultiStatusResponse> objectResponse_2 = await ReadObjectResponseAsync<BulkMultiStatusResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					return objectResponse_2.Object;
				}
				case 404:
				{
					ObjectResponseResult<NoSuchInstructionSetResponse> objectResponse_ = await ReadObjectResponseAsync<NoSuchInstructionSetResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<NoSuchInstructionSetResponse>("Returns a Problem detail instance representing a not found request.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_3 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Unable to process request due to an Internal Error. Please try again later.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
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

	public virtual async Task<AsynchronousInstructionResponse> InternalAssetTransfersAsync(string client_id, Body9 body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
		}
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
			urlBuilder_.Append("gw/api/v1/internal-asset-transfers");
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
				case 202:
				{
					ObjectResponseResult<AsynchronousInstructionResponse> objectResponse_5 = await ReadObjectResponseAsync<AsynchronousInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_2 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<ForbiddenInstructionResponse> objectResponse_3 = await ReadObjectResponseAsync<ForbiddenInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<ForbiddenInstructionResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 422:
				{
					ObjectResponseResult<BusinessRejectResponse> objectResponse_ = await ReadObjectResponseAsync<BusinessRejectResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<BusinessRejectResponse>("Returns a Problem detail instance representing a business error.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<AsynchronousInstructionResponse> InternalCashTransfersAsync(string client_id, Body10 body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
		}
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
			urlBuilder_.Append("gw/api/v1/internal-cash-transfers");
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
				case 201:
				{
					ObjectResponseResult<AsynchronousInstructionResponse> objectResponse_ = await ReadObjectResponseAsync<AsynchronousInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 202:
				{
					ObjectResponseResult<AsynchronousInstructionResponse> objectResponse_6 = await ReadObjectResponseAsync<AsynchronousInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					return objectResponse_6.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_2 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<ForbiddenInstructionResponse> objectResponse_5 = await ReadObjectResponseAsync<ForbiddenInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ForbiddenInstructionResponse>("Returns a Problem detail instance representing a forbidden request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 422:
				{
					ObjectResponseResult<BusinessRejectResponse> objectResponse_3 = await ReadObjectResponseAsync<BusinessRejectResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<BusinessRejectResponse>("Returns a Problem detail instance representing a business error.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<Au10TixDetailResponse> KycAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (accountId == null)
		{
			throw new ArgumentNullException("accountId");
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
			urlBuilder_.Append("gw/api/v1/accounts/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)));
			urlBuilder_.Append("/kyc");
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
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<Au10TixDetailResponse> objectResponse_3 = await ReadObjectResponseAsync<Au10TixDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<LoginMessageResponse> LoginMessages2Async(string accountId, string? type = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (accountId == null)
		{
			throw new ArgumentNullException("accountId");
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
			urlBuilder_.Append("gw/api/v1/accounts/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)));
			urlBuilder_.Append("/login-messages");
			urlBuilder_.Append('?');
			if (type != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("type")).Append('=').Append(Uri.EscapeDataString(ConvertToString(type, CultureInfo.InvariantCulture)))
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
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<LoginMessageResponse> objectResponse_3 = await ReadObjectResponseAsync<LoginMessageResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<LoginMessageResponse> LoginMessagesAsync(LoginMessageRequest loginMessageRequest, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (loginMessageRequest == null)
		{
			throw new ArgumentNullException("loginMessageRequest");
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
			urlBuilder_.Append("gw/api/v1/accounts/login-messages");
			urlBuilder_.Append('?');
			foreach (KeyValuePair<string, object> item_ in loginMessageRequest.AdditionalProperties)
			{
				urlBuilder_.Append(Uri.EscapeDataString(item_.Key)).Append('=').Append(Uri.EscapeDataString(ConvertToString(item_.Value, CultureInfo.InvariantCulture)))
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
					foreach (KeyValuePair<string, IEnumerable<string>> item_3 in response_.Content.Headers)
					{
						headers_[item_3.Key] = item_3.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<LoginMessageResponse> objectResponse_3 = await ReadObjectResponseAsync<LoginMessageResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<GetParticipatingListResponse> ParticipatingBanksAsync(string client_id, string type, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
		}
		if (type == null)
		{
			throw new ArgumentNullException("type");
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
			urlBuilder_.Append("gw/api/v1/participating-banks");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("type")).Append('=').Append(Uri.EscapeDataString(ConvertToString(type, CultureInfo.InvariantCulture)))
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
					ObjectResponseResult<GetParticipatingListResponse> objectResponse_2 = await ReadObjectResponseAsync<GetParticipatingListResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					return objectResponse_2.Object;
				}
				case 400:
				{
					ObjectResponseResult<NoSuchInstructionResponse> objectResponse_ = await ReadObjectResponseAsync<NoSuchInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<NoSuchInstructionResponse>("Returns a Problem detail instance representing a not found request.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_3 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Unable to process request due to an Internal Error. Please try again later.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
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

	public virtual async Task<Response4> Query2Async(string client_id, Body6 body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
		}
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
			urlBuilder_.Append("gw/api/v1/external-cash-transfers/query");
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
				case 201:
				{
					ObjectResponseResult<Response4> objectResponse_ = await ReadObjectResponseAsync<Response4>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 202:
				{
					ObjectResponseResult<AsynchronousInstructionResponse> objectResponse_6 = await ReadObjectResponseAsync<AsynchronousInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<AsynchronousInstructionResponse>("Accepts request to create a new instruction asynchronously", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_2 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<ForbiddenInstructionResponse> objectResponse_5 = await ReadObjectResponseAsync<ForbiddenInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ForbiddenInstructionResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 422:
				{
					ObjectResponseResult<BusinessRejectResponse> objectResponse_3 = await ReadObjectResponseAsync<BusinessRejectResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<BusinessRejectResponse>("Returns a Problem detail instance representing a business error.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<AsynchronousInstructionResponse> Query3Async(string client_id, Body8 body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
		}
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
			urlBuilder_.Append("gw/api/v1/instructions/query");
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
				case 202:
				{
					ObjectResponseResult<AsynchronousInstructionResponse> objectResponse_5 = await ReadObjectResponseAsync<AsynchronousInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_2 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<ForbiddenInstructionResponse> objectResponse_3 = await ReadObjectResponseAsync<ForbiddenInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<ForbiddenInstructionResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 422:
				{
					ObjectResponseResult<BusinessRejectResponse> objectResponse_ = await ReadObjectResponseAsync<BusinessRejectResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<BusinessRejectResponse>("Returns a Problem detail instance representing a business error.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<Response2> QueryAsync(string client_id, Body3 body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (client_id == null)
		{
			throw new ArgumentNullException("client_id");
		}
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
			urlBuilder_.Append("gw/api/v1/bank-instructions/query");
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
				case 201:
				{
					ObjectResponseResult<Response2> objectResponse_5 = await ReadObjectResponseAsync<Response2>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_2 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<ForbiddenInstructionResponse> objectResponse_3 = await ReadObjectResponseAsync<ForbiddenInstructionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<ForbiddenInstructionResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 422:
				{
					ObjectResponseResult<BusinessRejectResponse> objectResponse_ = await ReadObjectResponseAsync<BusinessRejectResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<BusinessRejectResponse>("Returns a Problem detail instance representing a business error.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<RequestDetailsResponse> RequestsAsync(RequestDetailsRequest requestDetails, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (requestDetails == null)
		{
			throw new ArgumentNullException("requestDetails");
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
			urlBuilder_.Append("gw/api/v1/requests");
			urlBuilder_.Append('?');
			foreach (KeyValuePair<string, object> item_ in requestDetails.AdditionalProperties)
			{
				urlBuilder_.Append(Uri.EscapeDataString(item_.Key)).Append('=').Append(Uri.EscapeDataString(ConvertToString(item_.Value, CultureInfo.InvariantCulture)))
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
					foreach (KeyValuePair<string, IEnumerable<string>> item_3 in response_.Content.Headers)
					{
						headers_[item_3.Key] = item_3.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<RequestDetailsResponse> objectResponse_3 = await ReadObjectResponseAsync<RequestDetailsResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<EchoResponse> SignedJwtAsync(object? body = null, CancellationToken cancellationToken = default(CancellationToken))
	{
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
			urlBuilder_.Append("gw/api/v1/echo/signed-jwt");
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
					ObjectResponseResult<EchoResponse> objectResponse_ = await ReadObjectResponseAsync<EchoResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 401:
				{
					ObjectResponseResult<InvalidAccessTokenResponse> objectResponse_3 = await ReadObjectResponseAsync<InvalidAccessTokenResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<InvalidAccessTokenResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<InsufficientScopeResponse> objectResponse_2 = await ReadObjectResponseAsync<InsufficientScopeResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<InsufficientScopeResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<CreateBrowserSessionResponse> SsoBrowserSessionsAsync(string authorization, object? body = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		HttpClient client_ = _httpClient;
		bool disposeClient_ = false;
		try
		{
			using HttpRequestMessage request_ = new HttpRequestMessage();
			if (authorization == null)
			{
				throw new ArgumentNullException("authorization");
			}
			request_.Headers.TryAddWithoutValidation("authorization", ConvertToString(authorization, CultureInfo.InvariantCulture));
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
			urlBuilder_.Append("gw/api/v1/sso-browser-sessions");
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
					ObjectResponseResult<CreateBrowserSessionResponse> objectResponse_5 = await ReadObjectResponseAsync<CreateBrowserSessionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_2 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<InvalidAccessTokenResponse> objectResponse_3 = await ReadObjectResponseAsync<InvalidAccessTokenResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<InvalidAccessTokenResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<InsufficientScopeResponse> objectResponse_ = await ReadObjectResponseAsync<InsufficientScopeResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<InsufficientScopeResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<CreateSessionResponse> SsoSessionsAsync(string authorization, object? body = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		HttpClient client_ = _httpClient;
		bool disposeClient_ = false;
		try
		{
			using HttpRequestMessage request_ = new HttpRequestMessage();
			if (authorization == null)
			{
				throw new ArgumentNullException("authorization");
			}
			request_.Headers.TryAddWithoutValidation("authorization", ConvertToString(authorization, CultureInfo.InvariantCulture));
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
			urlBuilder_.Append("gw/api/v1/sso-sessions");
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
					ObjectResponseResult<CreateSessionResponse> objectResponse_5 = await ReadObjectResponseAsync<CreateSessionResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					return objectResponse_5.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_2 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<InvalidAccessTokenResponse> objectResponse_3 = await ReadObjectResponseAsync<InvalidAccessTokenResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<InvalidAccessTokenResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<InsufficientScopeResponse> objectResponse_ = await ReadObjectResponseAsync<InsufficientScopeResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<InsufficientScopeResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<GetStatementsResponse> StatementsAsync(string authorization, StmtRequest body, CancellationToken cancellationToken = default(CancellationToken))
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
			if (authorization == null)
			{
				throw new ArgumentNullException("authorization");
			}
			request_.Headers.TryAddWithoutValidation("authorization", ConvertToString(authorization, CultureInfo.InvariantCulture));
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
			urlBuilder_.Append("gw/api/v1/statements");
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
					ObjectResponseResult<GetStatementsResponse> objectResponse_ = await ReadObjectResponseAsync<GetStatementsResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_6 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<InvalidAccessTokenResponse> objectResponse_2 = await ReadObjectResponseAsync<InvalidAccessTokenResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<InvalidAccessTokenResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 402:
				{
					ObjectResponseResult<UnauthorizedAccessResponse> objectResponse_5 = await ReadObjectResponseAsync<UnauthorizedAccessResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<UnauthorizedAccessResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<InsufficientScopeResponse> objectResponse_3 = await ReadObjectResponseAsync<InsufficientScopeResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<InsufficientScopeResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<AccountStatusResponse> StatusGET2Async(string accountId, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (accountId == null)
		{
			throw new ArgumentNullException("accountId");
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
			urlBuilder_.Append("gw/api/v1/accounts/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)));
			urlBuilder_.Append("/status");
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
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<AccountStatusResponse> objectResponse_3 = await ReadObjectResponseAsync<AccountStatusResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<AmRequestStatusResponse> StatusGET3Async(int requestId, Type2 type, CancellationToken cancellationToken = default(CancellationToken))
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
			urlBuilder_.Append("gw/api/v1/requests/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(requestId, CultureInfo.InvariantCulture)));
			urlBuilder_.Append("/status");
			urlBuilder_.Append('?');
			urlBuilder_.Append(Uri.EscapeDataString("type")).Append('=').Append(Uri.EscapeDataString(ConvertToString(type, CultureInfo.InvariantCulture)))
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
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<AmRequestStatusResponse> objectResponse_3 = await ReadObjectResponseAsync<AmRequestStatusResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<AccountStatusBulkResponse> StatusGETAsync(AccountStatusRequest accountStatusRequest, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (accountStatusRequest == null)
		{
			throw new ArgumentNullException("accountStatusRequest");
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
			urlBuilder_.Append("gw/api/v1/accounts/status");
			urlBuilder_.Append('?');
			foreach (KeyValuePair<string, object> item_ in accountStatusRequest.AdditionalProperties)
			{
				urlBuilder_.Append(Uri.EscapeDataString(item_.Key)).Append('=').Append(Uri.EscapeDataString(ConvertToString(item_.Value, CultureInfo.InvariantCulture)))
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
					foreach (KeyValuePair<string, IEnumerable<string>> item_3 in response_.Content.Headers)
					{
						headers_[item_3.Key] = item_3.Value;
					}
				}
				int status_ = (int)response_.StatusCode;
				switch (status_)
				{
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<AccountStatusBulkResponse> objectResponse_3 = await ReadObjectResponseAsync<AccountStatusBulkResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<RegistrationTasksResponse> TasksAsync(string accountId, Models.Type? type = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (accountId == null)
		{
			throw new ArgumentNullException("accountId");
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
			urlBuilder_.Append("gw/api/v1/accounts/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)));
			urlBuilder_.Append("/tasks");
			urlBuilder_.Append('?');
			if (type.HasValue)
			{
				urlBuilder_.Append(Uri.EscapeDataString("type")).Append('=').Append(Uri.EscapeDataString(ConvertToString(type, CultureInfo.InvariantCulture)))
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
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<RegistrationTasksResponse> objectResponse_3 = await ReadObjectResponseAsync<RegistrationTasksResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<TaxFormResponse> TaxDocumentsAsync(string authorization, TaxFormRequest body, CancellationToken cancellationToken = default(CancellationToken))
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
			if (authorization == null)
			{
				throw new ArgumentNullException("authorization");
			}
			request_.Headers.TryAddWithoutValidation("authorization", ConvertToString(authorization, CultureInfo.InvariantCulture));
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
			urlBuilder_.Append("gw/api/v1/tax-documents");
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
					ObjectResponseResult<TaxFormResponse> objectResponse_ = await ReadObjectResponseAsync<TaxFormResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_6 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<InvalidAccessTokenResponse> objectResponse_2 = await ReadObjectResponseAsync<InvalidAccessTokenResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<InvalidAccessTokenResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 402:
				{
					ObjectResponseResult<UnauthorizedAccessResponse> objectResponse_5 = await ReadObjectResponseAsync<UnauthorizedAccessResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<UnauthorizedAccessResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<InsufficientScopeResponse> objectResponse_3 = await ReadObjectResponseAsync<InsufficientScopeResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<InsufficientScopeResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<TradeConfirmationResponse> TradeConfirmationsAsync(string authorization, TradeConfirmationRequest body, CancellationToken cancellationToken = default(CancellationToken))
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
			if (authorization == null)
			{
				throw new ArgumentNullException("authorization");
			}
			request_.Headers.TryAddWithoutValidation("authorization", ConvertToString(authorization, CultureInfo.InvariantCulture));
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
			urlBuilder_.Append("gw/api/v1/trade-confirmations");
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
					ObjectResponseResult<TradeConfirmationResponse> objectResponse_ = await ReadObjectResponseAsync<TradeConfirmationResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 400:
				{
					ObjectResponseResult<MissingRequiredParameterResponse> objectResponse_6 = await ReadObjectResponseAsync<MissingRequiredParameterResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<MissingRequiredParameterResponse>("Returns a Problem detail instance representing a bad request.", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<InvalidAccessTokenResponse> objectResponse_2 = await ReadObjectResponseAsync<InvalidAccessTokenResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<InvalidAccessTokenResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 402:
				{
					ObjectResponseResult<UnauthorizedAccessResponse> objectResponse_5 = await ReadObjectResponseAsync<UnauthorizedAccessResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<UnauthorizedAccessResponse>("Returns a Problem detail instance representing an unauthorized request.", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 403:
				{
					ObjectResponseResult<InsufficientScopeResponse> objectResponse_3 = await ReadObjectResponseAsync<InsufficientScopeResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<InsufficientScopeResponse>("Returns a Problem detail instance representing a forbidden request.", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<InternalServerErrorResponse> objectResponse_4 = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<InternalServerErrorResponse>("Returns a Problem detail instance representing an internal server error.", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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

	public virtual async Task<UserNameAvailableResponse> UsernamesAsync(string username, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (username == null)
		{
			throw new ArgumentNullException("username");
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
			urlBuilder_.Append("gw/api/v1/validations/usernames/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(username, CultureInfo.InvariantCulture)));
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
				case 403:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_ = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
				}
				case 415:
				{
					ObjectResponseResult<IDictionary<string, object>> objectResponse_6 = await ReadObjectResponseAsync<IDictionary<string, object>>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_6.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_6.Text, headers_, null);
					}
					throw new ApiException<IDictionary<string, object>>("Unsupported Media Type", status_, objectResponse_6.Text, headers_, objectResponse_6.Object, null);
				}
				case 500:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_2 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_2.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_2.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing internal server error", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
				}
				case 400:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_5 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_5.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_5.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing bad request", status_, objectResponse_5.Text, headers_, objectResponse_5.Object, null);
				}
				case 200:
				{
					ObjectResponseResult<UserNameAvailableResponse> objectResponse_3 = await ReadObjectResponseAsync<UserNameAvailableResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					return objectResponse_3.Object;
				}
				case 401:
				{
					ObjectResponseResult<ProblemDetailResponse> objectResponse_4 = await ReadObjectResponseAsync<ProblemDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_4.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_4.Text, headers_, null);
					}
					throw new ApiException<ProblemDetailResponse>("Returns error description representing access issue", status_, objectResponse_4.Text, headers_, objectResponse_4.Object, null);
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
