using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class CounterpartyPermission
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("permission_name", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string Permission_name { get; set; }

    [JsonProperty("instruction_type_name", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Instruction_type_name { get; set; }

    [JsonProperty("permission_status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public CounterpartyPermissionPermission_status Permission_status { get; set; } =
        CounterpartyPermissionPermission_status.ACTIVE;

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}