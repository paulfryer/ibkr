using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class OrderPreview
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("amount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Amount Amount { get; set; } = null;


	[JsonProperty("equity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Equity Equity { get; set; } = null;


	[JsonProperty("initial", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Initial Initial { get; set; } = null;


	[JsonProperty("maintenance", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Maintenance Maintenance { get; set; } = null;


	[JsonProperty("position", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Position Position { get; set; } = null;


	[JsonProperty("warn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Warn { get; set; } = null;


	[JsonProperty("error", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Error { get; set; } = null;


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
