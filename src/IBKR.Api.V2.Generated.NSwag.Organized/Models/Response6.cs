using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Response6
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("total", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Total { get; set; }

    [JsonProperty("size", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Size { get; set; }

    [JsonProperty("offset", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Offset { get; set; }

    [JsonProperty("scanTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ScanTime { get; set; }

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("position", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Position { get; set; }

    [JsonProperty("warningText", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string WarningText { get; set; }

    [JsonProperty("Contracts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Contracts2 Contracts { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}