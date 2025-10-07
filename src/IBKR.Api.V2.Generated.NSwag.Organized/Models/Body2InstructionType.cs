using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum Body2InstructionType
{
	[EnumMember(Value = "ACH_INSTRUCTION")]
	ACH_INSTRUCTION,
	[EnumMember(Value = "TRADITIONAL_BANK_INSTRUCTION_VERIFICATION")]
	TRADITIONAL_BANK_INSTRUCTION_VERIFICATION,
	[EnumMember(Value = "DELETE_BANK_INSTRUCTION")]
	DELETE_BANK_INSTRUCTION,
	[EnumMember(Value = "PREDEFINED_DESTINATION_INSTRUCTION")]
	PREDEFINED_DESTINATION_INSTRUCTION,
	[EnumMember(Value = "EDDA_INSTRUCTION")]
	EDDA_INSTRUCTION
}
