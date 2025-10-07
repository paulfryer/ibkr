using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum Body3InstructionType
{
	[EnumMember(Value = "QUERY_BANK_INSTRUCTION")]
	QUERY_BANK_INSTRUCTION,
	[EnumMember(Value = "QUERY_RECENT_RECURRING_EVENTS")]
	QUERY_RECENT_RECURRING_EVENTS,
	[EnumMember(Value = "QUERY_RECURRING_INSTRUCTIONS")]
	QUERY_RECURRING_INSTRUCTIONS
}
