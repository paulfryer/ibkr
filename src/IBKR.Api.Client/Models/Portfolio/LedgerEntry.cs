using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Portfolio;

/// <summary>
/// Represents cash balance ledger entry for a specific currency.
/// </summary>
public record LedgerEntry
{
    [JsonPropertyName("commoditymarketvalue")]
    public decimal? CommodityMarketValue { get; init; }

    [JsonPropertyName("futuremarketvalue")]
    public decimal? FutureMarketValue { get; init; }

    [JsonPropertyName("settledcash")]
    public decimal? SettledCash { get; init; }

    [JsonPropertyName("exchangerate")]
    public decimal? ExchangeRate { get; init; }

    [JsonPropertyName("sessionid")]
    public int? SessionId { get; init; }

    [JsonPropertyName("cashbalance")]
    public decimal? CashBalance { get; init; }

    [JsonPropertyName("corporatebondsmarketvalue")]
    public decimal? CorporateBondsMarketValue { get; init; }

    [JsonPropertyName("warrantsmarketvalue")]
    public decimal? WarrantsMarketValue { get; init; }

    [JsonPropertyName("netliquidationvalue")]
    public decimal? NetLiquidationValue { get; init; }

    [JsonPropertyName("interest")]
    public decimal? Interest { get; init; }

    [JsonPropertyName("unrealizedpnl")]
    public decimal? UnrealizedPnl { get; init; }

    [JsonPropertyName("stockmarketvalue")]
    public decimal? StockMarketValue { get; init; }

    [JsonPropertyName("moneyfunds")]
    public decimal? MoneyFunds { get; init; }

    [JsonPropertyName("currency")]
    public string? Currency { get; init; }

    [JsonPropertyName("realizedpnl")]
    public decimal? RealizedPnl { get; init; }

    [JsonPropertyName("funds")]
    public decimal? Funds { get; init; }

    [JsonPropertyName("acctcode")]
    public string? AcctCode { get; init; }

    [JsonPropertyName("issueroptionsmarketvalue")]
    public decimal? IssuerOptionsMarketValue { get; init; }

    [JsonPropertyName("key")]
    public string? Key { get; init; }

    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    [JsonPropertyName("severity")]
    public int? Severity { get; init; }

    [JsonPropertyName("stockoptionmarketvalue")]
    public decimal? StockOptionMarketValue { get; init; }

    [JsonPropertyName("futuresonlypnl")]
    public decimal? FuturesOnlyPnl { get; init; }

    [JsonPropertyName("tbondsmarketvalue")]
    public decimal? TBondsMarketValue { get; init; }

    [JsonPropertyName("futureoptionmarketvalue")]
    public decimal? FutureOptionMarketValue { get; init; }

    [JsonPropertyName("cashbalancefxsegment")]
    public decimal? CashBalanceFxSegment { get; init; }

    [JsonPropertyName("secondkey")]
    public string? SecondKey { get; init; }

    [JsonPropertyName("tbillsmarketvalue")]
    public decimal? TBillsMarketValue { get; init; }

    [JsonPropertyName("dividends")]
    public decimal? Dividends { get; init; }
}
