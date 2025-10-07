using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ResidenceAddress
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("street1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Street1 { get; set; } = null;


	[JsonProperty("street2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Street2 { get; set; } = null;


	[JsonProperty("city", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string City { get; set; } = null;


	[JsonProperty("state", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string State { get; set; } = null;


	[JsonProperty("country", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Country { get; set; } = null;


	[JsonProperty("postalCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PostalCode { get; set; } = null;


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
