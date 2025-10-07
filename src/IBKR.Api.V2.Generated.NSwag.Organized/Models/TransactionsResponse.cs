using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TransactionsResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("rc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Rc { get; set; }

    [JsonProperty("nd", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Nd { get; set; }

    [JsonProperty("rpnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Rpnl Rpnl { get; set; }

    [JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Currency { get; set; }

    [JsonProperty("from", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int From { get; set; }

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("to", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int To { get; set; }

    [JsonProperty("includesRealTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IncludesRealTime { get; set; }

    [JsonProperty("transactions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Transactions> Transactions { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}