using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum CustomerType
{
	[EnumMember(Value = "INDIVIDUAL")]
	INDIVIDUAL,
	[EnumMember(Value = "JOINT")]
	JOINT,
	[EnumMember(Value = "TRUST")]
	TRUST,
	[EnumMember(Value = "UGMA")]
	UGMA,
	[EnumMember(Value = "UTMA")]
	UTMA,
	[EnumMember(Value = "ORG")]
	ORG,
	[EnumMember(Value = "IRA")]
	IRA
}
