using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Customer
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("organization", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public OrganizationApplicant Organization { get; set; }

    [JsonProperty("accountHolder", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IndividualApplicant AccountHolder { get; set; }

    [JsonProperty("jointHolders", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public JointApplicant JointHolders { get; set; }

    [JsonProperty("trust", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public TrustApplicant Trust { get; set; }

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalId { get; set; }

    [JsonProperty("transferUsMicroCapStock", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool TransferUsMicroCapStock { get; set; }

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public CustomerType Type { get; set; } = CustomerType.INDIVIDUAL;

    [JsonProperty("prefix", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Prefix { get; set; }

    [JsonProperty("userName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string UserName { get; set; }

    [JsonProperty("userNameAlias", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string UserNameAlias { get; set; }

    [JsonProperty("userNameSource", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string UserNameSource { get; set; }

    [JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Email { get; set; }

    [JsonProperty("mdStatusNonPro", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool MdStatusNonPro { get; set; }

    [JsonProperty("preferredPrimaryLanguage", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string PreferredPrimaryLanguage { get; set; }

    [JsonProperty("preferredSecondaryLanguage", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string PreferredSecondaryLanguage { get; set; }

    [JsonProperty("legalResidenceCountry", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string LegalResidenceCountry { get; set; }

    [JsonProperty("taxTreatyCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string TaxTreatyCountry { get; set; }

    [JsonProperty("meetAmlStandard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MeetAmlStandard { get; set; }

    [JsonProperty("meetsAmlStandard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MeetsAmlStandard { get; set; }

    [JsonProperty("directTradingAccess", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool DirectTradingAccess { get; set; }

    [JsonProperty("originCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string OriginCountry { get; set; }

    [JsonProperty("terminationAge", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int TerminationAge { get; set; }

    [JsonProperty("governingState", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string GoverningState { get; set; }

    [JsonProperty("optForDebitCard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool OptForDebitCard { get; set; }

    [JsonProperty("roboFaClient", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool RoboFaClient { get; set; }

    [JsonProperty("independentAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool IndependentAccount { get; set; }

    [JsonProperty("paperAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool PaperAccount { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}