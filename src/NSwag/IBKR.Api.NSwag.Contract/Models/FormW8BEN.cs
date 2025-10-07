using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FormW8BEN
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("localTaxForms", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<LocalTaxForm> LocalTaxForms { get; set; } = null;


	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; } = null;


	[JsonProperty("tin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Tin { get; set; } = null;


	[JsonProperty("foreignTaxId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ForeignTaxId { get; set; } = null;


	[JsonProperty("tinOrExplanationRequired", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool TinOrExplanationRequired { get; set; } = false;


	[JsonProperty("explanation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FormW8BENExplanation Explanation { get; set; } = FormW8BENExplanation.US_TIN;


	[JsonProperty("referenceNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int ReferenceNumber { get; set; } = 0;


	[JsonProperty("part29ACountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Part29ACountry { get; set; } = null;


	[JsonProperty("cert", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Cert { get; set; } = false;


	[JsonProperty("signatureType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FormW8BENSignatureType SignatureType { get; set; } = FormW8BENSignatureType.Electronic;


	[JsonProperty("blankForm", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool BlankForm { get; set; } = false;


	[JsonProperty("taxFormFile", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TaxFormFile { get; set; } = null;


	[JsonProperty("proprietaryFormNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int ProprietaryFormNumber { get; set; } = 0;


	[JsonProperty("electronicFormat", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ElectronicFormat { get; set; } = false;


	[JsonProperty("submitDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SubmitDate { get; set; } = null;


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
