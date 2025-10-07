using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryWithdrawableAmountsInstructionResult : PollingInstructionResult
{
    [JsonProperty("accountId", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string AccountId { get; set; }

    [JsonProperty("currency", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string Currency { get; set; }

    [JsonProperty("withdrawableAmount", Required = Required.Always)]
    public double WithdrawableAmount { get; set; }

    [JsonProperty("withdrawableAmountNoBorrow", Required = Required.Always)]
    public double WithdrawableAmountNoBorrow { get; set; }

    [JsonProperty("allowedTransferAmountToMaster", Required = Required.Always)]
    public double AllowedTransferAmountToMaster { get; set; }

    [JsonProperty("allowedTransferAmountToMasterNoBorrow", Required = Required.Always)]
    public double AllowedTransferAmountToMasterNoBorrow { get; set; }
}