using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum EchoResponseSecurityPolicy
{
	[EnumMember(Value = "HTTPS")]
	HTTPS,
	[EnumMember(Value = "SIGNED_JWT")]
	SIGNED_JWT,
	[EnumMember(Value = "ENCRYPTED_JWE")]
	ENCRYPTED_JWE
}
