namespace IBKR.Api.Client.Models.Common;

/// <summary>
/// Generic wrapper for API responses.
/// </summary>
/// <typeparam name="T">The type of data returned in the response.</typeparam>
public record ApiResponse<T>
{
    /// <summary>
    /// Gets or sets the response data.
    /// </summary>
    public T? Data { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the request was successful.
    /// </summary>
    public bool IsSuccess { get; init; }

    /// <summary>
    /// Gets or sets the error message, if any.
    /// </summary>
    public string? ErrorMessage { get; init; }

    /// <summary>
    /// Gets or sets the HTTP status code.
    /// </summary>
    public int? StatusCode { get; init; }
}
