using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AdministratorContactPersonType
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
	public AdministratorContactPersonTypeSuffix Suffix { get; set; } = AdministratorContactPersonTypeSuffix.Jr_;


	[JsonProperty("phoneNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string PhoneNumber { get; set; } = null;


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
