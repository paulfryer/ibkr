using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum Body4InstructionType
{
	[EnumMember(Value = "DWAC")]
	DWAC,
	[EnumMember(Value = "FOP")]
	FOP,
	[EnumMember(Value = "COMPLEX_ASSET_TRANSFER")]
	COMPLEX_ASSET_TRANSFER,
	[EnumMember(Value = "EXTERNAL_POSITION_TRANSFER")]
	EXTERNAL_POSITION_TRANSFER
}
