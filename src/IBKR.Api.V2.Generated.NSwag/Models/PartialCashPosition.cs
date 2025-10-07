using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PartialCashPosition
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("amount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public float Amount { get; set; } = 0f;


	[JsonProperty("marginLoan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool MarginLoan { get; set; } = false;


	[JsonProperty("fullCash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool FullCash { get; set; } = false;


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
