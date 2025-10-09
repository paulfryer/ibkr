using IBKR.Api.Authentication;
using IBKR.Api.NSwag.Authentication;
using IBKR.Api.NSwag.Contract.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBKR.Api.Testing.Extensions;

/// <summary>
/// Extension methods for configuring NSwag test services with mock or real implementations.
/// </summary>
public static class NSwagTestExtensions
{
    /// <summary>
    /// Adds NSwag test services (IIserverService, IMdService) using mock or real implementation
    /// based on IBKR_USE_MOCKS flag and credential availability.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="configuration">Configuration containing IBKR credentials and settings</param>
    /// <param name="mockAuthProvider">Factory for creating mock authentication provider (optional)</param>
    /// <param name="mockIserverService">Factory for creating mock IserverService implementation (optional)</param>
    /// <param name="mockMdService">Factory for creating mock MdService implementation (optional)</param>
    public static IServiceCollection AddNSwagTestServices(
        this IServiceCollection services,
        IConfiguration configuration,
        Func<IIBKRAuthenticationProvider>? mockAuthProvider = null,
        Func<IIserverService>? mockIserverService = null,
        Func<IMdService>? mockMdService = null)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        TestConfiguration.LogTestMode(configuration);

        if (TestConfiguration.ShouldUseMock(configuration))
        {
            // Register mock services
            if (mockAuthProvider != null)
            {
                services.AddSingleton(mockAuthProvider());
            }
            else
            {
                services.AddSingleton<IIBKRAuthenticationProvider>(new MockAuthenticationProvider());
            }

            if (mockIserverService != null)
            {
                services.AddTransient(sp => mockIserverService());
            }
            else
            {
                throw new InvalidOperationException(
                    "Mock IIserverService factory must be provided when using mock mode. " +
                    $"Pass mockIserverService parameter or set {ConfigurationKeys.UseMocks}=false to use real API.");
            }

            if (mockMdService != null)
            {
                services.AddTransient(sp => mockMdService());
            }
            else
            {
                throw new InvalidOperationException(
                    "Mock IMdService factory must be provided when using mock mode. " +
                    $"Pass mockMdService parameter or set {ConfigurationKeys.UseMocks}=false to use real API.");
            }
        }
        else
        {
            // Register real services with authentication
            var authOptions = TestConfiguration.GetAuthOptions(configuration);
            authOptions.Validate();

            services.AddIBKRAuthenticatedClient<IIserverService, IBKR.Api.NSwag.Client.Services.IserverService>(authOptions);
            services.AddIBKRAuthenticatedClient<IMdService, IBKR.Api.NSwag.Client.Services.MdService>(authOptions);
        }

        return services;
    }
}
