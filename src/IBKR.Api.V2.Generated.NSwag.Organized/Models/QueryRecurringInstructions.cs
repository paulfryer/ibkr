using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryRecurringInstructions
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;

	[JsonProperty("accountId", Required = Required.Always)]
	[Required]
	public string AccountId { get; set; } = null;

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
