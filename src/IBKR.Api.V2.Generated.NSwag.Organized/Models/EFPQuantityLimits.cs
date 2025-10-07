using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class EFPQuantityLimits
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("maxNominalEfpPerOrder", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int MaxNominalEfpPerOrder { get; set; } = 0;

	[JsonProperty("maxNetEfpTrades", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int MaxNetEfpTrades { get; set; } = 0;

	[JsonProperty("maxGrossEfpTrades", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int MaxGrossEfpTrades { get; set; } = 0;

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
