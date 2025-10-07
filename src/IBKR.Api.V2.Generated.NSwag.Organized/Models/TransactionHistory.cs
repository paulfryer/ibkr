using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TransactionHistory
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("daysToGoBack", Required = Required.Always)]
	[Range(1.0, double.MaxValue)]
	public double DaysToGoBack { get; set; } = 0.0;

	[JsonProperty("transactionType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public TransactionHistoryTransactionType TransactionType { get; set; } = TransactionHistoryTransactionType.ALL;

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
