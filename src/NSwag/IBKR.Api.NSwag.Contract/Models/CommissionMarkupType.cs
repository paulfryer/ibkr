using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class CommissionMarkupType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("stairs", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<MarkupStaircaseType> Stairs { get; set; } = null;


	[JsonProperty("code", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Code { get; set; } = null;


	[JsonProperty("minimum", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Minimum { get; set; } = 0.0;


	[JsonProperty("maximum", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Maximum { get; set; } = 0.0;


	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public CommissionMarkupTypeType Type { get; set; } = CommissionMarkupTypeType.FA;


	[JsonProperty("amount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Amount { get; set; } = 0.0;


	[JsonProperty("plusCost", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool PlusCost { get; set; } = false;


	[JsonProperty("ticketCharge", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double TicketCharge { get; set; } = 0.0;


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
