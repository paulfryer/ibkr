using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PoliticalMilitaryDiplomaticDetailsType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("personName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PersonName { get; set; } = null;

	[JsonProperty("title", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Title { get; set; } = null;

	[JsonProperty("organization", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Organization { get; set; } = null;

	[JsonProperty("country", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Country { get; set; } = null;

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
