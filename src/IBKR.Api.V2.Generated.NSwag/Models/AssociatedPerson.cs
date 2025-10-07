using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AssociatedPerson
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("entityId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int EntityId { get; set; } = 0;


	[JsonProperty("externalCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalCode { get; set; } = null;


	[JsonProperty("firstName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FirstName { get; set; } = null;


	[JsonProperty("middleName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MiddleName { get; set; } = null;


	[JsonProperty("middleInitial", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MiddleInitial { get; set; } = null;


	[JsonProperty("lastName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string LastName { get; set; } = null;


	[JsonProperty("suffix", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Suffix { get; set; } = null;


	[JsonProperty("username", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Username { get; set; } = null;


	[JsonProperty("passwordDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PasswordDate { get; set; } = null;


	[JsonProperty("userStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string UserStatus { get; set; } = null;


	[JsonProperty("userStatusTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string UserStatusTrading { get; set; } = null;


	[JsonProperty("lastLogin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string LastLogin { get; set; } = null;


	[JsonProperty("gender", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Gender { get; set; } = null;


	[JsonProperty("maritalStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MaritalStatus { get; set; } = null;


	[JsonProperty("salutation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Salutation { get; set; } = null;


	[JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Email { get; set; } = null;


	[JsonProperty("countryOfCitizenship", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CountryOfCitizenship { get; set; } = null;


	[JsonProperty("countryOfBirth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CountryOfBirth { get; set; } = null;


	[JsonProperty("dateOfBirth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DateOfBirth { get; set; } = null;


	[JsonProperty("motersMaidenName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MotersMaidenName { get; set; } = null;


	[JsonProperty("numberOfDependents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int NumberOfDependents { get; set; } = 0;


	[JsonProperty("securityDevice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SecurityDevice { get; set; } = null;


	[JsonProperty("commercial", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Commercial { get; set; } = null;


	[JsonProperty("phones", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, string> Phones { get; set; } = null;


	[JsonProperty("residence", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, string> Residence { get; set; } = null;


	[JsonProperty("mailing", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, string> Mailing { get; set; } = null;


	[JsonProperty("associations", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> Associations { get; set; } = null;


	[JsonProperty("identityDocuments", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IDictionary<string, string>> IdentityDocuments { get; set; } = null;


	[JsonProperty("employmentType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string EmploymentType { get; set; } = null;


	[JsonProperty("employmentDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, object> EmploymentDetails { get; set; } = null;


	[JsonProperty("subscribedServices", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IDictionary<string, object>> SubscribedServices { get; set; } = null;


	[JsonProperty("taxTreatyDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IDictionary<string, string>> TaxTreatyDetails { get; set; } = null;


	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get
		{
			return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
		}
		set
		{
			_additionalProperties = value;
		}
	}
}
