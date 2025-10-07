using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class UpdateBCAN
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountId { get; set; } = null;

	[JsonProperty("bcan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Bcan { get; set; } = null;

	[JsonProperty("ceNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CeNumber { get; set; } = null;

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
