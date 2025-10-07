using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Total
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("current_available", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Current_available { get; set; }

    [JsonProperty("current_excess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Current_excess { get; set; }

    [JsonProperty("Prdctd Pst-xpry Excss", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Prdctd_PstXpry_Excss { get; set; }

    [JsonProperty("Lk Ahd Avlbl Fnds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Lk_Ahd_Avlbl_Fnds { get; set; }

    [JsonProperty("Lk Ahd Excss Lqdty", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Lk_Ahd_Excss_Lqdty { get; set; }

    [JsonProperty("overnight_available", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Overnight_available { get; set; }

    [JsonProperty("overnight_excess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Overnight_excess { get; set; }

    [JsonProperty("buying_power", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Buying_power { get; set; }

    [JsonProperty("leverage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Leverage { get; set; }

    [JsonProperty("Lk Ahd Nxt Chng", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Lk_Ahd_Nxt_Chng { get; set; }

    [JsonProperty("day_trades_left", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Day_trades_left { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}