using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class EddaInstruction
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;

	[JsonProperty("bankInstructionName", Required = Required.Always)]
	[Required]
	[StringLength(100, MinimumLength = 1)]
	public string BankInstructionName { get; set; } = null;

	[JsonProperty("currency", Required = Required.Always)]
	[Required]
	[StringLength(3, MinimumLength = 1)]
	public string Currency { get; set; } = null;

	[JsonProperty("accountId", Required = Required.Always)]
	[Required]
	[StringLength(32, MinimumLength = 1)]
	public string AccountId { get; set; } = null;

	[JsonProperty("bankBranchCode", Required = Required.Always)]
	[Required]
	[StringLength(3, MinimumLength = 1)]
	public string BankBranchCode { get; set; } = null;

	[JsonProperty("bankAccountNumber", Required = Required.Always)]
	[Required]
	[StringLength(32, MinimumLength = 1)]
	public string BankAccountNumber { get; set; } = null;

	[JsonProperty("bankClearingCode", Required = Required.Always)]
	[Required]
	[StringLength(3, MinimumLength = 1)]
	public string BankClearingCode { get; set; } = null;

	[JsonProperty("debtorIdentificationDocumentType", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public EddaInstructionDebtorIdentificationDocumentType DebtorIdentificationDocumentType { get; set; } = EddaInstructionDebtorIdentificationDocumentType.HkId;

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
