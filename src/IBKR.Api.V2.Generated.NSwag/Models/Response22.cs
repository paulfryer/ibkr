using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Response22
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("diffie_hellman_challenge", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Diffie_hellman_challenge { get; set; } = null;


	[JsonProperty("live_session_token_signature", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Live_session_token_signature { get; set; } = null;


	[JsonProperty("live_session_token_expiration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Live_session_token_expiration { get; set; } = 0;


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
