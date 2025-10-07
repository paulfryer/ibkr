using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RegistrationTasksResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("error", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ErrorResponse Error { get; set; }

    [JsonProperty("hasError", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool HasError { get; set; }

    [JsonProperty("errorDescription", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ErrorDescription { get; set; }

    [JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountId { get; set; }

    [JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Status { get; set; }

    [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("state", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string State { get; set; }

    [JsonProperty("registrationTaskPresent", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool RegistrationTaskPresent { get; set; }

    [JsonProperty("registrationTasks", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<RegistrationTask> RegistrationTasks { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}