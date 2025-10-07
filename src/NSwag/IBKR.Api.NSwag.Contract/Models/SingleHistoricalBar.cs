using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class SingleHistoricalBar
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("t", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int T { get; set; } = 0;


	[JsonProperty("o", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double O { get; set; } = 0.0;


	[JsonProperty("c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double C { get; set; } = 0.0;


	[JsonProperty("h", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double H { get; set; } = 0.0;


	[JsonProperty("l", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double L { get; set; } = 0.0;


	[JsonProperty("v", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double V { get; set; } = 0.0;


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
