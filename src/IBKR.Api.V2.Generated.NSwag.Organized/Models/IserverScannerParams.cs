using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IserverScannerParams
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("scan_type_list", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Scan_type_list> Scan_type_list { get; set; }

    [JsonProperty("instrument_list", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Instrument_list> Instrument_list { get; set; }

    [JsonProperty("filter_list", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Filter_list> Filter_list { get; set; }

    [JsonProperty("location_tree", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Location_tree> Location_tree { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}