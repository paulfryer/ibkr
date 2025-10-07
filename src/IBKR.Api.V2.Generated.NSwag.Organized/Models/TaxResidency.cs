using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TaxResidency
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("country", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Country { get; set; } = null;

	[JsonProperty("tin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Tin { get; set; } = null;

	[JsonProperty("tinType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public TaxResidencyTinType TinType { get; set; } = TaxResidencyTinType.SSN;

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
