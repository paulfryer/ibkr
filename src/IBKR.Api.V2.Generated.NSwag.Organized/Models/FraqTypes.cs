using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum FraqTypes
{
    [EnumMember(Value = "limit")] Limit,
    [EnumMember(Value = "market")] Market,
    [EnumMember(Value = "stop")] Stop,
    [EnumMember(Value = "stop_limit")] Stop_limit,
    [EnumMember(Value = "mit")] Mit,
    [EnumMember(Value = "lit")] Lit,
    [EnumMember(Value = "trailing_stop")] Trailing_stop,

    [EnumMember(Value = "trailing_stop_limit")]
    Trailing_stop_limit
}