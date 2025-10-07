using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AlertActivationResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("request_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Request_id { get; set; } = 0;

	[JsonProperty("order_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Order_id { get; set; } = 0;

	[JsonProperty("success", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Success { get; set; } = false;

	[JsonProperty("text", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Text { get; set; } = null;

	[JsonProperty("failure_list", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Failure_list { get; set; } = null;

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
