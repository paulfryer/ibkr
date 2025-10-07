using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class UpdatePassword
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("encryptedPassword", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string EncryptedPassword { get; set; } = null;

	[JsonProperty("encryptedKeyName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string EncryptedKeyName { get; set; } = null;

	[JsonProperty("token", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Token { get; set; } = null;

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
