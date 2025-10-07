using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryRecentRecurringEvents
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("clientInstructionId", Required = Required.Always)]
    public double ClientInstructionId { get; set; }

    [JsonProperty("ibReferenceId", Required = Required.Always)]
    [Range(0.0, double.MaxValue)]
    public double IbReferenceId { get; set; }

    [JsonProperty("numberOfTransactions", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    [Range(1.0, double.MaxValue)]
    public double NumberOfTransactions { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}