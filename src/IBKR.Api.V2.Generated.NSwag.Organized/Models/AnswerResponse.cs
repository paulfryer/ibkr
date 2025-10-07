using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AnswerResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("answerId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public long AnswerId { get; set; }

    [JsonProperty("answer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Answer { get; set; }

    [JsonProperty("dependentQuestionId", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public long DependentQuestionId { get; set; }

    [JsonProperty("dependentAnswerId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public long DependentAnswerId { get; set; }

    [JsonProperty("multiAnswerDetail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> MultiAnswerDetail { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}