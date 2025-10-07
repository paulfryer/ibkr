using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class WithdrawFundsInstruction
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("clientInstructionId", Required = Required.Always)]
    public double ClientInstructionId { get; set; }

    [JsonProperty("accountId", Required = Required.Always)]
    [Required]
    [StringLength(32, MinimumLength = 1)]
    public string AccountId { get; set; }

    [JsonProperty("currency", Required = Required.Always)]
    [Required]
    [StringLength(3, MinimumLength = 1)]
    public string Currency { get; set; }

    [JsonProperty("amount", Required = Required.Always)]
    public double Amount { get; set; }

    [JsonProperty("bankInstructionName", Required = Required.Always)]
    [Required]
    [StringLength(150, MinimumLength = 1)]
    public string BankInstructionName { get; set; }

    [JsonProperty("bankInstructionMethod", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(StringEnumConverter))]
    public WithdrawFundsInstructionBankInstructionMethod BankInstructionMethod { get; set; } =
        WithdrawFundsInstructionBankInstructionMethod.ACH;

    [JsonProperty("dateTimeToOccur", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset DateTimeToOccur { get; set; } = default;

    [JsonProperty("iraWithdrawalDetail", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public IraWithdrawalDetail IraWithdrawalDetail { get; set; }

    [JsonProperty("recurringInstructionDetail", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public RecurringInstructionDetail RecurringInstructionDetail { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}