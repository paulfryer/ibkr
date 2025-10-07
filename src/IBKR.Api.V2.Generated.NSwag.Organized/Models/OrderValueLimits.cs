using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class OrderValueLimits
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("maxOrderValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double MaxOrderValue { get; set; } = 0.0;

	[JsonProperty("maxGrossValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double MaxGrossValue { get; set; } = 0.0;

	[JsonProperty("maxNetValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double MaxNetValue { get; set; } = 0.0;

	[JsonProperty("netContractLimit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double NetContractLimit { get; set; } = 0.0;

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
