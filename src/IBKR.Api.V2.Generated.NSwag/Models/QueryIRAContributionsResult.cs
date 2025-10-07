using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QueryIRAContributionsResult : PollingInstructionResult
{
	[JsonProperty("accountId", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string AccountId { get; set; } = null;


	[JsonProperty("year", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Year { get; set; } = null;


	[JsonProperty("iraType", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string IraType { get; set; } = null;


	[JsonProperty("contributions", Required = Required.Always)]
	[Required]
	public ICollection<Contributions> Contributions { get; set; } = new Collection<Contributions>();

}
