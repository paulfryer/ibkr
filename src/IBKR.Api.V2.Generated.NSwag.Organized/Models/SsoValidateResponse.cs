using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class SsoValidateResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("USER_ID", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int USER_ID { get; set; }

    [JsonProperty("USER_NAME", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string USER_NAME { get; set; }

    [JsonProperty("RESULT", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool RESULT { get; set; }

    [JsonProperty("AUTH_TIME", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int AUTH_TIME { get; set; }

    [JsonProperty("SF_ENABLED", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool SF_ENABLED { get; set; }

    [JsonProperty("IS_FREE_TRIAL", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IS_FREE_TRIAL { get; set; }

    [JsonProperty("CREDENTIAL", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CREDENTIAL { get; set; }

    [JsonProperty("IP", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string IP { get; set; }

    [JsonProperty("EXPIRES", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int EXPIRES { get; set; }

    [JsonProperty("QUALIFIED_FOR_MOBILE_AUTH", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool QUALIFIED_FOR_MOBILE_AUTH { get; set; }

    [JsonProperty("LANDING_APP", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string LANDING_APP { get; set; }

    [JsonProperty("IS_MASTER", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IS_MASTER { get; set; }

    [JsonProperty("lastAccessed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int LastAccessed { get; set; }

    [JsonProperty("loginType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int LoginType { get; set; }

    [JsonProperty("PAPER_USER_NAME", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string PAPER_USER_NAME { get; set; }

    [JsonProperty("features", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Features2 Features { get; set; }

    [JsonProperty("region", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Region { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}