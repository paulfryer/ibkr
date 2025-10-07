using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class DeleteBankInstruction
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;


	[JsonProperty("accountId", Required = Required.Always)]
	[Required]
	[StringLength(32, MinimumLength = 1)]
	public string AccountId { get; set; } = null;


	[JsonProperty("bankInstructionName", Required = Required.Always)]
	[Required]
	[StringLength(150, MinimumLength = 1)]
	public string BankInstructionName { get; set; } = null;


	[JsonProperty("bankInstructionMethod", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public DeleteBankInstructionBankInstructionMethod BankInstructionMethod { get; set; } = DeleteBankInstructionBankInstructionMethod.WIRE;


	[JsonProperty("currency", Required = Required.Always)]
	[Required]
	[StringLength(3, MinimumLength = 1)]
	public string Currency { get; set; } = null;


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
