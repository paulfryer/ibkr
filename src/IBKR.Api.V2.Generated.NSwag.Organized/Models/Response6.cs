using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Response6
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("total", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Total { get; set; } = 0;

	[JsonProperty("size", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Size { get; set; } = 0;

	[JsonProperty("offset", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Offset { get; set; } = 0;

	[JsonProperty("scanTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ScanTime { get; set; } = null;

	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Id { get; set; } = null;

	[JsonProperty("position", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Position { get; set; } = null;

	[JsonProperty("warningText", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string WarningText { get; set; } = null;

	[JsonProperty("Contracts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Contracts2 Contracts { get; set; } = null;

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
