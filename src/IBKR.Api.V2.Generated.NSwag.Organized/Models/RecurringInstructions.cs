using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RecurringInstructions
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("requestId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int RequestId { get; set; } = 0;

	[JsonProperty("bankInstructionName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BankInstructionName { get; set; } = null;

	[JsonProperty("transactionType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TransactionType { get; set; } = null;

	[JsonProperty("bankInstructionMethod", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BankInstructionMethod { get; set; } = null;

	[JsonProperty("amount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Amount { get; set; } = 0.0;

	[JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Currency { get; set; } = null;

	[JsonProperty("frequency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Frequency { get; set; } = null;

	[JsonProperty("startDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string StartDate { get; set; } = null;

	[JsonProperty("endDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string EndDate { get; set; } = null;

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
