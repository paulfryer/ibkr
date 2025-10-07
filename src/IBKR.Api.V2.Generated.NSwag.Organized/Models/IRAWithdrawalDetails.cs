using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IRAWithdrawalDetails
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("distributionType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IRAWithdrawalDetailsDistributionType DistributionType { get; set; } =
        IRAWithdrawalDetailsDistributionType.NORMAL;

    [JsonProperty("excessContribYr", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int ExcessContribYr { get; set; }

    [JsonProperty("fedTaxRate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double FedTaxRate { get; set; }

    [JsonProperty("legalResidenceState", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string LegalResidenceState { get; set; }

    [JsonProperty("stateTaxRate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double StateTaxRate { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}