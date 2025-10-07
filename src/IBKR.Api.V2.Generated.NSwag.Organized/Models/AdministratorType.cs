using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AdministratorType
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("firstName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FirstName { get; set; }

    [JsonProperty("middleInitial", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MiddleInitial { get; set; }

    [JsonProperty("lastName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string LastName { get; set; }

    [JsonProperty("suffix", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AdministratorTypeSuffix Suffix { get; set; } = AdministratorTypeSuffix.Jr_;

    [JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Address Address { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}