using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AmRequestStatusResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("requestId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string RequestId { get; set; } = null;


	[JsonProperty("requestType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string RequestType { get; set; } = null;


	[JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Status { get; set; } = null;


	[JsonProperty("message", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Message { get; set; } = null;


	[JsonProperty("acctId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AcctId { get; set; } = null;


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
