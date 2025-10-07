using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class LegalEntity
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; } = null;

	[JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Address Address { get; set; } = null;

	[JsonProperty("phones", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<PhoneInfo> Phones { get; set; } = null;

	[JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Email { get; set; } = null;

	[JsonProperty("legalEntityIdentification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LegalEntityIdentification LegalEntityIdentification { get; set; } = null;

	[JsonProperty("taxResidencies", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<TaxResidency> TaxResidencies { get; set; } = null;

	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Id { get; set; } = null;

	[JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalId { get; set; } = null;

	[JsonProperty("usTaxResident", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool UsTaxResident { get; set; } = false;

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
