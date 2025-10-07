using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TrusteeIndividual
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IndividualName Name { get; set; }

    [JsonProperty("nativeName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IndividualName NativeName { get; set; }

    [JsonProperty("birthName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IndividualName BirthName { get; set; }

    [JsonProperty("motherMaidenName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IndividualName MotherMaidenName { get; set; }

    [JsonProperty("dateOfBirth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DateOfBirth { get; set; }

    [JsonProperty("countryOfBirth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CountryOfBirth { get; set; }

    [JsonProperty("cityOfBirth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CityOfBirth { get; set; }

    [JsonProperty("gender", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public TrusteeIndividualGender Gender { get; set; } = TrusteeIndividualGender.M;

    [JsonProperty("maritalStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public TrusteeIndividualMaritalStatus MaritalStatus { get; set; } = TrusteeIndividualMaritalStatus.S;

    [JsonProperty("numDependents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int NumDependents { get; set; }

    [JsonProperty("residenceAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ResidenceAddress ResidenceAddress { get; set; }

    [JsonProperty("mailingAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Address MailingAddress { get; set; }

    [JsonProperty("phones", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<PhoneInfo> Phones { get; set; }

    [JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Email { get; set; }

    [JsonProperty("identification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Identification Identification { get; set; }

    [JsonProperty("employmentType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string EmploymentType { get; set; }

    [JsonProperty("employmentDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public EmploymentDetails EmploymentDetails { get; set; }

    [JsonProperty("employeeTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string EmployeeTitle { get; set; }

    [JsonProperty("taxResidencies", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<TaxResidency> TaxResidencies { get; set; }

    [JsonProperty("w9", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public FormW9 W9 { get; set; }

    [JsonProperty("w8Ben", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public FormW8BEN W8Ben { get; set; }

    [JsonProperty("crs", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public FormCRS Crs { get; set; }

    [JsonProperty("prohibitedCountryQuestionnaire", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ProhibitedCountryQuestionnaireList ProhibitedCountryQuestionnaire { get; set; }

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalId { get; set; }

    [JsonProperty("userId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string UserId { get; set; }

    [JsonProperty("sameMailAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool SameMailAddress { get; set; }

    [JsonProperty("authorizedToSignOnBehalfOfOwner", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool AuthorizedToSignOnBehalfOfOwner { get; set; }

    [JsonProperty("authorizedTrader", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool AuthorizedTrader { get; set; }

    [JsonProperty("usTaxResident", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool UsTaxResident { get; set; }

    [JsonProperty("translated", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Translated { get; set; }

    [JsonProperty("primaryTrustee", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool PrimaryTrustee { get; set; }

    [JsonProperty("nfaRegistered", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool NfaRegistered { get; set; }

    [JsonProperty("nfaRegistrationNumber", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string NfaRegistrationNumber { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}