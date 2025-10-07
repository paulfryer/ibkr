using IBKR.Api.Authentication;
using IBKR.Api.Kiota.Authentication;
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
        var useRealAuthentication = Configuration.GetValue<bool>("Testing:UseRealAuthentication", defaultValue: false);

        if (useMockClient)
        {
            Console.WriteLine("[Test Setup] Using MOCK request adapter");

            // Register mock request adapter
            services.AddSingleton<IRequestAdapter>(sp => new MockRequestAdapter());

            // Register IBKRClient with mock adapter
            services.AddTransient<IBKRClient>(sp =>
            {
                var adapter = sp.GetRequiredService<IRequestAdapter>();
                return new IBKRClient(adapter);
            });
        }
        else if (useRealAuthentication)
        {
            Console.WriteLine("[Test Setup] Using REAL request adapter with IBKR authentication");

            // Load authentication options from configuration
            var authOptions = new IBKRAuthenticationOptions
            {
                ClientId = Configuration["IBKR:ClientId"] ?? throw new InvalidOperationException("IBKR:ClientId not configured"),
                Credential = Configuration["IBKR:Credential"] ?? throw new InvalidOperationException("IBKR:Credential not configured"),
                ClientKeyId = Configuration["IBKR:ClientKeyId"] ?? throw new InvalidOperationException("IBKR:ClientKeyId not configured"),
                ClientPemPath = Configuration["IBKR:ClientPemPath"] ?? throw new InvalidOperationException("IBKR:ClientPemPath not configured"),
                BaseUrl = Configuration["IBKR:BaseUrl"] ?? "https://api.ibkr.com"
            };

            // Use extension method to register authenticated Kiota client
            services.AddIBKRAuthenticatedKiotaClient(authOptions);
        }
        else
        {
            Console.WriteLine("[Test Setup] Using REAL request adapter with anonymous authentication");

            // Register real request adapter with HTTP client (no IBKR auth)
            services.AddHttpClient();

            services.AddSingleton<IRequestAdapter>(sp =>
            {
                var authProvider = new AnonymousAuthenticationProvider();
                var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient();
                var baseUrl = Configuration["IBKR:BaseUrl"] ?? "https://localhost:5000";
                return new HttpClientRequestAdapter(authProvider, httpClient: httpClient)
                {
                    BaseUrl = baseUrl
                };
            });

            // Register IBKRClient
            services.AddTransient<IBKRClient>(sp =>
            {
                var adapter = sp.GetRequiredService<IRequestAdapter>();
                return new IBKRClient(adapter);
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
