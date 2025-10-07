using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ParticipatingBanks
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("institutionName", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string InstitutionName { get; set; }

    [JsonProperty("clearingCode", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string ClearingCode { get; set; }

    [JsonProperty("BIC", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string BIC { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}