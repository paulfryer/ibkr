using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IndividualName
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("salutation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public IndividualNameSalutation Salutation { get; set; } = IndividualNameSalutation.Mr_;

	[JsonProperty("first", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string First { get; set; } = null;

	[JsonProperty("last", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Last { get; set; } = null;

	[JsonProperty("middle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Middle { get; set; } = null;

	[JsonProperty("suffix", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public IndividualNameSuffix Suffix { get; set; } = IndividualNameSuffix.Jr_;

	[JsonProperty("title", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Title { get; set; } = null;

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
