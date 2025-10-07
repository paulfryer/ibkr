using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class LocalTaxForm
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("taxAuthority", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public LocalTaxFormTaxAuthority TaxAuthority { get; set; } = LocalTaxFormTaxAuthority.ISRAEL_TA;

	[JsonProperty("qualified", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Qualified { get; set; } = false;

	[JsonProperty("treatyCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TreatyCountry { get; set; } = null;

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
