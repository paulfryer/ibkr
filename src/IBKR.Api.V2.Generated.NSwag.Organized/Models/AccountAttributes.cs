using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountAttributes
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("accountAlias", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public string? AccountAlias { get; set; }

    [JsonProperty("accountStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int AccountStatus { get; set; }

    [JsonProperty("accountTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountTitle { get; set; }

    [JsonProperty("accountVan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountVan { get; set; }

    [JsonProperty("acctCustType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AcctCustType { get; set; }

    [JsonProperty("brokerageAccess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool BrokerageAccess { get; set; }

    [JsonProperty("businessType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AccountAttributesBusinessType BusinessType { get; set; } = AccountAttributesBusinessType.IB_SALES;

    [JsonProperty("clearingStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AccountAttributesClearingStatus ClearingStatus { get; set; } = AccountAttributesClearingStatus.O;

    [JsonProperty("covestor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Covestor { get; set; }

    [JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AccountAttributesCurrency Currency { get; set; } = AccountAttributesCurrency.USD;

    [JsonProperty("desc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Desc { get; set; }

    [JsonProperty("displayName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DisplayName { get; set; }

    [JsonProperty("faClient", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool FaClient { get; set; }

    [JsonProperty("ibEntity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AccountAttributesIbEntity IbEntity { get; set; } = AccountAttributesIbEntity.IBLLCUS;

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("noClientTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool NoClientTrading { get; set; }

    [JsonProperty("parent", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Parent Parent { get; set; }

    [JsonProperty("PrepaidCrypto-P", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool PrepaidCryptoP { get; set; }

    [JsonProperty("PrepaidCrypto-Z", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool PrepaidCryptoZ { get; set; }

    [JsonProperty("trackVirtualFXPortfolio", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool TrackVirtualFXPortfolio { get; set; }

    [JsonProperty("tradingType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AccountAttributesTradingType TradingType { get; set; } = AccountAttributesTradingType.STKNOPT;

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AccountAttributesType Type { get; set; } = AccountAttributesType.DEMO;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}