using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FinancialInformation
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("investmentExperience", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AssetExperience> InvestmentExperience { get; set; }

    [JsonProperty("InvestmentObjectives", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
    public ICollection<InvestmentObjectives> InvestmentObjectives { get; set; }

    [JsonProperty("additionalSourcesOfIncome", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<SourceOfIncomeType> AdditionalSourcesOfIncome { get; set; }

    [JsonProperty("sourcesOfWealth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<SourceOfWealthType> SourcesOfWealth { get; set; }

    [JsonProperty("soiQuestionnaire", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public SOIQuestionnaire SoiQuestionnaire { get; set; }

    [JsonProperty("questionnaires", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<QuestionnaireType> Questionnaires { get; set; }

    [JsonProperty("netWorth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double NetWorth { get; set; }

    [JsonProperty("liquidNetWorth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double LiquidNetWorth { get; set; }

    [JsonProperty("annualNetIncome", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double AnnualNetIncome { get; set; }

    [JsonProperty("totalAssets", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public double TotalAssets { get; set; }

    [JsonProperty("sourceOfFunds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string SourceOfFunds { get; set; }

    [JsonProperty("translated", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Translated { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}