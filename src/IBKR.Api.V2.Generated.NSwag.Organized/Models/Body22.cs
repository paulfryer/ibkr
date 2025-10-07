using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Body22
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("symbol", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string Symbol { get; set; }

    [JsonProperty("secType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Body22SecType SecType { get; set; } = Body22SecType.STK;

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Name { get; set; }

    [JsonProperty("more", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool More { get; set; }

    [JsonProperty("fund", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Fund { get; set; }

    [JsonProperty("fundFamilyConidEx", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FundFamilyConidEx { get; set; }

    [JsonProperty("pattern", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Pattern { get; set; }

    [JsonProperty("referrer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Referrer { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}