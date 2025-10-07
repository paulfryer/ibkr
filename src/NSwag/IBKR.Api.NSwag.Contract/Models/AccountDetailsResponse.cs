using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountDetailsResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("error", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ErrorResponse Error { get; set; } = null;


	[JsonProperty("hasError", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool HasError { get; set; } = false;


	[JsonProperty("errorDescription", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ErrorDescription { get; set; } = null;


	[JsonProperty("account", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccountData Account { get; set; } = null;


	[JsonProperty("associatedPersons", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<AssociatedPerson> AssociatedPersons { get; set; } = null;


	[JsonProperty("associatedEntities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<AssociatedEntity> AssociatedEntities { get; set; } = null;


	[JsonProperty("withHoldingStatement", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, string> WithHoldingStatement { get; set; } = null;


	[JsonProperty("marketData", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IDictionary<string, string>> MarketData { get; set; } = null;


	[JsonProperty("financialInformation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, object> FinancialInformation { get; set; } = null;


	[JsonProperty("sourcesOfWealth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IDictionary<string, object>> SourcesOfWealth { get; set; } = null;


	[JsonProperty("tradeBundles", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> TradeBundles { get; set; } = null;


	[JsonProperty("individualIRABeneficiaries", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IndividualIRABene> IndividualIRABeneficiaries { get; set; } = null;


	[JsonProperty("entityIRABeneficiaries", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<EntityIRABene> EntityIRABeneficiaries { get; set; } = null;


	[JsonProperty("decedents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IDictionary<string, string>> Decedents { get; set; } = null;


	[JsonProperty("restrictions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<RestrictionInfo> Restrictions { get; set; } = null;


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
