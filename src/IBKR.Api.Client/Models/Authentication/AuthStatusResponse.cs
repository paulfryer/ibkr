using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Authentication;

/// <summary>
/// Response from the authentication status endpoint.
/// </summary>
public record AuthStatusResponse
{
    /// <summary>
    /// Gets or sets a value indicating whether the user is authenticated.
    /// </summary>
    [JsonPropertyName("authenticated")]
    public bool Authenticated { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the connection is established.
    /// </summary>
    [JsonPropertyName("connected")]
    public bool Connected { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether there is a competing session.
    /// </summary>
    [JsonPropertyName("competing")]
    public bool Competing { get; init; }

    /// <summary>
    /// Gets or sets the status message.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; init; }

    /// <summary>
    /// Gets or sets the server information.
    /// </summary>
    [JsonPropertyName("serverInfo")]
    public ServerInfo? ServerInfo { get; init; }
}

/// <summary>
/// Information about the API server.
/// </summary>
public record ServerInfo
{
    /// <summary>
    /// Gets or sets the server name.
    /// </summary>
    [JsonPropertyName("serverName")]
    public string? ServerName { get; init; }

    /// <summary>
    /// Gets or sets the server version.
    /// </summary>
    [JsonPropertyName("serverVersion")]
    public string? ServerVersion { get; init; }
}
