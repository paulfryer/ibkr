using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TradeConfirmationRequest
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("accountId", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string AccountId { get; set; }

    [JsonProperty("startDate", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string StartDate { get; set; }

    [JsonProperty("endDate", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string EndDate { get; set; }

    [JsonProperty("mimeType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string MimeType { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}