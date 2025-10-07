using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class BankInstructionDetails
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("instructionName", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string InstructionName { get; set; }

    [JsonProperty("type", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string Type { get; set; }

    [JsonProperty("currency", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string Currency { get; set; }

    [JsonProperty("instructionStatus", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string InstructionStatus { get; set; }

    [JsonProperty("bankRoutingNumber", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string BankRoutingNumber { get; set; }

    [JsonProperty("bankAccountNumber", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string BankAccountNumber { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}