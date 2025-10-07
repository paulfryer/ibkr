using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Body16
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Conid { get; set; } = 0;

	[JsonProperty("isBuy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsBuy { get; set; } = true;

	[JsonProperty("modifyOrder", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ModifyOrder { get; set; } = false;

	[JsonProperty("orderId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int OrderId { get; set; } = 0;

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
