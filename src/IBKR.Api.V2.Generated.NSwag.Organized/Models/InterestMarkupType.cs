using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class InterestMarkupType
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public InterestMarkupTypeCurrency Currency { get; set; } = InterestMarkupTypeCurrency.USD;

    [JsonProperty("debitMarkup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double DebitMarkup { get; set; }

    [JsonProperty("ibDebitMarkup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double IbDebitMarkup { get; set; }

    [JsonProperty("creditMarkdown", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double CreditMarkdown { get; set; }

    [JsonProperty("shortCreditMarkdown", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double ShortCreditMarkdown { get; set; }

    [JsonProperty("shortCfdCreditMarkdown", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double ShortCfdCreditMarkdown { get; set; }

    [JsonProperty("longCfdDebitMarkdown", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double LongCfdDebitMarkdown { get; set; }

    [JsonProperty("shortIndexCfdCreditMarkdown", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double ShortIndexCfdCreditMarkdown { get; set; }

    [JsonProperty("longIndexCfdDebitMarkdown", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double LongIndexCfdDebitMarkdown { get; set; }

    [JsonProperty("shortFxCfdMarkup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double ShortFxCfdMarkup { get; set; }

    [JsonProperty("longFxCfdMarkdown", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double LongFxCfdMarkdown { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}