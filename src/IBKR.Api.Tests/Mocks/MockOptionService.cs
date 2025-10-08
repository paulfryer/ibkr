using IBKR.Api.Contract.Enums;
using IBKR.Api.Contract.Interfaces;
using IBKR.Api.Contract.Models;

namespace IBKR.Api.Tests.Mocks;

/// <summary>
/// Mock implementation of IOptionService for testing without real API calls.
/// Returns predictable, deterministic test data.
/// </summary>
public class MockOptionService : IOptionService
{
    public Task<OptionChain> GetOptionChainAsync(
        string symbol,
        DateTime expirationStart,
        DateTime expirationEnd,
        CancellationToken cancellationToken = default)
    {
        // Generate mock option chain data
        var contracts = new List<OptionContract>();
        var underlyingConid = symbol switch
        {
            "AAPL" => 265598,
            "TSLA" => 76792991,
            "AMZN" => 3691937,
            _ => 999999
        };

        // Generate strikes around current "price"
        var mockPrice = symbol switch
        {
            "AAPL" => 175.0m,
            "TSLA" => 250.0m,
            "AMZN" => 145.0m,
            _ => 100.0m
        };

        var strikes = new[] { 0.9m, 0.95m, 1.0m, 1.05m, 1.1m }
            .Select(multiplier => Math.Round(mockPrice * multiplier, 2))
            .ToList();

        // Generate expirations (weekly on Fridays)
        var expirations = new List<DateTime>();
        var current = expirationStart.Date;
        while (current <= expirationEnd)
        {
            // Find next Friday
            while (current.DayOfWeek != DayOfWeek.Friday)
            {
                current = current.AddDays(1);
            }

            if (current <= expirationEnd)
            {
                expirations.Add(current);
            }

            current = current.AddDays(7); // Next week
        }

        // Generate contracts for each expiration and strike
        int contractIdCounter = 600000000;
        foreach (var expiration in expirations)
        {
            foreach (var strike in strikes)
            {
                // Call
                contracts.Add(new OptionContract
                {
                    ContractId = contractIdCounter++,
                    UnderlyingContractId = underlyingConid,
                    Symbol = symbol,
                    Right = OptionRight.Call,
                    Strike = strike,
                    Expiration = expiration,
                    TradingClass = symbol,
                    Exchange = "SMART",
                    Currency = "USD",
                    Multiplier = 100,
                    ValidExchanges = new[] { "SMART", "CBOE", "AMEX", "ISE" },
                    DaysUntilExpiration = (int)(expiration - DateTime.UtcNow.Date).TotalDays
                });

                // Put
                contracts.Add(new OptionContract
                {
                    ContractId = contractIdCounter++,
                    UnderlyingContractId = underlyingConid,
                    Symbol = symbol,
                    Right = OptionRight.Put,
                    Strike = strike,
                    Expiration = expiration,
                    TradingClass = symbol,
                    Exchange = "SMART",
                    Currency = "USD",
                    Multiplier = 100,
                    ValidExchanges = new[] { "SMART", "CBOE", "AMEX", "ISE" },
                    DaysUntilExpiration = (int)(expiration - DateTime.UtcNow.Date).TotalDays
                });
            }
        }

        return Task.FromResult(new OptionChain
        {
            Symbol = symbol,
            UnderlyingContractId = underlyingConid,
            Contracts = contracts,
            RequestedExpirationStart = expirationStart,
            RequestedExpirationEnd = expirationEnd,
            RetrievedAt = DateTime.UtcNow
        });
    }
}
