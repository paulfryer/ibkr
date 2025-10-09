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
    /// based on IBKR_USE_MOCKS flag and credential availability.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="configuration">Configuration containing IBKR credentials and settings</param>
    /// <param name="mockOptionService">Factory for creating mock OptionService implementation (optional)</param>
    /// <param name="mockIserverService">Factory for creating mock IIserverService (optional, required for quote services in mock mode)</param>
    /// <param name="mockMdService">Factory for creating mock IMdService (optional)</param>
    public static IServiceCollection AddSdkTestServices(
        this IServiceCollection services,
        IConfiguration configuration,
        Func<IOptionService>? mockOptionService = null,
        Func<IIserverService>? mockIserverService = null,
        Func<IBKR.Api.NSwag.Contract.Interfaces.IMdService>? mockMdService = null)
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
                    $"Pass mockOptionService parameter or set {ConfigurationKeys.UseMocks}=false to use real API.");
            }

            // Register underlying NSwag mock services for quote services to use
            if (mockIserverService != null)
            {
                services.AddNSwagTestServices(
                    configuration,
                    mockIserverService: mockIserverService,
                    mockMdService: mockMdService
                );

                // Register quote services using the mock NSwag services
                services.AddTransient<IStockQuoteService>(sp =>
                {
                    var nswagIserver = sp.GetRequiredService<IIserverService>();
                    var logger = sp.GetRequiredService<ILogger<IBKR.Sdk.Client.Services.StockQuoteService>>();
                    return new IBKR.Sdk.Client.Services.StockQuoteService(nswagIserver, logger);
                });

                services.AddTransient<IOptionQuoteService>(sp =>
                {
                    var nswagIserver = sp.GetRequiredService<IIserverService>();
                    var optionService = sp.GetRequiredService<IOptionService>();
                    var logger = sp.GetRequiredService<ILogger<IBKR.Sdk.Client.Services.OptionQuoteService>>();
                    return new IBKR.Sdk.Client.Services.OptionQuoteService(nswagIserver, optionService, logger);
                });
            }
        }
        else
        {
            // Register real SDK services
            var authOptions = TestConfiguration.GetAuthOptions(configuration);
            authOptions.Validate();

            // Register underlying NSwag IserverService
            services.AddIBKRAuthenticatedClient<IIserverService, IBKR.Api.NSwag.Client.Services.IserverService>(authOptions);

            // Register IBKR SDK services that wrap NSwag
            services.AddTransient<IOptionService>(sp =>
            {
                var nswagIserver = sp.GetRequiredService<IIserverService>();
                var logger = sp.GetRequiredService<ILogger<OptionService>>();
                var optionServiceOptions = new IBKR.Sdk.Client.OptionServiceOptions(); // Use default options
                return new OptionService(nswagIserver, logger, optionServiceOptions);
            });

            services.AddTransient<IStockQuoteService>(sp =>
            {
                var nswagIserver = sp.GetRequiredService<IIserverService>();
                var logger = sp.GetRequiredService<ILogger<IBKR.Sdk.Client.Services.StockQuoteService>>();
                return new IBKR.Sdk.Client.Services.StockQuoteService(nswagIserver, logger);
            });

            services.AddTransient<IOptionQuoteService>(sp =>
            {
                var nswagIserver = sp.GetRequiredService<IIserverService>();
                var optionService = sp.GetRequiredService<IOptionService>();
                var logger = sp.GetRequiredService<ILogger<IBKR.Sdk.Client.Services.OptionQuoteService>>();
                return new IBKR.Sdk.Client.Services.OptionQuoteService(nswagIserver, optionService, logger);
            });
        }

        return services;
    }
}
