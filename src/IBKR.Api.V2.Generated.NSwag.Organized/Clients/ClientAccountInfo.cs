using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ClientAccountInfo
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("bankRoutingNumber", Required = Required.Always)]
    [Required]
    [StringLength(24, MinimumLength = 1)]
    public string BankRoutingNumber { get; set; }

    [JsonProperty("bankAccountNumber", Required = Required.Always)]
    [Required]
    [StringLength(32, MinimumLength = 1)]
    public string BankAccountNumber { get; set; }

    [JsonProperty("bankName", Required = Required.Always)]
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string BankName { get; set; }

    [JsonProperty("bankAccountTypeCode", Required = Required.Always)]
    public double BankAccountTypeCode { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}