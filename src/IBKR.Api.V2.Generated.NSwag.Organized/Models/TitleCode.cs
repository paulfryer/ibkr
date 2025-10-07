using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum TitleCode
{
    [EnumMember(Value = "Account Holder")] Account_Holder,
    [EnumMember(Value = "FIRST HOLDER")] FIRST_HOLDER,
    [EnumMember(Value = "SECOND HOLDER")] SECOND_HOLDER,
    [EnumMember(Value = "TRADER")] TRADER,
    [EnumMember(Value = "CEO")] CEO,
    [EnumMember(Value = "SECRETARY")] SECRETARY,
    [EnumMember(Value = "TREASURER")] TREASURER,
    [EnumMember(Value = "OWNER")] OWNER,
    [EnumMember(Value = "PRINCIPAL")] PRINCIPAL,
    [EnumMember(Value = "SHAREHOLDER")] SHAREHOLDER,
    [EnumMember(Value = "TRUSTEE")] TRUSTEE,
    [EnumMember(Value = "BENEFICIARY")] BENEFICIARY,
    [EnumMember(Value = "GRANTOR")] GRANTOR,
    [EnumMember(Value = "Employee")] Employee,
    [EnumMember(Value = "CONTINGENT")] CONTINGENT,

    [EnumMember(Value = "IRA_BENEFICIARY")]
    IRA_BENEFICIARY,
    [EnumMember(Value = "IRA DECEDENT")] IRA_DECEDENT,
    [EnumMember(Value = "COMP_OFFICER")] COMP_OFFICER,
    [EnumMember(Value = "Other Officer")] Other_Officer,

    [EnumMember(Value = "Controlling Officer")]
    Controlling_Officer,
    [EnumMember(Value = "SIGNATORY")] SIGNATORY,
    [EnumMember(Value = "NON-EMPLOYEE")] NONEMPLOYEE,
    [EnumMember(Value = "CUSTODIAN")] CUSTODIAN,

    [EnumMember(Value = "SUCCESSOR_CUSTODIAN")]
    SUCCESSOR_CUSTODIAN,
    [EnumMember(Value = "DIRECTOR")] DIRECTOR,
    [EnumMember(Value = "PARTNER")] PARTNER,

    [EnumMember(Value = "CUSTODIAN EMPLOYEE")]
    CUSTODIAN_EMPLOYEE,

    [EnumMember(Value = "SUCCESSOR CUSTODIAN EMPLOYEE")]
    SUCCESSOR_CUSTODIAN_EMPLOYEE,
    [EnumMember(Value = "SPOUSE")] SPOUSE,

    [EnumMember(Value = "Successor Holder")]
    Successor_Holder,

    [EnumMember(Value = "Registered Contact")]
    Registered_Contact
}