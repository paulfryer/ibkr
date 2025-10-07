using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PartialBondPosition
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("cusipNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CusipNumber { get; set; }

    [JsonProperty("numberOfBonds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public long NumberOfBonds { get; set; }

    [JsonProperty("all", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool All { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}