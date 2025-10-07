using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum DocumentProofOfIdentityType
{
    [EnumMember(Value = "Driver License")] Driver_License,
    [EnumMember(Value = "Passport")] Passport,
    [EnumMember(Value = "Alien ID Card")] Alien_ID_Card,

    [EnumMember(Value = "National ID Card")]
    National_ID_Card,
    [EnumMember(Value = "Bank Statement")] Bank_Statement,

    [EnumMember(Value = "Evidence of Ownership of Property")]
    Evidence_of_Ownership_of_Property,

    [EnumMember(Value = "Credit Card Statement")]
    Credit_Card_Statement,
    [EnumMember(Value = "Utility Bill")] Utility_Bill,

    [EnumMember(Value = "Brokerage Statement")]
    Brokerage_Statement,
    [EnumMember(Value = "T4 Statement")] T4_Statement,
    [EnumMember(Value = "CRA Assessment")] CRA_Assessment,

    [EnumMember(Value = "Hong Kong and Macao Entry Permit")]
    Hong_Kong_and_Macao_Entry_Permit
}