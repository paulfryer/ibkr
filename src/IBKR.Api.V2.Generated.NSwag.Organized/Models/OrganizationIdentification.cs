using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class OrganizationIdentification
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("placeOfBusinessAddress", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Address PlaceOfBusinessAddress { get; set; }

    [JsonProperty("mailingAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Address MailingAddress { get; set; }

    [JsonProperty("phones", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<PhoneInfo> Phones { get; set; }

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("businessDescription", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string BusinessDescription { get; set; }

    [JsonProperty("websiteAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string WebsiteAddress { get; set; }

    [JsonProperty("identification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Identification { get; set; }

    [JsonProperty("identificationCountry", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string IdentificationCountry { get; set; }

    [JsonProperty("formationCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FormationCountry { get; set; }

    [JsonProperty("formationState", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FormationState { get; set; }

    [JsonProperty("sameMailAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool SameMailAddress { get; set; }

    [JsonProperty("translated", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Translated { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}