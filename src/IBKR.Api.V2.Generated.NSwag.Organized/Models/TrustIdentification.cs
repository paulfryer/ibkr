using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TrustIdentification
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Address Address { get; set; }

    [JsonProperty("mailingAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Address MailingAddress { get; set; }

    [JsonProperty("phones", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<PhoneInfo> Phones { get; set; }

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("typeOfTrust", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public TrustIdentificationTypeOfTrust TypeOfTrust { get; set; } = TrustIdentificationTypeOfTrust.IRREVOC;

    [JsonProperty("purposeOfTrust", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string PurposeOfTrust { get; set; }

    [JsonProperty("dateFormed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(DateFormatConverter))]
    public DateTimeOffset DateFormed { get; set; } = default;

    [JsonProperty("formationCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FormationCountry { get; set; }

    [JsonProperty("formationState", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FormationState { get; set; }

    [JsonProperty("registrationNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string RegistrationNumber { get; set; }

    [JsonProperty("registrationType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public TrustIdentificationRegistrationType RegistrationType { get; set; } = TrustIdentificationRegistrationType.SSN;

    [JsonProperty("registrationCountry", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string RegistrationCountry { get; set; }

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