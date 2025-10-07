using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Anonymous6
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("acctcode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Acctcode { get; set; } = null;


	[JsonProperty("cashbalance", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Cashbalance { get; set; } = 0.0;


	[JsonProperty("cashbalancefxsegment", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Cashbalancefxsegment { get; set; } = 0.0;


	[JsonProperty("commoditymarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Commoditymarketvalue { get; set; } = 0.0;


	[JsonProperty("corporatebondsmarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Corporatebondsmarketvalue { get; set; } = 0.0;


	[JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Currency { get; set; } = null;


	[JsonProperty("dividends", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Dividends { get; set; } = 0.0;


	[JsonProperty("exchangerate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Exchangerate { get; set; } = 0;


	[JsonProperty("funds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Funds { get; set; } = 0.0;


	[JsonProperty("futuremarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Futuremarketvalue { get; set; } = 0.0;


	[JsonProperty("futureoptionmarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Futureoptionmarketvalue { get; set; } = 0.0;


	[JsonProperty("futuresonlypnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Futuresonlypnl { get; set; } = 0.0;


	[JsonProperty("interest", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Interest { get; set; } = 0.0;


	[JsonProperty("issueroptionsmarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Issueroptionsmarketvalue { get; set; } = 0.0;


	[JsonProperty("key", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public Key Key { get; set; } = Key.LedgerList;


	[JsonProperty("moneyfunds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Moneyfunds { get; set; } = 0.0;


	[JsonProperty("netliquidationvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Netliquidationvalue { get; set; } = 0.0;


	[JsonProperty("realizedpnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Realizedpnl { get; set; } = 0.0;


	[JsonProperty("secondkey", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Secondkey { get; set; } = null;


	[JsonProperty("sessionid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Sessionid { get; set; } = 0;


	[JsonProperty("settledcash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Settledcash { get; set; } = 0.0;


	[JsonProperty("severity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Severity { get; set; } = 0;


	[JsonProperty("stockmarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Stockmarketvalue { get; set; } = 0.0;


	[JsonProperty("stockoptionmarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Stockoptionmarketvalue { get; set; } = 0.0;


	[JsonProperty("tbillsmarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Tbillsmarketvalue { get; set; } = 0.0;


	[JsonProperty("tbondsmarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Tbondsmarketvalue { get; set; } = 0.0;


	[JsonProperty("timestamp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Timestamp { get; set; } = 0;


	[JsonProperty("unrealizedpnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Unrealizedpnl { get; set; } = 0.0;


	[JsonProperty("warrantsmarketvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Warrantsmarketvalue { get; set; } = 0.0;


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
