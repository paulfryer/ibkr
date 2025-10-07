using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Combo_values
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("default", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Default { get; set; } = false;


	[JsonProperty("vendor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public object Vendor { get; set; } = null;


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
