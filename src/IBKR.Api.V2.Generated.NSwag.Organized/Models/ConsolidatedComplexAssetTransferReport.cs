using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ConsolidatedComplexAssetTransferReport
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("contractId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int ContractId { get; set; } = 0;

	[JsonProperty("assetType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AssetType { get; set; } = null;

	[JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Description { get; set; } = null;

	[JsonProperty("isin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Isin { get; set; } = null;

	[JsonProperty("symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Symbol { get; set; } = null;

	[JsonProperty("quantity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Quantity { get; set; } = null;

	[JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Status { get; set; } = null;

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
