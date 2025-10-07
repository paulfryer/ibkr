using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Data4
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("dataType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DataType { get; set; }

    [JsonProperty("encoding", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Encoding { get; set; }

    [JsonProperty("value", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Value { get; set; }

    [JsonProperty("mimeType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MimeType { get; set; }

    [JsonProperty("gzip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Gzip { get; set; }

    [JsonProperty("accept", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Accept { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}