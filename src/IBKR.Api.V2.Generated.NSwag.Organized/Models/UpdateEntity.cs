using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class UpdateEntity
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("addRelationships", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AddRelationship> AddRelationships { get; set; }

    [JsonProperty("deleteRelationships", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<DeleteRelationship> DeleteRelationships { get; set; }

    [JsonProperty("individual", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Individual Individual { get; set; }

    [JsonProperty("legalEntity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public LegalEntity LegalEntity { get; set; }

    [JsonProperty("trust", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Trust Trust { get; set; }

    [JsonProperty("organization", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Organization Organization { get; set; }

    [JsonProperty("documents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Document> Documents { get; set; }

    [JsonProperty("ibEntityId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int IbEntityId { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}