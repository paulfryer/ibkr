using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum FormW8BENExplanation
{
	[EnumMember(Value = "US_TIN")]
	US_TIN,
	[EnumMember(Value = "TIN_NOT_DISCLOSED")]
	TIN_NOT_DISCLOSED,
	[EnumMember(Value = "TIN_NOT_REQUIRED")]
	TIN_NOT_REQUIRED,
	[EnumMember(Value = "TIN_NOT_ISSUED")]
	TIN_NOT_ISSUED
}
