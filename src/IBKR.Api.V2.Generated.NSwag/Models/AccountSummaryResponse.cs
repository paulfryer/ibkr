using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountSummaryResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("accountType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountType { get; set; } = null;


	[JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Status { get; set; } = null;


	[JsonProperty("balance", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Balance { get; set; } = 0;


	[JsonProperty("SMA", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int SMA { get; set; } = 0;


	[JsonProperty("buyingPower", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int BuyingPower { get; set; } = 0;


	[JsonProperty("availableFunds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int AvailableFunds { get; set; } = 0;


	[JsonProperty("excessLiquidity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int ExcessLiquidity { get; set; } = 0;


	[JsonProperty("netLiquidationValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int NetLiquidationValue { get; set; } = 0;


	[JsonProperty("equityWithLoanValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int EquityWithLoanValue { get; set; } = 0;


	[JsonProperty("regTLoan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int RegTLoan { get; set; } = 0;


	[JsonProperty("securitiesGVP", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int SecuritiesGVP { get; set; } = 0;


	[JsonProperty("totalCashValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int TotalCashValue { get; set; } = 0;


	[JsonProperty("accruedInterest", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int AccruedInterest { get; set; } = 0;


	[JsonProperty("regTMargin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int RegTMargin { get; set; } = 0;


	[JsonProperty("initialMargin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int InitialMargin { get; set; } = 0;


	[JsonProperty("maintenanceMargin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int MaintenanceMargin { get; set; } = 0;


	[JsonProperty("cashBalances", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<CashBalances> CashBalances { get; set; } = null;


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
