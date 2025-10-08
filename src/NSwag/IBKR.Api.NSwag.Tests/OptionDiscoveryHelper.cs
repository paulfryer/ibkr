namespace IBKR.Api.NSwag.Tests;

/// <summary>
/// Helper utilities for discovering option contracts within a date range.
/// </summary>
public static class OptionDiscoveryHelper
{
    /// <summary>
    /// Generates month strings in YYYYMM format for the date range starting from today.
    /// </summary>
    /// <param name="daysAhead">Number of days ahead to include</param>
    /// <returns>Enumerable of month strings in YYYYMM format</returns>
    public static IEnumerable<string> GetMonthsInRange(int daysAhead)
    {
        var startDate = DateTime.UtcNow;
        var endDate = startDate.AddDays(daysAhead);

        var months = new HashSet<string>();
        var currentDate = startDate;

        while (currentDate <= endDate)
        {
            months.Add(currentDate.ToString("yyyyMM"));
            currentDate = currentDate.AddMonths(1);
            // Reset to first day of next month to avoid skipping months
            currentDate = new DateTime(currentDate.Year, currentDate.Month, 1);
        }

        return months.OrderBy(m => m);
    }

    /// <summary>
    /// Parses an expiration date in YYYYMMDD format and returns DateTime.
    /// </summary>
    /// <param name="yyyymmdd">Date string in YYYYMMDD format</param>
    /// <returns>Parsed DateTime</returns>
    public static DateTime ParseExpirationDate(string yyyymmdd)
    {
        if (string.IsNullOrEmpty(yyyymmdd) || yyyymmdd.Length != 8)
        {
            throw new ArgumentException($"Invalid date format: {yyyymmdd}. Expected YYYYMMDD format.");
        }

        var year = int.Parse(yyyymmdd.Substring(0, 4));
        var month = int.Parse(yyyymmdd.Substring(4, 2));
        var day = int.Parse(yyyymmdd.Substring(6, 2));

        return new DateTime(year, month, day);
    }

    /// <summary>
    /// Checks if an expiration date is within the specified number of days from today.
    /// </summary>
    /// <param name="expirationDate">Expiration date in YYYYMMDD format</param>
    /// <param name="daysAhead">Maximum days ahead</param>
    /// <returns>True if expiration is within range</returns>
    public static bool IsExpirationWithinRange(string expirationDate, int daysAhead)
    {
        try
        {
            var expDate = ParseExpirationDate(expirationDate);
            var maxDate = DateTime.UtcNow.AddDays(daysAhead);
            return expDate <= maxDate && expDate >= DateTime.UtcNow.Date;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Calculates the number of days until expiration.
    /// </summary>
    /// <param name="expirationDate">Expiration date in YYYYMMDD format</param>
    /// <returns>Number of days until expiration (can be negative if past)</returns>
    public static int GetDaysUntilExpiration(string expirationDate)
    {
        var expDate = ParseExpirationDate(expirationDate);
        return (int)(expDate - DateTime.UtcNow.Date).TotalDays;
    }

    /// <summary>
    /// Gets typical monthly option expiration dates (3rd Friday of each month) within range.
    /// Note: This is an approximation - actual expirations may vary.
    /// </summary>
    /// <param name="daysAhead">Number of days ahead</param>
    /// <returns>List of expiration dates in YYYYMMDD format</returns>
    public static List<string> GetTypicalMonthlyExpirations(int daysAhead)
    {
        var expirations = new List<string>();
        var endDate = DateTime.UtcNow.AddDays(daysAhead);
        var currentMonth = DateTime.UtcNow;

        for (int i = 0; i < 12; i++) // Check up to 12 months ahead
        {
            var thirdFriday = GetThirdFriday(currentMonth.Year, currentMonth.Month);

            if (thirdFriday <= endDate && thirdFriday >= DateTime.UtcNow.Date)
            {
                expirations.Add(thirdFriday.ToString("yyyyMMdd"));
            }

            if (thirdFriday > endDate)
            {
                break;
            }

            currentMonth = currentMonth.AddMonths(1);
        }

        return expirations;
    }

    /// <summary>
    /// Gets the 3rd Friday of a given month (typical monthly option expiration).
    /// </summary>
    private static DateTime GetThirdFriday(int year, int month)
    {
        var firstDay = new DateTime(year, month, 1);
        var firstFriday = firstDay;

        // Find first Friday
        while (firstFriday.DayOfWeek != DayOfWeek.Friday)
        {
            firstFriday = firstFriday.AddDays(1);
        }

        // Add 2 weeks to get third Friday
        return firstFriday.AddDays(14);
    }
}
