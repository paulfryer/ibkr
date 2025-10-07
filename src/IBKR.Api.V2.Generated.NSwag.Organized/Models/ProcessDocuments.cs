using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ProcessDocuments
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("documents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Document> Documents { get; set; }

    [JsonProperty("inputLanguage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ProcessDocumentsInputLanguage InputLanguage { get; set; } = ProcessDocumentsInputLanguage.En;

    [JsonProperty("translation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Translation { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}