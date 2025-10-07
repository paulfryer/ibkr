using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FyiEnableDeviceOption
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("deviceName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DeviceName { get; set; } = null;

	[JsonProperty("deviceId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DeviceId { get; set; } = null;

	[JsonProperty("uiName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string UiName { get; set; } = null;

	[JsonProperty("enabled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Enabled { get; set; } = false;

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get
		{
			return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
		}
		set
		{
			_additionalProperties = value;
		}
	}
}
