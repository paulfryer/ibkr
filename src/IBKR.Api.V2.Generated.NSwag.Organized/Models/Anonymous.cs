using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Anonymous
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("D", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string D { get; set; } = null;

	[JsonProperty("ID", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ID { get; set; } = null;

	[JsonProperty("FC", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FC { get; set; } = null;

	[JsonProperty("MD", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MD { get; set; } = null;

	[JsonProperty("MS", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MS { get; set; } = null;

	[JsonProperty("R", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string R { get; set; } = null;

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
