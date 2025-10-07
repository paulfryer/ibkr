using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PublicCompanyInfoType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("exchangeTradedOn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExchangeTradedOn { get; set; } = null;


	[JsonProperty("quotedSymbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string QuotedSymbol { get; set; } = null;


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
