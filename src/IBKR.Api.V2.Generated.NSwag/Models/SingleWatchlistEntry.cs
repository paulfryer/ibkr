using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class SingleWatchlistEntry
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("ST", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public SingleWatchlistEntryST ST { get; set; } = SingleWatchlistEntryST.STK;


	[JsonProperty("C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string C { get; set; } = null;


	[JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Conid { get; set; } = 0;


	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; } = null;


	[JsonProperty("fullName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FullName { get; set; } = null;


	[JsonProperty("assetClass", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public SingleWatchlistEntryAssetClass AssetClass { get; set; } = SingleWatchlistEntryAssetClass.STK;


	[JsonProperty("ticker", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Ticker { get; set; } = null;


	[JsonProperty("chineseName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ChineseName { get; set; } = null;


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
