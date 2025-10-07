using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum IraDepositDetailIraContributionType
{
	[EnumMember(Value = "ROLLOVER")]
	ROLLOVER,
	[EnumMember(Value = "LATE_ROLLOVER")]
	LATE_ROLLOVER,
	[EnumMember(Value = "DIRECT_ROLLOVER")]
	DIRECT_ROLLOVER,
	[EnumMember(Value = "CONTRIBUTION")]
	CONTRIBUTION,
	[EnumMember(Value = "SPOUSAL_CONTRIBUTION")]
	SPOUSAL_CONTRIBUTION,
	[EnumMember(Value = "EMPLOYER_SEP_CONTRIBUTION")]
	EMPLOYER_SEP_CONTRIBUTION
}
