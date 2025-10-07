using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum AchInstructionAchType
{
	[EnumMember(Value = "DEBIT")]
	DEBIT,
	[EnumMember(Value = "CREDIT")]
	CREDIT,
	[EnumMember(Value = "DEBIT_CREDIT")]
	DEBIT_CREDIT
}
