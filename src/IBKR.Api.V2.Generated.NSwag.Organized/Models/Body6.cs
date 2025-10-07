using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Body6
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("instructionType", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Body6InstructionType InstructionType { get; set; } = Body6InstructionType.QUERY_WITHDRAWABLE_FUNDS;

    [JsonProperty("instruction", Required = Required.Always)]
    [Required]
    public QueryWithdrawableFunds Instruction { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}