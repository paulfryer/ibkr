using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class LoginMessageResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountId { get; set; }

    [JsonProperty("clearingStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ClearingStatus { get; set; }

    [JsonProperty("clearingStatusDescription", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string ClearingStatusDescription { get; set; }

    [JsonProperty("loginMessages", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<LoginMessage> LoginMessages { get; set; }

    [JsonProperty("loginMessagePresent", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool LoginMessagePresent { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}