using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class DwacInstruction
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;

	[JsonProperty("direction", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public DwacInstructionDirection Direction { get; set; } = DwacInstructionDirection.IN;

	[JsonProperty("accountId", Required = Required.Always)]
	[Required]
	[StringLength(32, MinimumLength = 1)]
	public string AccountId { get; set; } = null;

	[JsonProperty("contraBrokerAccountId", Required = Required.Always)]
	[Required]
	[StringLength(20, MinimumLength = 1)]
	public string ContraBrokerAccountId { get; set; } = null;

	[JsonProperty("contraBrokerTaxId", Required = Required.Always)]
	[Required]
	[StringLength(25, MinimumLength = 1)]
	public string ContraBrokerTaxId { get; set; } = null;

	[JsonProperty("quantity", Required = Required.Always)]
	public double Quantity { get; set; } = 0.0;

	[JsonProperty("tradingInstrument", Required = Required.Always)]
	[Required]
	public TradingInstrument TradingInstrument { get; set; } = new TradingInstrument();

	[JsonProperty("accountTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(140)]
	public string AccountTitle { get; set; } = null;

	[JsonProperty("referenceId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(20)]
	public string ReferenceId { get; set; } = null;

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
