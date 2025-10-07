using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Body9
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("instructionType", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public Body9InstructionType InstructionType { get; set; } = Body9InstructionType.INTERNAL_POSITION_TRANSFER;


	[JsonProperty("instruction", Required = Required.Always)]
	[Required]
	public InternalPositionTransferInstruction Instruction { get; set; } = new InternalPositionTransferInstruction();


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
