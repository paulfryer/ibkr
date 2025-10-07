using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountSupportType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("businessDescription", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BusinessDescription { get; set; } = null;


	[JsonProperty("primaryContributor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public PrimaryContributorType PrimaryContributor { get; set; } = null;


	[JsonProperty("administrator", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AdministratorType Administrator { get; set; } = null;


	[JsonProperty("administratorContactPerson", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AdministratorContactPersonType AdministratorContactPerson { get; set; } = null;


	[JsonProperty("ownersResideUS", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool OwnersResideUS { get; set; } = false;


	[JsonProperty("solicitOwnersResideUS", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool SolicitOwnersResideUS { get; set; } = false;


	[JsonProperty("acceptOwnersResideUS", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AcceptOwnersResideUS { get; set; } = false;


	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AccountSupportTypeType Type { get; set; } = AccountSupportTypeType.FINANCIALINSTITUTION;


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
