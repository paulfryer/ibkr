using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Currency
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("total_cash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Total_cash { get; set; }

    [JsonProperty("settled_cash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Settled_cash { get; set; }

    [JsonProperty("MTD Interest", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MTD_Interest { get; set; }

    [JsonProperty("stock", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Stock { get; set; }

    [JsonProperty("options", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Options { get; set; }

    [JsonProperty("futures", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Futures { get; set; }

    [JsonProperty("future_options", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Future_options { get; set; }

    [JsonProperty("funds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Funds { get; set; }

    [JsonProperty("dividends_receivable", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Dividends_receivable { get; set; }

    [JsonProperty("mutual_funds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Mutual_funds { get; set; }

    [JsonProperty("money_market", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Money_market { get; set; }

    [JsonProperty("bonds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Bonds { get; set; }

    [JsonProperty("Govt Bonds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Govt_Bonds { get; set; }

    [JsonProperty("t_bills", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string T_bills { get; set; }

    [JsonProperty("warrants", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Warrants { get; set; }

    [JsonProperty("issuer_option", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Issuer_option { get; set; }

    [JsonProperty("commodity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Commodity { get; set; }

    [JsonProperty("Notional CFD", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Notional_CFD { get; set; }

    [JsonProperty("cfd", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Cfd { get; set; }

    [JsonProperty("net_liquidation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Net_liquidation { get; set; }

    [JsonProperty("unrealized_pnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Unrealized_pnl { get; set; }

    [JsonProperty("realized_pnl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Realized_pnl { get; set; }

    [JsonProperty("Exchange Rate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Exchange_Rate { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}