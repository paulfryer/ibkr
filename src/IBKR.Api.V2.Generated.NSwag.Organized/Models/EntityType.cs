using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum EntityType
{
    [EnumMember(Value = "INDIVIDUAL")] INDIVIDUAL,
    [EnumMember(Value = "Joint")] Joint,
    [EnumMember(Value = "ORG")] ORG
}