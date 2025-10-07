using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountDetailsResponse
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("error", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ErrorResponse Error { get; set; }

    [JsonProperty("hasError", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool HasError { get; set; }

    [JsonProperty("errorDescription", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ErrorDescription { get; set; }

    [JsonProperty("account", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AccountData Account { get; set; }

    [JsonProperty("associatedPersons", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AssociatedPerson> AssociatedPersons { get; set; }

    [JsonProperty("associatedEntities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<AssociatedEntity> AssociatedEntities { get; set; }

    [JsonProperty("withHoldingStatement", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> WithHoldingStatement { get; set; }

    [JsonProperty("marketData", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IDictionary<string, string>> MarketData { get; set; }

    [JsonProperty("financialInformation", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, object> FinancialInformation { get; set; }

    [JsonProperty("sourcesOfWealth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IDictionary<string, object>> SourcesOfWealth { get; set; }

    [JsonProperty("tradeBundles", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> TradeBundles { get; set; }

    [JsonProperty("individualIRABeneficiaries", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IndividualIRABene> IndividualIRABeneficiaries { get; set; }

    [JsonProperty("entityIRABeneficiaries", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<EntityIRABene> EntityIRABeneficiaries { get; set; }

    [JsonProperty("decedents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IDictionary<string, string>> Decedents { get; set; }

    [JsonProperty("restrictions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<RestrictionInfo> Restrictions { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}