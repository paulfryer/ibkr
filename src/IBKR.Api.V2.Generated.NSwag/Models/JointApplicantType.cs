using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum JointApplicantType
{
	[EnumMember(Value = "community")]
	Community,
	[EnumMember(Value = "joint_tenants")]
	Joint_tenants,
	[EnumMember(Value = "tenants_common")]
	Tenants_common,
	[EnumMember(Value = "tbe")]
	Tbe,
	[EnumMember(Value = "au_joint_account")]
	Au_joint_account
}
