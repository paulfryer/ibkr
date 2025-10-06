using System.Text.Json.Serialization;

namespace IBKR.Api.Client.Models.Instruments;

/// <summary>
/// Security definition search result.
/// </summary>
public record SecurityDefinition
{
    /// <summary>
    /// Gets or sets the contract ID.
    /// </summary>
    [JsonPropertyName("conid")]
    public string? Conid { get; init; }

    /// <summary>
    /// Gets or sets the company header.
    /// </summary>
    [JsonPropertyName("companyHeader")]
    public string? CompanyHeader { get; init; }

    /// <summary>
    /// Gets or sets the company name.
    /// </summary>
    [JsonPropertyName("companyName")]
    public string? CompanyName { get; init; }

    /// <summary>
    /// Gets or sets the symbol.
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; init; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Gets or sets the restricted status.
    /// </summary>
    [JsonPropertyName("restricted")]
    public string? Restricted { get; init; }

    /// <summary>
    /// Gets or sets the sections containing contract details.
    /// </summary>
    [JsonPropertyName("sections")]
    public List<SecuritySection>? Sections { get; init; }
}

/// <summary>
/// Section of a security definition with contract details.
/// </summary>
public record SecuritySection
{
    /// <summary>
    /// Gets or sets the security type.
    /// </summary>
    [JsonPropertyName("secType")]
    public string? SecType { get; init; }

    /// <summary>
    /// Gets or sets the available months (for derivatives).
    /// </summary>
    [JsonPropertyName("months")]
    public string? Months { get; init; }

    /// <summary>
    /// Gets or sets the exchange.
    /// </summary>
    [JsonPropertyName("exchange")]
    public string? Exchange { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether PRIIPs information should be shown.
    /// </summary>
    [JsonPropertyName("showPrips")]
    public bool? ShowPrips { get; init; }
}
