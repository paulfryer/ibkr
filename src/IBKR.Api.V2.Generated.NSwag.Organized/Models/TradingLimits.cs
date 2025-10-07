using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TradingLimits
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("orderValueLimits", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public OrderValueLimits OrderValueLimits { get; set; }

    [JsonProperty("efpQuantityLimits", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public EFPQuantityLimits EfpQuantityLimits { get; set; }

    [JsonProperty("orderQuantityLimits", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<OrderQuantityLimit> OrderQuantityLimits { get; set; }

    [JsonProperty("dayQuantityLimits", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<DayQuantityLimit> DayQuantityLimits { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}