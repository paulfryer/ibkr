using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum EnumerationType
{
    [EnumMember(Value = "exchange-bundles")]
    ExchangeBundles,

    [EnumMember(Value = "business-and-occupation")]
    BusinessAndOccupation,
    [EnumMember(Value = "employee-track")] EmployeeTrack,

    [EnumMember(Value = "fin-info-ranges")]
    FinInfoRanges,
    [EnumMember(Value = "acats")] Acats,
    [EnumMember(Value = "aton")] Aton,
    [EnumMember(Value = "market-Data")] MarketData,
    [EnumMember(Value = "edd-avt")] EddAvt,

    [EnumMember(Value = "prohibited-country")]
    ProhibitedCountry,
    [EnumMember(Value = "employee-plans")] EmployeePlans,
    [EnumMember(Value = "questionnaires")] Questionnaires,

    [EnumMember(Value = "security-questions")]
    SecurityQuestions,
    [EnumMember(Value = "quiz-questions")] QuizQuestions,

    [EnumMember(Value = "wire-instructions")]
    WireInstructions,

    [EnumMember(Value = "product-country-bundles")]
    ProductCountryBundles
}