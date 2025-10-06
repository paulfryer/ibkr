namespace IBKR.Api.Client.Core;

/// <summary>
/// Configuration options for the IBKR API client.
/// </summary>
public class IBKRClientOptions
{
    /// <summary>
    /// Gets or sets the base URL for the IBKR API.
    /// Default: https://api.ibkr.com/v1/api
    /// For Client Portal Gateway: https://localhost:5000/v1/api
    /// </summary>
    public string BaseUrl { get; set; } = "https://api.ibkr.com/v1/api";

    /// <summary>
    /// Gets or sets the bearer token for authentication.
    /// </summary>
    public string? BearerToken { get; set; }

    /// <summary>
    /// Gets or sets the OAuth 2.0 access token.
    /// </summary>
    public string? AccessToken { get; set; }

    /// <summary>
    /// Gets or sets the global rate limit (requests per second).
    /// Default: 50 (production API limit)
    /// Client Portal Gateway: 10
    /// </summary>
    public int RateLimitPerSecond { get; set; } = 50;

    /// <summary>
    /// Gets or sets a value indicating whether to enable automatic retry on transient failures.
    /// Default: true
    /// </summary>
    public bool EnableRetry { get; set; } = true;

    /// <summary>
    /// Gets or sets the maximum number of retry attempts.
    /// Default: 3
    /// </summary>
    public int MaxRetryAttempts { get; set; } = 3;

    /// <summary>
    /// Gets or sets the base delay for exponential backoff (in milliseconds).
    /// Default: 1000ms
    /// </summary>
    public int RetryDelayMilliseconds { get; set; } = 1000;

    /// <summary>
    /// Gets or sets the HTTP request timeout (in seconds).
    /// Default: 30 seconds
    /// </summary>
    public int TimeoutSeconds { get; set; } = 30;

    /// <summary>
    /// Gets or sets a value indicating whether to throw exceptions on API errors.
    /// If false, errors are returned in the response object.
    /// Default: true
    /// </summary>
    public bool ThrowOnApiError { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to log HTTP requests and responses.
    /// Default: false
    /// </summary>
    public bool EnableLogging { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether to validate SSL certificates.
    /// Default: true (should only be false for testing with self-signed certs)
    /// </summary>
    public bool ValidateSslCertificates { get; set; } = true;

    /// <summary>
    /// Validates the configuration options.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when configuration is invalid.</exception>
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(BaseUrl))
        {
            throw new ArgumentException("BaseUrl cannot be null or empty.", nameof(BaseUrl));
        }

        if (!Uri.TryCreate(BaseUrl, UriKind.Absolute, out _))
        {
            throw new ArgumentException("BaseUrl must be a valid absolute URI.", nameof(BaseUrl));
        }

        if (RateLimitPerSecond <= 0)
        {
            throw new ArgumentException("RateLimitPerSecond must be greater than 0.", nameof(RateLimitPerSecond));
        }

        if (MaxRetryAttempts < 0)
        {
            throw new ArgumentException("MaxRetryAttempts cannot be negative.", nameof(MaxRetryAttempts));
        }

        if (RetryDelayMilliseconds < 0)
        {
            throw new ArgumentException("RetryDelayMilliseconds cannot be negative.", nameof(RetryDelayMilliseconds));
        }

        if (TimeoutSeconds <= 0)
        {
            throw new ArgumentException("TimeoutSeconds must be greater than 0.", nameof(TimeoutSeconds));
        }
    }
}
