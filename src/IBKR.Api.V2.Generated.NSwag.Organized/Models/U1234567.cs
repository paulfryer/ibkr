using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class U1234567
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("hasChildAccounts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool HasChildAccounts { get; set; }

    [JsonProperty("supportsCashQty", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool SupportsCashQty { get; set; }

    [JsonProperty("noFXConv", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool NoFXConv { get; set; }

    [JsonProperty("isProp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IsProp { get; set; }

    [JsonProperty("supportsFractions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool SupportsFractions { get; set; }

    [JsonProperty("allowCustomerTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool AllowCustomerTime { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}