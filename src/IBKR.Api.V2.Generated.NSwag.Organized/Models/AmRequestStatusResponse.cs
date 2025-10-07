using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AmRequestStatusResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("requestId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string RequestId { get; set; }

    [JsonProperty("requestType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string RequestType { get; set; }

    [JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Status { get; set; }

    [JsonProperty("message", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }

    [JsonProperty("acctId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AcctId { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}