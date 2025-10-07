using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryBankInstructionResult : InstructionResult
{
	[JsonProperty("accountId", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string AccountId { get; set; } = null;

	[JsonProperty("bankInstructionMethod", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public QueryBankInstructionResultBankInstructionMethod BankInstructionMethod { get; set; } = QueryBankInstructionResultBankInstructionMethod.WIRE;

	[JsonProperty("bankInstructionDetails", Required = Required.Always)]
	[Required]
	public ICollection<BankInstructionDetails> BankInstructionDetails { get; set; } = new Collection<BankInstructionDetails>();
}
