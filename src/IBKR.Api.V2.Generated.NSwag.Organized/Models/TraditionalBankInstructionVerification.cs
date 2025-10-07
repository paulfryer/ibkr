using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TraditionalBankInstructionVerification
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;

	[JsonProperty("bankInstructionCode", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public TraditionalBankInstructionVerificationBankInstructionCode BankInstructionCode { get; set; } = TraditionalBankInstructionVerificationBankInstructionCode.USACH;

	[JsonProperty("bankInstructionName", Required = Required.Always)]
	[Required]
	[StringLength(100, MinimumLength = 1)]
	public string BankInstructionName { get; set; } = null;

	[JsonProperty("accountId", Required = Required.Always)]
	[Required]
	[StringLength(32, MinimumLength = 1)]
	public string AccountId { get; set; } = null;

	[JsonProperty("pendingInstructionId", Required = Required.Always)]
	public double PendingInstructionId { get; set; } = 0.0;

	[JsonProperty("creditAmount1", Required = Required.Always)]
	public double CreditAmount1 { get; set; } = 0.0;

	[JsonProperty("creditAmount2", Required = Required.Always)]
	public double CreditAmount2 { get; set; } = 0.0;

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
