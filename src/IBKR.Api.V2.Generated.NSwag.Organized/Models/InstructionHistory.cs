using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class InstructionHistory
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("historyMaxDepthNumberOfDays", Required = Required.Always)]
	public int HistoryMaxDepthNumberOfDays { get; set; } = 0;

	[JsonProperty("historyMaxDepthNumberOfInstruction", Required = Required.Always)]
	public int HistoryMaxDepthNumberOfInstruction { get; set; } = 0;

	[JsonProperty("result", Required = Required.Always)]
	[Required]
	public ICollection<object> Result { get; set; } = new Collection<object>();

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
