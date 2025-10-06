using IBKR.Api.Client.Mock.Services;
using IBKR.Api.Client.Services;

namespace IBKR.Api.Client.Tests.Infrastructure;

/// <summary>
/// xUnit fixture that provides an IInstrumentApiService implementation for tests.
/// The implementation is determined by configuration (mock vs real API).
/// Tests receive this via constructor injection and have NO knowledge of which implementation is used.
/// </summary>
public class InstrumentServiceFixture : IDisposable
{
    private readonly TestConfiguration _config;

    /// <summary>
    /// The service instance used by all tests.
    /// Tests depend only on this interface - they don't know if it's mock or real.
    /// </summary>
    public IInstrumentApiService Service { get; }

    public InstrumentServiceFixture()
    {
        // Load configuration from environment
        _config = TestConfiguration.LoadFromEnvironment();

        if (_config.UseRealApi)
        {
            // TODO: When HTTP implementation is ready, create real service here
            // Service = new InstrumentApiService(new IBKRClientOptions
            // {
            //     BaseUrl = _config.RealApiBaseUrl,
            //     BearerToken = _config.AuthToken
            // });

            throw new NotImplementedException(
                "Real HTTP API implementation is not yet available. " +
                "Set USE_REAL_IBKR_API=false or remove the environment variable to use mock implementation.");
        }
        else
        {
            // Use mock implementation pre-loaded with test data
            Service = MockInstrumentApiServiceBuilder
                .CreateDefault()
                .Build();
        }
    }

    public void Dispose()
    {
        // Cleanup if needed (e.g., dispose HTTP client)
        if (Service is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
