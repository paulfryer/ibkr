using IBKR.Api.Client.Core;
using IBKR.Api.Client.Http.Infrastructure;
using IBKR.Api.Client.Http.Infrastructure.Handlers;
using IBKR.Api.Client.Http.Services;
using IBKR.Api.Client.Infrastructure.RateLimiter;
using IBKR.Api.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IBKR.Api.Client.Http.Extensions;

/// <summary>
/// Extension methods for IServiceCollection to register IBKR HTTP client services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds IBKR HTTP client services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="configureOptions">Action to configure IBKRClientOptions</param>
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection AddIBKRHttpClient(
        this IServiceCollection services,
        Action<IBKRClientOptions> configureOptions)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        if (configureOptions == null)
            throw new ArgumentNullException(nameof(configureOptions));

        // Register and validate options
        services.Configure(configureOptions);
        services.AddSingleton<IValidateOptions<IBKRClientOptions>, IBKRClientOptionsValidator>();

        // Register rate limiter as singleton (shared across all requests)
        services.AddSingleton<IRateLimiter>(sp =>
        {
            var options = sp.GetRequiredService<IOptions<IBKRClientOptions>>().Value;
            return new TokenBucketRateLimiter(options.RateLimitPerSecond);
        });

        // Register delegating handlers
        services.AddTransient<AuthenticationHandler>();
        services.AddTransient<RateLimitHandler>();
        services.AddTransient<RetryHandler>();
        services.AddTransient<LoggingHandler>();

        // Register HttpClient with handler pipeline
        services.AddHttpClient<IBKRHttpClient>((sp, httpClient) =>
        {
            var options = sp.GetRequiredService<IOptions<IBKRClientOptions>>().Value;

            // Validate options
            options.Validate();

            // Configure base address
            httpClient.BaseAddress = new Uri(options.BaseUrl);

            // Set timeout
            httpClient.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);

            // Set default headers
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "IBKR.Api.Client.Http/1.0");
        })
        // Configure handler pipeline (order matters - innermost to outermost)
        .AddHttpMessageHandler<LoggingHandler>()           // Log requests/responses (outermost)
        .AddHttpMessageHandler<AuthenticationHandler>()     // Add authentication
        .AddHttpMessageHandler<RateLimitHandler>()          // Enforce rate limits
        .AddHttpMessageHandler<RetryHandler>();             // Retry transient failures (innermost)

        // Configure SSL certificate validation if needed
        services.AddHttpClient<IBKRHttpClient>()
            .ConfigurePrimaryHttpMessageHandler((sp) =>
            {
                var options = sp.GetRequiredService<IOptions<IBKRClientOptions>>().Value;

                var handler = new HttpClientHandler();

                if (!options.ValidateSslCertificates)
                {
                    // Disable SSL validation (use only for development/testing)
                    handler.ServerCertificateCustomValidationCallback =
                        (message, cert, chain, errors) => true;
                }

                return handler;
            });

        // Register API services
        services.AddScoped<IInstrumentApiService, InstrumentApiService>();

        // TODO: Register other API services when implemented
        // services.AddScoped<IAccountApiService, AccountApiService>();
        // services.AddScoped<IOrderApiService, OrderApiService>();
        // services.AddScoped<IMarketDataApiService, MarketDataApiService>();
        // etc.

        return services;
    }
}

/// <summary>
/// Validator for IBKRClientOptions.
/// </summary>
internal class IBKRClientOptionsValidator : IValidateOptions<IBKRClientOptions>
{
    public ValidateOptionsResult Validate(string? name, IBKRClientOptions options)
    {
        try
        {
            options.Validate();
            return ValidateOptionsResult.Success;
        }
        catch (Exception ex)
        {
            return ValidateOptionsResult.Fail(ex.Message);
        }
    }
}
