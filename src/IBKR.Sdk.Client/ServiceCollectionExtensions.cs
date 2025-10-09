using IBKR.Api.Authentication;
using IBKR.Sdk.Client.Services;
using IBKR.Sdk.Contract.Interfaces;
using IBKR.Api.NSwag.Authentication;
using IBKR.Api.NSwag.Client.Services;
using IBKR.Api.NSwag.Contract.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

        // Load credentials: ENV variables first, then configuration
        var options = new IBKRAuthenticationOptions
        {
            ClientId = Environment.GetEnvironmentVariable(ConfigurationKeys.ClientId)
                      ?? configuration[ConfigurationKeys.ClientId]
                      ?? throw new InvalidOperationException($"{ConfigurationKeys.ClientId} not configured"),
            Credential = Environment.GetEnvironmentVariable(ConfigurationKeys.Credential)
                        ?? configuration[ConfigurationKeys.Credential]
                        ?? throw new InvalidOperationException($"{ConfigurationKeys.Credential} not configured"),
            ClientKeyId = Environment.GetEnvironmentVariable(ConfigurationKeys.ClientKeyId)
                         ?? configuration[ConfigurationKeys.ClientKeyId]
                         ?? throw new InvalidOperationException($"{ConfigurationKeys.ClientKeyId} not configured"),
            ClientPemPath = Environment.GetEnvironmentVariable(ConfigurationKeys.ClientPemPath)
                           ?? configuration[ConfigurationKeys.ClientPemPath]
                           ?? throw new InvalidOperationException($"{ConfigurationKeys.ClientPemPath} not configured"),
            BaseUrl = Environment.GetEnvironmentVariable(ConfigurationKeys.BaseUrl)
                     ?? configuration[ConfigurationKeys.BaseUrl]
                     ?? "https://api.ibkr.com"
        };

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
            var logger = sp.GetRequiredService<ILogger<OptionService>>();
            var optionServiceOptions = new OptionServiceOptions(); // Use default options (10 parallel calls)
            return new OptionService(nswagIserver, logger, optionServiceOptions);
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
            options.ClientId = Environment.GetEnvironmentVariable(ConfigurationKeys.ClientId)
                ?? throw new InvalidOperationException($"{ConfigurationKeys.ClientId} environment variable is required");
            options.Credential = Environment.GetEnvironmentVariable(ConfigurationKeys.Credential)
                ?? throw new InvalidOperationException($"{ConfigurationKeys.Credential} environment variable is required");
            options.ClientKeyId = Environment.GetEnvironmentVariable(ConfigurationKeys.ClientKeyId)
                ?? throw new InvalidOperationException($"{ConfigurationKeys.ClientKeyId} environment variable is required");
            options.ClientPemPath = Environment.GetEnvironmentVariable(ConfigurationKeys.ClientPemPath)
                ?? throw new InvalidOperationException($"{ConfigurationKeys.ClientPemPath} environment variable is required");
            options.BaseUrl = Environment.GetEnvironmentVariable(ConfigurationKeys.BaseUrl) ?? "https://api.ibkr.com";
        });
    }
}
