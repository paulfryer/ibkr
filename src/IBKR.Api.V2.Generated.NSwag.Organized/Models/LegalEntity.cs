using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class LegalEntity
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Address Address { get; set; }

    [JsonProperty("phones", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<PhoneInfo> Phones { get; set; }

    [JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Email { get; set; }

    [JsonProperty("legalEntityIdentification", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public LegalEntityIdentification LegalEntityIdentification { get; set; }

    [JsonProperty("taxResidencies", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<TaxResidency> TaxResidencies { get; set; }

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalId { get; set; }

    [JsonProperty("usTaxResident", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool UsTaxResident { get; set; }

    [JsonProperty("translated", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Translated { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}