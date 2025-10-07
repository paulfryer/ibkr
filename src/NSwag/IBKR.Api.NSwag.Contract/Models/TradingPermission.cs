using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TradingPermission
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("assetClass", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public TradingPermissionAssetClass AssetClass { get; set; } = TradingPermissionAssetClass.BILL;


	[JsonProperty("exchangeGroup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExchangeGroup { get; set; } = null;


	[JsonProperty("country", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public TradingPermissionCountry Country { get; set; } = TradingPermissionCountry.ALL;


	[JsonProperty("product", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public TradingPermissionProduct Product { get; set; } = TradingPermissionProduct.BONDS;


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
