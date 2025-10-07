using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Maintenance
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("current", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Current { get; set; } = null;

	[JsonProperty("change", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Change { get; set; } = null;

	[JsonProperty("after", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string After { get; set; } = null;

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
