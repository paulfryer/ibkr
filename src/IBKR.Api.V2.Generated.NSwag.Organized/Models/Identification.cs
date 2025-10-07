using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Identification
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("citizenship", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Citizenship { get; set; } = null;

	[JsonProperty("citizenship2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Citizenship2 { get; set; } = null;

	[JsonProperty("citizenship3", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Citizenship3 { get; set; } = null;

	[JsonProperty("ssn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Ssn { get; set; } = null;

	[JsonProperty("sin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Sin { get; set; } = null;

	[JsonProperty("driversLicense", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DriversLicense { get; set; } = null;

	[JsonProperty("passport", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Passport { get; set; } = null;

	[JsonProperty("alienCard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AlienCard { get; set; } = null;

	[JsonProperty("hkTravelPermit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string HkTravelPermit { get; set; } = null;

	[JsonProperty("medicareCard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MedicareCard { get; set; } = null;

	[JsonProperty("cardColor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public IdentificationCardColor CardColor { get; set; } = IdentificationCardColor.BLUE;

	[JsonProperty("medicareReference", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MedicareReference { get; set; } = null;

	[JsonProperty("nationalCard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string NationalCard { get; set; } = null;

	[JsonProperty("issuingCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string IssuingCountry { get; set; } = null;

	[JsonProperty("issuingState", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string IssuingState { get; set; } = null;

	[JsonProperty("rta", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Rta { get; set; } = null;

	[JsonProperty("legalResidenceCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string LegalResidenceCountry { get; set; } = null;

	[JsonProperty("legalResidenceState", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string LegalResidenceState { get; set; } = null;

	[JsonProperty("educationalQualification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string EducationalQualification { get; set; } = null;

	[JsonProperty("fathersName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FathersName { get; set; } = null;

	[JsonProperty("greenCard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool GreenCard { get; set; } = false;

	[JsonProperty("panNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PanNumber { get; set; } = null;

	[JsonProperty("taxId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TaxId { get; set; } = null;

	[JsonProperty("proofOfAgeCard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ProofOfAgeCard { get; set; } = null;

	[JsonProperty("expire", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Expire { get; set; } = false;

	[JsonProperty("expirationDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(DateFormatConverter))]
	public DateTimeOffset ExpirationDate { get; set; } = default(DateTimeOffset);

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
