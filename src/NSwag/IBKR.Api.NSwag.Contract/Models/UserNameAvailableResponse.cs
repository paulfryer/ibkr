using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class UserNameAvailableResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("error", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ErrorResponse Error { get; set; } = null;


	[JsonProperty("hasError", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool HasError { get; set; } = false;


	[JsonProperty("errorDescription", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ErrorDescription { get; set; } = null;


	[JsonProperty("isValid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsValid { get; set; } = false;


	[JsonProperty("isAvailable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsAvailable { get; set; } = false;


	[JsonProperty("suggestedUserName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> SuggestedUserName { get; set; } = null;


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
