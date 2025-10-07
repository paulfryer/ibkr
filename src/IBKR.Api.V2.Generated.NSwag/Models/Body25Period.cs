using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum Body25Period
{
	[EnumMember(Value = "1D")]
	_1D,
	[EnumMember(Value = "7D")]
	_7D,
	[EnumMember(Value = "MTD")]
	MTD,
	[EnumMember(Value = "1M")]
	_1M,
	[EnumMember(Value = "3M")]
	_3M,
	[EnumMember(Value = "6M")]
	_6M,
	[EnumMember(Value = "12M")]
	_12M,
	[EnumMember(Value = "YTD")]
	YTD
}
