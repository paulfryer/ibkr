using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum FormCRSControllingPersonDesignation
{
	[EnumMember(Value = "SENIOR_MGMT_OFFICER")]
	SENIOR_MGMT_OFFICER,
	[EnumMember(Value = "BY_OWNERSHIP")]
	BY_OWNERSHIP,
	[EnumMember(Value = "BY_OTHER_MEANS")]
	BY_OTHER_MEANS
}
