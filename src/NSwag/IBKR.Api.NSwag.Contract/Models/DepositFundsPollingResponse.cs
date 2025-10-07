using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class DepositFundsPollingResponse : InstructionPollingResponse
{
	[JsonProperty("instructionResult", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public new DepositFundsPollingResult InstructionResult { get; set; } = null;

}
