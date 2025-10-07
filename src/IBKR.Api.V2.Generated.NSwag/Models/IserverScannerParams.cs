using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IserverScannerParams
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("scan_type_list", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<Scan_type_list> Scan_type_list { get; set; } = null;


	[JsonProperty("instrument_list", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<Instrument_list> Instrument_list { get; set; } = null;


	[JsonProperty("filter_list", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<Filter_list> Filter_list { get; set; } = null;


	[JsonProperty("location_tree", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<Location_tree> Location_tree { get; set; } = null;


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
