using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Anonymous2
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int A { get; set; } = 0;

	[JsonProperty("FC", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FC { get; set; } = null;

	[JsonProperty("H", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int H { get; set; } = 0;

	[JsonProperty("FD", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FD { get; set; } = null;

	[JsonProperty("FN", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FN { get; set; } = null;

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
