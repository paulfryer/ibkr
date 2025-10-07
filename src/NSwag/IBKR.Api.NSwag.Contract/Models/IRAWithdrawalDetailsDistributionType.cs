using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum IRAWithdrawalDetailsDistributionType
{
	[EnumMember(Value = "NORMAL")]
	NORMAL,
	[EnumMember(Value = "EARLY")]
	EARLY,
	[EnumMember(Value = "EARLY_EXCEPT")]
	EARLY_EXCEPT,
	[EnumMember(Value = "DEATH")]
	DEATH,
	[EnumMember(Value = "DISABILITY")]
	DISABILITY,
	[EnumMember(Value = "EXCESS_CONTRIB")]
	EXCESS_CONTRIB
}
