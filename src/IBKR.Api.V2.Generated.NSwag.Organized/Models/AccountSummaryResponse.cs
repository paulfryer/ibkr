using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountSummaryResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("accountType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountType { get; set; }

    [JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Status { get; set; }

    [JsonProperty("balance", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Balance { get; set; }

    [JsonProperty("SMA", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int SMA { get; set; }

    [JsonProperty("buyingPower", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int BuyingPower { get; set; }

    [JsonProperty("availableFunds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int AvailableFunds { get; set; }

    [JsonProperty("excessLiquidity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int ExcessLiquidity { get; set; }

    [JsonProperty("netLiquidationValue", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public int NetLiquidationValue { get; set; }

    [JsonProperty("equityWithLoanValue", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public int EquityWithLoanValue { get; set; }

    [JsonProperty("regTLoan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int RegTLoan { get; set; }

    [JsonProperty("securitiesGVP", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int SecuritiesGVP { get; set; }

    [JsonProperty("totalCashValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int TotalCashValue { get; set; }

    [JsonProperty("accruedInterest", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int AccruedInterest { get; set; }

    [JsonProperty("regTMargin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int RegTMargin { get; set; }

    [JsonProperty("initialMargin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int InitialMargin { get; set; }

    [JsonProperty("maintenanceMargin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int MaintenanceMargin { get; set; }

    [JsonProperty("cashBalances", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<CashBalances> CashBalances { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}