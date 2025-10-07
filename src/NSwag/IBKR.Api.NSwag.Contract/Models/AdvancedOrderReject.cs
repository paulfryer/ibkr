using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AdvancedOrderReject
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("orderId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int OrderId { get; set; } = 0;


	[JsonProperty("reqId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ReqId { get; set; } = null;


	[JsonProperty("dismissable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<object> Dismissable { get; set; } = null;


	[JsonProperty("text", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Text { get; set; } = null;


	[JsonProperty("options", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> Options { get; set; } = null;


	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Type { get; set; } = null;


	[JsonProperty("messageId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MessageId { get; set; } = null;


	[JsonProperty("prompt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Prompt { get; set; } = false;


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
