using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Response21
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("is_true", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Is_true { get; set; } = false;


	[JsonProperty("oauth_token", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Oauth_token { get; set; } = null;


	[JsonProperty("oauth_token_secret", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Oauth_token_secret { get; set; } = null;


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
