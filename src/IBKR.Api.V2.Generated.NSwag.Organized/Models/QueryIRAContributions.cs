using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryIRAContributions
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("clientInstructionId", Required = Required.Always)]
    public double ClientInstructionId { get; set; }

    [JsonProperty("accountId", Required = Required.Always)]
    [Required]
    public string AccountId { get; set; }

    [JsonProperty("year", Required = Required.Always)]
    [Required]
    [StringLength(4, MinimumLength = 4)]
    public string Year { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}