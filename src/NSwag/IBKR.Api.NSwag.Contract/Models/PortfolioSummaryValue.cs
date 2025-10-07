using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PortfolioSummaryValue
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("amount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Amount { get; set; } = 0.0;


	[JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Currency { get; set; } = 0.0;


	[JsonProperty("isNull", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsNull { get; set; } = false;


	[JsonProperty("severity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Severity { get; set; } = 0;


	[JsonProperty("timestamp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Timestamp { get; set; } = 0;


	[JsonProperty("value", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Value { get; set; } = null;


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
