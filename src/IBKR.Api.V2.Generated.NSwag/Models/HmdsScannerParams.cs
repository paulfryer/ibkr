using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class HmdsScannerParams
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("scan_type_list", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<object> Scan_type_list { get; set; } = null;


	[JsonProperty("instrument_list", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<object> Instrument_list { get; set; } = null;


	[JsonProperty("location_tree", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<object> Location_tree { get; set; } = null;


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
