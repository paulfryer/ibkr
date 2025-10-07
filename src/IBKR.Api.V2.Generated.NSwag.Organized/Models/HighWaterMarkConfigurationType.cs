using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class HighWaterMarkConfigurationType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("numberOfPeriods", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int NumberOfPeriods { get; set; } = 0;

	[JsonProperty("prorateForWithdrawals", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ProrateForWithdrawals { get; set; } = false;

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
