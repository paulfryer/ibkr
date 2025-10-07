using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class LoginMessage
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("recordDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset RecordDate { get; set; } = default;

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Id { get; set; }

    [JsonProperty("username", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Username { get; set; }

    [JsonProperty("messageType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MessageType { get; set; }

    [JsonProperty("contentId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int ContentId { get; set; }

    [JsonProperty("state", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string State { get; set; }

    [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("tasks", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<int> Tasks { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}