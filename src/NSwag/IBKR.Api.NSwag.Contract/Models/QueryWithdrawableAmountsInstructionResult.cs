using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryWithdrawableAmountsInstructionResult : PollingInstructionResult
{
	[JsonProperty("accountId", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string AccountId { get; set; } = null;


	[JsonProperty("currency", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Currency { get; set; } = null;


	[JsonProperty("withdrawableAmount", Required = Required.Always)]
	public double WithdrawableAmount { get; set; } = 0.0;


	[JsonProperty("withdrawableAmountNoBorrow", Required = Required.Always)]
	public double WithdrawableAmountNoBorrow { get; set; } = 0.0;


	[JsonProperty("allowedTransferAmountToMaster", Required = Required.Always)]
	public double AllowedTransferAmountToMaster { get; set; } = 0.0;


	[JsonProperty("allowedTransferAmountToMasterNoBorrow", Required = Required.Always)]
	public double AllowedTransferAmountToMasterNoBorrow { get; set; } = 0.0;

}
