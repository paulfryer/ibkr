using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class InformationChange
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("addEntities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AddEntity> AddEntities { get; set; }

    [JsonProperty("updateEntities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<UpdateEntity> UpdateEntities { get; set; }

    [JsonProperty("deleteEntities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<DeleteEntity> DeleteEntities { get; set; }

    [JsonProperty("ibAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string IbAccountId { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}