using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class InternalPositionTransferInstruction
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;

	[JsonProperty("sourceAccountId", Required = Required.Always)]
	[Required]
	public string SourceAccountId { get; set; } = null;

	[JsonProperty("targetAccountId", Required = Required.Always)]
	[Required]
	public string TargetAccountId { get; set; } = null;

	[JsonProperty("transferQuantity", Required = Required.Always)]
	public double TransferQuantity { get; set; } = 0.0;

	[JsonProperty("tradingInstrument", Required = Required.Always)]
	[Required]
	public TradingInstrument TradingInstrument { get; set; } = new TradingInstrument();

	[JsonProperty("transferPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double TransferPrice { get; set; } = 0.0;

	[JsonProperty("tradeDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TradeDate { get; set; } = null;

	[JsonProperty("settleDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SettleDate { get; set; } = null;

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
