using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Features2
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("envs", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Envs { get; set; } = null;

	[JsonProperty("wlms", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Wlms { get; set; } = false;

	[JsonProperty("realtime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Realtime { get; set; } = false;

	[JsonProperty("bond", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Bond { get; set; } = false;

	[JsonProperty("optionChains", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool OptionChains { get; set; } = false;

	[JsonProperty("calendar", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Calendar { get; set; } = false;

	[JsonProperty("newMf", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool NewMf { get; set; } = false;

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
