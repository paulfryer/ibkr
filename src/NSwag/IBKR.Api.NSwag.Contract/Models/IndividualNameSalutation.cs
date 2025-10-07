using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum IndividualNameSalutation
{
	[EnumMember(Value = "Mr.")]
	Mr_,
	[EnumMember(Value = "Mrs.")]
	Mrs_,
	[EnumMember(Value = "Ms.")]
	Ms_,
	[EnumMember(Value = "Dr.")]
	Dr_,
	[EnumMember(Value = "Mx.")]
	Mx_,
	[EnumMember(Value = "Ind.")]
	Ind_
}
