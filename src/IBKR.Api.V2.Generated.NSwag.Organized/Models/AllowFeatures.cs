using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AllowFeatures
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("showGFIS", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool ShowGFIS { get; set; }

    [JsonProperty("showEUCostReport", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool ShowEUCostReport { get; set; }

    [JsonProperty("allowEventContract", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool AllowEventContract { get; set; }

    [JsonProperty("allowFXConv", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool AllowFXConv { get; set; }

    [JsonProperty("allowFinancialLens", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool AllowFinancialLens { get; set; }

    [JsonProperty("allowMTA", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool AllowMTA { get; set; }

    [JsonProperty("allowTypeAhead", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool AllowTypeAhead { get; set; }

    [JsonProperty("allowEventTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool AllowEventTrading { get; set; }

    [JsonProperty("snapshotRefreshTimeout", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public long SnapshotRefreshTimeout { get; set; }

    [JsonProperty("liteUser", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool LiteUser { get; set; }

    [JsonProperty("showWebNews", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool ShowWebNews { get; set; }

    [JsonProperty("research", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Research { get; set; }

    [JsonProperty("debugPnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool DebugPnl { get; set; }

    [JsonProperty("showTaxOpt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool ShowTaxOpt { get; set; }

    [JsonProperty("showImpactDashboard", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool ShowImpactDashboard { get; set; }

    [JsonProperty("allowDynAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool AllowDynAccount { get; set; }

    [JsonProperty("allowCrypto", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool AllowCrypto { get; set; }

    [JsonProperty("allowedAssetTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AllowedAssetTypes { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}