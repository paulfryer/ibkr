using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Anonymous8
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("tradeVenueId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TradeVenueId { get; set; }

    [JsonProperty("exchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Exchange { get; set; }

    [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("timezone", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Timezone { get; set; }

    [JsonProperty("schedules", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<object> Schedules { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}