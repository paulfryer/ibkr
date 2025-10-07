using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Details
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("question", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Question { get; set; } = null;


	[JsonProperty("answer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Answer { get; set; } = null;


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
