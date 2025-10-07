using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class UserAccountsResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("accounts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> Accounts { get; set; }

    [JsonProperty("acctProps", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AcctProps AcctProps { get; set; }

    [JsonProperty("aliases", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Aliases Aliases { get; set; }

    [JsonProperty("allowFeatures", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AllowFeatures AllowFeatures { get; set; }

    [JsonProperty("chartPeriods", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ChartPeriods ChartPeriods { get; set; }

    [JsonProperty("groups", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> Groups { get; set; }

    [JsonProperty("profiles", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> Profiles { get; set; }

    [JsonProperty("selectedAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SelectedAccount { get; set; }

    [JsonProperty("serverInfo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ServerInfo2 ServerInfo { get; set; }

    [JsonProperty("sessionId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SessionId { get; set; }

    [JsonProperty("isFt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsFt { get; set; }

    [JsonProperty("isPaper", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsPaper { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}