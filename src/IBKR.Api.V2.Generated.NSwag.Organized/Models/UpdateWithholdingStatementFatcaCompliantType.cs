using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum UpdateWithholdingStatementFatcaCompliantType
{
	[EnumMember(Value = "FATCA_COMPLIANT")]
	FATCA_COMPLIANT,
	[EnumMember(Value = "NON_CONSENTING_US_ACCOUNT")]
	NON_CONSENTING_US_ACCOUNT,
	[EnumMember(Value = "NON_COOPERATIVE_ACCOUNT")]
	NON_COOPERATIVE_ACCOUNT
}
