using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class CreateSessionRequest
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("credential", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Credential { get; set; } = null;

	[JsonProperty("ip", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Ip { get; set; } = null;

	[JsonProperty("service", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Service { get; set; } = null;

	[JsonProperty("alternativeIps", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> AlternativeIps { get; set; } = null;

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
