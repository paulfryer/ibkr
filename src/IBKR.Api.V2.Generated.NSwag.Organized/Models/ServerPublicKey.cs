using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ServerPublicKey
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("keyId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string KeyId { get; set; }

    [JsonProperty("keyBitSize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [Range(3072, int.MaxValue)]
    public int KeyBitSize { get; set; }

    [JsonProperty("symmetric", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Symmetric { get; set; }

    [JsonProperty("public", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Public { get; set; }

    [JsonProperty("private", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Private { get; set; }

    [JsonProperty("asymmetric", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Asymmetric { get; set; }

    [JsonProperty("empty", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Empty { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}