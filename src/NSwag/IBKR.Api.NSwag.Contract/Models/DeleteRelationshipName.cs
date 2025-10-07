using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum DeleteRelationshipName
{
	[EnumMember(Value = "Account_Holder")]
	Account_Holder,
	[EnumMember(Value = "Spouse")]
	Spouse,
	[EnumMember(Value = "Firstholder")]
	Firstholder,
	[EnumMember(Value = "Secondholder")]
	Secondholder,
	[EnumMember(Value = "Trader")]
	Trader,
	[EnumMember(Value = "Secretary")]
	Secretary,
	[EnumMember(Value = "Treasurer")]
	Treasurer,
	[EnumMember(Value = "Ceo")]
	Ceo,
	[EnumMember(Value = "Owner")]
	Owner,
	[EnumMember(Value = "Trustee")]
	Trustee,
	[EnumMember(Value = "Beneficiary")]
	Beneficiary,
	[EnumMember(Value = "Grantor")]
	Grantor,
	[EnumMember(Value = "Director")]
	Director,
	[EnumMember(Value = "Principal")]
	Principal,
	[EnumMember(Value = "Shareholder")]
	Shareholder,
	[EnumMember(Value = "Partner")]
	Partner,
	[EnumMember(Value = "Controlling_Officer")]
	Controlling_Officer,
	[EnumMember(Value = "Beneficialowner")]
	Beneficialowner,
	[EnumMember(Value = "Signatory")]
	Signatory,
	[EnumMember(Value = "Comp_Officer")]
	Comp_Officer,
	[EnumMember(Value = "Superv_Broker")]
	Superv_Broker,
	[EnumMember(Value = "Pooled_User")]
	Pooled_User,
	[EnumMember(Value = "Financial_User")]
	Financial_User,
	[EnumMember(Value = "Contingent")]
	Contingent,
	[EnumMember(Value = "Ira_Beneficiary")]
	Ira_Beneficiary,
	[EnumMember(Value = "Employee")]
	Employee,
	[EnumMember(Value = "Non_Employee")]
	Non_Employee,
	[EnumMember(Value = "Fund_Admin")]
	Fund_Admin,
	[EnumMember(Value = "Fund_Contact")]
	Fund_Contact,
	[EnumMember(Value = "Firm_Admin")]
	Firm_Admin,
	[EnumMember(Value = "Firm_Billing")]
	Firm_Billing,
	[EnumMember(Value = "Firm_Clearing")]
	Firm_Clearing,
	[EnumMember(Value = "Firm_Sales")]
	Firm_Sales,
	[EnumMember(Value = "Firm_Trading")]
	Firm_Trading,
	[EnumMember(Value = "Firm_User")]
	Firm_User,
	[EnumMember(Value = "Account_Admin")]
	Account_Admin,
	[EnumMember(Value = "Account_Billing")]
	Account_Billing,
	[EnumMember(Value = "Account_Clearing")]
	Account_Clearing,
	[EnumMember(Value = "Account_Sales")]
	Account_Sales,
	[EnumMember(Value = "Account_Trading")]
	Account_Trading,
	[EnumMember(Value = "User_Individual")]
	User_Individual,
	[EnumMember(Value = "Fund_Manager")]
	Fund_Manager,
	[EnumMember(Value = "Investment_Advisor")]
	Investment_Advisor,
	[EnumMember(Value = "Shf_Investmanager")]
	Shf_Investmanager,
	[EnumMember(Value = "Advisory_Principal")]
	Advisory_Principal,
	[EnumMember(Value = "Advisory_Signatory")]
	Advisory_Signatory,
	[EnumMember(Value = "Associated_Fund")]
	Associated_Fund,
	[EnumMember(Value = "Primary_Contributor")]
	Primary_Contributor,
	[EnumMember(Value = "Administrator")]
	Administrator,
	[EnumMember(Value = "Contact")]
	Contact,
	[EnumMember(Value = "Lead_Compliance_Officer")]
	Lead_Compliance_Officer,
	[EnumMember(Value = "Compliance_Officer")]
	Compliance_Officer,
	[EnumMember(Value = "Other_Officer")]
	Other_Officer,
	[EnumMember(Value = "Apply_User")]
	Apply_User,
	[EnumMember(Value = "Transfer_On_Death_Legator")]
	Transfer_On_Death_Legator,
	[EnumMember(Value = "Tod_Primary_Beneficiary")]
	Tod_Primary_Beneficiary,
	[EnumMember(Value = "Tod_Contingent_Beneficiary")]
	Tod_Contingent_Beneficiary,
	[EnumMember(Value = "Nominee")]
	Nominee,
	[EnumMember(Value = "Nominee_Guardian")]
	Nominee_Guardian,
	[EnumMember(Value = "Ira_Decedent")]
	Ira_Decedent,
	[EnumMember(Value = "Authorized_Person")]
	Authorized_Person,
	[EnumMember(Value = "Promoter")]
	Promoter,
	[EnumMember(Value = "Wholetime_Director")]
	Wholetime_Director,
	[EnumMember(Value = "Nominee_Owner")]
	Nominee_Owner,
	[EnumMember(Value = "Third_Party_Admin")]
	Third_Party_Admin,
	[EnumMember(Value = "Compliance_Contact")]
	Compliance_Contact,
	[EnumMember(Value = "Trust_Controller")]
	Trust_Controller,
	[EnumMember(Value = "Trust_Applicant")]
	Trust_Applicant,
	[EnumMember(Value = "Organization_Applicant")]
	Organization_Applicant,
	[EnumMember(Value = "Mm_Contact")]
	Mm_Contact,
	[EnumMember(Value = "Reg_Rep")]
	Reg_Rep,
	[EnumMember(Value = "Plan_Sponsor")]
	Plan_Sponsor,
	[EnumMember(Value = "Plan_Sponsor_Officer")]
	Plan_Sponsor_Officer,
	[EnumMember(Value = "Pension_Admin")]
	Pension_Admin,
	[EnumMember(Value = "Pension_Admin_Contact")]
	Pension_Admin_Contact,
	[EnumMember(Value = "Accountant")]
	Accountant,
	[EnumMember(Value = "Joint_Applicant")]
	Joint_Applicant,
	[EnumMember(Value = "Custodian_Employee")]
	Custodian_Employee,
	[EnumMember(Value = "Successor_Custodian")]
	Successor_Custodian,
	[EnumMember(Value = "Custodian")]
	Custodian,
	[EnumMember(Value = "Successor_Custodian_Employee")]
	Successor_Custodian_Employee,
	[EnumMember(Value = "Chief_Compliance_Officer")]
	Chief_Compliance_Officer,
	[EnumMember(Value = "Chief_Financial_Officer")]
	Chief_Financial_Officer,
	[EnumMember(Value = "Trading_Officer")]
	Trading_Officer,
	[EnumMember(Value = "Child")]
	Child,
	[EnumMember(Value = "Parent")]
	Parent,
	[EnumMember(Value = "Sibling")]
	Sibling,
	[EnumMember(Value = "Estate")]
	Estate,
	[EnumMember(Value = "As_Interest_May_Appear")]
	As_Interest_May_Appear,
	[EnumMember(Value = "Ira_Present_Trust")]
	Ira_Present_Trust,
	[EnumMember(Value = "Other")]
	Other,
	[EnumMember(Value = "Life_Partner")]
	Life_Partner,
	[EnumMember(Value = "Common_Law_Partner")]
	Common_Law_Partner,
	[EnumMember(Value = "Grandchild")]
	Grandchild,
	[EnumMember(Value = "Charity")]
	Charity,
	[EnumMember(Value = "Trust_Ira")]
	Trust_Ira,
	[EnumMember(Value = "Successor_Holder")]
	Successor_Holder,
	[EnumMember(Value = "Head_Of_Desk")]
	Head_Of_Desk,
	[EnumMember(Value = "Cftc_Non_Applicant_Ocr_Contact")]
	Cftc_Non_Applicant_Ocr_Contact,
	[EnumMember(Value = "Ocr_Account_Controller")]
	Ocr_Account_Controller,
	[EnumMember(Value = "Cftc_Applicant_Ocr_Contact")]
	Cftc_Applicant_Ocr_Contact
}
