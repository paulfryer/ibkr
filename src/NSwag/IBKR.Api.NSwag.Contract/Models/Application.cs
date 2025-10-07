using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Application
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("customer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Customer Customer { get; set; } = null;


	[JsonProperty("accounts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<Account> Accounts { get; set; } = null;


	[JsonProperty("users", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<User> Users { get; set; } = null;


	[JsonProperty("documents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<Document> Documents { get; set; } = null;


	[JsonProperty("additionalAccounts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<AddAdditionalAccount> AdditionalAccounts { get; set; } = null;


	[JsonProperty("masterAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MasterAccountId { get; set; } = null;


	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Id { get; set; } = null;


	[JsonProperty("inputLanguage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ApplicationInputLanguage InputLanguage { get; set; } = ApplicationInputLanguage.En;


	[JsonProperty("translation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Translation { get; set; } = false;


	[JsonProperty("paperAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool PaperAccount { get; set; } = false;


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
