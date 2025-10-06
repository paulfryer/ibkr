using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Authentication;

/// <summary>
/// Response from the tickle endpoint (session keep-alive).
/// </summary>
public record TickleResponse
{
    /// <summary>
    /// Gets or sets the session identifier.
    /// </summary>
    [JsonPropertyName("session")]
    public string? Session { get; init; }

    /// <summary>
    /// Gets or sets the SSO expiration time (Unix timestamp).
    /// </summary>
    [JsonPropertyName("ssoExpires")]
    public long? SsoExpires { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether there is a session collision.
    /// </summary>
    [JsonPropertyName("collission")]
    public bool Collission { get; init; }

    /// <summary>
    /// Gets or sets the user ID.
    /// </summary>
    [JsonPropertyName("userId")]
    public int? UserId { get; init; }

    /// <summary>
    /// Gets or sets the iServer information.
    /// </summary>
    [JsonPropertyName("iserver")]
    public object? IServer { get; init; }
}
