using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Application
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("customer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Customer Customer { get; set; }

    [JsonProperty("accounts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Account> Accounts { get; set; }

    [JsonProperty("users", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<User> Users { get; set; }

    [JsonProperty("documents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Document> Documents { get; set; }

    [JsonProperty("additionalAccounts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AddAdditionalAccount> AdditionalAccounts { get; set; }

    [JsonProperty("masterAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MasterAccountId { get; set; }

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("inputLanguage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ApplicationInputLanguage InputLanguage { get; set; } = ApplicationInputLanguage.En;

    [JsonProperty("translation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Translation { get; set; }

    [JsonProperty("paperAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool PaperAccount { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}