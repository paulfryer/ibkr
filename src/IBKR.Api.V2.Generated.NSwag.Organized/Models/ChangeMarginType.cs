using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ChangeMarginType
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("documentSubmission", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DocumentSubmission DocumentSubmission { get; set; }

    [JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountId { get; set; }

    [JsonProperty("newMargin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string NewMargin { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}