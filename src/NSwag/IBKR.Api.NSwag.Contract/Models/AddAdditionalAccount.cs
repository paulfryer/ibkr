using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AddAdditionalAccount
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("customer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Customer Customer { get; set; } = null;


	[JsonProperty("account", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Account Account { get; set; } = null;


	[JsonProperty("documents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<Document> Documents { get; set; } = null;


	[JsonProperty("users", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<User> Users { get; set; } = null;


	[JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountId { get; set; } = null;


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
