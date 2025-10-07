using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryWithdrawableFunds
{
	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;

	[JsonProperty("accountId", Required = Required.Always)]
	[Required]
	public string AccountId { get; set; } = null;

	[JsonProperty("currency", Required = Required.Always)]
	[Required]
	public string Currency { get; set; } = null;

	[JsonProperty("bankRoutingNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(int.MaxValue, MinimumLength = 1)]
	public string BankRoutingNumber { get; set; } = null;

	[JsonProperty("bankAccountNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(int.MaxValue, MinimumLength = 1)]
	public string BankAccountNumber { get; set; } = null;

	[JsonProperty("bankInstructionName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(int.MaxValue, MinimumLength = 1)]
	public string BankInstructionName { get; set; } = null;
}
