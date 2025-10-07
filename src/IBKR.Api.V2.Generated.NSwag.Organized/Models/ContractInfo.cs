using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ContractInfo
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("cfi_code", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Cfi_code { get; set; } = null;

	[JsonProperty("symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Symbol { get; set; } = null;

	[JsonProperty("cusip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Cusip { get; set; } = null;

	[JsonProperty("expiry_full", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Expiry_full { get; set; } = null;

	[JsonProperty("con_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Con_id { get; set; } = 0;

	[JsonProperty("maturity_date", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Maturity_date { get; set; } = null;

	[JsonProperty("industry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Industry { get; set; } = null;

	[JsonProperty("instrument_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Instrument_type { get; set; } = null;

	[JsonProperty("trading_class", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Trading_class { get; set; } = null;

	[JsonProperty("valid_exchanges", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Valid_exchanges { get; set; } = null;

	[JsonProperty("allow_sell_long", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Allow_sell_long { get; set; } = false;

	[JsonProperty("is_zero_commission_security", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Is_zero_commission_security { get; set; } = false;

	[JsonProperty("local_symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Local_symbol { get; set; } = null;

	[JsonProperty("contract_clarification_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Contract_clarification_type { get; set; } = null;

	[JsonProperty("classifier", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Classifier { get; set; } = null;

	[JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Currency { get; set; } = null;

	[JsonProperty("text", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Text { get; set; } = null;

	[JsonProperty("underlying_con_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Underlying_con_id { get; set; } = 0;

	[JsonProperty("r_t_h", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool R_t_h { get; set; } = false;

	[JsonProperty("multiplier", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Multiplier { get; set; } = null;

	[JsonProperty("underlying_issuer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Underlying_issuer { get; set; } = null;

	[JsonProperty("contract_month", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Contract_month { get; set; } = null;

	[JsonProperty("company_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Company_name { get; set; } = null;

	[JsonProperty("smart_available", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Smart_available { get; set; } = false;

	[JsonProperty("exchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Exchange { get; set; } = null;

	[JsonProperty("category", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Category { get; set; } = null;

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
