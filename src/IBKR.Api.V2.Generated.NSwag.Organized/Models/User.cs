using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class User
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("roleId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string RoleId { get; set; } = null;

	[JsonProperty("hasRightCodeInd", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool HasRightCodeInd { get; set; } = false;

	[JsonProperty("entity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Entity Entity { get; set; } = null;

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
