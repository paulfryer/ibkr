using IBKR.Api.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace IBKR.Api.NSwag.Authentication;

/// <summary>
/// Extension methods for registering IBKR authentication with NSwag SDK
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Ensures the base URL ends with a trailing slash for proper URL concatenation.
    /// </summary>
    private static string NormalizeBaseUrl(string baseUrl)
    {
        if (string.IsNullOrEmpty(baseUrl))
            return baseUrl;

        return baseUrl.EndsWith('/') ? baseUrl : baseUrl + '/';
    }
    /// <summary>
    /// Add IBKR authentication to NSwag SDK service registration.
    /// This configures the HttpClient to automatically include authentication headers.
    /// </summary>
    /// <typeparam name="TInterface">Service interface (e.g., IIserverService)</typeparam>
    /// <typeparam name="TImplementation">Service implementation (e.g., IserverService)</typeparam>
    /// <param name="services">Service collection</param>
    /// <param name="options">Authentication options</param>
    /// <returns>IHttpClientBuilder for further configuration</returns>
    public static IHttpClientBuilder AddIBKRAuthenticatedClient<TInterface, TImplementation>(
        this IServiceCollection services,
        IBKRAuthenticationOptions options)
        where TInterface : class
        where TImplementation : class, TInterface
    {
        var normalizedBaseUrl = NormalizeBaseUrl(options.BaseUrl);

        // Register authentication provider as singleton (only if not already registered)
        if (!services.Any(x => x.ServiceType == typeof(IIBKRAuthenticationProvider)))
        {
            services.AddSingleton<IIBKRAuthenticationProvider>(sp =>
                new IBKRAuthenticationProvider(options));
        }

        // Register the authentication handler as Transient (each HttpClient gets its own instance)
        if (!services.Any(x => x.ServiceType == typeof(IBKRAuthenticationHandler)))
        {
            services.AddTransient<IBKRAuthenticationHandler>();
        }

        // Configure the named HttpClient with authentication
        var builder = services.AddHttpClient(typeof(TInterface).Name)
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler())
            .AddHttpMessageHandler<IBKRAuthenticationHandler>();  // Use typed registration

        // Register service factory that uses the baseUrl constructor
        services.AddTransient<TInterface>(sp =>
        {
            var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient(typeof(TInterface).Name);
            // Use reflection to create instance with baseUrl constructor
            return (TInterface)Activator.CreateInstance(typeof(TImplementation), httpClient, normalizedBaseUrl)!;
        });

        return builder;
    }

    /// <summary>
    /// Add IBKR authentication to NSwag SDK service registration with configuration action.
    /// </summary>
    /// <typeparam name="TInterface">Service interface (e.g., IIserverService)</typeparam>
    /// <typeparam name="TImplementation">Service implementation (e.g., IserverService)</typeparam>
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
        var normalizedBaseUrl = NormalizeBaseUrl(options.BaseUrl);

        // Register authentication provider as singleton (only if not already registered)
        if (!services.Any(x => x.ServiceType == typeof(IIBKRAuthenticationProvider)))
        {
            services.AddSingleton<IIBKRAuthenticationProvider>(sp =>
                new IBKRAuthenticationProvider(options));
        }

        // Register the authentication handler as Transient (each HttpClient gets its own instance)
        if (!services.Any(x => x.ServiceType == typeof(IBKRAuthenticationHandler)))
        {
            services.AddTransient<IBKRAuthenticationHandler>();
        }

        // Configure the named HttpClient with authentication
        var builder = services.AddHttpClient(typeof(TInterface).Name)
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler())
            .AddHttpMessageHandler<IBKRAuthenticationHandler>();  // Use typed registration

        if (configureClient != null)
        {
            builder.ConfigureHttpClient(configureClient);
        }

        // Register service factory that uses the baseUrl constructor
        services.AddTransient<TInterface>(sp =>
        {
            var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient(typeof(TInterface).Name);
            // Use reflection to create instance with baseUrl constructor
            return (TInterface)Activator.CreateInstance(typeof(TImplementation), httpClient, normalizedBaseUrl)!;
        });

        return builder;
    }
}
