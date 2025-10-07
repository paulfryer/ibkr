using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FormFileResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("error", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ErrorResponse Error { get; set; }

    [JsonProperty("hasError", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool HasError { get; set; }

    [JsonProperty("errorDescription", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ErrorDescription { get; set; }

    [JsonProperty("fileData", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public FileData FileData { get; set; }

    [JsonProperty("formDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<FormDetails> FormDetails { get; set; }

    [JsonProperty("timestamp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset Timestamp { get; set; } = default;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}