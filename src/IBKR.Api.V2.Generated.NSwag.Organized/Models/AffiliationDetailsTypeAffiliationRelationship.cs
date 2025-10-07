using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum AffiliationDetailsTypeAffiliationRelationship
{
	[EnumMember(Value = "Self")]
	Self,
	[EnumMember(Value = "Spouse")]
	Spouse,
	[EnumMember(Value = "Parent")]
	Parent,
	[EnumMember(Value = "Child")]
	Child,
	[EnumMember(Value = "Other")]
	Other
}
