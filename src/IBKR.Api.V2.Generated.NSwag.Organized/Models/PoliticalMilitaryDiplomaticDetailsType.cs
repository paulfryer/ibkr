using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PoliticalMilitaryDiplomaticDetailsType
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("personName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string PersonName { get; set; }

    [JsonProperty("title", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }

    [JsonProperty("organization", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Organization { get; set; }

    [JsonProperty("country", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Country { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}