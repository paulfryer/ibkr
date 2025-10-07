using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IndividualIRABene
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("firstName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FirstName { get; set; } = null;


	[JsonProperty("lastName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string LastName { get; set; } = null;


	[JsonProperty("dateOfBirth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DateOfBirth { get; set; } = null;


	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Type { get; set; } = null;


	[JsonProperty("identification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, string> Identification { get; set; } = null;


	[JsonProperty("location", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IDictionary<string, string> Location { get; set; } = null;


	[JsonProperty("relationship", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Relationship { get; set; } = null;


	[JsonProperty("ownership", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Ownership { get; set; } = 0;


	[JsonProperty("perStripes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PerStripes { get; set; } = null;


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
