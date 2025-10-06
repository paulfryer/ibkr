using IBKR.Api.Client.Mock.Data;
using IBKR.Api.Client.Models.Instruments;
using IBKR.Api.Client.Services;

namespace IBKR.Api.Client.Mock.Services;

/// <summary>
/// Fluent builder for creating configured MockInstrumentApiService instances.
/// Provides convenient methods for setting up test data.
/// </summary>
public class MockInstrumentApiServiceBuilder
{
    private readonly MockInstrumentApiService _service;

    public MockInstrumentApiServiceBuilder()
    {
        _service = new MockInstrumentApiService();
    }

    /// <summary>
    /// Adds stock search data.
    /// </summary>
    public MockInstrumentApiServiceBuilder WithStockSearch(
        string symbols,
        Dictionary<string, List<StockResult>> results)
    {
        _service.AddStockData(symbols, results);
        return this;
    }

    /// <summary>
    /// Adds futures search data.
    /// </summary>
    public MockInstrumentApiServiceBuilder WithFuturesSearch(
        string symbols,
        Dictionary<string, List<SecurityInfo>> results)
    {
        _service.AddFuturesData(symbols, results);
        return this;
    }

    /// <summary>
    /// Adds security definitions.
    /// </summary>
    public MockInstrumentApiServiceBuilder WithSecurityDefinitions(
        string symbol,
        List<SecurityDefinition> definitions)
    {
        _service.AddSecurityDefinitions(symbol, definitions);
        return this;
    }

    /// <summary>
    /// Adds security info for a contract ID.
    /// </summary>
    public MockInstrumentApiServiceBuilder WithSecurityInfo(
        int conid,
        List<SecurityInfo> info)
    {
        _service.AddSecurityInfo(conid, info);
        return this;
    }

    /// <summary>
    /// Adds strike data.
    /// </summary>
    public MockInstrumentApiServiceBuilder WithStrikes(
        int conid,
        StrikeData strikes,
        string exchange = "SMART",
        string secType = "OPT",
        string month = "")
    {
        _service.AddStrikes(conid, exchange, secType, month, strikes);
        return this;
    }

    /// <summary>
    /// Adds option chain data.
    /// </summary>
    public MockInstrumentApiServiceBuilder WithOptionChain(
        int conid,
        OptionChain chain)
    {
        _service.AddOptionChain(conid, chain);
        return this;
    }

    /// <summary>
    /// Adds option contracts.
    /// </summary>
    public MockInstrumentApiServiceBuilder WithOptionContracts(
        int conid,
        string expiration,
        decimal strike,
        string right,
        List<OptionContract> contracts)
    {
        _service.AddOptionContracts(conid, expiration, strike, right, contracts);
        return this;
    }

    /// <summary>
    /// Creates a default instance pre-loaded with MSFT test data.
    /// </summary>
    public static MockInstrumentApiServiceBuilder CreateDefault()
    {
        var expiration7Days = DateTime.Today.AddDays(7).ToString("yyyyMMdd");

        return new MockInstrumentApiServiceBuilder()
            .WithStockSearch(MsftTestData.MsftSymbol, MsftTestData.GetStockSearchResult())
            .WithSecurityInfo(MsftTestData.MsftConid, MsftTestData.GetSecurityInfo())
            .WithOptionChain(MsftTestData.MsftConid, MsftTestData.GetOptionChain())
            .WithStrikes(MsftTestData.MsftConid, MsftTestData.GetStrikeData())
            .WithOptionContracts(
                MsftTestData.MsftConid,
                expiration7Days,
                420m,
                "C",
                MsftTestData.GetOptionContracts(expiration7Days, 420m, "C"));
    }

    /// <summary>
    /// Builds and returns the configured service.
    /// </summary>
    public IInstrumentApiService Build()
    {
        return _service;
    }
}
