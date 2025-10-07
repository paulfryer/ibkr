using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class CommissionScheduleType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("markups", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<CommissionMarkupType> Markups { get; set; } = null;

	[JsonProperty("pricingStructure", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public CommissionScheduleTypePricingStructure PricingStructure { get; set; } = CommissionScheduleTypePricingStructure.FIXED;

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
