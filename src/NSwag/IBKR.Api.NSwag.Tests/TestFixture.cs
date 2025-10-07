using IBKR.Api.Authentication;
using IBKR.Api.NSwag.Authentication;
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
        var useRealAuthentication = Configuration.GetValue<bool>("Testing:UseRealAuthentication", defaultValue: false);

        // Configure authentication
        if (useRealAuthentication && !useMockClient)
        {
            Console.WriteLine("[Test Setup] Using REAL IBKR authentication");

            // Load authentication options from configuration
            var authOptions = new IBKRAuthenticationOptions
            {
                ClientId = Configuration["IBKR:ClientId"] ?? throw new InvalidOperationException("IBKR:ClientId not configured"),
                Credential = Configuration["IBKR:Credential"] ?? throw new InvalidOperationException("IBKR:Credential not configured"),
                ClientKeyId = Configuration["IBKR:ClientKeyId"] ?? throw new InvalidOperationException("IBKR:ClientKeyId not configured"),
                ClientPemPath = Configuration["IBKR:ClientPemPath"] ?? throw new InvalidOperationException("IBKR:ClientPemPath not configured"),
                BaseUrl = Configuration["IBKR:BaseUrl"] ?? "https://api.ibkr.com"
            };

            // Register authenticated services
            services.AddIBKRAuthenticatedClient<IFyiService, FyiService>(authOptions, client =>
            {
                client.BaseAddress = new Uri(authOptions.BaseUrl);
            });
            // TODO: Add more authenticated services as needed
        }
        else
        {
            Console.WriteLine($"[Test Setup] Using MOCK authentication (UseRealAuth={useRealAuthentication})");

            // Register mock authentication provider
            services.AddSingleton<IIBKRAuthenticationProvider>(new MockAuthenticationProvider());
        }

        // Configure client implementations
        if (useMockClient)
        {
            Console.WriteLine("[Test Setup] Using MOCK client implementations");

            // Register mock service implementations
            services.AddTransient<IFyiService, MockFyiService>();
            // TODO: MockIserverService needs all interface methods implemented
            // services.AddTransient<IIserverService, MockIserverService>();
            services.AddTransient<IMdService, MockMdService>();
            // TODO: Add more mock services as needed:
            // services.AddTransient<IGwService, MockGwService>();
            // services.AddTransient<IPortfolioService, MockPortfolioService>();
        }
        else
        {
            Console.WriteLine("[Test Setup] Using REAL client implementations");

            // Real services are registered above with authentication if UseRealAuthentication is true
            // If UseRealAuthentication is false, register them without authentication
            if (!useRealAuthentication)
            {
                services.AddHttpClient();
                services.AddTransient<IFyiService, FyiService>();
                // TODO: Add more real services as needed
            }
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
