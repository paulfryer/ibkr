using System.CodeDom.Compiler;
using System.Runtime.Serialization;
using IBKR.Api.NSwag.Contract.Models;

namespace IBKR.Api.NSwag.Contract.Clients;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum ClientConfigurationAccount_selection_mode
{
	[EnumMember(Value = "SINGLE")]
	SINGLE,
	[EnumMember(Value = "MULTIPLE")]
	MULTIPLE
}
