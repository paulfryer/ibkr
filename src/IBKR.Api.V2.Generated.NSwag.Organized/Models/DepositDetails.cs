using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class DepositDetails
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("amount", Required = Required.Always)]
    public double Amount { get; set; }

    [JsonProperty("currency", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string Currency { get; set; }

    [JsonProperty("whenAvailable", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string WhenAvailable { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}