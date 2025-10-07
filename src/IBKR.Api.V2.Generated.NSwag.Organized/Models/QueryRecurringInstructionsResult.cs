using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryRecurringInstructionsResult : InstructionResult
{
	[JsonProperty("accountId", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string AccountId { get; set; } = null;

	[JsonProperty("recurringInstructions", Required = Required.Always)]
	[Required]
	public ICollection<RecurringInstructions> RecurringInstructions { get; set; } = new Collection<RecurringInstructions>();
}
