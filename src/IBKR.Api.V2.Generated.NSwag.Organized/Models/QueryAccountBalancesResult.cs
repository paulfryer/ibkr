using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryAccountBalancesResult : InstructionResult
{
	[JsonProperty("accountId", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string AccountId { get; set; } = null;

	[JsonProperty("currency", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Currency { get; set; } = null;

	[JsonProperty("withdrawableAmount", Required = Required.Always)]
	public double WithdrawableAmount { get; set; } = 0.0;

	[JsonProperty("transferableAmount", Required = Required.Always)]
	public double TransferableAmount { get; set; } = 0.0;

	[JsonProperty("clientBankAccountWithdrawableBalance", Required = Required.Always)]
	[Required]
	public ICollection<object> ClientBankAccountWithdrawableBalance { get; set; } = new Collection<object>();
}
