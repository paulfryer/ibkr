using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class OrganizationIdentification
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("placeOfBusinessAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Address PlaceOfBusinessAddress { get; set; } = null;


	[JsonProperty("mailingAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Address MailingAddress { get; set; } = null;


	[JsonProperty("phones", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<PhoneInfo> Phones { get; set; } = null;


	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; } = null;


	[JsonProperty("businessDescription", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BusinessDescription { get; set; } = null;


	[JsonProperty("websiteAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string WebsiteAddress { get; set; } = null;


	[JsonProperty("identification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Identification { get; set; } = null;


	[JsonProperty("identificationCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string IdentificationCountry { get; set; } = null;


	[JsonProperty("formationCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FormationCountry { get; set; } = null;


	[JsonProperty("formationState", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FormationState { get; set; } = null;


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
