using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryWithdrawableFunds
{
    [JsonProperty("clientInstructionId", Required = Required.Always)]
    public double ClientInstructionId { get; set; }

    [JsonProperty("accountId", Required = Required.Always)]
    [Required]
    public string AccountId { get; set; }

    [JsonProperty("currency", Required = Required.Always)]
    [Required]
    public string Currency { get; set; }

    [JsonProperty("bankRoutingNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string BankRoutingNumber { get; set; }

    [JsonProperty("bankAccountNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string BankAccountNumber { get; set; }

    [JsonProperty("bankInstructionName", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string BankInstructionName { get; set; }
}