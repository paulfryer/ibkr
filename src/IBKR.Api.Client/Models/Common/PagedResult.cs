namespace IBKR.Api.Client.Models.Common;

/// <summary>
/// Represents a paged result set.
/// </summary>
/// <typeparam name="T">The type of items in the result set.</typeparam>
public record PagedResult<T>
{
    /// <summary>
    /// Gets or sets the items in the current page.
    /// </summary>
    public IReadOnlyList<T> Items { get; init; } = Array.Empty<T>();

    /// <summary>
    /// Gets or sets the total number of items across all pages.
    /// </summary>
    public int? TotalCount { get; init; }

    /// <summary>
    /// Gets or sets the current page number.
    /// </summary>
    public int PageNumber { get; init; }

    /// <summary>
    /// Gets or sets the page size.
    /// </summary>
    public int PageSize { get; init; }

    /// <summary>
    /// Gets a value indicating whether there is a next page.
    /// </summary>
    public bool HasNextPage => TotalCount.HasValue && PageNumber * PageSize < TotalCount;

    /// <summary>
    /// Gets a value indicating whether there is a previous page.
    /// </summary>
    public bool HasPreviousPage => PageNumber > 1;
}
