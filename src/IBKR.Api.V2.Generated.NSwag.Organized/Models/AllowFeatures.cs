using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AllowFeatures
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("showGFIS", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ShowGFIS { get; set; } = false;

	[JsonProperty("showEUCostReport", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ShowEUCostReport { get; set; } = false;

	[JsonProperty("allowEventContract", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AllowEventContract { get; set; } = false;

	[JsonProperty("allowFXConv", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AllowFXConv { get; set; } = false;

	[JsonProperty("allowFinancialLens", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AllowFinancialLens { get; set; } = false;

	[JsonProperty("allowMTA", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AllowMTA { get; set; } = false;

	[JsonProperty("allowTypeAhead", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AllowTypeAhead { get; set; } = false;

	[JsonProperty("allowEventTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AllowEventTrading { get; set; } = false;

	[JsonProperty("snapshotRefreshTimeout", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public long SnapshotRefreshTimeout { get; set; } = 0L;

	[JsonProperty("liteUser", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool LiteUser { get; set; } = false;

	[JsonProperty("showWebNews", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ShowWebNews { get; set; } = false;

	[JsonProperty("research", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Research { get; set; } = false;

	[JsonProperty("debugPnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool DebugPnl { get; set; } = false;

	[JsonProperty("showTaxOpt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ShowTaxOpt { get; set; } = false;

	[JsonProperty("showImpactDashboard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ShowImpactDashboard { get; set; } = false;

	[JsonProperty("allowDynAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AllowDynAccount { get; set; } = false;

	[JsonProperty("allowCrypto", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AllowCrypto { get; set; } = false;

	[JsonProperty("allowedAssetTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AllowedAssetTypes { get; set; } = null;

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
