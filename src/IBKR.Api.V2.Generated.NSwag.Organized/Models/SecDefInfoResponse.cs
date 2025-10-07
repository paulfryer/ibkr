using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class SecDefInfoResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Conid { get; set; }

    [JsonProperty("ticker", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Ticker { get; set; }

    [JsonProperty("secType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SecType { get; set; }

    [JsonProperty("listingExchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ListingExchange { get; set; }

    [JsonProperty("exchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Exchange { get; set; }

    [JsonProperty("companyName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyName { get; set; }

    [JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Currency { get; set; }

    [JsonProperty("validExchanges", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ValidExchanges { get; set; }

    [JsonProperty("priceRendering", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public object? PriceRendering { get; set; }

    [JsonProperty("maturityDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public string? MaturityDate { get; set; }

    [JsonProperty("right", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SecDefInfoResponseRight Right { get; set; } = SecDefInfoResponseRight.P;

    [JsonProperty("strike", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Strike { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}