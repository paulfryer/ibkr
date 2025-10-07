using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum RecurringTransactionMethod
{
	[EnumMember(Value = "CHECK")]
	CHECK,
	[EnumMember(Value = "WIRE")]
	WIRE,
	[EnumMember(Value = "ACH")]
	ACH,
	[EnumMember(Value = "SKIP_DEPOSIT")]
	SKIP_DEPOSIT
}
