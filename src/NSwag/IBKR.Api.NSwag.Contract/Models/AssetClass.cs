using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum AssetClass
{
	[EnumMember(Value = "STK")]
	STK,
	[EnumMember(Value = "OPT")]
	OPT,
	[EnumMember(Value = "FUT")]
	FUT,
	[EnumMember(Value = "CFD")]
	CFD,
	[EnumMember(Value = "WAR")]
	WAR,
	[EnumMember(Value = "SWP")]
	SWP,
	[EnumMember(Value = "FND")]
	FND,
	[EnumMember(Value = "BND")]
	BND,
	[EnumMember(Value = "ICS")]
	ICS
}
