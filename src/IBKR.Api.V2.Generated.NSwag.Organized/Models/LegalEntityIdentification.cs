using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class LegalEntityIdentification
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("placeOfBusinessAddress", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Address PlaceOfBusinessAddress { get; set; }

    [JsonProperty("mailingAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Address MailingAddress { get; set; }

    [JsonProperty("identification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Identification { get; set; }

    [JsonProperty("identificationCountry", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string IdentificationCountry { get; set; }

    [JsonProperty("formationCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FormationCountry { get; set; }

    [JsonProperty("formationType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public LegalEntityIdentificationFormationType FormationType { get; set; } =
        LegalEntityIdentificationFormationType.PUBLIC;

    [JsonProperty("exchangeCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExchangeCode { get; set; }

    [JsonProperty("exchangeSymbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExchangeSymbol { get; set; }

    [JsonProperty("sameMailAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool SameMailAddress { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}