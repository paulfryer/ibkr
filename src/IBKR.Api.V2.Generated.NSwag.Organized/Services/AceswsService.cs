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
/// Implementation of AceswsService
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class AceswsService : IAceswsService
{
	private readonly HttpClient _httpClient;
	private readonly Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;
	private readonly string _baseUrl;

	public AceswsService(HttpClient httpClient)
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

	public virtual async Task<SignatureAndOwners> SignaturesAndOwnersAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken))
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
			urlBuilder_.Append("acesws/");
			urlBuilder_.Append(Uri.EscapeDataString(ConvertToString(accountId, CultureInfo.InvariantCulture)));
			urlBuilder_.Append("/signatures-and-owners");
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
					ObjectResponseResult<SignatureAndOwners> objectResponse_ = await ReadObjectResponseAsync<SignatureAndOwners>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
					}
					return objectResponse_.Object;
				}
				case 400:
				{
					ObjectResponseResult<ErrorResponse> objectResponse_3 = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (objectResponse_3.Object == null)
					{
						throw new ApiException("Response was null which was not expected.", status_, objectResponse_3.Text, headers_, null);
					}
					throw new ApiException<ErrorResponse>("bad request; accountId is empty", status_, objectResponse_3.Text, headers_, objectResponse_3.Object, null);
				}
				case 401:
				{
					ObjectResponseResult<string?> objectResponse_2 = await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					throw new ApiException<string>("access denied", status_, objectResponse_2.Text, headers_, objectResponse_2.Object, null);
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
