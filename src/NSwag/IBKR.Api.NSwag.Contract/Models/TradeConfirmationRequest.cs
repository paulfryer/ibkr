using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TradeConfirmationRequest
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("accountId", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string AccountId { get; set; } = null;


	[JsonProperty("startDate", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string StartDate { get; set; } = null;


	[JsonProperty("endDate", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string EndDate { get; set; } = null;


	[JsonProperty("mimeType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MimeType { get; set; } = null;


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
