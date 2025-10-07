using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class NonDisclosedDetail
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("tradeDate", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string TradeDate { get; set; } = null;

	[JsonProperty("settleDate", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string SettleDate { get; set; } = null;

	[JsonProperty("psetBic", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(64)]
	public string PsetBic { get; set; } = null;

	[JsonProperty("reagDeagBic", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(64)]
	public string ReagDeagBic { get; set; } = null;

	[JsonProperty("buyerSellBic", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(64)]
	public string BuyerSellBic { get; set; } = null;

	[JsonProperty("memberAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(64)]
	public string MemberAccountId { get; set; } = null;

	[JsonProperty("safeKeepingAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(64)]
	public string SafeKeepingAccountId { get; set; } = null;

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
