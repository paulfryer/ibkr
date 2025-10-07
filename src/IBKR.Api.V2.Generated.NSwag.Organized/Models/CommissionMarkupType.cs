using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class CommissionMarkupType
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("stairs", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<MarkupStaircaseType> Stairs { get; set; }

    [JsonProperty("code", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; }

    [JsonProperty("minimum", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Minimum { get; set; }

    [JsonProperty("maximum", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Maximum { get; set; }

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public CommissionMarkupTypeType Type { get; set; } = CommissionMarkupTypeType.FA;

    [JsonProperty("amount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double Amount { get; set; }

    [JsonProperty("plusCost", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool PlusCost { get; set; }

    [JsonProperty("ticketCharge", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double TicketCharge { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}