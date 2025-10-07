using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class InternalPositionTransferInstruction
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("clientInstructionId", Required = Required.Always)]
    public double ClientInstructionId { get; set; }

    [JsonProperty("sourceAccountId", Required = Required.Always)]
    [Required]
    public string SourceAccountId { get; set; }

    [JsonProperty("targetAccountId", Required = Required.Always)]
    [Required]
    public string TargetAccountId { get; set; }

    [JsonProperty("transferQuantity", Required = Required.Always)]
    public double TransferQuantity { get; set; }

    [JsonProperty("tradingInstrument", Required = Required.Always)]
    [Required]
    public TradingInstrument TradingInstrument { get; set; } = new();

    [JsonProperty("transferPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double TransferPrice { get; set; }

    [JsonProperty("tradeDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TradeDate { get; set; }

    [JsonProperty("settleDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SettleDate { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}