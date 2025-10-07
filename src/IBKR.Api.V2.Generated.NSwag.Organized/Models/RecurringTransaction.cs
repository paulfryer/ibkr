using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
[Obsolete]
public class RecurringTransaction
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("achInstruction", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ACHInstruction AchInstruction { get; set; } = null;

	[JsonProperty("iraWithdrawalDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IRAWithdrawalDetails IraWithdrawalDetails { get; set; } = null;

	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public RecurringTransactionType Type { get; set; } = RecurringTransactionType.DEPOSIT;

	[JsonProperty("method", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public RecurringTransactionMethod Method { get; set; } = RecurringTransactionMethod.CHECK;

	[JsonProperty("instruction", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Instruction { get; set; } = null;

	[JsonProperty("frequency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public RecurringTransactionFrequency Frequency { get; set; } = RecurringTransactionFrequency.MONTHLY;

	[JsonProperty("startDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(DateFormatConverter))]
	public DateTimeOffset StartDate { get; set; } = default(DateTimeOffset);

	[JsonProperty("endDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(DateFormatConverter))]
	public DateTimeOffset EndDate { get; set; } = default(DateTimeOffset);

	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; } = null;

	[JsonProperty("amount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Amount { get; set; } = 0.0;

	[JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public RecurringTransactionCurrency Currency { get; set; } = RecurringTransactionCurrency.USD;

	[JsonProperty("ibAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string IbAccount { get; set; } = null;

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
