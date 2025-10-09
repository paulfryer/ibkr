using IBKR.Api.Authentication;
using IBKR.Api.Kiota.Authentication;
using IBKR.Api.Kiota.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Kiota.Abstractions;

namespace IBKR.Api.Testing.Extensions;

/// <summary>
/// Extension methods for configuring Kiota test services with mock or real implementations.
/// </summary>
public static class KiotaTestExtensions
{
    /// <summary>
    /// Adds Kiota test services (IBKRClient via IRequestAdapter) using mock or real implementation
    /// based on IBKR_USE_MOCKS flag and credential availability.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="configuration">Configuration containing IBKR credentials and settings</param>
    /// <param name="mockRequestAdapter">Factory for creating mock request adapter (optional)</param>
    public static IServiceCollection AddKiotaTestServices(
        this IServiceCollection services,
        IConfiguration configuration,
        Func<IRequestAdapter>? mockRequestAdapter = null)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        TestConfiguration.LogTestMode(configuration);

        if (TestConfiguration.ShouldUseMock(configuration))
        {
            // Register mock request adapter
            if (mockRequestAdapter != null)
            {
                services.AddSingleton(mockRequestAdapter());
            }
            else
            {
                throw new InvalidOperationException(
                    "Mock IRequestAdapter factory must be provided when using mock mode. " +
                    $"Pass mockRequestAdapter parameter or set {ConfigurationKeys.UseMocks}=false to use real API.");
            }

            // Register IBKRClient with mock adapter
            services.AddTransient<IBKRClient>(sp =>
            {
                var adapter = sp.GetRequiredService<IRequestAdapter>();
                return new IBKRClient(adapter);
            });
        }
        else
        {
            // Register real services with authentication
            var authOptions = TestConfiguration.GetAuthOptions(configuration);
            authOptions.Validate();

            services.AddIBKRAuthenticatedKiotaClient(authOptions);
        }

        return services;
    }
}
