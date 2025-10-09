namespace IBKR.Api.Authentication;

/// <summary>
/// Configuration options for IBKR OAuth2 authentication
/// </summary>
public class IBKRAuthenticationOptions
{
    /// <summary>
    /// IBKR OAuth2 Client ID (e.g., "TESTCONS")
    /// </summary>
    public string ClientId { get; set; } = string.Empty;

    /// <summary>
    /// IBKR account username/credential
    /// </summary>
    public string Credential { get; set; } = string.Empty;

    /// <summary>
    /// OAuth2 Key Identifier (kid) from IBKR portal
    /// </summary>
    public string ClientKeyId { get; set; } = string.Empty;

    /// <summary>
    /// Path to RSA private key PEM file
    /// </summary>
    public string ClientPemPath { get; set; } = string.Empty;

    /// <summary>
    /// Base URL for IBKR API (default: https://api.ibkr.com)
    /// </summary>
    public string BaseUrl { get; set; } = "https://api.ibkr.com";

    /// <summary>
    /// Token cache lifetime in minutes (default: 5)
    /// </summary>
    public int TokenCacheMinutes { get; set; } = 5;

    /// <summary>
    /// Validate that all required options are set
    /// </summary>
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(ClientId))
            throw new InvalidOperationException("ClientId is required");

        if (string.IsNullOrWhiteSpace(Credential))
            throw new InvalidOperationException("Credential is required");

        if (string.IsNullOrWhiteSpace(ClientKeyId))
            throw new InvalidOperationException("ClientKeyId is required");

        if (string.IsNullOrWhiteSpace(ClientPemPath))
            throw new InvalidOperationException("ClientPemPath is required");

        if (!File.Exists(ClientPemPath))
            throw new FileNotFoundException($"PEM file not found: {ClientPemPath}");
    }
}
