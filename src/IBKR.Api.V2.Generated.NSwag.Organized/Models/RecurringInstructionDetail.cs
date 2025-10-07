using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RecurringInstructionDetail
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("instructionName", Required = Required.Always)]
    [Required]
    [StringLength(64, MinimumLength = 1)]
    public string InstructionName { get; set; }

    [JsonProperty("frequency", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(StringEnumConverter))]
    public RecurringInstructionDetailFrequency Frequency { get; set; } = RecurringInstructionDetailFrequency.MONTHLY;

    [JsonProperty("startDate", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
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