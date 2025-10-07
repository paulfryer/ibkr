using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AlertCreationRequest
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("orderId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public long OrderId { get; set; } = 0L;

	[JsonProperty("alertName", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string AlertName { get; set; } = null;

	[JsonProperty("alertMessage", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string AlertMessage { get; set; } = null;

	[JsonProperty("alertRepeatable", Required = Required.Always)]
	public int AlertRepeatable { get; set; } = 0;

	[JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Email { get; set; } = null;

	[JsonProperty("expireTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExpireTime { get; set; } = null;

	[JsonProperty("iTWSOrdersOnly", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int ITWSOrdersOnly { get; set; } = 0;

	[JsonProperty("outsideRth", Required = Required.Always)]
	public int OutsideRth { get; set; } = 0;

	[JsonProperty("sendMessage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int SendMessage { get; set; } = 0;

	[JsonProperty("showPopup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int ShowPopup { get; set; } = 0;

	[JsonProperty("tif", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AlertCreationRequestTif Tif { get; set; } = AlertCreationRequestTif.GTC;

	[JsonProperty("conditions", Required = Required.Always)]
	[Required]
	public ICollection<object> Conditions { get; set; } = new Collection<object>();

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
