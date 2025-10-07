using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Presets
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("group_auto_close_positions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Group_auto_close_positions { get; set; } = false;

	[JsonProperty("default_method_for_all", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public PresetsDefault_method_for_all Default_method_for_all { get; set; } = PresetsDefault_method_for_all.AvailableEquity;

	[JsonProperty("profiles_auto_close_positions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Profiles_auto_close_positions { get; set; } = false;

	[JsonProperty("strict_credit_check", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Strict_credit_check { get; set; } = false;

	[JsonProperty("group_proportional_allocation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Group_proportional_allocation { get; set; } = false;

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
