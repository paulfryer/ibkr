using IBKR.Api.Kiota.Client;
using IBKR.Api.Kiota.MockClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace IBKR.Api.Kiota.Tests;

/// <summary>
/// Test fixture for dependency injection setup.
/// Configures IRequestAdapter based on appsettings.json to use either Mock or Real implementation.
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
            Console.WriteLine("[Test Setup] Using MOCK request adapter");

            // Register mock request adapter
            services.AddSingleton<IRequestAdapter>(sp => new MockRequestAdapter());
        }
        else
        {
            Console.WriteLine("[Test Setup] Using REAL request adapter");

            // Register real request adapter with HTTP client
            services.AddHttpClient();

            services.AddSingleton<IRequestAdapter>(sp =>
            {
                var authProvider = new AnonymousAuthenticationProvider();
                var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient();
                return new HttpClientRequestAdapter(authProvider, httpClient: httpClient);
            });
        }

        // Register IBKRClient
        services.AddTransient<IBKRClient>(sp =>
        {
            var adapter = sp.GetRequiredService<IRequestAdapter>();
            return new IBKRClient(adapter);
        });
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
