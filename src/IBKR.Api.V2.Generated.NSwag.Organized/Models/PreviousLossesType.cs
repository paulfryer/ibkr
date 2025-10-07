using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PreviousLossesType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("loss", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Loss { get; set; } = 0;

	[JsonProperty("quarter", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Quarter { get; set; } = 0;

	[JsonProperty("year", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Year { get; set; } = 0;

	[JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Currency { get; set; } = null;

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
