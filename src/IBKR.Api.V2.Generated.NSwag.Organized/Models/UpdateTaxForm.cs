using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class UpdateTaxForm
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("localTaxForms", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<LocalTaxForm> LocalTaxForms { get; set; }

    [JsonProperty("w8Ben", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public FormW8BEN W8Ben { get; set; }

    [JsonProperty("w8BenE", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public FormW8BENE W8BenE { get; set; }

    [JsonProperty("w9", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public FormW9 W9 { get; set; }

    [JsonProperty("translation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Translation { get; set; }

    [JsonProperty("inputLanguage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public UpdateTaxFormInputLanguage InputLanguage { get; set; } = UpdateTaxFormInputLanguage.En;

    [JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string AccountId { get; set; }

    [JsonProperty("documents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<Document> Documents { get; set; }

    [JsonProperty("entityId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string EntityId { get; set; }

    [JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalId { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}