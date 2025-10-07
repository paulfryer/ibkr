using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum SourceOfIncomeTypeSourceType
{
    [EnumMember(Value = "CONSULTING")] CONSULTING,
    [EnumMember(Value = "DISABILITY")] DISABILITY,
    [EnumMember(Value = "INHERITANCE")] INHERITANCE,
    [EnumMember(Value = "INTEREST")] INTEREST,
    [EnumMember(Value = "REALESTATE")] REALESTATE,
    [EnumMember(Value = "RENTAL")] RENTAL,
    [EnumMember(Value = "SEVERANCE")] SEVERANCE,
    [EnumMember(Value = "SPOUSE")] SPOUSE,

    [EnumMember(Value = "TRADINGANDINVESTMENTS")]
    TRADINGANDINVESTMENTS,

    [EnumMember(Value = "PENSIONANDSOCIALSECURITY")]
    PENSIONANDSOCIALSECURITY,
    [EnumMember(Value = "UNEMPLOYMENT")] UNEMPLOYMENT,
    [EnumMember(Value = "OTHER")] OTHER
}