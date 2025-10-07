using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TransactionsResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("rc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Rc { get; set; } = 0;


	[JsonProperty("nd", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Nd { get; set; } = 0;


	[JsonProperty("rpnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Rpnl Rpnl { get; set; } = null;


	[JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Currency { get; set; } = null;


	[JsonProperty("from", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int From { get; set; } = 0;


	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Id { get; set; } = null;


	[JsonProperty("to", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int To { get; set; } = 0;


	[JsonProperty("includesRealTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IncludesRealTime { get; set; } = false;


	[JsonProperty("transactions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<Transactions> Transactions { get; set; } = null;


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
