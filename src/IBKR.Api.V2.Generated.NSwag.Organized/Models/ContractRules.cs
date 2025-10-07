using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ContractRules
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("algoEligible", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AlgoEligible { get; set; } = false;

	[JsonProperty("overnightEligible", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool OvernightEligible { get; set; } = false;

	[JsonProperty("costReport", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool CostReport { get; set; } = false;

	[JsonProperty("canTradeAcctIds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> CanTradeAcctIds { get; set; } = null;

	[JsonProperty("error", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public string? Error { get; set; } = null;

	[JsonProperty("orderTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
	public ICollection<OrderTypes> OrderTypes { get; set; } = null;

	[JsonProperty("ibAlgoTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
	public ICollection<IbAlgoTypes> IbAlgoTypes { get; set; } = null;

	[JsonProperty("fraqTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
	public ICollection<FraqTypes> FraqTypes { get; set; } = null;

	[JsonProperty("forceOrderPreview", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ForceOrderPreview { get; set; } = false;

	[JsonProperty("cqtTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
	public ICollection<CqtTypes> CqtTypes { get; set; } = null;

	[JsonProperty("orderDefaults", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public OrderDefaults OrderDefaults { get; set; } = null;

	[JsonProperty("orderTypesOutside", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
	public ICollection<OrderTypesOutside> OrderTypesOutside { get; set; } = null;

	[JsonProperty("defaultSize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int DefaultSize { get; set; } = 0;

	[JsonProperty("cashSize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int CashSize { get; set; } = 0;

	[JsonProperty("sizeIncrement", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int SizeIncrement { get; set; } = 0;

	[JsonProperty("tifTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> TifTypes { get; set; } = null;

	[JsonProperty("tifDefaults", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public TifDefaults TifDefaults { get; set; } = null;

	[JsonProperty("limitPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int LimitPrice { get; set; } = 0;

	[JsonProperty("stopPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int StopPrice { get; set; } = 0;

	[JsonProperty("orderOrigination", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public string? OrderOrigination { get; set; } = null;

	[JsonProperty("preview", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Preview { get; set; } = false;

	[JsonProperty("displaySize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public int? DisplaySize { get; set; } = null;

	[JsonProperty("fraqInt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int FraqInt { get; set; } = 0;

	[JsonProperty("cashCcy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CashCcy { get; set; } = null;

	[JsonProperty("cashQtyIncr", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int CashQtyIncr { get; set; } = 0;

	[JsonProperty("priceMagnifier", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public int? PriceMagnifier { get; set; } = null;

	[JsonProperty("negativeCapable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool NegativeCapable { get; set; } = false;

	[JsonProperty("incrementType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int IncrementType { get; set; } = 0;

	[JsonProperty("IncrementRules", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IncrementRules> IncrementRules { get; set; } = null;

	[JsonProperty("hasSecondary", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool HasSecondary { get; set; } = false;

	[JsonProperty("modTypes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<object> ModTypes { get; set; } = null;

	[JsonProperty("increment", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Increment { get; set; } = 0;

	[JsonProperty("incrementDigits", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int IncrementDigits { get; set; } = 0;

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get
		{
			return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
		}
		set
		{
			_additionalProperties = value;
		}
	}
}
