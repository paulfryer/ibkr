namespace IBKR.Api.Authentication;

/// <summary>
/// Centralized configuration key constants for IBKR SDK.
/// ALL configuration keys are defined here ONCE to prevent naming inconsistencies.
/// Use these constants throughout the codebase - never hardcode key strings.
/// </summary>
public static class ConfigurationKeys
{
    /// <summary>
    /// IBKR Client ID (e.g., "TESTCONS" for paper trading).
    /// Used in both environment variables and configuration files.
    /// </summary>
    public const string ClientId = "IBKR_CLIENT_ID";

    /// <summary>
    /// IBKR username/credential for authentication.
    /// Used in both environment variables and configuration files.
    /// </summary>
    public const string Credential = "IBKR_CREDENTIAL";

    /// <summary>
    /// IBKR Client Key ID (kid) for JWT signing.
    /// Used in both environment variables and configuration files.
    /// </summary>
    public const string ClientKeyId = "IBKR_CLIENT_KEY_ID";

    /// <summary>
    /// Path to the private key PEM file for JWT signing.
    /// Used in both environment variables and configuration files.
    /// </summary>
    public const string ClientPemPath = "IBKR_CLIENT_PEM_PATH";

    /// <summary>
    /// IBKR API base URL (default: "https://api.ibkr.com").
    /// Used in both environment variables and configuration files.
    /// </summary>
    public const string BaseUrl = "IBKR_BASE_URL";

    /// <summary>
    /// Flag to force mock implementations in tests (default: false).
    /// When true, tests will use mocks regardless of credential availability.
    /// When false or not set, tests will attempt to use real API with credentials.
    /// Used in both environment variables and configuration files.
    /// </summary>
    public const string UseMocks = "IBKR_USE_MOCKS";
}
