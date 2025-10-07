using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PhoneInfo
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public PhoneInfoType Type { get; set; } = PhoneInfoType.Work;

    [JsonProperty("number", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Number { get; set; }

    [JsonProperty("country", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Country { get; set; }

    [JsonProperty("verified", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Verified { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}