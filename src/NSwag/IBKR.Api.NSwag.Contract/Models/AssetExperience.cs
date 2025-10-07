using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AssetExperience
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("assetClass", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AssetExperienceAssetClass AssetClass { get; set; } = AssetExperienceAssetClass.BILL;


	[JsonProperty("yearsTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int YearsTrading { get; set; } = 0;


	[JsonProperty("tradesPerYear", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int TradesPerYear { get; set; } = 0;


	[JsonProperty("knowledgeLevel", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AssetExperienceKnowledgeLevel KnowledgeLevel { get; set; } = AssetExperienceKnowledgeLevel.Extensive;


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
