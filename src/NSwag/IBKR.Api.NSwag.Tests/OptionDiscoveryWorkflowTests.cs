using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.Contract.Models;
using Xunit;
using Xunit.Abstractions;

namespace IBKR.Api.NSwag.Tests;

/// <summary>
/// Workflow tests for discovering option contracts within a configurable date range.
/// Tests the complete flow: Search stock → Get contract info → Find option expirations → Get strikes → Get contract details
/// </summary>
[Collection("IBKR API Sequential")]
public class OptionDiscoveryWorkflowTests : IClassFixture<TestFixture>
{
    private readonly IIserverService _iserverService;
    private readonly ITestOutputHelper _output;

    public OptionDiscoveryWorkflowTests(TestFixture fixture, ITestOutputHelper output)
    {
        _iserverService = fixture.GetService<IIserverService>();
        _output = output;
    }

    [Theory]
    [InlineData("AMZN", 30)]
    [InlineData("AAPL", 45)]
    [InlineData("TSLA", 60)]
    public async System.Threading.Tasks.Task DiscoverOptionsWithinDays_CompleteWorkflow_ReturnsValidContracts(
        string symbol,
        int daysAhead)
    {
        _output.WriteLine($"\n=== Option Discovery Workflow for {symbol} within {daysAhead} days ===\n");

        // Step 1: Search for stock symbol
        _output.WriteLine($"Step 1: Searching for symbol '{symbol}'...");
        var searchResults = await _iserverService.SearchAllGETAsync(
            symbol: symbol,
            secType: SecType.STK
        );

        Assert.NotNull(searchResults);
        Assert.NotEmpty(searchResults);

        var stock = searchResults.First();
        var conid = stock.Conid?.ToString();

        Assert.NotNull(conid);
        _output.WriteLine($"  ✓ Found: {stock.CompanyName} (conid: {conid})");

        // Step 2: Get contract information
        _output.WriteLine($"\nStep 2: Getting contract details for conid {conid}...");
        var contractInfo = await _iserverService.InfoAsync(conid);

        Assert.NotNull(contractInfo);
        _output.WriteLine($"  ✓ Validated: {symbol} contract exists");

        // Step 3: Discover option expirations within date range
        _output.WriteLine($"\nStep 3: Discovering option expirations within {daysAhead} days...");
        var months = OptionDiscoveryHelper.GetMonthsInRange(daysAhead);
        _output.WriteLine($"  Checking months: {string.Join(", ", months)}");

        var allOptionContracts = new List<OptionContractSummary>();

        foreach (var month in months)
        {
            try
            {
                // Step 4: Get strikes for this month
                var strikes = await _iserverService.StrikesAsync(
                    conid: conid,
                    sectype: "OPT",
                    month: month
                );

                if (strikes?.Call?.Any() == true || strikes?.Put?.Any() == true)
                {
                    var callCount = strikes.Call?.Count ?? 0;
                    var putCount = strikes.Put?.Count ?? 0;
                    _output.WriteLine($"  ✓ Month {month}: {callCount} calls, {putCount} puts");

                    // For this test, we'll sample a few strikes instead of all
                    // In production, you'd process all strikes or filter by specific criteria
                    var sampleStrikes = strikes.Call?.Take(2).ToList() ?? new List<double>();

                    foreach (var strike in sampleStrikes)
                    {
                        // Step 5: Get full contract details
                        // Note: API returns an array but SDK expects single object,
                        // so we need to handle ApiException and manually deserialize
                        ICollection<SecDefInfoResponse>? callInfoArray = null;

                        try
                        {
                            var callInfo = await _iserverService.Info2Async(
                                conid: conid,
                                sectype: "OPT",
                                month: month,
                                strike: strike,
                                right: Right.C
                            );
                            // If this succeeds (shouldn't), wrap in array
                            callInfoArray = new List<SecDefInfoResponse> { callInfo };
                        }
                        catch (ApiException ex) when (ex.StatusCode == 200)
                        {
                            // API returned 200 OK but couldn't deserialize as single object
                            // Extract the raw response body and deserialize as array
                            var responseBody = ex.Response;
                            if (!string.IsNullOrEmpty(responseBody))
                            {
                                callInfoArray = Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<SecDefInfoResponse>>(responseBody);
                            }
                        }

                        if (callInfoArray != null)
                        {
                            foreach (var callInfo in callInfoArray)
                            {
                                if (callInfo != null && !string.IsNullOrEmpty(callInfo.MaturityDate))
                                {
                                    // Check if expiration is within our date range
                                    if (OptionDiscoveryHelper.IsExpirationWithinRange(callInfo.MaturityDate, daysAhead))
                                    {
                                        var daysUntilExp = OptionDiscoveryHelper.GetDaysUntilExpiration(callInfo.MaturityDate);

                                        allOptionContracts.Add(new OptionContractSummary
                                        {
                                            Symbol = symbol,
                                            UnderlyingConid = conid,
                                            OptionConid = callInfo.Conid.ToString(),
                                            ExpirationDate = callInfo.MaturityDate,
                                            Strike = strike,
                                            Right = "C",
                                            DaysUntilExpiration = daysUntilExp
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _output.WriteLine($"  ⚠ Month {month}: {ex.Message}");
            }
        }

        // Step 6: Verify results
        _output.WriteLine($"\n=== Summary ===");
        _output.WriteLine($"Total option contracts found: {allOptionContracts.Count}");

        Assert.NotEmpty(allOptionContracts);

        // Group by expiration date
        var byExpiration = allOptionContracts.GroupBy(o => o.ExpirationDate).OrderBy(g => g.Key);

        foreach (var group in byExpiration)
        {
            var expirationDate = OptionDiscoveryHelper.ParseExpirationDate(group.Key);
            var daysOut = OptionDiscoveryHelper.GetDaysUntilExpiration(group.Key);
            _output.WriteLine($"  {expirationDate:yyyy-MM-dd} ({daysOut} days): {group.Count()} contracts");
        }

        // Verify all contracts are within the specified date range
        Assert.All(allOptionContracts, contract =>
        {
            var daysOut = contract.DaysUntilExpiration;
            Assert.True(daysOut >= 0, $"Contract expires in the past: {contract.ExpirationDate}");
            Assert.True(daysOut <= daysAhead, $"Contract expires beyond {daysAhead} days: {contract.ExpirationDate}");
        });
    }

    [Fact]
    public async System.Threading.Tasks.Task GetTypicalMonthlyExpirations_WithinRange_ReturnsValidDates()
    {
        // Test the helper method for generating typical 3rd Friday expirations
        var daysAhead = 60;
        var expirations = OptionDiscoveryHelper.GetTypicalMonthlyExpirations(daysAhead);

        _output.WriteLine($"Typical monthly expirations within {daysAhead} days:");
        foreach (var exp in expirations)
        {
            var date = OptionDiscoveryHelper.ParseExpirationDate(exp);
            var daysOut = OptionDiscoveryHelper.GetDaysUntilExpiration(exp);
            var dayOfWeek = date.DayOfWeek;

            _output.WriteLine($"  {date:yyyy-MM-dd} ({dayOfWeek}) - {daysOut} days");

            // Verify it's a Friday
            Assert.Equal(DayOfWeek.Friday, dayOfWeek);

            // Verify it's within range
            Assert.True(daysOut <= daysAhead);
            Assert.True(daysOut >= 0);
        }

        Assert.NotEmpty(expirations);
    }

    [Fact]
    public async System.Threading.Tasks.Task SearchMultipleSymbols_FindContracts_AllSucceed()
    {
        var symbols = new[] { "AAPL", "AMZN", "MSFT" };

        _output.WriteLine("Testing multiple symbol lookups...\n");

        foreach (var symbol in symbols)
        {
            var results = await _iserverService.SearchAllGETAsync(
                symbol: symbol,
                secType: SecType.STK
            );

            Assert.NotNull(results);
            Assert.NotEmpty(results);

            var stock = results.First();
            _output.WriteLine($"  {symbol}: conid={stock.Conid}, company={stock.CompanyName}");

            Assert.Equal(symbol, stock.Symbol);
            Assert.NotNull(stock.Conid);
        }
    }
}

/// <summary>
/// Summary information for an option contract discovered in the workflow
/// </summary>
public class OptionContractSummary
{
    public string Symbol { get; set; } = string.Empty;
    public string UnderlyingConid { get; set; } = string.Empty;
    public string? OptionConid { get; set; }
    public string ExpirationDate { get; set; } = string.Empty;
    public double Strike { get; set; }
    public string Right { get; set; } = string.Empty; // "C" or "P"
    public int DaysUntilExpiration { get; set; }
}
