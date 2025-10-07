using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PredefinedDestinationInstruction
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;


	[JsonProperty("bankInstructionName", Required = Required.Always)]
	[Required]
	[StringLength(100, MinimumLength = 1)]
	public string BankInstructionName { get; set; } = null;


	[JsonProperty("bankInstructionMethod", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public PredefinedDestinationInstructionBankInstructionMethod BankInstructionMethod { get; set; } = PredefinedDestinationInstructionBankInstructionMethod.LVP;


	[JsonProperty("accountId", Required = Required.Always)]
	[Required]
	[StringLength(10, MinimumLength = 1)]
	public string AccountId { get; set; } = null;


	[JsonProperty("currency", Required = Required.Always)]
	[Required]
	[StringLength(3, MinimumLength = 3)]
	public string Currency { get; set; } = null;


	[JsonProperty("financialInstitution", Required = Required.Always)]
	[Required]
	public FinancialInstitution FinancialInstitution { get; set; } = new FinancialInstitution();


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
