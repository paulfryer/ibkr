namespace IBKR.Sdk.Contract.Models;

/// <summary>
/// Option Greeks - measures of risk and sensitivity for option contracts.
/// All values are nullable since the API may not return all Greeks for all options.
/// </summary>
public class OptionGreeks
{
    /// <summary>
    /// Delta - Rate of change of option price relative to underlying price.
    /// Range: -1.0 to 1.0 for puts, 0.0 to 1.0 for calls.
    /// Measures how much the option price changes when the underlying moves $1.
    /// </summary>
    public decimal? Delta { get; set; }

    /// <summary>
    /// Gamma - Rate of change of delta relative to underlying price.
    /// Measures how much delta changes when the underlying moves $1.
    /// Higher gamma means delta is more sensitive to price changes.
    /// </summary>
    public decimal? Gamma { get; set; }

    /// <summary>
    /// Vega - Sensitivity to changes in implied volatility.
    /// Measures how much the option price changes when IV changes by 1%.
    /// Higher vega means the option is more sensitive to volatility changes.
    /// </summary>
    public decimal? Vega { get; set; }

    /// <summary>
    /// Theta - Time decay per day.
    /// Typically negative, measures how much value the option loses per day.
    /// More negative theta means faster time decay.
    /// </summary>
    public decimal? Theta { get; set; }

    /// <summary>
    /// Implied volatility as a decimal (e.g., 0.28 for 28% IV).
    /// Represents the market's expectation of future volatility.
    /// </summary>
    public decimal? ImpliedVolatility { get; set; }

    /// <summary>
    /// Returns true if all Greeks are available
    /// </summary>
    public bool IsComplete =>
        Delta.HasValue &&
        Gamma.HasValue &&
        Vega.HasValue &&
        Theta.HasValue &&
        ImpliedVolatility.HasValue;

    /// <summary>
    /// Returns a formatted string representation of the Greeks
    /// </summary>
    public override string ToString()
    {
        return $"Delta: {Delta:F4}, Gamma: {Gamma:F4}, Vega: {Vega:F4}, Theta: {Theta:F4}, IV: {ImpliedVolatility:P2}";
    }
}
