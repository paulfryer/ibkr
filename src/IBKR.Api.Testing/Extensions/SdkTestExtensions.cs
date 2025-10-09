using IBKR.Api.Authentication;
using IBKR.Api.NSwag.Authentication;
using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Sdk.Client.Services;
using IBKR.Sdk.Contract.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IBKR.Api.Testing.Extensions;

/// <summary>
/// Extension methods for configuring IBKR SDK test services with mock or real implementations.
/// </summary>
public static class SdkTestExtensions
{
    /// <summary>
    /// Adds IBKR SDK test services (IOptionService, etc.) using mock or real implementation
    /// based on Testing:UseMockClient configuration and credential availability.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="configuration">Configuration containing IBKR credentials and Testing settings</param>
    /// <param name="mockOptionService">Factory for creating mock OptionService implementation (optional)</param>
    public static IServiceCollection AddSdkTestServices(
        this IServiceCollection services,
        IConfiguration configuration,
        Func<IOptionService>? mockOptionService = null)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        TestConfiguration.LogTestMode(configuration);

        if (TestConfiguration.ShouldUseMock(configuration))
        {
            // Register mock OptionService
            if (mockOptionService != null)
            {
                services.AddTransient(sp => mockOptionService());
            }
            else
            {
                throw new InvalidOperationException(
                    "Mock IOptionService factory must be provided when using mock mode. " +
                    "Pass mockOptionService parameter or set Testing:UseMockClient=false to use real API.");
            }
        }
        else
        {
            // Register real SDK services
            var authOptions = BuildAuthOptions(configuration);
            authOptions.Validate();

            // Register underlying NSwag IserverService
            services.AddIBKRAuthenticatedClient<IIserverService, IBKR.Api.NSwag.Client.Services.IserverService>(authOptions);

            // Register IBKR SDK service that wraps NSwag
            services.AddTransient<IOptionService>(sp =>
            {
                var nswagIserver = sp.GetRequiredService<IIserverService>();
                var logger = sp.GetRequiredService<ILogger<OptionService>>();
                return new OptionService(nswagIserver, logger);
            });
        }

        return services;
    }

    private static IBKRAuthenticationOptions BuildAuthOptions(IConfiguration configuration)
    {
        return new IBKRAuthenticationOptions
        {
            ClientId = configuration["IBKR:ClientId"]
                ?? throw new InvalidOperationException("IBKR:ClientId not configured"),
            Credential = configuration["IBKR:Credential"]
                ?? throw new InvalidOperationException("IBKR:Credential not configured"),
            ClientKeyId = configuration["IBKR:ClientKeyId"]
                ?? throw new InvalidOperationException("IBKR:ClientKeyId not configured"),
            ClientPemPath = configuration["IBKR:ClientPemPath"]
                ?? throw new InvalidOperationException("IBKR:ClientPemPath not configured"),
            BaseUrl = configuration["IBKR:BaseUrl"] ?? "https://api.ibkr.com"
        };
    }
}
