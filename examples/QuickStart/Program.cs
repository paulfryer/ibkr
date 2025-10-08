using IBKR.Sdk.Client;
using IBKR.Sdk.Contract.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// Build configuration from appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables() // Environment variables override appsettings.json
    .Build();

// Setup dependency injection
var services = new ServiceCollection();

// ⭐ AWS SDK-like setup - ONE LINE!
services.AddIBKRSdk(configuration.GetSection("IBKR"));

var serviceProvider = services.BuildServiceProvider();

Console.WriteLine("IBKR SDK Quick Start");
Console.WriteLine("====================\n");

try
{
    // Get the option service from DI container
    var optionService = serviceProvider.GetRequiredService<IOptionService>();

    // Get option chain for AAPL expiring in next 30 days
    Console.WriteLine("Fetching option chain for AAPL...\n");

    var chain = await optionService.GetOptionChainAsync(
        symbol: "AAPL",
        expirationStart: DateTime.UtcNow,
        expirationEnd: DateTime.UtcNow.AddDays(30));

    Console.WriteLine($"Symbol: {chain.Symbol}");
    Console.WriteLine($"Underlying Contract ID: {chain.UnderlyingContractId}");
    Console.WriteLine($"Total Contracts Retrieved: {chain.Contracts.Count}");
    Console.WriteLine($"Retrieved At: {chain.RetrievedAt:yyyy-MM-dd HH:mm:ss} UTC\n");

    Console.WriteLine("First 10 Contracts:");
    Console.WriteLine("-------------------");

    foreach (var contract in chain.Contracts.Take(10))
    {
        Console.WriteLine($"{contract.Symbol,-6} {contract.Right,-4} " +
                         $"Strike: {contract.Strike,8:C} " +
                         $"Exp: {contract.Expiration:yyyy-MM-dd} " +
                         $"({contract.DaysUntilExpiration,3} days) " +
                         $"Exchange: {contract.Exchange}");
    }

    Console.WriteLine($"\n... and {chain.Contracts.Count - 10} more contracts");

    // Group by expiration date
    var byExpiration = chain.Contracts
        .GroupBy(c => c.Expiration.Date)
        .OrderBy(g => g.Key);

    Console.WriteLine("\n\nContracts by Expiration:");
    Console.WriteLine("------------------------");

    foreach (var group in byExpiration)
    {
        var calls = group.Count(c => c.Right == IBKR.Sdk.Contract.Enums.OptionRight.Call);
        var puts = group.Count(c => c.Right == IBKR.Sdk.Contract.Enums.OptionRight.Put);
        Console.WriteLine($"{group.Key:yyyy-MM-dd}: {group.Count(),3} contracts ({calls} calls, {puts} puts)");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"\n❌ Error: {ex.Message}");
    Console.WriteLine($"\nStack trace:\n{ex.StackTrace}");

    if (ex.InnerException != null)
    {
        Console.WriteLine($"\nInner exception: {ex.InnerException.Message}");
    }
}
finally
{
    // Cleanup
    if (serviceProvider is IDisposable disposable)
    {
        disposable.Dispose();
    }
}
