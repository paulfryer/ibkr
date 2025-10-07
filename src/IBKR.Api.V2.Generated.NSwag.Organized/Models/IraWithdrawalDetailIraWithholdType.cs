using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum IraWithdrawalDetailIraWithholdType
{
	[EnumMember(Value = "DIRECT_ROLLOVER")]
	DIRECT_ROLLOVER,
	[EnumMember(Value = "ROTH_DISTRIBUTION")]
	ROTH_DISTRIBUTION,
	[EnumMember(Value = "NORMAL")]
	NORMAL,
	[EnumMember(Value = "EARLY")]
	EARLY,
	[EnumMember(Value = "DEATH")]
	DEATH,
	[EnumMember(Value = "EXCESS_CY")]
	EXCESS_CY,
	[EnumMember(Value = "EXCESS_PY")]
	EXCESS_PY,
	[EnumMember(Value = "EXCESS_SC")]
	EXCESS_SC
}
