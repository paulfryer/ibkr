using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RequestDetail
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("requestId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public long RequestId { get; set; }

    [JsonProperty("dateSubmitted", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DateSubmitted { get; set; }

    [JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Status { get; set; }

    [JsonProperty("accountID", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountID { get; set; }

    [JsonProperty("requestType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string RequestType { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}