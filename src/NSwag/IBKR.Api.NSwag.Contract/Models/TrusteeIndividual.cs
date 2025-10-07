using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TrusteeIndividual
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IndividualName Name { get; set; } = null;


	[JsonProperty("nativeName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IndividualName NativeName { get; set; } = null;


	[JsonProperty("birthName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IndividualName BirthName { get; set; } = null;


	[JsonProperty("motherMaidenName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IndividualName MotherMaidenName { get; set; } = null;


	[JsonProperty("dateOfBirth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DateOfBirth { get; set; } = null;


	[JsonProperty("countryOfBirth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CountryOfBirth { get; set; } = null;


	[JsonProperty("cityOfBirth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CityOfBirth { get; set; } = null;


	[JsonProperty("gender", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public TrusteeIndividualGender Gender { get; set; } = TrusteeIndividualGender.M;


	[JsonProperty("maritalStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public TrusteeIndividualMaritalStatus MaritalStatus { get; set; } = TrusteeIndividualMaritalStatus.S;


	[JsonProperty("numDependents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int NumDependents { get; set; } = 0;


	[JsonProperty("residenceAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ResidenceAddress ResidenceAddress { get; set; } = null;


	[JsonProperty("mailingAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Address MailingAddress { get; set; } = null;


	[JsonProperty("phones", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<PhoneInfo> Phones { get; set; } = null;


	[JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Email { get; set; } = null;


	[JsonProperty("identification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Identification Identification { get; set; } = null;


	[JsonProperty("employmentType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string EmploymentType { get; set; } = null;


	[JsonProperty("employmentDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public EmploymentDetails EmploymentDetails { get; set; } = null;


	[JsonProperty("employeeTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string EmployeeTitle { get; set; } = null;


	[JsonProperty("taxResidencies", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<TaxResidency> TaxResidencies { get; set; } = null;


	[JsonProperty("w9", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FormW9 W9 { get; set; } = null;


	[JsonProperty("w8Ben", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FormW8BEN W8Ben { get; set; } = null;


	[JsonProperty("crs", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FormCRS Crs { get; set; } = null;


	[JsonProperty("prohibitedCountryQuestionnaire", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ProhibitedCountryQuestionnaireList ProhibitedCountryQuestionnaire { get; set; } = null;


	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Id { get; set; } = null;


	[JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalId { get; set; } = null;


	[JsonProperty("userId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string UserId { get; set; } = null;


	[JsonProperty("sameMailAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool SameMailAddress { get; set; } = false;


	[JsonProperty("authorizedToSignOnBehalfOfOwner", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AuthorizedToSignOnBehalfOfOwner { get; set; } = false;


	[JsonProperty("authorizedTrader", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AuthorizedTrader { get; set; } = false;


	[JsonProperty("usTaxResident", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool UsTaxResident { get; set; } = false;


	[JsonProperty("translated", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Translated { get; set; } = false;


	[JsonProperty("primaryTrustee", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool PrimaryTrustee { get; set; } = false;


	[JsonProperty("nfaRegistered", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool NfaRegistered { get; set; } = false;


	[JsonProperty("nfaRegistrationNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string NfaRegistrationNumber { get; set; } = null;


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
