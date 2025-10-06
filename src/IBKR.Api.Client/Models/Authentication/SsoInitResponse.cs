using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Authentication;

/// <summary>
/// Response from SSO initialization endpoint.
/// </summary>
public record SsoInitResponse
{
    /// <summary>
    /// Gets or sets the authentication URL for SSO flow.
    /// </summary>
    [JsonPropertyName("authUrl")]
    public string? AuthUrl { get; init; }
}
