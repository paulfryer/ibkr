using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Data3
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("dataType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DataType { get; set; } = null;

	[JsonProperty("encoding", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Encoding { get; set; } = null;

	[JsonProperty("value", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Value { get; set; } = null;

	[JsonProperty("mimeType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MimeType { get; set; } = null;

	[JsonProperty("gzip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Gzip { get; set; } = false;

	[JsonProperty("accept", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Accept { get; set; } = null;

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
