using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PrimaryContributorType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("firstName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FirstName { get; set; } = null;

	[JsonProperty("middleInitial", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MiddleInitial { get; set; } = null;

	[JsonProperty("lastName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string LastName { get; set; } = null;

	[JsonProperty("suffix", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public PrimaryContributorTypeSuffix Suffix { get; set; } = PrimaryContributorTypeSuffix.Jr_;

	[JsonProperty("employer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Employer { get; set; } = null;

	[JsonProperty("occupation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Occupation { get; set; } = null;

	[JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Address Address { get; set; } = null;

	[JsonProperty("sourceOfFunds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SourceOfFunds { get; set; } = null;

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
