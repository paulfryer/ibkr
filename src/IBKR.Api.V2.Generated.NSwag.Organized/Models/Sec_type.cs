using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum Sec_type
{
	[EnumMember(Value = "STK")]
	STK,
	[EnumMember(Value = "OPT")]
	OPT,
	[EnumMember(Value = "FUT")]
	FUT,
	[EnumMember(Value = "FOP")]
	FOP,
	[EnumMember(Value = "CASH")]
	CASH,
	[EnumMember(Value = "CRYPTO")]
	CRYPTO,
	[EnumMember(Value = "BOND")]
	BOND,
	[EnumMember(Value = "WAR")]
	WAR,
	[EnumMember(Value = "FUND")]
	FUND
}
