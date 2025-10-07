using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AdvisorWrapFeesType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("automatedFeesDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<AutomatedWrapFeeDetailsType> AutomatedFeesDetails { get; set; } = null;


	[JsonProperty("highWaterMarkConfigHwma", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public HighWaterMarkType HighWaterMarkConfigHwma { get; set; } = null;


	[JsonProperty("highWaterMarkConfigHwmq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public HighWaterMarkType HighWaterMarkConfigHwmq { get; set; } = null;


	[JsonProperty("strategy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AdvisorWrapFeesTypeStrategy Strategy { get; set; } = AdvisorWrapFeesTypeStrategy.AUTOMATED;


	[JsonProperty("chargeAdvisor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ChargeAdvisor { get; set; } = false;


	[JsonProperty("chargeOtherFeesToAdvisor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ChargeOtherFeesToAdvisor { get; set; } = false;


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
