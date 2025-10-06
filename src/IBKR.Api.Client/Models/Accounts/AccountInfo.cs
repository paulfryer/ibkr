using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Accounts;

/// <summary>
/// Detailed information about an account.
/// </summary>
public record AccountInfo
{
    /// <summary>
    /// Gets or sets the internal account identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the account ID.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; init; }

    /// <summary>
    /// Gets or sets the account VAN (Virtual Account Number).
    /// </summary>
    [JsonPropertyName("accountVan")]
    public string? AccountVan { get; init; }

    /// <summary>
    /// Gets or sets the account title.
    /// </summary>
    [JsonPropertyName("accountTitle")]
    public string? AccountTitle { get; init; }

    /// <summary>
    /// Gets or sets the display name.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; init; }

    /// <summary>
    /// Gets or sets the account alias.
    /// </summary>
    [JsonPropertyName("accountAlias")]
    public string? AccountAlias { get; init; }

    /// <summary>
    /// Gets or sets the account status code.
    /// </summary>
    [JsonPropertyName("accountStatus")]
    public int? AccountStatus { get; init; }

    /// <summary>
    /// Gets or sets the account currency.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; init; }

    /// <summary>
    /// Gets or sets the account type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets or sets the trading type.
    /// </summary>
    [JsonPropertyName("tradingType")]
    public string? TradingType { get; init; }

    /// <summary>
    /// Gets or sets the business type.
    /// </summary>
    [JsonPropertyName("businessType")]
    public string? BusinessType { get; init; }

    /// <summary>
    /// Gets or sets the IB entity.
    /// </summary>
    [JsonPropertyName("ibEntity")]
    public string? IbEntity { get; init; }

    /// <summary>
    /// Gets or sets the clearing status.
    /// </summary>
    [JsonPropertyName("clearingStatus")]
    public string? ClearingStatus { get; init; }

    /// <summary>
    /// Gets or sets parent account information.
    /// </summary>
    [JsonPropertyName("parent")]
    public AccountParent? Parent { get; init; }
}

/// <summary>
/// Parent account information for multi-level account structures.
/// </summary>
public record AccountParent
{
    /// <summary>
    /// Gets or sets the master management client list.
    /// </summary>
    [JsonPropertyName("mmc")]
    public List<string>? Mmc { get; init; }

    /// <summary>
    /// Gets or sets the parent account ID.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a multiplex parent.
    /// </summary>
    [JsonPropertyName("isMParent")]
    public bool IsMParent { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a multiplex child.
    /// </summary>
    [JsonPropertyName("isMChild")]
    public bool IsMChild { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether multiplex is enabled.
    /// </summary>
    [JsonPropertyName("isMultiplex")]
    public bool IsMultiplex { get; init; }
}
