using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Error
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("errorCode", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string ErrorCode { get; set; } = null;


	[JsonProperty("errorMessage", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string ErrorMessage { get; set; } = null;


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
