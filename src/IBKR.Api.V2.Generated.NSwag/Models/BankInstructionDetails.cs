using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class BankInstructionDetails
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("instructionName", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string InstructionName { get; set; } = null;


	[JsonProperty("type", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Type { get; set; } = null;


	[JsonProperty("currency", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Currency { get; set; } = null;


	[JsonProperty("instructionStatus", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string InstructionStatus { get; set; } = null;


	[JsonProperty("bankRoutingNumber", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string BankRoutingNumber { get; set; } = null;


	[JsonProperty("bankAccountNumber", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string BankAccountNumber { get; set; } = null;


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
