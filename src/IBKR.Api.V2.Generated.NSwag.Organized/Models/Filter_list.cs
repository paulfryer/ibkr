using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Filter_list
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("group", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Group { get; set; } = null;

	[JsonProperty("display_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Display_name { get; set; } = null;

	[JsonProperty("code", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Code { get; set; } = null;

	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Type { get; set; } = null;

	[JsonProperty("combo_values", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<Combo_values> Combo_values { get; set; } = null;

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
