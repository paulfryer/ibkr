using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum TradingPermissionProduct
{
    [EnumMember(Value = "BONDS")] BONDS,
    [EnumMember(Value = "FUTURES")] FUTURES,
    [EnumMember(Value = "FOREX")] FOREX,

    [EnumMember(Value = "FUTURES OPTIONS")]
    FUTURES_OPTIONS,
    [EnumMember(Value = "MUTUAL FUNDS")] MUTUAL_FUNDS,
    [EnumMember(Value = "STOCKS")] STOCKS,

    [EnumMember(Value = "SINGLE STOCK FUTURES")]
    SINGLE_STOCK_FUTURES,
    [EnumMember(Value = "OPTIONS")] OPTIONS,
    [EnumMember(Value = "STOCK OPTIONS")] STOCK_OPTIONS,
    [EnumMember(Value = "WARRANTS")] WARRANTS
}