using IBKR.Api.Authentication;
using Microsoft.Extensions.Configuration;

namespace IBKR.Api.Testing;

/// <summary>
/// Shared test configuration logic for determining whether to use mock or real IBKR API.
/// Standardizes behavior across all test projects (NSwag, Kiota, SDK).
/// </summary>
public static class TestConfiguration
{
    /// <summary>
    /// Determines whether tests should use mock implementation.
    /// Logic (priority order):
    /// 1. If IBKR_USE_MOCKS=true → use mocks (CI/CD override)
    /// 2. Else try to get credentials → use real API
    /// 3. If credentials not found → throw error (no silent fallback to mock)
    /// </summary>
    public static bool ShouldUseMock(IConfiguration configuration)
    {
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        // Priority 1: Check IBKR_USE_MOCKS flag
        var useMocksStr = Environment.GetEnvironmentVariable(ConfigurationKeys.UseMocks)
                         ?? configuration[ConfigurationKeys.UseMocks];

        if (bool.TryParse(useMocksStr, out var useMocks) && useMocks)
        {
            return true; // Explicitly requested mocks
        }

        // Priority 2: Try to find credentials
        // If credentials exist → use real API
        // If not → throw error (don't silently fall back to mock)
        return !HasCredentials(configuration);
    }

    /// <summary>
    /// Checks if all required IBKR credentials are configured.
    /// Checks environment variables first, then configuration.
    /// </summary>
    public static bool HasCredentials(IConfiguration configuration)
    {
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        // Try environment variables first
        var clientId = Environment.GetEnvironmentVariable(ConfigurationKeys.ClientId);
        var credential = Environment.GetEnvironmentVariable(ConfigurationKeys.Credential);
        var clientKeyId = Environment.GetEnvironmentVariable(ConfigurationKeys.ClientKeyId);
        var clientPemPath = Environment.GetEnvironmentVariable(ConfigurationKeys.ClientPemPath);

        // If all found in ENV, we're good
        if (!string.IsNullOrEmpty(clientId) &&
            !string.IsNullOrEmpty(credential) &&
            !string.IsNullOrEmpty(clientKeyId) &&
            !string.IsNullOrEmpty(clientPemPath))
        {
            return true;
        }

        // Fallback: check configuration (appsettings.json)
        clientId = configuration[ConfigurationKeys.ClientId];
        credential = configuration[ConfigurationKeys.Credential];
        clientKeyId = configuration[ConfigurationKeys.ClientKeyId];
        clientPemPath = configuration[ConfigurationKeys.ClientPemPath];

        return !string.IsNullOrEmpty(clientId) &&
               !string.IsNullOrEmpty(credential) &&
               !string.IsNullOrEmpty(clientKeyId) &&
               !string.IsNullOrEmpty(clientPemPath);
    }

    /// <summary>
    /// Loads IBKR authentication options from environment variables or configuration.
    /// Priority: ENV variables first, then configuration.
    /// Throws if credentials are not found.
    /// </summary>
    public static IBKRAuthenticationOptions GetAuthOptions(IConfiguration configuration)
    {
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        // Load from ENV first, fallback to config
        var clientId = Environment.GetEnvironmentVariable(ConfigurationKeys.ClientId)
                      ?? configuration[ConfigurationKeys.ClientId];
        var credential = Environment.GetEnvironmentVariable(ConfigurationKeys.Credential)
                        ?? configuration[ConfigurationKeys.Credential];
        var clientKeyId = Environment.GetEnvironmentVariable(ConfigurationKeys.ClientKeyId)
                         ?? configuration[ConfigurationKeys.ClientKeyId];
        var clientPemPath = Environment.GetEnvironmentVariable(ConfigurationKeys.ClientPemPath)
                           ?? configuration[ConfigurationKeys.ClientPemPath];
        var baseUrl = Environment.GetEnvironmentVariable(ConfigurationKeys.BaseUrl)
                     ?? configuration[ConfigurationKeys.BaseUrl]
                     ?? "https://api.ibkr.com";

        if (string.IsNullOrEmpty(clientId))
            throw new InvalidOperationException($"{ConfigurationKeys.ClientId} not configured");
        if (string.IsNullOrEmpty(credential))
            throw new InvalidOperationException($"{ConfigurationKeys.Credential} not configured");
        if (string.IsNullOrEmpty(clientKeyId))
            throw new InvalidOperationException($"{ConfigurationKeys.ClientKeyId} not configured");
        if (string.IsNullOrEmpty(clientPemPath))
            throw new InvalidOperationException($"{ConfigurationKeys.ClientPemPath} not configured");

        return new IBKRAuthenticationOptions
        {
            ClientId = clientId,
            Credential = credential,
            ClientKeyId = clientKeyId,
            ClientPemPath = clientPemPath,
            BaseUrl = baseUrl
        };
    }

    /// <summary>
    /// Logs the test mode being used (mock or real API) for diagnostic purposes.
    /// </summary>
    public static void LogTestMode(IConfiguration configuration)
    {
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        var useMocksStr = Environment.GetEnvironmentVariable(ConfigurationKeys.UseMocks)
                         ?? configuration[ConfigurationKeys.UseMocks];
        var forceMock = bool.TryParse(useMocksStr, out var useMocks) && useMocks;
        var hasCredentials = HasCredentials(configuration);

        if (forceMock)
        {
            Console.WriteLine("[Test Setup] Using MOCK implementation");
            Console.WriteLine($"  Reason: {ConfigurationKeys.UseMocks}=true");
        }
        else if (hasCredentials)
        {
            Console.WriteLine("[Test Setup] Using REAL IBKR API");
            var clientId = Environment.GetEnvironmentVariable(ConfigurationKeys.ClientId)
                          ?? configuration[ConfigurationKeys.ClientId];
            var baseUrl = Environment.GetEnvironmentVariable(ConfigurationKeys.BaseUrl)
                         ?? configuration[ConfigurationKeys.BaseUrl]
                         ?? "https://api.ibkr.com";
            Console.WriteLine($"  ClientId: {clientId}");
            Console.WriteLine($"  BaseUrl: {baseUrl}");
        }
        else
        {
            Console.WriteLine("[Test Setup] Using MOCK implementation");
            Console.WriteLine($"  Reason: No credentials found");
        }
    }
}
