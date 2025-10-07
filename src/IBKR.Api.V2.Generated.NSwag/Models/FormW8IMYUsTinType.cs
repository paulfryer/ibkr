using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum FormW8IMYUsTinType
{
	[EnumMember(Value = "QI-EIN")]
	QIEIN,
	[EnumMember(Value = "WP-EIN")]
	WPEIN,
	[EnumMember(Value = "WT-EIN")]
	WTEIN,
	[EnumMember(Value = "EIN")]
	EIN,
	[EnumMember(Value = "SSN")]
	SSN,
	[EnumMember(Value = "ITIN")]
	ITIN
}
