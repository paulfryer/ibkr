using FluentAssertions;
using IBKR.Api.Client.Mock.Data;
using IBKR.Api.Client.Services;
using IBKR.Api.Client.Tests.Infrastructure;

namespace IBKR.Api.Client.Tests.Services;

/// <summary>
/// Unit tests for IInstrumentApiService.
/// Tests the service interface contract without HTTP dependencies.
/// Uses dependency injection - NO knowledge of implementation.
/// </summary>
public class InstrumentApiServiceTests : IClassFixture<InstrumentServiceFixture>
{
    private readonly IInstrumentApiService _service;

    public InstrumentApiServiceTests(InstrumentServiceFixture fixture)
    {
        _service = fixture.Service;
    }

    [Fact]
    public async Task SearchStocksAsync_WithValidSymbol_ReturnsStockResults()
    {
        // Act
        var results = await _service.SearchStocksAsync(MsftTestData.MsftSymbol);

        // Assert
        results.Should().NotBeNull();
        results.Should().ContainKey(MsftTestData.MsftSymbol);
        results[MsftTestData.MsftSymbol].Should().NotBeEmpty();
        results[MsftTestData.MsftSymbol][0].Name.Should().Be("MICROSOFT CORP");
        results[MsftTestData.MsftSymbol][0].AssetClass.Should().Be("STK");
    }

    [Fact]
    public async Task SearchStocksAsync_ValidatesContractId()
    {
        // Act
        var results = await _service.SearchStocksAsync(MsftTestData.MsftSymbol);

        // Assert
        var firstContract = results[MsftTestData.MsftSymbol][0].Contracts![0];
        firstContract.Conid.Should().Be(MsftTestData.MsftConid);
        firstContract.Exchange.Should().Be(MsftTestData.MsftExchange);
        firstContract.IsUS.Should().BeTrue();
    }

    [Fact]
    public async Task SearchStocksAsync_ReturnsMultipleExchanges()
    {
        // Act
        var results = await _service.SearchStocksAsync(MsftTestData.MsftSymbol);

        // Assert
        var contracts = results[MsftTestData.MsftSymbol][0].Contracts;
        contracts.Should().NotBeNull();
        contracts.Should().HaveCountGreaterThanOrEqualTo(2, "MSFT should be available on multiple exchanges");
        contracts.Should().Contain(c => c.Exchange == "NASDAQ");
        contracts.Should().Contain(c => c.Exchange == "SMART");
    }

    [Fact]
    public async Task GetSecurityInfoAsync_WithValidConid_ReturnsSecurityDetails()
    {
        // Act
        var info = await _service.GetSecurityInfoAsync(MsftTestData.MsftConid);

        // Assert
        info.Should().NotBeNull();
        info.Should().NotBeEmpty();
        info[0].Conid.Should().Be(MsftTestData.MsftConid);
        info[0].Symbol.Should().Be(MsftTestData.MsftSymbol);
        info[0].SecType.Should().Be("STK");
    }

    [Fact]
    public async Task GetSecurityInfoAsync_IncludesExchangeInformation()
    {
        // Act
        var info = await _service.GetSecurityInfoAsync(MsftTestData.MsftConid);

        // Assert
        info[0].Exchange.Should().Be("NASDAQ");
        info[0].Currency.Should().Be("USD");
        info[0].ValidExchanges.Should().NotBeNullOrEmpty();
        info[0].ValidExchanges.Should().Contain("SMART");
    }

    [Fact]
    public async Task GetStrikesAsync_ReturnsCallAndPutStrikes()
    {
        // Act
        var strikes = await _service.GetStrikesAsync(
            MsftTestData.MsftConid,
            "SMART",
            "OPT",
            "");

        // Assert
        strikes.Should().NotBeNull();
        strikes.Call.Should().NotBeNullOrEmpty();
        strikes.Put.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task GetStrikesAsync_StrikesAreRealistic()
    {
        // Act
        var strikes = await _service.GetStrikesAsync(
            MsftTestData.MsftConid,
            "SMART",
            "OPT",
            "");

        // Assert
        strikes.Call.Should().OnlyContain(s => s >= 300m && s <= 600m,
            "strikes should be in realistic range for MSFT");
        strikes.Put.Should().OnlyContain(s => s >= 300m && s <= 600m,
            "strikes should be in realistic range for MSFT");
    }
}
