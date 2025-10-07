using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TifDefaults
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("TIF", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TIF { get; set; }

    [JsonProperty("SIZE", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SIZE { get; set; }

    [JsonProperty("DEFAULT_ACCT", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DEFAULT_ACCT { get; set; }

    [JsonProperty("PMALGO", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool PMALGO { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}