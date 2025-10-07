using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class SourceOfIncomeType
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("sourceType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SourceOfIncomeTypeSourceType SourceType { get; set; } = SourceOfIncomeTypeSourceType.CONSULTING;

    [JsonProperty("percentage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Percentage { get; set; }

    [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}