using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryBankInstruction
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("clientInstructionId", Required = Required.Always)]
    public double ClientInstructionId { get; set; }

    [JsonProperty("accountId", Required = Required.Always)]
    [Required]
    public string AccountId { get; set; }

    [JsonProperty("bankInstructionMethod", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(StringEnumConverter))]
    public QueryBankInstructionBankInstructionMethod BankInstructionMethod { get; set; } =
        QueryBankInstructionBankInstructionMethod.ACH;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}