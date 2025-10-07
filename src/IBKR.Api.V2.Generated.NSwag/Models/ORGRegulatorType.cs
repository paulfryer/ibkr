using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ORGRegulatorType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("regulatorName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string RegulatorName { get; set; } = null;


	[JsonProperty("regulatorCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string RegulatorCountry { get; set; } = null;


	[JsonProperty("regulatedInCapacity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string RegulatedInCapacity { get; set; } = null;


	[JsonProperty("regulatorId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string RegulatorId { get; set; } = null;


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
