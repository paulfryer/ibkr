using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IncrementRules
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("increment", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Increment { get; set; } = 0.0;

	[JsonProperty("lowerEdge", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double LowerEdge { get; set; } = 0.0;

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
