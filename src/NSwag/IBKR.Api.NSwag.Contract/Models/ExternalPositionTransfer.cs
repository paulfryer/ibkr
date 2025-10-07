using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ExternalPositionTransfer
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("clientInstructionId", Required = Required.Always)]
	public double ClientInstructionId { get; set; } = 0.0;


	[JsonProperty("type", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ExternalPositionTransferType Type { get; set; } = ExternalPositionTransferType.FULL;


	[JsonProperty("subType", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ExternalPositionTransferSubType SubType { get; set; } = ExternalPositionTransferSubType.ACATS;


	[JsonProperty("brokerId", Required = Required.Always)]
	[Required]
	[StringLength(20, MinimumLength = 1)]
	public string BrokerId { get; set; } = null;


	[JsonProperty("brokerName", Required = Required.Always)]
	[Required]
	[StringLength(256, MinimumLength = 1)]
	public string BrokerName { get; set; } = null;


	[JsonProperty("accountAtBroker", Required = Required.Always)]
	[Required]
	[StringLength(34, MinimumLength = 1)]
	public string AccountAtBroker { get; set; } = null;


	[JsonProperty("sourceIRAType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ExternalPositionTransferSourceIRAType SourceIRAType { get; set; } = ExternalPositionTransferSourceIRAType.RO;


	[JsonProperty("accountId", Required = Required.Always)]
	[Required]
	[StringLength(32, MinimumLength = 1)]
	public string AccountId { get; set; } = null;


	[JsonProperty("signature", Required = Required.Always)]
	[Required]
	[StringLength(140, MinimumLength = 1)]
	public string Signature { get; set; } = null;


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
