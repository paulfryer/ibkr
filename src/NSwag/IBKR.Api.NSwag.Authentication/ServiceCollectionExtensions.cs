using IBKR.Api.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace IBKR.Api.NSwag.Authentication;

/// <summary>
/// Extension methods for registering IBKR authentication with NSwag SDK
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add IBKR authentication to NSwag SDK service registration.
    /// This configures the HttpClient to automatically include authentication headers.
    /// </summary>
    /// <typeparam name="TInterface">Service interface (e.g., IFyiService)</typeparam>
    /// <typeparam name="TImplementation">Service implementation (e.g., FyiService)</typeparam>
    /// <param name="services">Service collection</param>
    /// <param name="options">Authentication options</param>
    /// <returns>IHttpClientBuilder for further configuration</returns>
    public static IHttpClientBuilder AddIBKRAuthenticatedClient<TInterface, TImplementation>(
        this IServiceCollection services,
        IBKRAuthenticationOptions options)
        where TInterface : class
        where TImplementation : class, TInterface
    {
        // Register authentication provider as singleton
        services.AddSingleton<IIBKRAuthenticationProvider>(sp =>
            new IBKRAuthenticationProvider(options));

        // Register authentication handler as transient
        services.AddTransient<IBKRAuthenticationHandler>();

        // Register service with authentication handler
        return services.AddHttpClient<TInterface, TImplementation>()
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler())
            .AddHttpMessageHandler<IBKRAuthenticationHandler>();
    }

    /// <summary>
    /// Add IBKR authentication to NSwag SDK service registration with configuration action.
    /// </summary>
    /// <typeparam name="TInterface">Service interface (e.g., IFyiService)</typeparam>
    /// <typeparam name="TImplementation">Service implementation (e.g., FyiService)</typeparam>
    /// <param name="services">Service collection</param>
    /// <param name="options">Authentication options</param>
    /// <param name="configureClient">Optional HttpClient configuration</param>
    /// <returns>IHttpClientBuilder for further configuration</returns>
    public static IHttpClientBuilder AddIBKRAuthenticatedClient<TInterface, TImplementation>(
        this IServiceCollection services,
        IBKRAuthenticationOptions options,
        Action<HttpClient> configureClient)
        where TInterface : class
        where TImplementation : class, TInterface
    {
        var builder = services.AddIBKRAuthenticatedClient<TInterface, TImplementation>(options);

        if (configureClient != null)
        {
            builder.ConfigureHttpClient(configureClient);
        }

        return builder;
    }
}
