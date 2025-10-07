using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class OrderPreview
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("amount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Amount Amount { get; set; }

    [JsonProperty("equity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Equity Equity { get; set; }

    [JsonProperty("initial", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Initial Initial { get; set; }

    [JsonProperty("maintenance", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Maintenance Maintenance { get; set; }

    [JsonProperty("position", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Position Position { get; set; }

    [JsonProperty("warn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Warn { get; set; }

    [JsonProperty("error", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Error { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}