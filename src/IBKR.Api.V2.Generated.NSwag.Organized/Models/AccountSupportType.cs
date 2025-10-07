using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountSupportType
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("businessDescription", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string BusinessDescription { get; set; }

    [JsonProperty("primaryContributor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public PrimaryContributorType PrimaryContributor { get; set; }

    [JsonProperty("administrator", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AdministratorType Administrator { get; set; }

    [JsonProperty("administratorContactPerson", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public AdministratorContactPersonType AdministratorContactPerson { get; set; }

    [JsonProperty("ownersResideUS", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool OwnersResideUS { get; set; }

    [JsonProperty("solicitOwnersResideUS", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool SolicitOwnersResideUS { get; set; }

    [JsonProperty("acceptOwnersResideUS", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool AcceptOwnersResideUS { get; set; }

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AccountSupportTypeType Type { get; set; } = AccountSupportTypeType.FINANCIALINSTITUTION;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}