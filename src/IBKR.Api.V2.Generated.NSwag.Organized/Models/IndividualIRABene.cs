using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IndividualIRABene
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("firstName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FirstName { get; set; }

    [JsonProperty("lastName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string LastName { get; set; }

    [JsonProperty("dateOfBirth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DateOfBirth { get; set; }

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }

    [JsonProperty("identification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> Identification { get; set; }

    [JsonProperty("location", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> Location { get; set; }

    [JsonProperty("relationship", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Relationship { get; set; }

    [JsonProperty("ownership", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Ownership { get; set; }

    [JsonProperty("perStripes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string PerStripes { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}