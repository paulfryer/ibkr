using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PerformanceResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("currencyType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CurrencyType { get; set; }

    [JsonProperty("rc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Rc { get; set; }

    [JsonProperty("nav", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Nav Nav { get; set; }

    [JsonProperty("nd", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Nd { get; set; }

    [JsonProperty("cps", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Cps Cps { get; set; }

    [JsonProperty("tpps", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Tpps Tpps { get; set; }

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("included", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<object> Included { get; set; }

    [JsonProperty("pm", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Pm { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}