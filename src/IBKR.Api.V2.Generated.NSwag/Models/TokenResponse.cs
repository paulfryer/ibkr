using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TokenResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("access_token", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Access_token { get; set; } = null;


	[JsonProperty("refresh_token", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Refresh_token { get; set; } = null;


	[JsonProperty("id_token", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Id_token { get; set; } = null;


	[JsonProperty("token_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Token_type { get; set; } = null;


	[JsonProperty("scope", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Scope { get; set; } = null;


	[JsonProperty("expires_in", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public long Expires_in { get; set; } = 0L;


	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get
		{
			return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
		}
		set
		{
			_additionalProperties = value;
		}
	}
}
