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
    /// Logic: Use mock if Testing:UseMockClient=true OR credentials are not available.
    /// This allows:
    /// - Developers with credentials to test against real API by default
    /// - CI/CD to force mock by setting Testing:UseMockClient=true
    /// - Local dev without credentials to fall back to mock
    /// </summary>
    public static bool ShouldUseMock(IConfiguration configuration)
    {
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        var forceMock = configuration.GetValue<bool>("Testing:UseMockClient", defaultValue: false);
        var hasCredentials = HasCredentials(configuration);

        // Use mock if explicitly forced OR credentials are missing
        return forceMock || !hasCredentials;
    }

    /// <summary>
    /// Checks if all required IBKR credentials are configured.
    /// </summary>
    public static bool HasCredentials(IConfiguration configuration)
    {
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        return !string.IsNullOrEmpty(configuration["IBKR:ClientId"]) &&
               !string.IsNullOrEmpty(configuration["IBKR:Credential"]) &&
               !string.IsNullOrEmpty(configuration["IBKR:ClientKeyId"]) &&
               !string.IsNullOrEmpty(configuration["IBKR:ClientPemPath"]);
    }

    /// <summary>
    /// Logs the test mode being used (mock or real API) for diagnostic purposes.
    /// </summary>
    public static void LogTestMode(IConfiguration configuration)
    {
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        var useMock = ShouldUseMock(configuration);
        var forceMock = configuration.GetValue<bool>("Testing:UseMockClient", defaultValue: false);
        var hasCredentials = HasCredentials(configuration);

        if (useMock)
        {
            Console.WriteLine("[Test Setup] Using MOCK implementation");
            Console.WriteLine($"  Reason: {(forceMock ? "Testing:UseMockClient=true" : "No credentials found")}");
        }
        else
        {
            Console.WriteLine("[Test Setup] Using REAL IBKR API");
            Console.WriteLine($"  ClientId: {configuration["IBKR:ClientId"]}");
            Console.WriteLine($"  BaseUrl: {configuration["IBKR:BaseUrl"] ?? "https://api.ibkr.com"}");
        }
    }
}
