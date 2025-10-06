using IBKR.Api.Client.Models.Instruments;

namespace IBKR.Api.Client.Mock.Data;

/// <summary>
/// Test data for Microsoft (MSFT) stock and options.
/// Provides realistic data for testing and development.
/// </summary>
public static class MsftTestData
{
    /// <summary>
    /// MSFT contract ID (realistic value).
    /// </summary>
    public const int MsftConid = 272093;

    /// <summary>
    /// MSFT symbol.
    /// </summary>
    public const string MsftSymbol = "MSFT";

    /// <summary>
    /// Primary exchange for MSFT.
    /// </summary>
    public const string MsftExchange = "NASDAQ";

    /// <summary>
    /// Gets a stock search result for MSFT.
    /// </summary>
    public static Dictionary<string, List<StockResult>> GetStockSearchResult()
    {
        return new Dictionary<string, List<StockResult>>
        {
            {
                MsftSymbol, new List<StockResult>
                {
                    new()
                    {
                        Name = "MICROSOFT CORP",
                        AssetClass = "STK",
                        Contracts = new List<StockContract>
                        {
                            new() { Conid = MsftConid, Exchange = "NASDAQ", IsUS = true },
                            new() { Conid = MsftConid, Exchange = "SMART", IsUS = true },
                            new() { Conid = MsftConid, Exchange = "ISLAND", IsUS = true }
                        }
                    }
                }
            }
        };
    }

    /// <summary>
    /// Gets security info for MSFT stock.
    /// </summary>
    public static List<SecurityInfo> GetSecurityInfo()
    {
        return new List<SecurityInfo>
        {
            new()
            {
                Conid = MsftConid,
                Symbol = MsftSymbol,
                SecType = "STK",
                Exchange = "NASDAQ",
                ListingExchange = "NASDAQ",
                Currency = "USD",
                Desc1 = "MICROSOFT CORP",
                Desc2 = "Common Stock",
                ValidExchanges = "SMART,NASDAQ,ISLAND,DRCTEDGE,BEX,BATS,IEX,EDGEA,BYX,PSX"
            }
        };
    }

    /// <summary>
    /// Gets an option chain for MSFT with expirations over the next 30 days.
    /// Assumes current date context for realistic testing.
    /// </summary>
    public static OptionChain GetOptionChain()
    {
        var today = DateTime.Today;

        return new OptionChain
        {
            Conid = MsftConid,
            Symbol = MsftSymbol,
            Exchange = "SMART",
            Expirations = new List<OptionExpiration>
            {
                // Weekly expiration (7 days out)
                new()
                {
                    Expiration = today.AddDays(7).ToString("yyyyMMdd"),
                    DaysToExpiration = 7,
                    Strikes = GetRealisticStrikes()
                },
                // Bi-weekly expiration (14 days out)
                new()
                {
                    Expiration = today.AddDays(14).ToString("yyyyMMdd"),
                    DaysToExpiration = 14,
                    Strikes = GetRealisticStrikes()
                },
                // Monthly expiration (21 days out)
                new()
                {
                    Expiration = today.AddDays(21).ToString("yyyyMMdd"),
                    DaysToExpiration = 21,
                    Strikes = GetRealisticStrikes()
                },
                // Monthly expiration (28 days out)
                new()
                {
                    Expiration = today.AddDays(28).ToString("yyyyMMdd"),
                    DaysToExpiration = 28,
                    Strikes = GetRealisticStrikes()
                },
                // Just outside 30 days (35 days - for filtering tests)
                new()
                {
                    Expiration = today.AddDays(35).ToString("yyyyMMdd"),
                    DaysToExpiration = 35,
                    Strikes = GetRealisticStrikes()
                }
            }
        };
    }

    /// <summary>
    /// Gets realistic strike prices for MSFT options (centered around $400-$450 range).
    /// </summary>
    private static List<decimal> GetRealisticStrikes()
    {
        return new List<decimal>
        {
            380m, 385m, 390m, 395m, 400m, 405m, 410m, 415m, 420m, 425m,
            430m, 435m, 440m, 445m, 450m, 455m, 460m, 465m, 470m
        };
    }

    /// <summary>
    /// Gets strike data for a specific expiration.
    /// </summary>
    public static StrikeData GetStrikeData()
    {
        var strikes = GetRealisticStrikes();
        return new StrikeData
        {
            Call = strikes,
            Put = strikes
        };
    }

    /// <summary>
    /// Gets specific option contracts for testing.
    /// </summary>
    /// <param name="expiration">Expiration date in YYYYMMDD format.</param>
    /// <param name="strike">Strike price.</param>
    /// <param name="right">Option right (C or P).</param>
    public static List<OptionContract> GetOptionContracts(string expiration, decimal strike, string right)
    {
        return new List<OptionContract>
        {
            new()
            {
                Conid = MsftConid + 1000 + (int)strike, // Mock contract ID
                Symbol = MsftSymbol,
                Strike = strike,
                Right = right,
                Expiration = expiration,
                Exchange = "SMART",
                Multiplier = "100"
            }
        };
    }

    /// <summary>
    /// Gets sample option contracts for the 7-day expiration at 420 strike.
    /// </summary>
    public static List<OptionContract> GetSampleOptionContracts()
    {
        var expiration = DateTime.Today.AddDays(7).ToString("yyyyMMdd");
        var contracts = new List<OptionContract>();

        // Call option
        contracts.AddRange(GetOptionContracts(expiration, 420m, "C"));

        // Put option
        contracts.AddRange(GetOptionContracts(expiration, 420m, "P"));

        return contracts;
    }
}
