using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum AccountSupportTypeType
{
	[EnumMember(Value = "FINANCIALINSTITUTION")]
	FINANCIALINSTITUTION,
	[EnumMember(Value = "PROPRIETARYTRADING")]
	PROPRIETARYTRADING,
	[EnumMember(Value = "FAMILYINVVEHICLE")]
	FAMILYINVVEHICLE,
	[EnumMember(Value = "OPERATINGBUSINESS")]
	OPERATINGBUSINESS,
	[EnumMember(Value = "BROKERDEALER")]
	BROKERDEALER,
	[EnumMember(Value = "LICENSEDADVISOR")]
	LICENSEDADVISOR
}
