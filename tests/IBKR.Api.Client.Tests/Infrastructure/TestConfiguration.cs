namespace IBKR.Api.Client.Tests.Infrastructure;

/// <summary>
/// Configuration for test execution.
/// Determines which implementation to use (mock or real HTTP API).
/// </summary>
public class TestConfiguration
{
    /// <summary>
    /// If true, tests will use the real HTTP API implementation.
    /// If false (default), tests will use the mock implementation.
    /// </summary>
    public bool UseRealApi { get; set; } = false;

    /// <summary>
    /// Base URL for the real API (only used when UseRealApi = true).
    /// </summary>
    public string RealApiBaseUrl { get; set; } = "https://localhost:5000/v1/api";

    /// <summary>
    /// Authentication token for real API (only used when UseRealApi = true).
    /// </summary>
    public string? AuthToken { get; set; }

    /// <summary>
    /// Reads configuration from environment variables and falls back to defaults.
    /// </summary>
    public static TestConfiguration LoadFromEnvironment()
    {
        var config = new TestConfiguration();

        // Check environment variable
        var useRealApiEnv = Environment.GetEnvironmentVariable("USE_REAL_IBKR_API");
        if (!string.IsNullOrEmpty(useRealApiEnv))
        {
            config.UseRealApi = bool.Parse(useRealApiEnv);
        }

        // Override base URL if provided
        var baseUrlEnv = Environment.GetEnvironmentVariable("IBKR_API_BASE_URL");
        if (!string.IsNullOrEmpty(baseUrlEnv))
        {
            config.RealApiBaseUrl = baseUrlEnv;
        }

        // Auth token from environment
        var authTokenEnv = Environment.GetEnvironmentVariable("IBKR_AUTH_TOKEN");
        if (!string.IsNullOrEmpty(authTokenEnv))
        {
            config.AuthToken = authTokenEnv;
        }

        return config;
    }
}
