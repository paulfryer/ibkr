using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountStatusRequest
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("startDate", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(DateFormatConverter))]
    public DateTimeOffset StartDate { get; set; } = default;

    [JsonProperty("endDate", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(DateFormatConverter))]
    public DateTimeOffset EndDate { get; set; } = default;

    [JsonProperty("offset", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [Range(0, int.MaxValue)]
    public int Offset { get; set; }

    [JsonProperty("limit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [Range(1, 1000)]
    public int Limit { get; set; }

    [JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AccountStatusRequestStatus Status { get; set; } = AccountStatusRequestStatus.N;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}