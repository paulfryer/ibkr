using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FinancialInformation
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("investmentExperience", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<AssetExperience> InvestmentExperience { get; set; } = null;

	[JsonProperty("InvestmentObjectives", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
	public ICollection<InvestmentObjectives> InvestmentObjectives { get; set; } = null;

	[JsonProperty("additionalSourcesOfIncome", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<SourceOfIncomeType> AdditionalSourcesOfIncome { get; set; } = null;

	[JsonProperty("sourcesOfWealth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<SourceOfWealthType> SourcesOfWealth { get; set; } = null;

	[JsonProperty("soiQuestionnaire", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public SOIQuestionnaire SoiQuestionnaire { get; set; } = null;

	[JsonProperty("questionnaires", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<QuestionnaireType> Questionnaires { get; set; } = null;

	[JsonProperty("netWorth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double NetWorth { get; set; } = 0.0;

	[JsonProperty("liquidNetWorth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double LiquidNetWorth { get; set; } = 0.0;

	[JsonProperty("annualNetIncome", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double AnnualNetIncome { get; set; } = 0.0;

	[JsonProperty("totalAssets", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double TotalAssets { get; set; } = 0.0;

	[JsonProperty("sourceOfFunds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SourceOfFunds { get; set; } = null;

	[JsonProperty("translated", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Translated { get; set; } = false;

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get
		{
			return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
		}
		set
		{
			_additionalProperties = value;
		}
	}
}
