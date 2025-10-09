namespace IBKR.Sdk.Contract.Constants;

/// <summary>
/// Market data field codes for IBKR API.
/// These codes are used to request specific market data fields in snapshot and streaming requests.
/// See IBKR API documentation for complete field list.
/// </summary>
public static class MarketDataFields
{
    #region Basic Price Fields

    /// <summary>
    /// Last price (field 31)
    /// </summary>
    public const string Last = "31";

    /// <summary>
    /// Bid price (field 84)
    /// </summary>
    public const string Bid = "84";

    /// <summary>
    /// Ask price (field 86)
    /// </summary>
    public const string Ask = "86";

    /// <summary>
    /// Ask size (field 85)
    /// </summary>
    public const string AskSize = "85";

    /// <summary>
    /// Bid size (field 88)
    /// </summary>
    public const string BidSize = "88";

    /// <summary>
    /// Volume (field 87)
    /// </summary>
    public const string Volume = "87";

    #endregion

    #region High/Low/Open/Close

    /// <summary>
    /// High price of the day (field 70)
    /// </summary>
    public const string High = "70";

    /// <summary>
    /// Low price of the day (field 71)
    /// </summary>
    public const string Low = "71";

    /// <summary>
    /// Market value (field 73)
    /// </summary>
    public const string MarketValue = "73";

    /// <summary>
    /// Average price (field 74)
    /// </summary>
    public const string AveragePrice = "74";

    /// <summary>
    /// Close price (field 82)
    /// </summary>
    public const string Close = "82";

    #endregion

    #region Option Greeks

    /// <summary>
    /// Delta - Rate of change of option price relative to underlying price (field 7308)
    /// </summary>
    public const string Delta = "7308";

    /// <summary>
    /// Gamma - Rate of change of delta (field 7309)
    /// </summary>
    public const string Gamma = "7309";

    /// <summary>
    /// Vega - Sensitivity to volatility changes (field 7310)
    /// </summary>
    public const string Vega = "7310";

    /// <summary>
    /// Theta - Time decay per day (field 7311)
    /// </summary>
    public const string Theta = "7311";

    #endregion

    #region Option Volatility

    /// <summary>
    /// Implied volatility (field 7295)
    /// </summary>
    public const string ImpliedVolatility = "7295";

    /// <summary>
    /// Historical volatility (field 7633)
    /// </summary>
    public const string HistoricalVolatility = "7633";

    #endregion

    #region Option-Specific

    /// <summary>
    /// Open interest (field 7289)
    /// </summary>
    public const string OpenInterest = "7289";

    /// <summary>
    /// Option open price (field 7283)
    /// </summary>
    public const string OptionOpen = "7283";

    /// <summary>
    /// Option high price (field 7284)
    /// </summary>
    public const string OptionHigh = "7284";

    /// <summary>
    /// Option low price (field 7285)
    /// </summary>
    public const string OptionLow = "7285";

    /// <summary>
    /// Option close price (field 7286)
    /// </summary>
    public const string OptionClose = "7286";

    #endregion

    #region Change/Percent Change

    /// <summary>
    /// Percent change (field 83)
    /// </summary>
    public const string PercentChange = "83";

    #endregion

    /// <summary>
    /// Returns a comma-separated string of common stock quote fields
    /// </summary>
    public static string StockQuoteFields => $"{Last},{Bid},{Ask},{BidSize},{AskSize},{Volume},{High},{Low},{Close},{PercentChange}";

    /// <summary>
    /// Returns a comma-separated string of common option quote fields including Greeks
    /// </summary>
    public static string OptionQuoteFields => $"{Last},{Bid},{Ask},{BidSize},{AskSize},{Volume},{OpenInterest},{ImpliedVolatility},{Delta},{Gamma},{Vega},{Theta}";

    /// <summary>
    /// Returns a comma-separated string of just the Greeks fields
    /// </summary>
    public static string GreeksFields => $"{Delta},{Gamma},{Vega},{Theta},{ImpliedVolatility}";
}
