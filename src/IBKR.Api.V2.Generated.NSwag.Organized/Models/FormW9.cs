using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FormW9
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("localTaxForms", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<LocalTaxForm> LocalTaxForms { get; set; }

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("businessName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string BusinessName { get; set; }

    [JsonProperty("customerType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public FormW9CustomerType CustomerType { get; set; } = FormW9CustomerType.Individual;

    [JsonProperty("taxClassification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TaxClassification { get; set; }

    [JsonProperty("otherCustomerType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string OtherCustomerType { get; set; }

    [JsonProperty("tin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Tin { get; set; }

    [JsonProperty("tinType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public FormW9TinType TinType { get; set; } = FormW9TinType.SSN;

    [JsonProperty("cert1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Cert1 { get; set; }

    [JsonProperty("cert2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Cert2 { get; set; }

    [JsonProperty("cert3", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Cert3 { get; set; }

    [JsonProperty("cert4", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Cert4 { get; set; }

    [JsonProperty("signatureType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public FormW9SignatureType SignatureType { get; set; } = FormW9SignatureType.Electronic;

    [JsonProperty("blankForm", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool BlankForm { get; set; }

    [JsonProperty("taxFormFile", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TaxFormFile { get; set; }

    [JsonProperty("proprietaryFormNumber", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public int ProprietaryFormNumber { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}