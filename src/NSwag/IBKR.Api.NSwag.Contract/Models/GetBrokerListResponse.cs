using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class GetBrokerListResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("instructionType", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string InstructionType { get; set; } = null;


	[JsonProperty("brokers", Required = Required.Always)]
	[Required]
	[MinLength(1)]
	public ICollection<string> Brokers { get; set; } = new Collection<string>();


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
