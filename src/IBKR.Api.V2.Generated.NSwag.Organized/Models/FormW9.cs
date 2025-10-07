using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FormW9
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("localTaxForms", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<LocalTaxForm> LocalTaxForms { get; set; } = null;

	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; } = null;

	[JsonProperty("businessName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BusinessName { get; set; } = null;

	[JsonProperty("customerType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FormW9CustomerType CustomerType { get; set; } = FormW9CustomerType.Individual;

	[JsonProperty("taxClassification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TaxClassification { get; set; } = null;

	[JsonProperty("otherCustomerType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string OtherCustomerType { get; set; } = null;

	[JsonProperty("tin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Tin { get; set; } = null;

	[JsonProperty("tinType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FormW9TinType TinType { get; set; } = FormW9TinType.SSN;

	[JsonProperty("cert1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Cert1 { get; set; } = false;

	[JsonProperty("cert2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Cert2 { get; set; } = false;

	[JsonProperty("cert3", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Cert3 { get; set; } = false;

	[JsonProperty("cert4", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Cert4 { get; set; } = false;

	[JsonProperty("signatureType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FormW9SignatureType SignatureType { get; set; } = FormW9SignatureType.Electronic;

	[JsonProperty("blankForm", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool BlankForm { get; set; } = false;

	[JsonProperty("taxFormFile", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TaxFormFile { get; set; } = null;

	[JsonProperty("proprietaryFormNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int ProprietaryFormNumber { get; set; } = 0;

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
