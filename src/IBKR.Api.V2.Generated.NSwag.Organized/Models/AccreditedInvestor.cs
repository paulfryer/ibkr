using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccreditedInvestor
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("qualifiedPurchaser", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public QualifiedPurchaser QualifiedPurchaser { get; set; }

    [JsonProperty("eligibleContractParticipant", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public EligibleContractParticipant EligibleContractParticipant { get; set; }

    [JsonProperty("signedBy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> SignedBy { get; set; }

    [JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountId { get; set; }

    [JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Status { get; set; }

    [JsonProperty("signature", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Signature { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}