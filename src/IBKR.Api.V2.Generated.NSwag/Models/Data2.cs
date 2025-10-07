using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Data2
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("idType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string IdType { get; set; } = null;


	[JsonProperty("start", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Start { get; set; } = null;


	[JsonProperty("end", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string End { get; set; } = null;


	[JsonProperty("returns", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<object> Returns { get; set; } = null;


	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Id { get; set; } = null;


	[JsonProperty("baseCurrency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BaseCurrency { get; set; } = null;


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
