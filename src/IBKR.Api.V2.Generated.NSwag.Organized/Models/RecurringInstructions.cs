using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RecurringInstructions
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("requestId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int RequestId { get; set; }

    [JsonProperty("bankInstructionName", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string BankInstructionName { get; set; }

    [JsonProperty("transactionType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TransactionType { get; set; }

    [JsonProperty("bankInstructionMethod", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string BankInstructionMethod { get; set; }

    [JsonProperty("amount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Amount { get; set; }

    [JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Currency { get; set; }

    [JsonProperty("frequency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Frequency { get; set; }

    [JsonProperty("startDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string StartDate { get; set; }

    [JsonProperty("endDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string EndDate { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}