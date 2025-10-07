using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IRADepositDetails
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("depositType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IRADepositDetailsDepositType DepositType { get; set; } = IRADepositDetailsDepositType.Contribution;

    [JsonProperty("taxYear", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IRADepositDetailsTaxYear TaxYear { get; set; } = IRADepositDetailsTaxYear.Current;

    [JsonProperty("fromIraType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IRADepositDetailsFromIraType FromIraType { get; set; } = IRADepositDetailsFromIraType.RI;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}