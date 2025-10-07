using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ChangeAccountHolderDetail
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("newAccountHolderDetails", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<AssociatedIndividual> NewAccountHolderDetails { get; set; } = null;

	[JsonProperty("documents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DocumentSubmission Documents { get; set; } = null;

	[JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountId { get; set; } = null;

	[JsonProperty("referenceUserName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ReferenceUserName { get; set; } = null;

	[JsonProperty("inputLanguage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ChangeAccountHolderDetailInputLanguage InputLanguage { get; set; } = ChangeAccountHolderDetailInputLanguage.En;

	[JsonProperty("translation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Translation { get; set; } = false;

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
