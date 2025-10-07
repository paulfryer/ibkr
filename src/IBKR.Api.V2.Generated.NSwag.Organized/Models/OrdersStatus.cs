using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum OrdersStatus
{
    [EnumMember(Value = "Inactive")] Inactive,
    [EnumMember(Value = "PendingSubmit")] PendingSubmit,
    [EnumMember(Value = "PreSubmitted")] PreSubmitted,
    [EnumMember(Value = "Submitted")] Submitted,
    [EnumMember(Value = "Filled")] Filled,
    [EnumMember(Value = "PendingCancel")] PendingCancel,
    [EnumMember(Value = "Cancelled")] Cancelled,
    [EnumMember(Value = "WarnState")] WarnState
}