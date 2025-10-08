using IBKR.Sdk.Authentication;
using IBKR.Sdk.Client.Services;
using IBKR.Sdk.Contract.Interfaces;
using IBKR.Api.NSwag.Authentication;
using IBKR.Api.NSwag.Client.Services;
using IBKR.Api.NSwag.Contract.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBKR.Sdk.Tests;

/// <summary>
/// Test fixture for the IBKR SDK.
/// Configures IOptionService and other IBKR SDK interfaces.
/// NO direct references to NSwag/Kiota in test code - only in this fixture.
/// </summary>
public class CleanApiTestFixture : IDisposable
{
    public IServiceProvider ServiceProvider { get; }
    public IConfiguration Configuration { get; }

    public CleanApiTestFixture()
    {
        // Load configuration
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
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
        services.AddSingleton(Configuration);

        // Strategy: Use real API if credentials are available (local dev), otherwise use mock (CI/CD)
        // Check if credentials are provided via environment variables or config
        var hasCredentials = !string.IsNullOrEmpty(Configuration["IBKR:ClientId"]) &&
                            !string.IsNullOrEmpty(Configuration["IBKR:Credential"]) &&
                            !string.IsNullOrEmpty(Configuration["IBKR:ClientKeyId"]) &&
                            !string.IsNullOrEmpty(Configuration["IBKR:ClientPemPath"]);

        // Allow override via config (for CI/CD to force mock even if creds exist)
        var forceMock = Configuration.GetValue<bool>("Testing:UseMockClient", defaultValue: false);

        var useMock = forceMock || !hasCredentials;

        if (useMock)
        {
            Console.WriteLine("[IBKR SDK Tests] Using MOCK implementation");
            Console.WriteLine($"  Reason: {(forceMock ? "Testing:UseMockClient=true" : "No credentials found")}");

            // Register mock implementations of IBKR SDK interfaces
            services.AddTransient<IOptionService, Mocks.MockOptionService>();
        }
        else
        {
            Console.WriteLine("[IBKR SDK Tests] Using REAL IBKR API");
            Console.WriteLine($"  ClientId: {Configuration["IBKR:ClientId"]}");
            Console.WriteLine($"  BaseUrl: {Configuration["IBKR:BaseUrl"] ?? "https://api.ibkr.com"}");

            // Load authentication options from environment variables
            var authOptions = new IBKRAuthenticationOptions
            {
                ClientId = Configuration["IBKR:ClientId"]!,
                Credential = Configuration["IBKR:Credential"]!,
                ClientKeyId = Configuration["IBKR:ClientKeyId"]!,
                ClientPemPath = Configuration["IBKR:ClientPemPath"]!,
                BaseUrl = Configuration["IBKR:BaseUrl"] ?? "https://api.ibkr.com"
            };

            authOptions.Validate();

            // Register real NSwag service (implementation detail - hidden from tests)
            services.AddIBKRAuthenticatedClient<IIserverService, IserverService>(authOptions);

            // Register IBKR SDK service that wraps NSwag
            services.AddTransient<IOptionService>(sp =>
            {
                var nswagIserver = sp.GetRequiredService<IIserverService>();
                return new OptionService(nswagIserver);
            });
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
