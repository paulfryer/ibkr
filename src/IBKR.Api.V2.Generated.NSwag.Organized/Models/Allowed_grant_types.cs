using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum Allowed_grant_types
{
	[EnumMember(Value = "client_credentials")]
	Client_credentials,
	[EnumMember(Value = "authorization_code")]
	Authorization_code,
	[EnumMember(Value = "refresh_token")]
	Refresh_token
}
