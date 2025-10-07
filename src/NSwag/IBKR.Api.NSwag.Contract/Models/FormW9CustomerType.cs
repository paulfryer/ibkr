using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum FormW9CustomerType
{
	[EnumMember(Value = "Individual")]
	Individual,
	[EnumMember(Value = "Corporation")]
	Corporation,
	[EnumMember(Value = "Partnership")]
	Partnership,
	[EnumMember(Value = "LLC")]
	LLC,
	[EnumMember(Value = "Other")]
	Other
}
