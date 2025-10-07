using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Address
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("street1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Street1 { get; set; }

    [JsonProperty("street2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Street2 { get; set; }

    [JsonProperty("city", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string City { get; set; }

    [JsonProperty("state", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string State { get; set; }

    [JsonProperty("country", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Country { get; set; }

    [JsonProperty("postalCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string PostalCode { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}