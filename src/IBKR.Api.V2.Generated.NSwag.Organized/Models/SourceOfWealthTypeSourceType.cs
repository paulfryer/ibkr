using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum SourceOfWealthTypeSourceType
{
	[EnumMember(Value = "SOW-IND-Allowance")]
	SOWINDAllowance,
	[EnumMember(Value = "SOW-IND-Disability")]
	SOWINDDisability,
	[EnumMember(Value = "SOW-IND-Income")]
	SOWINDIncome,
	[EnumMember(Value = "SOW-IND-Inheritance")]
	SOWINDInheritance,
	[EnumMember(Value = "SOW-IND-Interest")]
	SOWINDInterest,
	[EnumMember(Value = "SOW-IND-MarketProfit")]
	SOWINDMarketProfit,
	[EnumMember(Value = "SOW-IND-Other")]
	SOWINDOther,
	[EnumMember(Value = "SOW-IND-Pension")]
	SOWINDPension,
	[EnumMember(Value = "SOW-IND-Property")]
	SOWINDProperty,
	[EnumMember(Value = "SOW-ORG-Business")]
	SOWORGBusiness,
	[EnumMember(Value = "SOW-ORG-MarketTradingProfits")]
	SOWORGMarketTradingProfits,
	[EnumMember(Value = "SOW-ORG-Other")]
	SOWORGOther,
	[EnumMember(Value = "SOW-ORG-OwnerEquity")]
	SOWORGOwnerEquity,
	[EnumMember(Value = "SOW-ORG-Property")]
	SOWORGProperty,
	[EnumMember(Value = "SOW-ORG-RetainedEarnings")]
	SOWORGRetainedEarnings
}
