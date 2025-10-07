using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class DepositFundsInstruction
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;


	[JsonProperty("accountId", Required = Required.Always)]
	[Required]
	[StringLength(32, MinimumLength = 1)]
	public string AccountId { get; set; } = null;


	[JsonProperty("currency", Required = Required.Always)]
	[Required]
	[StringLength(3, MinimumLength = 1)]
	public string Currency { get; set; } = null;


	[JsonProperty("amount", Required = Required.Always)]
	public double Amount { get; set; } = 0.0;


	[JsonProperty("bankInstructionMethod", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public DepositFundsInstructionBankInstructionMethod BankInstructionMethod { get; set; } = DepositFundsInstructionBankInstructionMethod.ACH;


	[JsonProperty("sendingInstitution", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(128)]
	public string SendingInstitution { get; set; } = null;


	[JsonProperty("identifier", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(64)]
	public string Identifier { get; set; } = null;


	[JsonProperty("specialInstruction", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(128)]
	public string SpecialInstruction { get; set; } = null;


	[JsonProperty("bankInstructionName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(150)]
	public string BankInstructionName { get; set; } = null;


	[JsonProperty("senderInstitutionName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(128)]
	public string SenderInstitutionName { get; set; } = null;


	[JsonProperty("iraDepositDetail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IraDepositDetail IraDepositDetail { get; set; } = null;


	[JsonProperty("recurringInstructionDetail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public RecurringInstructionDetail RecurringInstructionDetail { get; set; } = null;


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
