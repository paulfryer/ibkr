using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Currency
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("total_cash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Total_cash { get; set; } = null;

	[JsonProperty("settled_cash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Settled_cash { get; set; } = null;

	[JsonProperty("MTD Interest", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MTD_Interest { get; set; } = null;

	[JsonProperty("stock", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Stock { get; set; } = null;

	[JsonProperty("options", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Options { get; set; } = null;

	[JsonProperty("futures", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Futures { get; set; } = null;

	[JsonProperty("future_options", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Future_options { get; set; } = null;

	[JsonProperty("funds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Funds { get; set; } = null;

	[JsonProperty("dividends_receivable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Dividends_receivable { get; set; } = null;

	[JsonProperty("mutual_funds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Mutual_funds { get; set; } = null;

	[JsonProperty("money_market", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Money_market { get; set; } = null;

	[JsonProperty("bonds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Bonds { get; set; } = null;

	[JsonProperty("Govt Bonds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Govt_Bonds { get; set; } = null;

	[JsonProperty("t_bills", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string T_bills { get; set; } = null;

	[JsonProperty("warrants", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Warrants { get; set; } = null;

	[JsonProperty("issuer_option", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Issuer_option { get; set; } = null;

	[JsonProperty("commodity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Commodity { get; set; } = null;

	[JsonProperty("Notional CFD", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Notional_CFD { get; set; } = null;

	[JsonProperty("cfd", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Cfd { get; set; } = null;

	[JsonProperty("net_liquidation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Net_liquidation { get; set; } = null;

	[JsonProperty("unrealized_pnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Unrealized_pnl { get; set; } = null;

	[JsonProperty("realized_pnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Realized_pnl { get; set; } = null;

	[JsonProperty("Exchange Rate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Exchange_Rate { get; set; } = null;

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
