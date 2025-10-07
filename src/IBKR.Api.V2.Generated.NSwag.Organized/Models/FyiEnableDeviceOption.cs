using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FyiEnableDeviceOption
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("deviceName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DeviceName { get; set; }

    [JsonProperty("deviceId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DeviceId { get; set; }

    [JsonProperty("uiName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string UiName { get; set; }

    [JsonProperty("enabled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Enabled { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}