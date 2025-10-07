using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Anonymous6
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("acctcode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Acctcode { get; set; }

    [JsonProperty("cashbalance", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Cashbalance { get; set; }

    [JsonProperty("cashbalancefxsegment", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double Cashbalancefxsegment { get; set; }

    [JsonProperty("commoditymarketvalue", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double Commoditymarketvalue { get; set; }

    [JsonProperty("corporatebondsmarketvalue", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double Corporatebondsmarketvalue { get; set; }

    [JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Currency { get; set; }

    [JsonProperty("dividends", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Dividends { get; set; }

    [JsonProperty("exchangerate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Exchangerate { get; set; }

    [JsonProperty("funds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Funds { get; set; }

    [JsonProperty("futuremarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Futuremarketvalue { get; set; }

    [JsonProperty("futureoptionmarketvalue", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double Futureoptionmarketvalue { get; set; }

    [JsonProperty("futuresonlypnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Futuresonlypnl { get; set; }

    [JsonProperty("interest", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Interest { get; set; }

    [JsonProperty("issueroptionsmarketvalue", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double Issueroptionsmarketvalue { get; set; }

    [JsonProperty("key", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Key Key { get; set; } = Key.LedgerList;

    [JsonProperty("moneyfunds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Moneyfunds { get; set; }

    [JsonProperty("netliquidationvalue", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double Netliquidationvalue { get; set; }

    [JsonProperty("realizedpnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Realizedpnl { get; set; }

    [JsonProperty("secondkey", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Secondkey { get; set; }

    [JsonProperty("sessionid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Sessionid { get; set; }

    [JsonProperty("settledcash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Settledcash { get; set; }

    [JsonProperty("severity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Severity { get; set; }

    [JsonProperty("stockmarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Stockmarketvalue { get; set; }

    [JsonProperty("stockoptionmarketvalue", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double Stockoptionmarketvalue { get; set; }

    [JsonProperty("tbillsmarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Tbillsmarketvalue { get; set; }

    [JsonProperty("tbondsmarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Tbondsmarketvalue { get; set; }

    [JsonProperty("timestamp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Timestamp { get; set; }

    [JsonProperty("unrealizedpnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Unrealizedpnl { get; set; }

    [JsonProperty("warrantsmarketvalue", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double Warrantsmarketvalue { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}