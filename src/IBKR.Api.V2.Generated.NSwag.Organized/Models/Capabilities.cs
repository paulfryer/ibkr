using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum Capabilities
{
	[EnumMember(Value = "BOND")]
	BOND,
	[EnumMember(Value = "FOP")]
	FOP,
	[EnumMember(Value = "FUND")]
	FUND,
	[EnumMember(Value = "FUT")]
	FUT,
	[EnumMember(Value = "MRGN")]
	MRGN,
	[EnumMember(Value = "MULT")]
	MULT,
	[EnumMember(Value = "OPT")]
	OPT,
	[EnumMember(Value = "SSF")]
	SSF,
	[EnumMember(Value = "CFD")]
	CFD,
	[EnumMember(Value = "STK")]
	STK,
	[EnumMember(Value = "CLP")]
	CLP,
	[EnumMember(Value = "LEVFX")]
	LEVFX,
	[EnumMember(Value = "CMDTY")]
	CMDTY
}
