using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class WatchlistDeleteSuccess
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("Data", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Data5 Data { get; set; }

    [JsonProperty("action", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public WatchlistDeleteSuccessAction Action { get; set; } = WatchlistDeleteSuccessAction.Context;

    [JsonProperty("MID", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MID { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}