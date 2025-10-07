using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IserverScannerRunRequest
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("instrument", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Instrument { get; set; }

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }

    [JsonProperty("location", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Location { get; set; }

    [JsonProperty("filter", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Filter> Filter { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}