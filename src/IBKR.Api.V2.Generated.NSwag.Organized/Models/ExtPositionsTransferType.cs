using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ExtPositionsTransferType
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("partialStockPositions", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<PartialStockPosition> PartialStockPositions { get; set; }

    [JsonProperty("partialBondPositions", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<PartialBondPosition> PartialBondPositions { get; set; }

    [JsonProperty("partialOptionPositions", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<PartialOptionPosition> PartialOptionPositions { get; set; }

    [JsonProperty("partialWarrantPositions", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<PartialWarrantPosition> PartialWarrantPositions { get; set; }

    [JsonProperty("partialFundPositions", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<PartialFundPosition> PartialFundPositions { get; set; }

    [JsonProperty("partialCashPositions", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<PartialCashPosition> PartialCashPositions { get; set; }

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ExtPositionsTransferTypeType Type { get; set; } = ExtPositionsTransferTypeType.FULL;

    [JsonProperty("subType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ExtPositionsTransferTypeSubType SubType { get; set; } = ExtPositionsTransferTypeSubType.ACATS;

    [JsonProperty("brokerId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string BrokerId { get; set; }

    [JsonProperty("brokerName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string BrokerName { get; set; }

    [JsonProperty("accountAtBroker", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountAtBroker { get; set; }

    [JsonProperty("srcIRAType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ExtPositionsTransferTypeSrcIRAType SrcIRAType { get; set; } = ExtPositionsTransferTypeSrcIRAType.RI;

    [JsonProperty("marginLoan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool MarginLoan { get; set; }

    [JsonProperty("shortPos", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool ShortPos { get; set; }

    [JsonProperty("optionPos", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool OptionPos { get; set; }

    [JsonProperty("ibAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string IbAccount { get; set; }

    [JsonProperty("thirdPartyType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ThirdPartyType { get; set; }

    [JsonProperty("approximateAccountValue", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public int ApproximateAccountValue { get; set; }

    [JsonProperty("ssn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Ssn { get; set; }

    [JsonProperty("ein", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Ein { get; set; }

    [JsonProperty("signature", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Signature { get; set; }

    [JsonProperty("authorizeToRemoveFund", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool AuthorizeToRemoveFund { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}