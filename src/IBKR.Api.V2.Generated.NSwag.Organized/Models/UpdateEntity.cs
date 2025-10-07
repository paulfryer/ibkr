using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class UpdateEntity
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("addRelationships", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<AddRelationship> AddRelationships { get; set; } = null;

	[JsonProperty("deleteRelationships", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<DeleteRelationship> DeleteRelationships { get; set; } = null;

	[JsonProperty("individual", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Individual Individual { get; set; } = null;

	[JsonProperty("legalEntity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LegalEntity LegalEntity { get; set; } = null;

	[JsonProperty("trust", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Trust Trust { get; set; } = null;

	[JsonProperty("organization", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Organization Organization { get; set; } = null;

	[JsonProperty("documents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<Document> Documents { get; set; } = null;

	[JsonProperty("ibEntityId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int IbEntityId { get; set; } = 0;

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
