using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class InstructionResult
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;


	[JsonProperty("instructionType", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public InstructionResultInstructionType InstructionType { get; set; } = InstructionResultInstructionType.ACH_INSTRUCTION;


	[JsonProperty("instructionStatus", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public InstructionResultInstructionStatus InstructionStatus { get; set; } = InstructionResultInstructionStatus.PENDING;


	[JsonProperty("instructionId", Required = Required.Always)]
	public double InstructionId { get; set; } = 0.0;


	[JsonProperty("ibReferenceId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double IbReferenceId { get; set; } = 0.0;


	[JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Description { get; set; } = null;


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
