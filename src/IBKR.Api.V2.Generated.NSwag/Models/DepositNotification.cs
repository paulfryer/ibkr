using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class DepositNotification
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("checkDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public CheckDetails CheckDetails { get; set; } = null;


	[JsonProperty("wireDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public WireDetails WireDetails { get; set; } = null;


	[JsonProperty("achDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ACHDetails AchDetails { get; set; } = null;


	[JsonProperty("iraDepositDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IRADepositDetails IraDepositDetails { get; set; } = null;


	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public DepositNotificationType Type { get; set; } = DepositNotificationType.CHECK;


	[JsonProperty("amount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Amount { get; set; } = 0.0;


	[JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public DepositNotificationCurrency Currency { get; set; } = DepositNotificationCurrency.USD;


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
