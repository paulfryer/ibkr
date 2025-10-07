using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AlertCondition
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("condition_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Condition_type { get; set; } = 0;


	[JsonProperty("conidex", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Conidex { get; set; } = null;


	[JsonProperty("contract_description_1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Contract_description_1 { get; set; } = null;


	[JsonProperty("condition_operator", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Condition_operator { get; set; } = null;


	[JsonProperty("condition_trigger_method", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Condition_trigger_method { get; set; } = 0;


	[JsonProperty("condition_value", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Condition_value { get; set; } = null;


	[JsonProperty("condition_logic_bind", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Condition_logic_bind { get; set; } = false;


	[JsonProperty("condition_time_zone", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Condition_time_zone { get; set; } = null;


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
