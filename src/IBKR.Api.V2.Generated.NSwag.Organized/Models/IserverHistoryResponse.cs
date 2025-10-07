using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IserverHistoryResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("serverId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ServerId { get; set; }

    [JsonProperty("symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Symbol { get; set; }

    [JsonProperty("text", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Text { get; set; }

    [JsonProperty("priceFactor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int PriceFactor { get; set; }

    [JsonProperty("startTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string StartTime { get; set; }

    [JsonProperty("high", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string High { get; set; }

    [JsonProperty("low", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Low { get; set; }

    [JsonProperty("timePeriod", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TimePeriod { get; set; }

    [JsonProperty("barLength", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int BarLength { get; set; }

    [JsonProperty("mdAvailability", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MdAvailability { get; set; }

    [JsonProperty("outsideRth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool OutsideRth { get; set; }

    [JsonProperty("tradingDayDuration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int TradingDayDuration { get; set; }

    [JsonProperty("volumeFactor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int VolumeFactor { get; set; }

    [JsonProperty("priceDisplayRule", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int PriceDisplayRule { get; set; }

    [JsonProperty("priceDisplayValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string PriceDisplayValue { get; set; }

    [JsonProperty("chartPanStartTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ChartPanStartTime { get; set; }

    [JsonProperty("direction", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Direction { get; set; }

    [JsonProperty("negativeCapable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool NegativeCapable { get; set; }

    [JsonProperty("messageVersion", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int MessageVersion { get; set; }

    [JsonProperty("travelTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int TravelTime { get; set; }

    [JsonProperty("Data", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<SingleHistoricalBar> Data { get; set; }

    [JsonProperty("points", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Points { get; set; }

    [JsonProperty("mktDataDelay", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int MktDataDelay { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}