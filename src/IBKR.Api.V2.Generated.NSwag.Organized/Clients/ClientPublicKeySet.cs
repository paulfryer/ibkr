using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using IBKR.Api.V2.Generated.NSwag.Models;

namespace IBKR.Api.V2.Generated.NSwag.Clients;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ClientPublicKeySet
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("keys", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<Keys> Keys { get; set; } = null;

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
