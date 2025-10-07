using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.Client.Services;
using IBKR.Api.NSwag.MockClient.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBKR.Api.NSwag.Tests;

/// <summary>
/// Test fixture for dependency injection setup.
/// Configures services based on appsettings.json to use either Mock or Real implementations.
/// </summary>
public class TestFixture : IDisposable
{
    public IServiceProvider ServiceProvider { get; }
    public IConfiguration Configuration { get; }

    public TestFixture()
    {
        // Load configuration
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.test.json", optional: true)
            .AddJsonFile("appsettings.development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        // Setup DI container
        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Add configuration
        services.AddSingleton(Configuration);

        // Determine which implementation to use
        var useMockClient = Configuration.GetValue<bool>("Testing:UseMockClient", defaultValue: true);

        if (useMockClient)
        {
            Console.WriteLine("[Test Setup] Using MOCK client implementations");

            // Register mock service implementations
            services.AddTransient<IFyiService, MockFyiService>();
            // TODO: Add more mock services as needed:
            // services.AddTransient<IGwService, MockGwService>();
            // services.AddTransient<IPortfolioService, MockPortfolioService>();
        }
        else
        {
            Console.WriteLine("[Test Setup] Using REAL client implementations");

            // Register real service implementations
            // Configure HttpClient for real services
            services.AddHttpClient();

            services.AddTransient<IFyiService, FyiService>();
            // TODO: Add more real services as needed:
            // services.AddTransient<IGwService, GwService>();
            // services.AddTransient<IPortfolioService, PortfolioService>();
        }
    }

    public T GetService<T>() where T : notnull
    {
        return ServiceProvider.GetRequiredService<T>();
    }

    public void Dispose()
    {
        if (ServiceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
