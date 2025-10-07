using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FormW8BEN
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("localTaxForms", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<LocalTaxForm> LocalTaxForms { get; set; }

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("tin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Tin { get; set; }

    [JsonProperty("foreignTaxId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ForeignTaxId { get; set; }

    [JsonProperty("tinOrExplanationRequired", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool TinOrExplanationRequired { get; set; }

    [JsonProperty("explanation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public FormW8BENExplanation Explanation { get; set; } = FormW8BENExplanation.US_TIN;

    [JsonProperty("referenceNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int ReferenceNumber { get; set; }

    [JsonProperty("part29ACountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part29ACountry { get; set; }

    [JsonProperty("cert", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Cert { get; set; }

    [JsonProperty("signatureType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public FormW8BENSignatureType SignatureType { get; set; } = FormW8BENSignatureType.Electronic;

    [JsonProperty("blankForm", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool BlankForm { get; set; }

    [JsonProperty("taxFormFile", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TaxFormFile { get; set; }

    [JsonProperty("proprietaryFormNumber", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public int ProprietaryFormNumber { get; set; }

    [JsonProperty("electronicFormat", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool ElectronicFormat { get; set; }

    [JsonProperty("submitDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SubmitDate { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}