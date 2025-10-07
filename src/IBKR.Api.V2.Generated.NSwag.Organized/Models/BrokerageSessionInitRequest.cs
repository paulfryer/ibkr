using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class BrokerageSessionInitRequest
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("publish", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Publish { get; set; } = false;

	[JsonProperty("compete", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Compete { get; set; } = false;

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
