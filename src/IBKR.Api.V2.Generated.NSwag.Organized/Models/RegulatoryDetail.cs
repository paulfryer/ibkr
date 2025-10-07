using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RegulatoryDetail
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("code", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public RegulatoryDetailCode Code { get; set; } = RegulatoryDetailCode.CRIMINAL;

    [JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Status { get; set; }

    [JsonProperty("details", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Details { get; set; }

    [JsonProperty("detail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Detail { get; set; }

    [JsonProperty("externalIndividualId", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalIndividualId { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}