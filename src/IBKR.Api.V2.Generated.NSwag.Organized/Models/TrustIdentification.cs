using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using IBKR.Api.V2.Generated.NSwag.Helpers;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TrustIdentification
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Address Address { get; set; } = null;

	[JsonProperty("mailingAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Address MailingAddress { get; set; } = null;

	[JsonProperty("phones", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<PhoneInfo> Phones { get; set; } = null;

	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; } = null;

	[JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Description { get; set; } = null;

	[JsonProperty("typeOfTrust", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public TrustIdentificationTypeOfTrust TypeOfTrust { get; set; } = TrustIdentificationTypeOfTrust.IRREVOC;

	[JsonProperty("purposeOfTrust", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PurposeOfTrust { get; set; } = null;

	[JsonProperty("dateFormed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(DateFormatConverter))]
	public DateTimeOffset DateFormed { get; set; } = default(DateTimeOffset);

	[JsonProperty("formationCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FormationCountry { get; set; } = null;

	[JsonProperty("formationState", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FormationState { get; set; } = null;

	[JsonProperty("registrationNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string RegistrationNumber { get; set; } = null;

	[JsonProperty("registrationType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public TrustIdentificationRegistrationType RegistrationType { get; set; } = TrustIdentificationRegistrationType.SSN;

	[JsonProperty("registrationCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string RegistrationCountry { get; set; } = null;

	[JsonProperty("sameMailAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool SameMailAddress { get; set; } = false;

	[JsonProperty("translated", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Translated { get; set; } = false;

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
