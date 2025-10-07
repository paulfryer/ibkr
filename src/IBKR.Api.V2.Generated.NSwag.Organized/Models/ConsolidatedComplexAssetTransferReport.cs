using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ConsolidatedComplexAssetTransferReport
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("contractId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int ContractId { get; set; }

    [JsonProperty("assetType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AssetType { get; set; }

    [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("isin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Isin { get; set; }

    [JsonProperty("symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Symbol { get; set; }

    [JsonProperty("quantity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Quantity { get; set; }

    [JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Status { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}