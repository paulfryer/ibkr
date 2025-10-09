namespace IBKR.Sdk.Client;

/// <summary>
/// Configuration options for OptionService performance and behavior.
/// </summary>
public class OptionServiceOptions
{
    /// <summary>
    /// Maximum number of concurrent API calls when fetching option contracts.
    /// Higher values = faster queries but risk hitting rate limits.
    /// Lower values = slower queries but safer.
    /// Default: 10 (conservative but provides ~10x speedup)
    /// </summary>
    public int MaxDegreeOfParallelism { get; set; } = 10;

    /// <summary>
    /// Enable parallel processing of option strikes.
    /// Set to false to disable parallelism (useful for debugging or rate limit issues).
    /// Default: true
    /// </summary>
    public bool EnableParallelProcessing { get; set; } = true;

    /// <summary>
    /// Validates the configuration options.
    /// </summary>
    public void Validate()
    {
        if (MaxDegreeOfParallelism < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(MaxDegreeOfParallelism),
                $"{nameof(MaxDegreeOfParallelism)} must be at least 1");
        }

        if (MaxDegreeOfParallelism > 50)
        {
            throw new ArgumentOutOfRangeException(
                nameof(MaxDegreeOfParallelism),
                $"{nameof(MaxDegreeOfParallelism)} should not exceed 50 to avoid overwhelming the API");
        }
    }
}
