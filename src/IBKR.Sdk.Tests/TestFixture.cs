using IBKR.Sdk.Contract.Interfaces;
using IBKR.Sdk.Tests.Mocks;
using IBKR.Api.Testing;
using IBKR.Api.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBKR.Sdk.Tests;

/// <summary>
/// Test fixture for the IBKR SDK.
/// Uses real IBKR API if credentials are provided (local dev), otherwise uses mock.
/// Set Testing:UseMockClient=true to force mock even with credentials (CI/CD).
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
            .AddJsonFile("appsettings.development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        // Setup DI container
        var services = new ServiceCollection();
        services.AddSingleton(Configuration);
        services.AddLogging(); // Add logging for ILogger<T> dependencies

        // Use shared test infrastructure - automatically decides mock vs real based on config + credentials
        services.AddSdkTestServices(
            Configuration,
            mockOptionService: () => new MockOptionService(),
            mockIserverService: () => new IBKR.Api.NSwag.MockClient.Services.MockIserverService(),
            mockMdService: () => new IBKR.Api.NSwag.MockClient.Services.MockMdService()
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
