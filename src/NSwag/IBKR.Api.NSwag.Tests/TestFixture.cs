using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.MockClient.Services;
using IBKR.Api.Testing;
using IBKR.Api.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBKR.Api.NSwag.Tests;

/// <summary>
/// Test fixture for dependency injection setup.
/// Uses real IBKR API if credentials are provided (local dev), otherwise uses mock.
/// Set Testing:UseMockClient=true to force mock even with credentials (CI/CD).
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
            .AddEnvironmentVariables()
            .Build();

        // Setup DI container
        var services = new ServiceCollection();
        services.AddSingleton(Configuration);

        // Use shared test infrastructure - automatically decides mock vs real based on config + credentials
        services.AddNSwagTestServices(
            Configuration,
            mockIserverService: () => new MockIserverService(),
            mockMdService: () => new MockMdService()
        );

        ServiceProvider = services.BuildServiceProvider();
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
