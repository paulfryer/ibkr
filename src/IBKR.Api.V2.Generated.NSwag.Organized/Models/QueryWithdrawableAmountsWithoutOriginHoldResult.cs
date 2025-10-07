using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryWithdrawableAmountsWithoutOriginHoldResult : PollingInstructionResult
{
    [JsonProperty("accountId", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string AccountId { get; set; }

    [JsonProperty("currency", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string Currency { get; set; }

    [JsonProperty("withdrawableAmountWithoutOriginationHold", Required = Required.Always)]
    public double WithdrawableAmountWithoutOriginationHold { get; set; }

    [JsonProperty("withdrawableAmountWithoutOriginationHoldNoBorrow", Required = Required.Always)]
    public double WithdrawableAmountWithoutOriginationHoldNoBorrow { get; set; }
}