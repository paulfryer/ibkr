using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RegisteredClient
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Id { get; set; }

    [JsonProperty("client_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Client_id { get; set; }

    [JsonProperty("client_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Client_name { get; set; }

    [JsonProperty("client_category", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public RegisteredClientClient_category Client_category { get; set; } = RegisteredClientClient_category.DIRECT;

    [JsonProperty("client_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public RegisteredClientClient_type Client_type { get; set; } = RegisteredClientClient_type.CONFIDENTIAL;

    [JsonProperty("client_status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public RegisteredClientClient_status Client_status { get; set; } = RegisteredClientClient_status.REQUESTED;

    [JsonProperty("redirect_uris", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> Redirect_uris { get; set; }

    [JsonProperty("jwks", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ClientPublicKeySet Jwks { get; set; }

    [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("client_uri", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Client_uri { get; set; }

    [JsonProperty("logo_uri", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Logo_uri { get; set; }

    [JsonProperty("policy_uri", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Policy_uri { get; set; }

    [JsonProperty("account_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Account_id { get; set; }

    [JsonProperty("csid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Csid { get; set; }

    [JsonProperty("allowed_grant_types", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore,
        ItemConverterType = typeof(StringEnumConverter))]
    public ICollection<Allowed_grant_types> Allowed_grant_types { get; set; }

    [JsonProperty("configuration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ClientConfiguration Configuration { get; set; }

    [JsonProperty("created_at", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset Created_at { get; set; } = default;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}