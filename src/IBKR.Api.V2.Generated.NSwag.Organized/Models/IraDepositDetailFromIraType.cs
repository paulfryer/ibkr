using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum IraDepositDetailFromIraType
{
	[EnumMember(Value = "NONE")]
	NONE,
	[EnumMember(Value = "TRADITIONAL")]
	TRADITIONAL,
	[EnumMember(Value = "ROLLOVER")]
	ROLLOVER,
	[EnumMember(Value = "ROTH")]
	ROTH,
	[EnumMember(Value = "SEP")]
	SEP,
	[EnumMember(Value = "EDUCATION")]
	EDUCATION,
	[EnumMember(Value = "TRADITIONAL_INHERITED")]
	TRADITIONAL_INHERITED,
	[EnumMember(Value = "ROTH_INHERITED")]
	ROTH_INHERITED,
	[EnumMember(Value = "SEP_INHERITED")]
	SEP_INHERITED,
	[EnumMember(Value = "RETIREMENT_SAVING_PLAN")]
	RETIREMENT_SAVING_PLAN,
	[EnumMember(Value = "SPOUSAL_RETIREMENT_SAVING_PLAN")]
	SPOUSAL_RETIREMENT_SAVING_PLAN,
	[EnumMember(Value = "TAX_FREE_SAVING_ACCOUNT")]
	TAX_FREE_SAVING_ACCOUNT
}
