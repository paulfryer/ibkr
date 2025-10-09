namespace IBKR.Api.Testing;

/// <summary>
/// Configuration key constants for IBKR SDK testing.
/// Used to access environment variables and configuration values.
/// </summary>
public static class ConfigurationKeys
{
    /// <summary>
    /// Flag to force using mock implementations in tests.
    /// Environment variable: IBKR_USE_MOCKS
    /// Configuration key: IBKR_USE_MOCKS
    /// </summary>
    public const string UseMocks = "IBKR_USE_MOCKS";

    /// <summary>
    /// IBKR Client ID (e.g., "TESTCONS" for paper trading).
    /// Environment variable: IBKR_CLIENT_ID
    /// Configuration key: IBKR_CLIENT_ID
    /// </summary>
    public const string ClientId = "IBKR_CLIENT_ID";

    /// <summary>
    /// IBKR Credential/username.
    /// Environment variable: IBKR_CREDENTIAL
    /// Configuration key: IBKR_CREDENTIAL
    /// </summary>
    public const string Credential = "IBKR_CREDENTIAL";

    /// <summary>
    /// IBKR Client Key ID (kid from RSA key pair).
    /// Environment variable: IBKR_CLIENT_KEY_ID
    /// Configuration key: IBKR_CLIENT_KEY_ID
    /// </summary>
    public const string ClientKeyId = "IBKR_CLIENT_KEY_ID";

    /// <summary>
    /// Path to PEM file containing RSA private key.
    /// Environment variable: IBKR_CLIENT_PEM_PATH
    /// Configuration key: IBKR_CLIENT_PEM_PATH
    /// </summary>
    public const string ClientPemPath = "IBKR_CLIENT_PEM_PATH";

    /// <summary>
    /// IBKR API base URL (defaults to https://api.ibkr.com).
    /// Environment variable: IBKR_BASE_URL
    /// Configuration key: IBKR_BASE_URL
    /// </summary>
    public const string BaseUrl = "IBKR_BASE_URL";
}
