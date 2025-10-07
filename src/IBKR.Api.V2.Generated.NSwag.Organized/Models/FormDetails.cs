using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FormDetails
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("formNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int FormNumber { get; set; }

    [JsonProperty("sha1Checksum", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Sha1Checksum { get; set; }

    [JsonProperty("dateModified", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset DateModified { get; set; } = default;

    [JsonProperty("fileName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FileName { get; set; }

    [JsonProperty("language", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Language { get; set; }

    [JsonProperty("formName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string FormName { get; set; }

    [JsonProperty("payload", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public FormPayload Payload { get; set; }

    [JsonProperty("apiSupportedTask", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool ApiSupportedTask { get; set; }

    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }

    [JsonProperty("action", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Action { get; set; }

    [JsonProperty("acceptableDocs", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string> AcceptableDocs { get; set; }

    [JsonProperty("questionnaire", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<QuestionnaireResponse> Questionnaire { get; set; }

    [JsonProperty("error", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ErrorResponse Error { get; set; }

    [JsonProperty("hasError", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool HasError { get; set; }

    [JsonProperty("errorDescription", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ErrorDescription { get; set; }

    [JsonProperty("fileLength", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public long FileLength { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}