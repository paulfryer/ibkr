using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum FormW8BENEPart314B
{
	[EnumMember(Value = "CompanyMeetsOwnershipAndBaseErosionTest")]
	CompanyMeetsOwnershipAndBaseErosionTest,
	[EnumMember(Value = "TaxExemptPensionTrustOrPensionFund")]
	TaxExemptPensionTrustOrPensionFund,
	[EnumMember(Value = "CompanyMeetsDerivativeBenefitsTest")]
	CompanyMeetsDerivativeBenefitsTest,
	[EnumMember(Value = "TaxExemptOrganization")]
	TaxExemptOrganization,
	[EnumMember(Value = "CompanyWithIncomeActiveBusiness")]
	CompanyWithIncomeActiveBusiness,
	[EnumMember(Value = "PubliclyTradedCorporation")]
	PubliclyTradedCorporation,
	[EnumMember(Value = "FavorableDiscretionaryDetermination")]
	FavorableDiscretionaryDetermination,
	[EnumMember(Value = "SubsidiaryOfAPubliclyTradedCorporation")]
	SubsidiaryOfAPubliclyTradedCorporation,
	[EnumMember(Value = "Government")]
	Government,
	[EnumMember(Value = "NoLobArticleInTreaty")]
	NoLobArticleInTreaty,
	[EnumMember(Value = "Other")]
	Other
}
