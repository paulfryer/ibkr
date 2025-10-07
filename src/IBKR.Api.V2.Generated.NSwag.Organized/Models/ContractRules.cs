using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ContractRules
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("algoEligible", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool AlgoEligible { get; set; }

    [JsonProperty("overnightEligible", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool OvernightEligible { get; set; }

    [JsonProperty("costReport", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool CostReport { get; set; }

    [JsonProperty("canTradeAcctIds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> CanTradeAcctIds { get; set; }

    [JsonProperty("error", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public string? Error { get; set; }

    [JsonProperty("orderTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore,
        ItemConverterType = typeof(StringEnumConverter))]
    public ICollection<OrderTypes> OrderTypes { get; set; }

    [JsonProperty("ibAlgoTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore,
        ItemConverterType = typeof(StringEnumConverter))]
    public ICollection<IbAlgoTypes> IbAlgoTypes { get; set; }

    [JsonProperty("fraqTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore,
        ItemConverterType = typeof(StringEnumConverter))]
    public ICollection<FraqTypes> FraqTypes { get; set; }

    [JsonProperty("forceOrderPreview", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool ForceOrderPreview { get; set; }

    [JsonProperty("cqtTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore,
        ItemConverterType = typeof(StringEnumConverter))]
    public ICollection<CqtTypes> CqtTypes { get; set; }

    [JsonProperty("orderDefaults", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public OrderDefaults OrderDefaults { get; set; }

    [JsonProperty("orderTypesOutside", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore,
        ItemConverterType = typeof(StringEnumConverter))]
    public ICollection<OrderTypesOutside> OrderTypesOutside { get; set; }

    [JsonProperty("defaultSize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int DefaultSize { get; set; }

    [JsonProperty("cashSize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int CashSize { get; set; }

    [JsonProperty("sizeIncrement", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int SizeIncrement { get; set; }

    [JsonProperty("tifTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> TifTypes { get; set; }

    [JsonProperty("tifDefaults", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public TifDefaults TifDefaults { get; set; }

    [JsonProperty("limitPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int LimitPrice { get; set; }

    [JsonProperty("stopPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int StopPrice { get; set; }

    [JsonProperty("orderOrigination", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public string? OrderOrigination { get; set; }

    [JsonProperty("preview", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Preview { get; set; }

    [JsonProperty("displaySize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public int? DisplaySize { get; set; }

    [JsonProperty("fraqInt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int FraqInt { get; set; }

    [JsonProperty("cashCcy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CashCcy { get; set; }

    [JsonProperty("cashQtyIncr", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int CashQtyIncr { get; set; }

    [JsonProperty("priceMagnifier", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public int? PriceMagnifier { get; set; }

    [JsonProperty("negativeCapable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool NegativeCapable { get; set; }

    [JsonProperty("incrementType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int IncrementType { get; set; }

    [JsonProperty("IncrementRules", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IncrementRules> IncrementRules { get; set; }

    [JsonProperty("hasSecondary", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool HasSecondary { get; set; }

    [JsonProperty("modTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<object> ModTypes { get; set; }

    [JsonProperty("increment", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Increment { get; set; }

    [JsonProperty("incrementDigits", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int IncrementDigits { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}