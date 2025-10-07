using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IRAContingentBeneficiaryEntity
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; } = null;

	[JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Address Address { get; set; } = null;

	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Id { get; set; } = null;

	[JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalId { get; set; } = null;

	[JsonProperty("ownershipPercentage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double OwnershipPercentage { get; set; } = 0.0;

	[JsonProperty("title", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Title Title { get; set; } = null;

	[JsonProperty("relationship", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public IRAContingentBeneficiaryEntityRelationship Relationship { get; set; } = IRAContingentBeneficiaryEntityRelationship.Brother;

	[JsonProperty("executor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Individual Executor { get; set; } = null;

	[JsonProperty("executionDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(DateFormatConverter))]
	public DateTimeOffset ExecutionDate { get; set; } = default(DateTimeOffset);

	[JsonProperty("articleOfWill", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ArticleOfWill { get; set; } = null;

	[JsonProperty("entityType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public IRAContingentBeneficiaryEntityEntityType EntityType { get; set; } = IRAContingentBeneficiaryEntityEntityType.Trust;

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
