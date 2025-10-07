using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Anonymous5
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("bondid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Bondid { get; set; }

    [JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Conid { get; set; }

    [JsonProperty("companyHeader", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyHeader { get; set; }

    [JsonProperty("companyName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyName { get; set; }

    [JsonProperty("symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Symbol { get; set; }

    [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("restricted", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public bool? Restricted { get; set; }

    [JsonProperty("fop", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public string? Fop { get; set; }

    [JsonProperty("opt", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public string? Opt { get; set; }

    [JsonProperty("war", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    public string? War { get; set; }

    [JsonProperty("sections", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Sections> Sections { get; set; }

    [JsonProperty("issuers", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Issuers> Issuers { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}