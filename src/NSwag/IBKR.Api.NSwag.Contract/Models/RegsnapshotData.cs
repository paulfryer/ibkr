using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RegsnapshotData
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Conid { get; set; } = 0;


	[JsonProperty("conidEx", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ConidEx { get; set; } = null;


	[JsonProperty("sizeMinTick", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double SizeMinTick { get; set; } = 0.0;


	[JsonProperty("BboExchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BboExchange { get; set; } = null;


	[JsonProperty("HasDelayed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool HasDelayed { get; set; } = false;


	[JsonProperty("84", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string _84 { get; set; } = null;


	[JsonProperty("86", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string _86 { get; set; } = null;


	[JsonProperty("88", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int _88 { get; set; } = 0;


	[JsonProperty("85", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int _85 { get; set; } = 0;


	[JsonProperty("BestBidExch", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int BestBidExch { get; set; } = 0;


	[JsonProperty("BestAskExch", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int BestAskExch { get; set; } = 0;


	[JsonProperty("31", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string _31 { get; set; } = null;


	[JsonProperty("7059", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string _7059 { get; set; } = null;


	[JsonProperty("LastExch", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int LastExch { get; set; } = 0;


	[JsonProperty("7057", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string _7057 { get; set; } = null;


	[JsonProperty("7068", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string _7068 { get; set; } = null;


	[JsonProperty("7058", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string _7058 { get; set; } = null;


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
