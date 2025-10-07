using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QuestionnaireResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("questionId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public long QuestionId { get; set; }

    [JsonProperty("question", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Question { get; set; }

    [JsonProperty("isMandatoryToAnswer", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool IsMandatoryToAnswer { get; set; }

    [JsonProperty("questionType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string QuestionType { get; set; }

    [JsonProperty("answers", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AnswerResponse> Answers { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}