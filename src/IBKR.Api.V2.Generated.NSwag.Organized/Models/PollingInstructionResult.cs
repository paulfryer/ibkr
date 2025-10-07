using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PollingInstructionResult
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("clientInstructionId", Required = Required.Always)]
    public double ClientInstructionId { get; set; }

    [JsonProperty("instructionType", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(StringEnumConverter))]
    public PollingInstructionResultInstructionType InstructionType { get; set; } =
        PollingInstructionResultInstructionType.ACH_INSTRUCTION;

    [JsonProperty("instructionStatus", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(StringEnumConverter))]
    public PollingInstructionResultInstructionStatus InstructionStatus { get; set; } =
        PollingInstructionResultInstructionStatus.PENDING;

    [JsonProperty("instructionId", Required = Required.Always)]
    public double InstructionId { get; set; }

    [JsonProperty("ibReferenceId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double IbReferenceId { get; set; }

    [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("error", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Error2 Error { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}