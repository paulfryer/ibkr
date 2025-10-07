using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class HmdsScannerRunRequest
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("instrument", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Instrument { get; set; } = null;

	[JsonProperty("Locations", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Locations { get; set; } = null;

	[JsonProperty("scanCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ScanCode { get; set; } = null;

	[JsonProperty("secType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SecType { get; set; } = null;

	[JsonProperty("delayedLocations", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DelayedLocations { get; set; } = null;

	[JsonProperty("maxItems", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int MaxItems { get; set; } = 250;

	[JsonProperty("filters", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<object> Filters { get; set; } = null;

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
