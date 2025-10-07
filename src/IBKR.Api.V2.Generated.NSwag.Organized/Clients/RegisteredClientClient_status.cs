using System.CodeDom.Compiler;
using System.Runtime.Serialization;
using IBKR.Api.V2.Generated.NSwag.Models;

namespace IBKR.Api.V2.Generated.NSwag.Clients;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum RegisteredClientClient_status
{
	[EnumMember(Value = "REQUESTED")]
	REQUESTED,
	[EnumMember(Value = "ACTIVE")]
	ACTIVE,
	[EnumMember(Value = "REVOKED")]
	REVOKED,
	[EnumMember(Value = "UNKNOWN")]
	UNKNOWN
}
