using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RegistrationTask
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalId { get; set; }

    [JsonProperty("formNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int FormNumber { get; set; }

    [JsonProperty("formName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FormName { get; set; }

    [JsonProperty("action", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Action { get; set; }

    [JsonProperty("dateCompleted", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset DateCompleted { get; set; } = default;

    [JsonProperty("state", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string State { get; set; }

    [JsonProperty("questionIds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<int> QuestionIds { get; set; }

    [JsonProperty("warning", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Warning { get; set; }

    [JsonProperty("isRequiredForApproval", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool IsRequiredForApproval { get; set; }

    [JsonProperty("isCompleted", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsCompleted { get; set; }

    [JsonProperty("isDeclined", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsDeclined { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}