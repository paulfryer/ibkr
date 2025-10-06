using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Accounts;

/// <summary>
/// Response containing the list of trading accounts.
/// </summary>
public record TradingAccountsResponse
{
    /// <summary>
    /// Gets or sets the list of account IDs.
    /// </summary>
    [JsonPropertyName("accounts")]
    public List<string> Accounts { get; init; } = new();

    /// <summary>
    /// Gets or sets the currently selected account ID.
    /// </summary>
    [JsonPropertyName("selectedAccount")]
    public string? SelectedAccount { get; init; }
}
