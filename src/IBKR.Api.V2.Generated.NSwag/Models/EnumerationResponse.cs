using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class EnumerationResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("enumerationsType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string EnumerationsType { get; set; } = null;


	[JsonProperty("formNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FormNumber { get; set; } = null;


	[JsonProperty("jsonData", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ArrayNode JsonData { get; set; } = null;


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
