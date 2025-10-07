using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Contributions
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("maximumContributionLimit", Required = Required.Always)]
    public double MaximumContributionLimit { get; set; }

    [JsonProperty("yearToDateContribution", Required = Required.Always)]
    public double YearToDateContribution { get; set; }

    [JsonProperty("allowedContributionLimit", Required = Required.Always)]
    public double AllowedContributionLimit { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}