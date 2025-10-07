using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AssociatedEntity
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("entityId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int EntityId { get; set; }

    [JsonProperty("externalCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalCode { get; set; }

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Email { get; set; }

    [JsonProperty("organizationCountry", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string OrganizationCountry { get; set; }

    [JsonProperty("phones", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> Phones { get; set; }

    [JsonProperty("residence", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> Residence { get; set; }

    [JsonProperty("mailing", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> Mailing { get; set; }

    [JsonProperty("associations", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> Associations { get; set; }

    [JsonProperty("identityDocuments", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IDictionary<string, string>> IdentityDocuments { get; set; }

    [JsonProperty("taxTreatyDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IDictionary<string, string>> TaxTreatyDetails { get; set; }

    [JsonProperty("AssociatedPersons", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AssociatedPerson> AssociatedPersons { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}