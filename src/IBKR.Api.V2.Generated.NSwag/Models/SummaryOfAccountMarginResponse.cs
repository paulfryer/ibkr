using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class SummaryOfAccountMarginResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("total", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Total3 Total { get; set; } = null;


	[JsonProperty("commodities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Commodities2 Commodities { get; set; } = null;


	[JsonProperty("securities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Securities3 Securities { get; set; } = null;


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
