using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ComplexAssetTransferInstruction
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("clientInstructionId", Required = Required.Always)]
    public double ClientInstructionId { get; set; }

    [JsonProperty("direction", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ComplexAssetTransferInstructionDirection Direction { get; set; } =
        ComplexAssetTransferInstructionDirection.IN;

    [JsonProperty("accountId", Required = Required.Always)]
    [Required]
    [StringLength(32, MinimumLength = 1)]
    public string AccountId { get; set; }

    [JsonProperty("accountIdAtCurrentBroker", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(64, MinimumLength = 1)]
    public string AccountIdAtCurrentBroker { get; set; }

    [JsonProperty("quantity", Required = Required.Always)]
    public double Quantity { get; set; }

    [JsonProperty("tradingInstrument", Required = Required.Always)]
    [Required]
    public TradingInstrument TradingInstrument { get; set; } = new();

    [JsonProperty("contraBrokerInfo", Required = Required.Always)]
    [Required]
    public ContraBrokerInfo ContraBrokerInfo { get; set; } = new();

    [JsonProperty("nonDisclosedDetail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public NonDisclosedDetail NonDisclosedDetail { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}