using IBKR.Api.Authentication;
using IBKR.Api.Kiota.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace IBKR.Api.Kiota.Authentication;

/// <summary>
/// Extension methods for registering IBKR authentication with Kiota SDK
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add IBKR authenticated Kiota client to service collection.
    /// This configures the request adapter to automatically include authentication headers.
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="options">Authentication options</param>
    /// <param name="baseUrl">Optional base URL override (default: from options.BaseUrl)</param>
    /// <returns>Service collection for chaining</returns>
    public static IServiceCollection AddIBKRAuthenticatedKiotaClient(
        this IServiceCollection services,
        IBKRAuthenticationOptions options,
        string? baseUrl = null)
    {
        // Register core authentication provider as singleton
        services.AddSingleton<IIBKRAuthenticationProvider>(sp =>
            new IBKRAuthenticationProvider(options));

        // Register Kiota authentication provider as singleton
        services.AddSingleton<IAuthenticationProvider, IBKRKiotaAuthenticationProvider>();

        // Register HttpClient for Kiota
        services.AddHttpClient("IBKRKiotaClient", client =>
        {
            client.BaseAddress = new Uri(baseUrl ?? options.BaseUrl);
        });

        // Register IRequestAdapter as singleton
        services.AddSingleton<IRequestAdapter>(sp =>
        {
            var authProvider = sp.GetRequiredService<IAuthenticationProvider>();
            var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("IBKRKiotaClient");

            return new HttpClientRequestAdapter(authProvider, httpClient: httpClient)
            {
                BaseUrl = baseUrl ?? options.BaseUrl
            };
        });

        // Register IBKRClient as transient
        services.AddTransient<IBKRClient>(sp =>
        {
            var adapter = sp.GetRequiredService<IRequestAdapter>();
            return new IBKRClient(adapter);
        });

        return services;
    }

    /// <summary>
    /// Add IBKR authenticated Kiota client with HttpClient configuration.
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="options">Authentication options</param>
    /// <param name="configureClient">HttpClient configuration action</param>
    /// <param name="baseUrl">Optional base URL override</param>
    /// <returns>Service collection for chaining</returns>
    public static IServiceCollection AddIBKRAuthenticatedKiotaClient(
        this IServiceCollection services,
        IBKRAuthenticationOptions options,
        Action<HttpClient> configureClient,
        string? baseUrl = null)
    {
        // Register core authentication provider
        services.AddSingleton<IIBKRAuthenticationProvider>(sp =>
            new IBKRAuthenticationProvider(options));

        // Register Kiota authentication provider
        services.AddSingleton<IAuthenticationProvider, IBKRKiotaAuthenticationProvider>();

        // Register HttpClient with configuration
        services.AddHttpClient("IBKRKiotaClient", client =>
        {
            client.BaseAddress = new Uri(baseUrl ?? options.BaseUrl);
            configureClient(client);
        });

        // Register IRequestAdapter
        services.AddSingleton<IRequestAdapter>(sp =>
        {
            var authProvider = sp.GetRequiredService<IAuthenticationProvider>();
            var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("IBKRKiotaClient");

            return new HttpClientRequestAdapter(authProvider, httpClient: httpClient)
            {
                BaseUrl = baseUrl ?? options.BaseUrl
            };
        });

        // Register IBKRClient
        services.AddTransient<IBKRClient>(sp =>
        {
            var adapter = sp.GetRequiredService<IRequestAdapter>();
            return new IBKRClient(adapter);
        });

        return services;
    }
}
