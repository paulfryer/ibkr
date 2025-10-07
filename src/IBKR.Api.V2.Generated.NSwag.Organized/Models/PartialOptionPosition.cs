using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PartialOptionPosition
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Symbol { get; set; }

    [JsonProperty("numberOfContracts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public long NumberOfContracts { get; set; }

    [JsonProperty("all", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool All { get; set; }

    [JsonProperty("position", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public PartialOptionPositionPosition Position { get; set; } = PartialOptionPositionPosition.LONG;

    [JsonProperty("optionType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public PartialOptionPositionOptionType OptionType { get; set; } = PartialOptionPositionOptionType.CALL;

    [JsonProperty("strikePrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public long StrikePrice { get; set; }

    [JsonProperty("expirationDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExpirationDate { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}