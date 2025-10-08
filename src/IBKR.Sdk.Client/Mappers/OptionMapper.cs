using IBKR.Sdk.Contract.Enums;
using IBKR.Sdk.Contract.Models;
using IBKR.Api.NSwag.Contract.Models;
using System.Globalization;

namespace IBKR.Sdk.Client.Mappers;

/// <summary>
/// Maps between generated NSwag models and clean contract models
/// </summary>
public class OptionMapper
{
    public OptionContract ToCleanModel(SecDefInfoResponse generated, int underlyingConid)
    {
        // Workaround: API returns "symbol" but OpenAPI spec says "ticker"
        // The actual value comes in AdditionalProperties since the spec doesn't match reality
        var symbol = GetAdditionalProperty<string>(generated, "symbol")
                    ?? generated.Ticker
                    ?? string.Empty;

        var tradingClass = GetAdditionalProperty<string>(generated, "tradingClass")
                          ?? generated.Ticker
                          ?? symbol;

        return new OptionContract
        {
            ContractId = generated.Conid,
            UnderlyingContractId = underlyingConid,
            Symbol = symbol,
            Strike = (decimal)generated.Strike,
            Expiration = ParseMaturityDate(generated.MaturityDate),
            Right = ParseRight(generated.Right),
            TradingClass = tradingClass,
            Exchange = generated.Exchange ?? string.Empty,
            Currency = generated.Currency ?? string.Empty,
            Multiplier = 100, // Default multiplier for equity options
            ValidExchanges = ParseValidExchanges(generated.ValidExchanges),
            DaysUntilExpiration = CalculateDaysUntilExpiration(generated.MaturityDate)
        };
    }

    private T? GetAdditionalProperty<T>(SecDefInfoResponse response, string key)
    {
        if (response.AdditionalProperties != null &&
            response.AdditionalProperties.TryGetValue(key, out var value))
        {
            if (value is T typedValue)
                return typedValue;

            // Try to convert if not exact type match
            try
            {
                return (T?)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return default;
            }
        }
        return default;
    }

    private DateTime ParseMaturityDate(string? date)
    {
        if (string.IsNullOrEmpty(date) || date.Length != 8)
            return DateTime.MinValue;

        return DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
    }

    private OptionRight ParseRight(SecDefInfoResponseRight right)
    {
        return right == SecDefInfoResponseRight.C ? OptionRight.Call : OptionRight.Put;
    }

    private decimal ParseDecimal(object? value)
    {
        if (value == null) return 0;
        if (value is decimal d) return d;
        if (value is double dbl) return (decimal)dbl;
        if (value is int i) return i;
        if (value is string s && decimal.TryParse(s, out var result)) return result;
        return 0;
    }

    private string[] ParseValidExchanges(string? exchanges)
    {
        if (string.IsNullOrEmpty(exchanges))
            return Array.Empty<string>();

        return exchanges.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }

    private int? CalculateDaysUntilExpiration(string? maturityDate)
    {
        try
        {
            var expDate = ParseMaturityDate(maturityDate);
            if (expDate == DateTime.MinValue) return null;
            return (int)(expDate - DateTime.UtcNow.Date).TotalDays;
        }
        catch
        {
            return null;
        }
    }
}
