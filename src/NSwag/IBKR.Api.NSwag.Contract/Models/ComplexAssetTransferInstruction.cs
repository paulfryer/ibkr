using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ComplexAssetTransferInstruction
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;


	[JsonProperty("direction", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ComplexAssetTransferInstructionDirection Direction { get; set; } = ComplexAssetTransferInstructionDirection.IN;


	[JsonProperty("accountId", Required = Required.Always)]
	[Required]
	[StringLength(32, MinimumLength = 1)]
	public string AccountId { get; set; } = null;


	[JsonProperty("accountIdAtCurrentBroker", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(64, MinimumLength = 1)]
	public string AccountIdAtCurrentBroker { get; set; } = null;


	[JsonProperty("quantity", Required = Required.Always)]
	public double Quantity { get; set; } = 0.0;


	[JsonProperty("tradingInstrument", Required = Required.Always)]
	[Required]
	public TradingInstrument TradingInstrument { get; set; } = new TradingInstrument();


	[JsonProperty("contraBrokerInfo", Required = Required.Always)]
	[Required]
	public ContraBrokerInfo ContraBrokerInfo { get; set; } = new ContraBrokerInfo();


	[JsonProperty("nonDisclosedDetail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public NonDisclosedDetail NonDisclosedDetail { get; set; } = null;


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
