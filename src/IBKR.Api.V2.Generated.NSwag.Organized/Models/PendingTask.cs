using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PendingTask
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("taskNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int TaskNumber { get; set; }

    [JsonProperty("formNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int FormNumber { get; set; }

    [JsonProperty("formName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FormName { get; set; }

    [JsonProperty("action", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Action { get; set; }

    [JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalId { get; set; }

    [JsonProperty("state", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string State { get; set; }

    [JsonProperty("documentRejectReason", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> DocumentRejectReason { get; set; }

    [JsonProperty("url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Url { get; set; }

    [JsonProperty("startDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset StartDate { get; set; } = default;

    [JsonProperty("au10tixCreatedDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset Au10tixCreatedDate { get; set; } = default;

    [JsonProperty("au10tixExpiryDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset Au10tixExpiryDate { get; set; } = default;

    [JsonProperty("entityId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int EntityId { get; set; }

    [JsonProperty("onlineTask", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool OnlineTask { get; set; }

    [JsonProperty("requiredForApproval", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool RequiredForApproval { get; set; }

    [JsonProperty("requiredForTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool RequiredForTrading { get; set; }

    [JsonProperty("questionIds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<int> QuestionIds { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}