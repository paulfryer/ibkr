using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum ProhibitedQuestionnaireDetailCode
{
	[EnumMember(Value = "PASSPORT")]
	PASSPORT,
	[EnumMember(Value = "CITIZENSHIP")]
	CITIZENSHIP,
	[EnumMember(Value = "BUSINESSDEALINGS")]
	BUSINESSDEALINGS,
	[EnumMember(Value = "FINANCIALACCOUNTS")]
	FINANCIALACCOUNTS,
	[EnumMember(Value = "RESIDENT")]
	RESIDENT,
	[EnumMember(Value = "MULTI")]
	MULTI,
	[EnumMember(Value = "BIRTH")]
	BIRTH
}
