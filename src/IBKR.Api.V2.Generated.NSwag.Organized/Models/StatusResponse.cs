using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class StatusResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("requestId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public long RequestId { get; set; }

    [JsonProperty("dateSubmitted", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset DateSubmitted { get; set; } = default;

    [JsonProperty("fileData", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public FileData FileData { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}