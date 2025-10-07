using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FopInstruction
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;


	[JsonProperty("direction", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FopInstructionDirection Direction { get; set; } = FopInstructionDirection.IN;


	[JsonProperty("accountId", Required = Required.Always)]
	[Required]
	[StringLength(32, MinimumLength = 1)]
	public string AccountId { get; set; } = null;


	[JsonProperty("contraBrokerAccountId", Required = Required.Always)]
	[Required]
	[StringLength(20, MinimumLength = 1)]
	public string ContraBrokerAccountId { get; set; } = null;


	[JsonProperty("contraBrokerDtcCode", Required = Required.Always)]
	[Required]
	[StringLength(20, MinimumLength = 1)]
	public string ContraBrokerDtcCode { get; set; } = null;


	[JsonProperty("quantity", Required = Required.Always)]
	public double Quantity { get; set; } = 0.0;


	[JsonProperty("tradingInstrument", Required = Required.Always)]
	[Required]
	public TradingInstrument TradingInstrument { get; set; } = new TradingInstrument();


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
