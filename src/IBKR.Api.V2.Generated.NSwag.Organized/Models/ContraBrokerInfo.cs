using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ContraBrokerInfo
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("accountType", Required = Required.Always)]
    [Required]
    [StringLength(32, MinimumLength = 1)]
    public string AccountType { get; set; }

    [JsonProperty("brokerName", Required = Required.Always)]
    [Required]
    [StringLength(128, MinimumLength = 1)]
    public string BrokerName { get; set; }

    [JsonProperty("depositoryId", Required = Required.Always)]
    [Required]
    [StringLength(64, MinimumLength = 1)]
    public string DepositoryId { get; set; }

    [JsonProperty("brokerAccountId", Required = Required.Always)]
    [Required]
    [StringLength(64, MinimumLength = 1)]
    public string BrokerAccountId { get; set; }

    [JsonProperty("country", Required = Required.Always)]
    [Required]
    [StringLength(64, MinimumLength = 1)]
    public string Country { get; set; }

    [JsonProperty("contactName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(64, MinimumLength = 1)]
    public string ContactName { get; set; }

    [JsonProperty("contactEmail", Required = Required.Always)]
    [Required]
    [StringLength(64, MinimumLength = 1)]
    public string ContactEmail { get; set; }

    [JsonProperty("contactPhone", Required = Required.Always)]
    [Required]
    [StringLength(16, MinimumLength = 1)]
    public string ContactPhone { get; set; }

    [JsonProperty("accountTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(128, MinimumLength = 1)]
    public string AccountTitle { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}