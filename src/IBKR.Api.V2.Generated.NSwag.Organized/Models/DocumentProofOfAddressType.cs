using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum DocumentProofOfAddressType
{
    [EnumMember(Value = "Driver License")] Driver_License,
    [EnumMember(Value = "Bank Statement")] Bank_Statement,

    [EnumMember(Value = "Brokerage Statement")]
    Brokerage_Statement,

    [EnumMember(Value = "Homeowner Insurance Policy Bill")]
    Homeowner_Insurance_Policy_Bill,

    [EnumMember(Value = "Homeowner Insurance Policy Document")]
    Homeowner_Insurance_Policy_Document,

    [EnumMember(Value = "Renter Insurance Policy bill")]
    Renter_Insurance_Policy_bill,

    [EnumMember(Value = "Renter Insurance Policy Document")]
    Renter_Insurance_Policy_Document,

    [EnumMember(Value = "Security System Bill")]
    Security_System_Bill,

    [EnumMember(Value = "Government Issued Letters")]
    Government_Issued_Letters,
    [EnumMember(Value = "Utility Bill")] Utility_Bill,
    [EnumMember(Value = "Current Lease")] Current_Lease,

    [EnumMember(Value = "Evidence of Ownership of Property")]
    Evidence_of_Ownership_of_Property,
    [EnumMember(Value = "Other Document")] Other_Document
}