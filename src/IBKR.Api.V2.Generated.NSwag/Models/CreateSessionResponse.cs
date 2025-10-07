using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class CreateSessionResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("active", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Active { get; set; } = false;


	[JsonProperty("access_token", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Access_token { get; set; } = null;


	[JsonProperty("token_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Token_type { get; set; } = null;


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
