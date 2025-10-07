using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AssociatedEntities
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("associatedIndividuals", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AssociatedIndividual> AssociatedIndividuals { get; set; }

    [JsonProperty("associatedEntities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AssociatedEntity> AssociatedEntities1 { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}