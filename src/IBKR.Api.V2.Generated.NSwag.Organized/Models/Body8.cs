using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Body8
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("instructionType", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public Body8InstructionType InstructionType { get; set; } = Body8InstructionType.QUERY_RECENT_INSTRUCTIONS;

	[JsonProperty("instruction", Required = Required.Always)]
	[Required]
	public QueryRecentInstructions Instruction { get; set; } = new QueryRecentInstructions();

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
