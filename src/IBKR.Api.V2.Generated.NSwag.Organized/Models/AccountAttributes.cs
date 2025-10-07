using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountAttributes
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("accountAlias", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public string? AccountAlias { get; set; } = null;

	[JsonProperty("accountStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int AccountStatus { get; set; } = 0;

	[JsonProperty("accountTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountTitle { get; set; } = null;

	[JsonProperty("accountVan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountVan { get; set; } = null;

	[JsonProperty("acctCustType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AcctCustType { get; set; } = null;

	[JsonProperty("brokerageAccess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool BrokerageAccess { get; set; } = false;

	[JsonProperty("businessType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AccountAttributesBusinessType BusinessType { get; set; } = AccountAttributesBusinessType.IB_SALES;

	[JsonProperty("clearingStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AccountAttributesClearingStatus ClearingStatus { get; set; } = AccountAttributesClearingStatus.O;

	[JsonProperty("covestor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Covestor { get; set; } = false;

	[JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AccountAttributesCurrency Currency { get; set; } = AccountAttributesCurrency.USD;

	[JsonProperty("desc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Desc { get; set; } = null;

	[JsonProperty("displayName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DisplayName { get; set; } = null;

	[JsonProperty("faClient", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool FaClient { get; set; } = false;

	[JsonProperty("ibEntity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AccountAttributesIbEntity IbEntity { get; set; } = AccountAttributesIbEntity.IBLLCUS;

	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Id { get; set; } = null;

	[JsonProperty("noClientTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool NoClientTrading { get; set; } = false;

	[JsonProperty("parent", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Parent Parent { get; set; } = null;

	[JsonProperty("PrepaidCrypto-P", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool PrepaidCryptoP { get; set; } = false;

	[JsonProperty("PrepaidCrypto-Z", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool PrepaidCryptoZ { get; set; } = false;

	[JsonProperty("trackVirtualFXPortfolio", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool TrackVirtualFXPortfolio { get; set; } = false;

	[JsonProperty("tradingType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AccountAttributesTradingType TradingType { get; set; } = AccountAttributesTradingType.STKNOPT;

	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AccountAttributesType Type { get; set; } = AccountAttributesType.DEMO;

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
