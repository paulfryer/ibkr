using FluentAssertions;
using IBKR.Api.Client.Mock.Data;
using IBKR.Api.Client.Services;
using IBKR.Api.Client.Tests.Infrastructure;

namespace IBKR.Api.Client.Tests.Services;

/// <summary>
/// Unit tests specifically for option chain functionality.
/// Uses dependency injection - NO knowledge of implementation.
/// </summary>
public class OptionChainTests : IClassFixture<InstrumentServiceFixture>
{
    private readonly IInstrumentApiService _service;

    public OptionChainTests(InstrumentServiceFixture fixture)
    {
        _service = fixture.Service;
    }

    [Fact]
    public async Task GetOptionChainAsync_ReturnsValidChain()
    {
        // Act
        var chain = await _service.GetOptionChainAsync(MsftTestData.MsftConid);

        // Assert
        chain.Should().NotBeNull();
        chain.Conid.Should().Be(MsftTestData.MsftConid);
        chain.Symbol.Should().Be(MsftTestData.MsftSymbol);
        chain.Expirations.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task GetOptionChainAsync_IncludesMultipleExpirations()
    {
        // Act
        var chain = await _service.GetOptionChainAsync(MsftTestData.MsftConid);

        // Assert
        chain.Expirations.Should().HaveCountGreaterThanOrEqualTo(4,
            "should have multiple expiration dates");
    }

    [Fact]
    public async Task GetOptionChainAsync_FiltersNext30Days()
    {
        // Act
        var chain = await _service.GetOptionChainAsync(MsftTestData.MsftConid);

        // Filter for next 30 days (application logic, not API)
        var next30DaysExpirations = chain.Expirations!
            .Where(e => e.DaysToExpiration <= 30)
            .ToList();

        // Assert
        next30DaysExpirations.Should().NotBeEmpty();
        next30DaysExpirations.Should().HaveCount(4,
            "test data has 4 expirations within 30 days");
        next30DaysExpirations.Should().OnlyContain(e => e.DaysToExpiration <= 30);
    }

    [Fact]
    public async Task GetOptionChainAsync_ExcludesExpirationsAfter30Days()
    {
        // Act
        var chain = await _service.GetOptionChainAsync(MsftTestData.MsftConid);

        // Filter for next 30 days
        var next30DaysExpirations = chain.Expirations!
            .Where(e => e.DaysToExpiration <= 30)
            .ToList();

        // Assert that expirations beyond 30 days are excluded
        var excluded = chain.Expirations!
            .Except(next30DaysExpirations)
            .ToList();

        excluded.Should().HaveCount(1, "test data has 1 expiration beyond 30 days");
        excluded[0].DaysToExpiration.Should().BeGreaterThan(30);
    }

    [Fact]
    public async Task GetOptionChainAsync_EachExpirationHasStrikes()
    {
        // Act
        var chain = await _service.GetOptionChainAsync(MsftTestData.MsftConid);

        // Assert
        chain.Expirations!.Should().OnlyContain(e => e.Strikes != null && e.Strikes.Any(),
            "each expiration should have available strikes");

        foreach (var expiration in chain.Expirations!)
        {
            expiration.Strikes.Should().HaveCountGreaterThan(10,
                $"expiration {expiration.Expiration} should have multiple strikes");
        }
    }

    [Fact]
    public async Task GetOptionChainAsync_ExpirationDatesAreFormatted()
    {
        // Act
        var chain = await _service.GetOptionChainAsync(MsftTestData.MsftConid);

        // Assert
        chain.Expirations!.Should().OnlyContain(e =>
            !string.IsNullOrEmpty(e.Expiration) && e.Expiration!.Length == 8,
            "expiration dates should be in YYYYMMDD format");

        // Verify dates are parseable
        foreach (var expiration in chain.Expirations!)
        {
            DateTime.TryParseExact(
                expiration.Expiration,
                "yyyyMMdd",
                null,
                System.Globalization.DateTimeStyles.None,
                out _).Should().BeTrue(
                    $"expiration {expiration.Expiration} should be a valid date");
        }
    }

    [Fact]
    public async Task GetOptionContractsAsync_ReturnsSpecificContracts()
    {
        // Arrange
        var expiration = DateTime.Today.AddDays(7).ToString("yyyyMMdd");
        var strike = 420m;
        var right = "C";

        // Act
        var contracts = await _service.GetOptionContractsAsync(
            MsftTestData.MsftConid,
            expiration,
            strike,
            right);

        // Assert
        contracts.Should().NotBeNullOrEmpty();
        contracts[0].Symbol.Should().Be(MsftTestData.MsftSymbol);
        contracts[0].Strike.Should().Be(strike);
        contracts[0].Right.Should().Be(right);
        contracts[0].Expiration.Should().Be(expiration);
    }

    [Fact]
    public async Task GetOptionContractsAsync_ContractHasMultiplier()
    {
        // Arrange
        var expiration = DateTime.Today.AddDays(7).ToString("yyyyMMdd");
        var strike = 420m;
        var right = "C";

        // Act
        var contracts = await _service.GetOptionContractsAsync(
            MsftTestData.MsftConid,
            expiration,
            strike,
            right);

        // Assert
        contracts[0].Multiplier.Should().Be("100",
            "standard equity options have 100 share multiplier");
    }
}
