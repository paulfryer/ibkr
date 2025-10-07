using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class BrokerageSessionStatus
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("authenticated", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Authenticated { get; set; } = false;

	[JsonProperty("competing", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Competing { get; set; } = false;

	[JsonProperty("connected", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Connected { get; set; } = false;

	[JsonProperty("message", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Message { get; set; } = null;

	[JsonProperty("MAC", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MAC { get; set; } = null;

	[JsonProperty("serverInfo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ServerInfo ServerInfo { get; set; } = null;

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
