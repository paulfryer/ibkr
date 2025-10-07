using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IndividualPosition
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("acctId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AcctId { get; set; }

    [JsonProperty("allExchanges", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AllExchanges { get; set; }

    [JsonProperty("assetClass", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AssetClass { get; set; }

    [JsonProperty("avgCost", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double AvgCost { get; set; }

    [JsonProperty("avgPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double AvgPrice { get; set; }

    [JsonProperty("baseAvgCost", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double BaseAvgCost { get; set; }

    [JsonProperty("baseAvgPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double BaseAvgPrice { get; set; }

    [JsonProperty("baseMktPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double BaseMktPrice { get; set; }

    [JsonProperty("baseMktValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double BaseMktValue { get; set; }

    [JsonProperty("baseRealizedPnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double BaseRealizedPnl { get; set; }

    [JsonProperty("baseUnrealizedPnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double BaseUnrealizedPnl { get; set; }

    [JsonProperty("chineseName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ChineseName { get; set; }

    [JsonProperty("conExchMap", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<object> ConExchMap { get; set; }

    [JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Conid { get; set; }

    [JsonProperty("contractDesc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ContractDesc { get; set; }

    [JsonProperty("countryCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CountryCode { get; set; }

    [JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Currency { get; set; }

    [JsonProperty("displayRule", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DisplayRule DisplayRule { get; set; }

    [JsonProperty("exchs", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public object? Exchs { get; set; }

    [JsonProperty("exerciseStyle", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public string? ExerciseStyle { get; set; }

    [JsonProperty("expiry", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public string? Expiry { get; set; }

    [JsonProperty("fullName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FullName { get; set; }

    [JsonProperty("group", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Group { get; set; }

    [JsonProperty("hasOptions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool HasOptions { get; set; }

    [JsonProperty("IncrementRules", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IncrementRules> IncrementRules { get; set; }

    [JsonProperty("isEventContract", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsEventContract { get; set; }

    [JsonProperty("isUS", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsUS { get; set; }

    [JsonProperty("lastTradingDay", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string LastTradingDay { get; set; }

    [JsonProperty("listingExchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ListingExchange { get; set; }

    [JsonProperty("mktPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double MktPrice { get; set; }

    [JsonProperty("mktValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double MktValue { get; set; }

    [JsonProperty("model", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Model { get; set; }

    [JsonProperty("multiplier", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Multiplier { get; set; }

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("pageSize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int PageSize { get; set; }

    [JsonProperty("position", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Position { get; set; }

    [JsonProperty("putOrCall", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IndividualPositionPutOrCall PutOrCall { get; set; } = IndividualPositionPutOrCall.P;

    [JsonProperty("realizedPnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double RealizedPnl { get; set; }

    [JsonProperty("sector", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Sector { get; set; }

    [JsonProperty("sectorGroup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SectorGroup { get; set; }

    [JsonProperty("strike", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Strike { get; set; }

    [JsonProperty("ticker", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Ticker { get; set; }

    [JsonProperty("time", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Time { get; set; }

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }

    [JsonProperty("undConid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int UndConid { get; set; }

    [JsonProperty("unrealizedPnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double UnrealizedPnl { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}