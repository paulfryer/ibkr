using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IRABeneficiariesType
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("primaryBeneficiaries", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IRAPrimaryBeneficiary> PrimaryBeneficiaries { get; set; }

    [JsonProperty("primaryBeneficiaryEntities", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IRAPrimaryBeneficiaryEntity> PrimaryBeneficiaryEntities { get; set; }

    [JsonProperty("contingentBeneficiaries", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IRAContingentBeneficiary> ContingentBeneficiaries { get; set; }

    [JsonProperty("contingentBeneficiaryEntities", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<IRAContingentBeneficiaryEntity> ContingentBeneficiaryEntities { get; set; }

    [JsonProperty("spousePrimaryBeneficary", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool SpousePrimaryBeneficary { get; set; }

    [JsonProperty("successor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Successor { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}