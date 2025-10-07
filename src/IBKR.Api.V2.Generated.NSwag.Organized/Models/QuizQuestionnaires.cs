using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QuizQuestionnaires
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("questionnaire", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Questionnaire> Questionnaire { get; set; }

    [JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountId { get; set; }

    [JsonProperty("task", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Task> Task { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}