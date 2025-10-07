using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AddEntity
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("addRelationships", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AddRelationship> AddRelationships { get; set; }

    [JsonProperty("individual", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Individual Individual { get; set; }

    [JsonProperty("legalEntity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public LegalEntity LegalEntity { get; set; }

    [JsonProperty("documents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Document> Documents { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}