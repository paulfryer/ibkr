using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class DisplayRuleStep
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("decimalDigits", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int DecimalDigits { get; set; } = 0;


	[JsonProperty("lowerEdge", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double LowerEdge { get; set; } = 0.0;


	[JsonProperty("wholeDigits", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int WholeDigits { get; set; } = 0;


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
