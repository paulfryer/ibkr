using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class VirtualAccountConfiguration
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("client_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Client_id { get; set; } = null;

	[JsonProperty("user_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string User_id { get; set; } = null;

	[JsonProperty("client_supports_virtual_accounts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Client_supports_virtual_accounts { get; set; } = false;

	[JsonProperty("account_id_mappings", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<VirtualAccountIdMapping> Account_id_mappings { get; set; } = null;

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
