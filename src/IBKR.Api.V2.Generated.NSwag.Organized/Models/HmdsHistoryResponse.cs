using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class HmdsHistoryResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("startTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string StartTime { get; set; }

    [JsonProperty("startTimeVal", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int StartTimeVal { get; set; }

    [JsonProperty("endTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string EndTime { get; set; }

    [JsonProperty("endTimeVal", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int EndTimeVal { get; set; }

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