using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class NAVRangeType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("min", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Min { get; set; } = 0.0;

	[JsonProperty("max", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Max { get; set; } = 0.0;

	[JsonProperty("maxFee", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double MaxFee { get; set; } = 0.0;

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
