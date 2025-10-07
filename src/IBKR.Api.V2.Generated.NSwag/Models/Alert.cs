using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Alert
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("order_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Order_id { get; set; } = 0;


	[JsonProperty("account", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Account { get; set; } = null;


	[JsonProperty("alert_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Alert_name { get; set; } = null;


	[JsonProperty("alert_active", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Alert_active { get; set; } = 0;


	[JsonProperty("order_time", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Order_time { get; set; } = null;


	[JsonProperty("alert_triggered", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Alert_triggered { get; set; } = false;


	[JsonProperty("alert_repeatable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Alert_repeatable { get; set; } = 0;


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
