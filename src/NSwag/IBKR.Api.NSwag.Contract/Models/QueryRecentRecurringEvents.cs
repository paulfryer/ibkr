using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryRecentRecurringEvents
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;


	[JsonProperty("ibReferenceId", Required = Required.Always)]
	[Range(0.0, double.MaxValue)]
	public double IbReferenceId { get; set; } = 0.0;


	[JsonProperty("numberOfTransactions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[Range(1.0, double.MaxValue)]
	public double NumberOfTransactions { get; set; } = 0.0;


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
