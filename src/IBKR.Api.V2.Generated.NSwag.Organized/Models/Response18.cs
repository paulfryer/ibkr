using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Response18
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("call", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<double> Call { get; set; } = null;

	[JsonProperty("put", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<double> Put { get; set; } = null;

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
