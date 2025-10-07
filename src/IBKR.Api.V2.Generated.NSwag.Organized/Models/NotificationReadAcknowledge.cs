using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class NotificationReadAcknowledge
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("V", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int V { get; set; } = 0;

	[JsonProperty("T", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int T { get; set; } = 0;

	[JsonProperty("P", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public P P { get; set; } = null;

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
