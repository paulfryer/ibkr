using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class HmdsScannerRunRequest
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("instrument", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Instrument { get; set; }

    [JsonProperty("Locations", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Locations { get; set; }

    [JsonProperty("scanCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ScanCode { get; set; }

    [JsonProperty("secType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SecType { get; set; }

    [JsonProperty("delayedLocations", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DelayedLocations { get; set; }

    [JsonProperty("maxItems", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int MaxItems { get; set; } = 250;

    [JsonProperty("filters", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<object> Filters { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}