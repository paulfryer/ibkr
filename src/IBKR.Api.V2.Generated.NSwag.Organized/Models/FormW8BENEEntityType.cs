using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum FormW8BENEEntityType
{
	[EnumMember(Value = "CORPORATION")]
	CORPORATION,
	[EnumMember(Value = "DISREGARDED_ENTITY")]
	DISREGARDED_ENTITY,
	[EnumMember(Value = "PARTNERSHIP")]
	PARTNERSHIP,
	[EnumMember(Value = "SIMPLE_TRUST")]
	SIMPLE_TRUST,
	[EnumMember(Value = "GRANTOR_TRUST")]
	GRANTOR_TRUST,
	[EnumMember(Value = "COMPLEX_TRUST")]
	COMPLEX_TRUST,
	[EnumMember(Value = "ESTATE")]
	ESTATE,
	[EnumMember(Value = "GOVERNMENT")]
	GOVERNMENT,
	[EnumMember(Value = "CENTRAL_BANK_OF_ISSUE")]
	CENTRAL_BANK_OF_ISSUE,
	[EnumMember(Value = "TAX_EXEMPT_ORGANIZATION")]
	TAX_EXEMPT_ORGANIZATION,
	[EnumMember(Value = "PRIVATE_FOUNDATION")]
	PRIVATE_FOUNDATION
}
