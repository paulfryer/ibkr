using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IserverHistoryResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("serverId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ServerId { get; set; } = null;


	[JsonProperty("symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Symbol { get; set; } = null;


	[JsonProperty("text", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Text { get; set; } = null;


	[JsonProperty("priceFactor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int PriceFactor { get; set; } = 0;


	[JsonProperty("startTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string StartTime { get; set; } = null;


	[JsonProperty("high", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string High { get; set; } = null;


	[JsonProperty("low", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Low { get; set; } = null;


	[JsonProperty("timePeriod", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TimePeriod { get; set; } = null;


	[JsonProperty("barLength", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int BarLength { get; set; } = 0;


	[JsonProperty("mdAvailability", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MdAvailability { get; set; } = null;


	[JsonProperty("outsideRth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool OutsideRth { get; set; } = false;


	[JsonProperty("tradingDayDuration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int TradingDayDuration { get; set; } = 0;


	[JsonProperty("volumeFactor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int VolumeFactor { get; set; } = 0;


	[JsonProperty("priceDisplayRule", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int PriceDisplayRule { get; set; } = 0;


	[JsonProperty("priceDisplayValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PriceDisplayValue { get; set; } = null;


	[JsonProperty("chartPanStartTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ChartPanStartTime { get; set; } = null;


	[JsonProperty("direction", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Direction { get; set; } = 0;


	[JsonProperty("negativeCapable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool NegativeCapable { get; set; } = false;


	[JsonProperty("messageVersion", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int MessageVersion { get; set; } = 0;


	[JsonProperty("travelTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int TravelTime { get; set; } = 0;


	[JsonProperty("Data", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<SingleHistoricalBar> Data { get; set; } = null;


	[JsonProperty("points", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Points { get; set; } = 0;


	[JsonProperty("mktDataDelay", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int MktDataDelay { get; set; } = 0;


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
