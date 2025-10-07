using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Identification
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("citizenship", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Citizenship { get; set; }

    [JsonProperty("citizenship2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Citizenship2 { get; set; }

    [JsonProperty("citizenship3", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Citizenship3 { get; set; }

    [JsonProperty("ssn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Ssn { get; set; }

    [JsonProperty("sin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Sin { get; set; }

    [JsonProperty("driversLicense", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DriversLicense { get; set; }

    [JsonProperty("passport", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Passport { get; set; }

    [JsonProperty("alienCard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AlienCard { get; set; }

    [JsonProperty("hkTravelPermit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string HkTravelPermit { get; set; }

    [JsonProperty("medicareCard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MedicareCard { get; set; }

    [JsonProperty("cardColor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IdentificationCardColor CardColor { get; set; } = IdentificationCardColor.BLUE;

    [JsonProperty("medicareReference", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MedicareReference { get; set; }

    [JsonProperty("nationalCard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string NationalCard { get; set; }

    [JsonProperty("issuingCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string IssuingCountry { get; set; }

    [JsonProperty("issuingState", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string IssuingState { get; set; }

    [JsonProperty("rta", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Rta { get; set; }

    [JsonProperty("legalResidenceCountry", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string LegalResidenceCountry { get; set; }

    [JsonProperty("legalResidenceState", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string LegalResidenceState { get; set; }

    [JsonProperty("educationalQualification", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string EducationalQualification { get; set; }

    [JsonProperty("fathersName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FathersName { get; set; }

    [JsonProperty("greenCard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool GreenCard { get; set; }

    [JsonProperty("panNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string PanNumber { get; set; }

    [JsonProperty("taxId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TaxId { get; set; }

    [JsonProperty("proofOfAgeCard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ProofOfAgeCard { get; set; }

    [JsonProperty("expire", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Expire { get; set; }

    [JsonProperty("expirationDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(DateFormatConverter))]
    public DateTimeOffset ExpirationDate { get; set; } = default;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}