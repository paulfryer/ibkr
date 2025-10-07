using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class EmploymentDetails
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("employer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Employer { get; set; }

    [JsonProperty("occupation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Occupation { get; set; }

    [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("employerBusiness", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string EmployerBusiness { get; set; }

    [JsonProperty("employerAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Address EmployerAddress { get; set; }

    [JsonProperty("employerPhone", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string EmployerPhone { get; set; }

    [JsonProperty("emplCountryResCountryDetails", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string EmplCountryResCountryDetails { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}