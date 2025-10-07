using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AuthorizationCode
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("code", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Code { get; set; } = null;

	[JsonProperty("hash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Hash { get; set; } = null;

	[JsonProperty("hash_algorithm", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Hash_algorithm { get; set; } = null;

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
