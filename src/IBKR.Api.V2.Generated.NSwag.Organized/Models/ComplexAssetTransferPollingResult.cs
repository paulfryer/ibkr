using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ComplexAssetTransferPollingResult : PollingInstructionResult
{
    [JsonProperty("clearingState", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string ClearingState { get; set; }

    [JsonProperty("consolidatedComplexAssetTransferReport", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<ConsolidatedComplexAssetTransferReport> ConsolidatedComplexAssetTransferReport { get; set; }
}