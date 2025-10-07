using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccreditedInvestorInformation
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("q1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Q1 { get; set; } = false;


	[JsonProperty("q2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Q2 { get; set; } = false;


	[JsonProperty("q3", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Q3 { get; set; } = false;


	[JsonProperty("q4", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Q4 { get; set; } = false;


	[JsonProperty("q5", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Q5 { get; set; } = false;


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
