using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PartialWarrantPosition
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Symbol { get; set; } = null;


	[JsonProperty("numberOfShares", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public long NumberOfShares { get; set; } = 0L;


	[JsonProperty("all", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool All { get; set; } = false;


	[JsonProperty("position", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public PartialWarrantPositionPosition Position { get; set; } = PartialWarrantPositionPosition.LONG;


	[JsonProperty("optionType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public PartialWarrantPositionOptionType OptionType { get; set; } = PartialWarrantPositionOptionType.CALL;


	[JsonProperty("strikePrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public long StrikePrice { get; set; } = 0L;


	[JsonProperty("expirationDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExpirationDate { get; set; } = null;


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
