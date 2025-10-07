using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RepresentativeDetail
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("representativeId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string RepresentativeId { get; set; } = null;

	[JsonProperty("percentage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Percentage { get; set; } = 0;

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
