using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AsynchronousInstructionResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("status", Required = Required.Always)]
    public double Status { get; set; }

    [JsonProperty("instructionSetId", Required = Required.Always)]
    public double InstructionSetId { get; set; }

    [JsonProperty("instructionResult", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public InstructionResult InstructionResult { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}