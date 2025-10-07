using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IndividualPosition
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("acctId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AcctId { get; set; } = null;

	[JsonProperty("allExchanges", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AllExchanges { get; set; } = null;

	[JsonProperty("assetClass", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AssetClass { get; set; } = null;

	[JsonProperty("avgCost", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double AvgCost { get; set; } = 0.0;

	[JsonProperty("avgPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double AvgPrice { get; set; } = 0.0;

	[JsonProperty("baseAvgCost", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double BaseAvgCost { get; set; } = 0.0;

	[JsonProperty("baseAvgPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double BaseAvgPrice { get; set; } = 0.0;

	[JsonProperty("baseMktPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double BaseMktPrice { get; set; } = 0.0;

	[JsonProperty("baseMktValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double BaseMktValue { get; set; } = 0.0;

	[JsonProperty("baseRealizedPnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double BaseRealizedPnl { get; set; } = 0.0;

	[JsonProperty("baseUnrealizedPnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double BaseUnrealizedPnl { get; set; } = 0.0;

	[JsonProperty("chineseName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ChineseName { get; set; } = null;

	[JsonProperty("conExchMap", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<object> ConExchMap { get; set; } = null;

	[JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Conid { get; set; } = 0;

	[JsonProperty("contractDesc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ContractDesc { get; set; } = null;

	[JsonProperty("countryCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CountryCode { get; set; } = null;

	[JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Currency { get; set; } = null;

	[JsonProperty("displayRule", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DisplayRule DisplayRule { get; set; } = null;

	[JsonProperty("exchs", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public object? Exchs { get; set; } = null;

	[JsonProperty("exerciseStyle", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public string? ExerciseStyle { get; set; } = null;

	[JsonProperty("expiry", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public string? Expiry { get; set; } = null;

	[JsonProperty("fullName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FullName { get; set; } = null;

	[JsonProperty("group", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Group { get; set; } = null;

	[JsonProperty("hasOptions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool HasOptions { get; set; } = false;

	[JsonProperty("IncrementRules", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IncrementRules> IncrementRules { get; set; } = null;

	[JsonProperty("isEventContract", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsEventContract { get; set; } = false;

	[JsonProperty("isUS", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsUS { get; set; } = false;

	[JsonProperty("lastTradingDay", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string LastTradingDay { get; set; } = null;

	[JsonProperty("listingExchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ListingExchange { get; set; } = null;

	[JsonProperty("mktPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double MktPrice { get; set; } = 0.0;

	[JsonProperty("mktValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double MktValue { get; set; } = 0.0;

	[JsonProperty("model", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Model { get; set; } = null;

	[JsonProperty("multiplier", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Multiplier { get; set; } = 0.0;

	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; } = null;

	[JsonProperty("pageSize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int PageSize { get; set; } = 0;

	[JsonProperty("position", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Position { get; set; } = 0.0;

	[JsonProperty("putOrCall", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public IndividualPositionPutOrCall PutOrCall { get; set; } = IndividualPositionPutOrCall.P;

	[JsonProperty("realizedPnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double RealizedPnl { get; set; } = 0.0;

	[JsonProperty("sector", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Sector { get; set; } = null;

	[JsonProperty("sectorGroup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SectorGroup { get; set; } = null;

	[JsonProperty("strike", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Strike { get; set; } = null;

	[JsonProperty("ticker", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Ticker { get; set; } = null;

	[JsonProperty("time", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Time { get; set; } = 0;

	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Type { get; set; } = null;

	[JsonProperty("undConid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int UndConid { get; set; } = 0;

	[JsonProperty("unrealizedPnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double UnrealizedPnl { get; set; } = 0.0;

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
