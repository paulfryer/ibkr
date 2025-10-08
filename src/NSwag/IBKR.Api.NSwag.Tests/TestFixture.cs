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
/// Uses Mock client by default. Set Testing:UseMockClient=false to test against real IBKR API.
/// Credentials can be provided via appsettings.json or environment variables (IBKR__ClientId, etc.)
/// </summary>
public class TestFixture : IDisposable
{
    public IServiceProvider ServiceProvider { get; }
    public IConfiguration Configuration { get; }

    public TestFixture()
    {
        // Load configuration: appsettings.json with environment variable overrides
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()  // Environment variables override config file
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
            Console.WriteLine("[Test Setup] Using MOCK client - no credentials required");

            // Register mock authentication provider
            services.AddSingleton<IIBKRAuthenticationProvider>(new MockAuthenticationProvider());

            // Register mock service implementations for stock and option testing
            services.AddTransient<IIserverService, MockIserverService>();
            services.AddTransient<IMdService, MockMdService>();
        }
        else
        {
            Console.WriteLine("[Test Setup] Using REAL IBKR API - credentials required");

            // Load authentication options from configuration or environment variables
            var authOptions = new IBKRAuthenticationOptions
            {
                ClientId = Configuration["IBKR:ClientId"] ?? throw new InvalidOperationException("IBKR:ClientId not configured. Set via appsettings.json or environment variable IBKR__ClientId"),
                Credential = Configuration["IBKR:Credential"] ?? throw new InvalidOperationException("IBKR:Credential not configured. Set via appsettings.json or environment variable IBKR__Credential"),
                ClientKeyId = Configuration["IBKR:ClientKeyId"] ?? throw new InvalidOperationException("IBKR:ClientKeyId not configured. Set via appsettings.json or environment variable IBKR__ClientKeyId"),
                ClientPemPath = Configuration["IBKR:ClientPemPath"] ?? throw new InvalidOperationException("IBKR:ClientPemPath not configured. Set via appsettings.json or environment variable IBKR__ClientPemPath"),
                BaseUrl = Configuration["IBKR:BaseUrl"] ?? "https://api.ibkr.com"
            };

            // Validate credentials are complete
            authOptions.Validate();

            // Register authenticated services for stock/option testing
            // The services will be created with the normalized baseUrl from authOptions
            services.AddIBKRAuthenticatedClient<IIserverService, IserverService>(authOptions);
            services.AddIBKRAuthenticatedClient<IMdService, MdService>(authOptions);
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
