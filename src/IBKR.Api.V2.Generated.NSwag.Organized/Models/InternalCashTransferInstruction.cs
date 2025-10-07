using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class InternalCashTransferInstruction
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;

	[JsonProperty("sourceAccountId", Required = Required.Always)]
	[Required]
	[StringLength(32, MinimumLength = 1)]
	public string SourceAccountId { get; set; } = null;

	[JsonProperty("targetAccountId", Required = Required.Always)]
	[Required]
	[StringLength(32, MinimumLength = 1)]
	public string TargetAccountId { get; set; } = null;

	[JsonProperty("amount", Required = Required.Always)]
	public double Amount { get; set; } = 0.0;

	[JsonProperty("currency", Required = Required.Always)]
	[Required]
	[StringLength(3, MinimumLength = 1)]
	public string Currency { get; set; } = null;

	[JsonProperty("clientNote", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(64, MinimumLength = 1)]
	public string ClientNote { get; set; } = null;

	[JsonProperty("dateTimeToOccur", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DateTimeOffset DateTimeToOccur { get; set; } = default(DateTimeOffset);

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
