using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Transactions
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("date", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Date { get; set; } = null;

	[JsonProperty("cur", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Cur { get; set; } = null;

	[JsonProperty("fxRate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int FxRate { get; set; } = 0;

	[JsonProperty("pr", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Pr { get; set; } = 0;

	[JsonProperty("qty", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Qty { get; set; } = 0;

	[JsonProperty("acctid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Acctid { get; set; } = null;

	[JsonProperty("amt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Amt { get; set; } = 0;

	[JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Conid { get; set; } = 0;

	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Type { get; set; } = null;

	[JsonProperty("desc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Desc { get; set; } = null;

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
