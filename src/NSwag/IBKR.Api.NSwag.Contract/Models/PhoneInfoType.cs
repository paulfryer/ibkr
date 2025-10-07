using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum PhoneInfoType
{
	[EnumMember(Value = "Work")]
	Work,
	[EnumMember(Value = "Home")]
	Home,
	[EnumMember(Value = "Fax")]
	Fax,
	[EnumMember(Value = "Mobile")]
	Mobile,
	[EnumMember(Value = "Mobile (work)")]
	Mobile__work_,
	[EnumMember(Value = "Mobile (other)")]
	Mobile__other_,
	[EnumMember(Value = "Business")]
	Business,
	[EnumMember(Value = "Other (voice)")]
	Other__voice_
}
