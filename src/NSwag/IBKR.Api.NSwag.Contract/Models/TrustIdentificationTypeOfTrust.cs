using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum TrustIdentificationTypeOfTrust
{
	[EnumMember(Value = "IRREVOC")]
	IRREVOC,
	[EnumMember(Value = "SMSF")]
	SMSF,
	[EnumMember(Value = "REVOCABLE")]
	REVOCABLE,
	[EnumMember(Value = "TESTAMENTARY")]
	TESTAMENTARY,
	[EnumMember(Value = "RETIREMENT")]
	RETIREMENT,
	[EnumMember(Value = "ERISA")]
	ERISA,
	[EnumMember(Value = "OTHER")]
	OTHER
}
