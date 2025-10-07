using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AutomatedWrapFeeDetailsType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("perTradeMarkups", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public CommissionScheduleType PerTradeMarkups { get; set; } = null;


	[JsonProperty("annualBlendedPercentages", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<AnnualBlendedPercentage> AnnualBlendedPercentages { get; set; } = null;


	[JsonProperty("navRanges", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<NAVRangeType> NavRanges { get; set; } = null;


	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AutomatedWrapFeeDetailsTypeType Type { get; set; } = AutomatedWrapFeeDetailsTypeType.ANNUALFLATFEE;


	[JsonProperty("maxFee", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double MaxFee { get; set; } = 0.0;


	[JsonProperty("numContracts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int NumContracts { get; set; } = 0;


	[JsonProperty("postFrequency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PostFrequency { get; set; } = null;


	[JsonProperty("percentOfNLVCap", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PercentOfNLVCap { get; set; } = null;


	[JsonProperty("percentOfNLVCapQ", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PercentOfNLVCapQ { get; set; } = null;


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
