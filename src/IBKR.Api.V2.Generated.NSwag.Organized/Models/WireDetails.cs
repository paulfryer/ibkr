using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class WireDetails
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("bankName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string BankName { get; set; }

    [JsonProperty("bankAccountNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string BankAccountNumber { get; set; }

    [JsonProperty("bankCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string BankCode { get; set; }

    [JsonProperty("routingNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string RoutingNumber { get; set; }

    [JsonProperty("instruction", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Instruction { get; set; }

    [JsonProperty("countryCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CountryCode { get; set; }

    [JsonProperty("referenceNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ReferenceNumber { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}