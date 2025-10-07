using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class InstructionPollingResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("status", Required = Required.Always)]
	public double Status { get; set; } = 0.0;

	[JsonProperty("instructionSetId", Required = Required.Always)]
	public double InstructionSetId { get; set; } = 0.0;

	[JsonProperty("instructionResult", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public PollingInstructionResult InstructionResult { get; set; } = null;

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
