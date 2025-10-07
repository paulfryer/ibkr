using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AlertDetails
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("account", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Account { get; set; } = null;

	[JsonProperty("order_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Order_id { get; set; } = 0;

	[JsonProperty("alertName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AlertName { get; set; } = null;

	[JsonProperty("tif", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Tif { get; set; } = null;

	[JsonProperty("expire_time", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Expire_time { get; set; } = null;

	[JsonProperty("alert_active", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Alert_active { get; set; } = 0;

	[JsonProperty("alert_repeatable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Alert_repeatable { get; set; } = 0;

	[JsonProperty("alert_email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Alert_email { get; set; } = null;

	[JsonProperty("alert_send_message", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Alert_send_message { get; set; } = 0;

	[JsonProperty("alert_message", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Alert_message { get; set; } = null;

	[JsonProperty("alert_show_popup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Alert_show_popup { get; set; } = 0;

	[JsonProperty("alert_play_audio", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Alert_play_audio { get; set; } = 0;

	[JsonProperty("order_status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AlertDetailsOrder_status Order_status { get; set; } = AlertDetailsOrder_status.Presubmitted;

	[JsonProperty("alert_triggered", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Alert_triggered { get; set; } = 0;

	[JsonProperty("fg_color", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Fg_color { get; set; } = null;

	[JsonProperty("bg_color", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Bg_color { get; set; } = null;

	[JsonProperty("order_not_editable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Order_not_editable { get; set; } = false;

	[JsonProperty("itws_orders_only", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Itws_orders_only { get; set; } = 0;

	[JsonProperty("alert_mta_currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Alert_mta_currency { get; set; } = null;

	[JsonProperty("alert_mta_defaults", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Alert_mta_defaults { get; set; } = null;

	[JsonProperty("tool_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Tool_id { get; set; } = 0;

	[JsonProperty("time_zone", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Time_zone { get; set; } = null;

	[JsonProperty("alert_default_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Alert_default_type { get; set; } = 0;

	[JsonProperty("condition_size", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Condition_size { get; set; } = 0;

	[JsonProperty("condition_outside_rth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Condition_outside_rth { get; set; } = 0;

	[JsonProperty("conditions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<AlertCondition> Conditions { get; set; } = null;

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
