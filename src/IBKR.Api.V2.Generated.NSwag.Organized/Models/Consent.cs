using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Consent
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("consent_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Consent_id { get; set; }

    [JsonProperty("consent_status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Consent_status Consent_status { get; set; } = Consent_status.GRANTED;

    [JsonProperty("client_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Client_id { get; set; }

    [JsonProperty("user_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public long User_id { get; set; }

    [JsonProperty("account_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Account_id { get; set; }

    [JsonProperty("consented_scopes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> Consented_scopes { get; set; }

    [JsonProperty("consented_at", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset Consented_at { get; set; } = default;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}