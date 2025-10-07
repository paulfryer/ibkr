using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class UpdateCredentials
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("updateEmail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public UpdateEmail UpdateEmail { get; set; } = null;


	[JsonProperty("updatePassword", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public UpdatePassword UpdatePassword { get; set; } = null;


	[JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountId { get; set; } = null;


	[JsonProperty("referenceUserName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ReferenceUserName { get; set; } = null;


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
