using IBKR.Api.Client.Core;
using IBKR.Api.Client.Http.Infrastructure;
using IBKR.Api.Client.Http.Infrastructure.Handlers;
using IBKR.Api.Client.Infrastructure.RateLimiter;
using IBKR.Api.Client.Mock.Services;
using IBKR.Api.Client.Services;
using Microsoft.Extensions.Options;

namespace IBKR.Api.Client.Tests.Infrastructure;

/// <summary>
/// xUnit fixture that provides an IInstrumentApiService implementation for tests.
/// The implementation is determined by configuration (mock vs real API).
/// Tests receive this via constructor injection and have NO knowledge of which implementation is used.
/// </summary>
public class InstrumentServiceFixture : IDisposable
{
    private readonly TestConfiguration _config;
    private HttpClient? _httpClient;

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
            // Create real HTTP implementation
            Service = CreateRealHttpService();
        }
        else
        {
            // Use mock implementation pre-loaded with test data
            Service = MockInstrumentApiServiceBuilder
                .CreateDefault()
                .Build();
        }
    }

    /// <summary>
    /// Creates a real HTTP-based implementation of IInstrumentApiService.
    /// </summary>
    private IInstrumentApiService CreateRealHttpService()
    {
        // Create options
        var options = new IBKRClientOptions
        {
            BaseUrl = _config.RealApiBaseUrl,
            BearerToken = _config.AuthToken,
            RateLimitPerSecond = 50,
            EnableRetry = true,
            MaxRetryAttempts = 3,
            RetryDelayMilliseconds = 1000,
            TimeoutSeconds = 30,
            EnableLogging = true
        };

        var optionsWrapper = Options.Create(options);

        // Create rate limiter
        var rateLimiter = new TokenBucketRateLimiter(options.RateLimitPerSecond);

        // Create delegating handlers
        var authHandler = new AuthenticationHandler(optionsWrapper);
        var rateLimitHandler = new RateLimitHandler(rateLimiter);
        var retryHandler = new RetryHandler(optionsWrapper);
        var loggingHandler = new LoggingHandler(optionsWrapper);

        // Build handler pipeline (innermost to outermost)
        retryHandler.InnerHandler = new HttpClientHandler();
        rateLimitHandler.InnerHandler = retryHandler;
        authHandler.InnerHandler = rateLimitHandler;
        loggingHandler.InnerHandler = authHandler;

        // Create HttpClient with handler pipeline
        _httpClient = new HttpClient(loggingHandler)
        {
            BaseAddress = new Uri(options.BaseUrl),
            Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds)
        };

        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "IBKR.Api.Client.Tests/1.0");

        // Create IBKRHttpClient and service
        var ibkrHttpClient = new IBKRHttpClient(_httpClient);
        return new Http.Services.InstrumentApiService(ibkrHttpClient);
    }

    public void Dispose()
    {
        // Cleanup HTTP client if created
        _httpClient?.Dispose();
    }
}
