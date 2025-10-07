using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AssociatedPerson
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("entityId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int EntityId { get; set; }

    [JsonProperty("externalCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalCode { get; set; }

    [JsonProperty("firstName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FirstName { get; set; }

    [JsonProperty("middleName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MiddleName { get; set; }

    [JsonProperty("middleInitial", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MiddleInitial { get; set; }

    [JsonProperty("lastName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string LastName { get; set; }

    [JsonProperty("suffix", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Suffix { get; set; }

    [JsonProperty("username", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Username { get; set; }

    [JsonProperty("passwordDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string PasswordDate { get; set; }

    [JsonProperty("userStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string UserStatus { get; set; }

    [JsonProperty("userStatusTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string UserStatusTrading { get; set; }

    [JsonProperty("lastLogin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string LastLogin { get; set; }

    [JsonProperty("gender", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Gender { get; set; }

    [JsonProperty("maritalStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MaritalStatus { get; set; }

    [JsonProperty("salutation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Salutation { get; set; }

    [JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Email { get; set; }

    [JsonProperty("countryOfCitizenship", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string CountryOfCitizenship { get; set; }

    [JsonProperty("countryOfBirth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CountryOfBirth { get; set; }

    [JsonProperty("dateOfBirth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DateOfBirth { get; set; }

    [JsonProperty("motersMaidenName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MotersMaidenName { get; set; }

    [JsonProperty("numberOfDependents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int NumberOfDependents { get; set; }

    [JsonProperty("securityDevice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SecurityDevice { get; set; }

    [JsonProperty("commercial", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Commercial { get; set; }

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

    [JsonProperty("employmentType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string EmploymentType { get; set; }

    [JsonProperty("employmentDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, object> EmploymentDetails { get; set; }

    [JsonProperty("subscribedServices", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IDictionary<string, object>> SubscribedServices { get; set; }

    [JsonProperty("taxTreatyDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IDictionary<string, string>> TaxTreatyDetails { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}