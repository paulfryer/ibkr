using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryRecentRecurringEventResult : InstructionResult
{
    [JsonProperty("recurringInstructionName", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string RecurringInstructionName { get; set; }

    [JsonProperty("recurringTransactionType", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string RecurringTransactionType { get; set; }

    [JsonProperty("recurringTransactionStatus", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string RecurringTransactionStatus { get; set; }

    [JsonProperty("amount", Required = Required.Always)]
    public double Amount { get; set; }

    [JsonProperty("currency", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string Currency { get; set; }

    [JsonProperty("method", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string Method { get; set; }

    [JsonProperty("transactionHistory", Required = Required.Always)]
    [Required]
    public TransactionHistory2 TransactionHistory { get; set; } = new();
}