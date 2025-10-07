using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class SummaryOfAccountBalancesResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("total", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Total2 Total { get; set; }

    [JsonProperty("commodities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Commodities Commodities { get; set; }

    [JsonProperty("securities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Securities2 Securities { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}