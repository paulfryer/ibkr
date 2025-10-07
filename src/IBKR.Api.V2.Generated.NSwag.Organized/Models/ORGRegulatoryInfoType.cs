using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ORGRegulatoryInfoType
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("publicCompanyInfo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public PublicCompanyInfoType PublicCompanyInfo { get; set; }

    [JsonProperty("orgRegulators", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<ORGRegulatorType> OrgRegulators { get; set; }

    [JsonProperty("regulated", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Regulated { get; set; }

    [JsonProperty("public", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Public { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}