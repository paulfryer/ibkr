using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum InstructionResultInstructionStatus
{
    [EnumMember(Value = "PENDING")] PENDING,
    [EnumMember(Value = "PROCESSED")] PROCESSED,
    [EnumMember(Value = "REJECTED")] REJECTED,

    [EnumMember(Value = "PENDING_VERIFICATION")]
    PENDING_VERIFICATION
}