using IBKR.Sdk.Authentication;
using IBKR.Sdk.Client.Services;
using IBKR.Sdk.Contract.Interfaces;
using IBKR.Api.NSwag.Authentication;
using IBKR.Api.NSwag.Client.Services;
using IBKR.Api.NSwag.Contract.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBKR.Sdk.Client;

/// <summary>
/// Extension methods for configuring IBKR SDK services with dependency injection.
/// Provides AWS SDK-like developer experience: services.AddIBKRSdk(config).
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add IBKR SDK services to the service collection using configuration from appsettings.json.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="configuration">Configuration section containing IBKR settings (e.g., from "IBKR" section)</param>
    /// <returns>The service collection for chaining</returns>
    /// <example>
    /// <code>
    /// // In Program.cs or Startup.cs
    /// services.AddIBKRSdk(Configuration.GetSection("IBKR"));
    ///
    /// // appsettings.json:
    /// {
    ///   "IBKR": {
    ///     "ClientId": "TESTCONS",
    ///     "Credential": "username",
    ///     "ClientKeyId": "kid-from-portal",
    ///     "ClientPemPath": "/path/to/private-key.pem",
    ///     "BaseUrl": "https://api.ibkr.com"
    ///   }
    /// }
    /// </code>
    /// </example>
    public static IServiceCollection AddIBKRSdk(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (configuration == null) throw new ArgumentNullException(nameof(configuration));

        // Bind configuration to IBKRAuthenticationOptions
        var options = new IBKRAuthenticationOptions();
        configuration.Bind(options);

        // Support environment variable overrides
        options.ClientId = Environment.GetEnvironmentVariable("IBKR_CLIENT_ID") ?? options.ClientId;
        options.Credential = Environment.GetEnvironmentVariable("IBKR_CREDENTIAL") ?? options.Credential;
        options.ClientKeyId = Environment.GetEnvironmentVariable("IBKR_CLIENT_KEY_ID") ?? options.ClientKeyId;
        options.ClientPemPath = Environment.GetEnvironmentVariable("IBKR_CLIENT_PEM_PATH") ?? options.ClientPemPath;
        options.BaseUrl = Environment.GetEnvironmentVariable("IBKR_BASE_URL") ?? options.BaseUrl;

        // Validate options
        options.Validate();

        return RegisterIBKRServices(services, options);
    }

    /// <summary>
    /// Add IBKR SDK services to the service collection using a configuration action.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="configureOptions">Action to configure authentication options</param>
    /// <returns>The service collection for chaining</returns>
    /// <example>
    /// <code>
    /// services.AddIBKRSdk(options => {
    ///     options.ClientId = Environment.GetEnvironmentVariable("IBKR_CLIENT_ID");
    ///     options.Credential = Environment.GetEnvironmentVariable("IBKR_CREDENTIAL");
    ///     options.ClientKeyId = Environment.GetEnvironmentVariable("IBKR_CLIENT_KEY_ID");
    ///     options.ClientPemPath = Environment.GetEnvironmentVariable("IBKR_CLIENT_PEM_PATH");
    ///     options.BaseUrl = "https://api.ibkr.com";
    /// });
    /// </code>
    /// </example>
    public static IServiceCollection AddIBKRSdk(
        this IServiceCollection services,
        Action<IBKRAuthenticationOptions> configureOptions)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (configureOptions == null) throw new ArgumentNullException(nameof(configureOptions));

        var options = new IBKRAuthenticationOptions();
        configureOptions(options);

        // Validate options
        options.Validate();

        return RegisterIBKRServices(services, options);
    }

    /// <summary>
    /// Internal method to register all IBKR SDK services with the DI container.
    /// </summary>
    private static IServiceCollection RegisterIBKRServices(
        IServiceCollection services,
        IBKRAuthenticationOptions options)
    {
        // 1. Register authentication provider (singleton - shared across all services)
        services.AddSingleton<IIBKRAuthenticationProvider>(sp =>
            new IBKRAuthenticationProvider(options));

        // 2. Register NSwag IserverService with authentication (using existing extension method)
        //    This is the low-level service that OptionService depends on
        services.AddIBKRAuthenticatedClient<IIserverService, IserverService>(options);

        // 3. Register IBKR SDK high-level services
        services.AddTransient<IOptionService>(sp =>
        {
            var nswagIserver = sp.GetRequiredService<IIserverService>();
            return new OptionService(nswagIserver);
        });

        // Future: Add more high-level services here as they're developed
        // services.AddTransient<IMarketDataService, MarketDataService>();
        // services.AddTransient<IAccountService, AccountService>();

        return services;
    }

    /// <summary>
    /// Add IBKR SDK services with default configuration.
    /// Uses environment variables for all authentication settings.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <returns>The service collection for chaining</returns>
    /// <example>
    /// <code>
    /// // Requires these environment variables:
    /// // IBKR_CLIENT_ID, IBKR_CREDENTIAL, IBKR_CLIENT_KEY_ID, IBKR_CLIENT_PEM_PATH
    /// services.AddIBKRSdk();
    /// </code>
    /// </example>
    public static IServiceCollection AddIBKRSdk(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        return services.AddIBKRSdk(options =>
        {
            options.ClientId = Environment.GetEnvironmentVariable("IBKR_CLIENT_ID")
                ?? throw new InvalidOperationException("IBKR_CLIENT_ID environment variable is required");
            options.Credential = Environment.GetEnvironmentVariable("IBKR_CREDENTIAL")
                ?? throw new InvalidOperationException("IBKR_CREDENTIAL environment variable is required");
            options.ClientKeyId = Environment.GetEnvironmentVariable("IBKR_CLIENT_KEY_ID")
                ?? throw new InvalidOperationException("IBKR_CLIENT_KEY_ID environment variable is required");
            options.ClientPemPath = Environment.GetEnvironmentVariable("IBKR_CLIENT_PEM_PATH")
                ?? throw new InvalidOperationException("IBKR_CLIENT_PEM_PATH environment variable is required");
            options.BaseUrl = Environment.GetEnvironmentVariable("IBKR_BASE_URL") ?? "https://api.ibkr.com";
        });
    }
}
