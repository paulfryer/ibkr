using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RequestDetailsResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("requestDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<RequestDetail> RequestDetails { get; set; }

    [JsonProperty("offset", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Offset { get; set; }

    [JsonProperty("limit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Limit { get; set; }

    [JsonProperty("total", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Total { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}